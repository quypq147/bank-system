// UserForm.cs (updated: auto-bind current customer's account; no AccountNo inputs)
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using BankClient.Api;
using BankClient.Models;

namespace BankClient
{
    public partial class UserForm : Form
    {
        private string _currentAccountNo;   // tài khoản của chính user
        private string _currentCurrency;
        private decimal _currentBalance;

        public UserForm()
        {
            InitializeComponent();

            // Wire events
            btnDeposit.Click += btnDeposit_Click;
            btnWithdraw.Click += btnWithdraw_Click;
            btnTransfer.Click += btnTransfer_Click;
            btnLoadStatement.Click += btnLoadStatement_Click;
            

            this.Load += UserForm_Load;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;

            try
            {
                await BindMyPrimaryAccountAsync();  // <-- lấy account của chính user và hiển thị
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được thông tin tài khoản của bạn: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // Lấy tài khoản của chính user (ưu tiên endpoint 'mine', fallback decode JWT)
        // =========================================================
        private async Task BindMyPrimaryAccountAsync()
        {
            // 1) Thử endpoint phổ biến: GET api/accounts/mine
            try
            {
                var mine = await ApiClient.GetAsync<AccountSummary[]>("api/accounts/mine");
                if (mine != null && mine.Length > 0)
                {
                    var pick = mine.FirstOrDefault(a => a.Status == AccountStatus.Active)
                               ?? mine.First();
                    ApplyAccountToUI(pick);
                    return;
                }
            }
            catch { /* ignore and try next */ }

            // 2) Thử endpoint: GET api/customers/me/accounts
            try
            {
                var mine2 = await ApiClient.GetAsync<AccountSummary[]>("api/customers/me/accounts");
                if (mine2 != null && mine2.Length > 0)
                {
                    var pick = mine2.FirstOrDefault(a => a.Status == AccountStatus.Active)
                               ?? mine2.First();
                    ApplyAccountToUI(pick);
                    return;
                }
            }
            catch { /* ignore and try next */ }

            // 3) Fallback: decode JWT -> customer_id -> GET api/customers/{id}/accounts
            var customerId = TryGetCustomerIdFromJwt();
            if (string.IsNullOrWhiteSpace(customerId))
                throw new Exception("Không tìm thấy customer_id trong token.");

            try
            {
                var list = await ApiClient.GetAsync<AccountSummary[]>($"api/customers/{customerId}/accounts");
                if (list != null && list.Length > 0)
                {
                    var pick = list.FirstOrDefault(a => a.Status == AccountStatus.Active)
                               ?? list.First();
                    ApplyAccountToUI(pick);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không tìm thấy tài khoản cho khách hàng. " + ex.Message);
            }

            throw new Exception("Tài khoản rỗng.");
        }

        private void ApplyAccountToUI(AccountSummary a)
        {
            _currentAccountNo = a.AccountNo;
            _currentCurrency = a.Currency;
            _currentBalance = a.Balance;

            lblAccNoValue.Text = a.AccountNo;
            lblAccClassValue.Text = a.AccountClass.ToString();
            lblCurrencyValue.Text = a.Currency;
            lblBalanceValue.Text = a.Balance.ToString("n0");
            lblStatusValue.Text = a.Status.ToString();
            lblOpenedAtValue.Text = a.OpenedAt.ToString("yyyy-MM-dd");

            lblAccountInfo.Text = $"Số dư: {a.Balance:n0} {a.Currency} | Trạng thái: {a.Status}";
        }

        // =========================================================
        // Helpers
        // =========================================================
        private string TryGetCustomerIdFromJwt()
        {
            string jwt = TryGetJwtFromApiClient();
            if (string.IsNullOrWhiteSpace(jwt)) return null;

            try
            {
                var parts = jwt.Split('.');
                if (parts.Length < 2) return null;

                string Base64UrlToString(string s)
                {
                    s = s.Replace('-', '+').Replace('_', '/');
                    switch (s.Length % 4) { case 2: s += "=="; break; case 3: s += "="; break; }
                    var bytes = Convert.FromBase64String(s);
                    return Encoding.UTF8.GetString(bytes);
                }

                var payloadJson = Base64UrlToString(parts[1]);
                JsonDocument doc = JsonDocument.Parse(payloadJson);
                var root = doc.RootElement;

                // Thử key "customer_id" trước
                if (root.TryGetProperty("customer_id", out var cidProp) && cidProp.ValueKind == JsonValueKind.String)
                    return cidProp.GetString();

                // Hoặc có thể là một claim URI tuỳ backend (ít gặp)
                var alt = "customer_id";
                if (root.TryGetProperty(alt, out var altProp) && altProp.ValueKind == JsonValueKind.String)
                    return altProp.GetString();

                return null;
            }
            catch
            {
                return null;
            }
        }

        private string TryGetJwtFromApiClient()
        {
            // Ưu tiên: thuộc tính public ApiClient.Token
            try
            {
                var prop = typeof(ApiClient).GetProperty("Token", BindingFlags.Public | BindingFlags.Static);
                if (prop != null)
                {
                    return prop.GetValue(null) as string;
                }
            }
            catch { }

            // Fallback: field private _token (nếu có)
            try
            {
                var field = typeof(ApiClient).GetField("_token", BindingFlags.NonPublic | BindingFlags.Static);
                if (field != null)
                {
                    return field.GetValue(null) as string;
                }
            }
            catch { }

            // Nếu BankApi có lộ token
            try
            {
                var prop = typeof(BankApi).GetProperty("LastToken", BindingFlags.Public | BindingFlags.Static);
                if (prop != null)
                {
                    return prop.GetValue(null) as string;
                }
            }
            catch { }

            return null;
        }

        private async Task DoCashAsync(Func<CashDto, Task> action, TextBox amount, TextBox note)
        {
            if (string.IsNullOrWhiteSpace(_currentAccountNo))
                throw new Exception("Chưa xác định tài khoản.");

            if (!decimal.TryParse(amount.Text.Trim(), out var amt) || amt <= 0)
                throw new Exception("Số tiền không hợp lệ (> 0).");

            var dto = new CashDto
            {
                AccountNo = _currentAccountNo,
                Amount = amt,
                Note = note.Text.Trim()
            };
            await action(dto);
        }

        // =========================================================
        // Actions
        // =========================================================
        private async void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                await DoCashAsync(BankApi.DepositAsync, txtDepAmount, txtDepNote);
                MessageBox.Show("Nạp tiền thành công!");
                await RefreshMyAccountInfoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp tiền: " + ex.Message);
            }
        }

        private async void btnWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                await DoCashAsync(BankApi.WithdrawAsync, txtWdrAmount, txtWdrNote);
                MessageBox.Show("Rút tiền thành công!");
                await RefreshMyAccountInfoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rút tiền: " + ex.Message);
            }
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentAccountNo))
                {
                    MessageBox.Show("Chưa xác định tài khoản nguồn.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTrTo.Text))
                {
                    MessageBox.Show("Vui lòng nhập ToAccountNo.");
                    return;
                }
                if (!decimal.TryParse(txtTrAmount.Text.Trim(), out var amt) || amt <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ (> 0).");
                    return;
                }

                var dto = new TransferDto
                {
                    FromAccountNo = _currentAccountNo,      // <-- dùng tài khoản của user
                    ToAccountNo = txtTrTo.Text.Trim(),
                    Amount = amt,
                    Note = txtTrNote.Text.Trim()
                };
                await BankApi.TransferAsync(dto);
                MessageBox.Show("Chuyển khoản thành công!");
                await RefreshMyAccountInfoAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoản: " + ex.Message);
            }
        }

        private async Task RefreshMyAccountInfoAsync()
        {
            // Sau giao dịch, đọc lại balance của account hiện tại
            try
            {
                var acc = await BankApi.GetAccountAsync(_currentAccountNo);
                ApplyAccountToUI(new AccountSummary
                {
                    AccountNo = acc.AccountNo,
                    AccountClass = acc.AccountClass,
                    Currency = acc.Currency,
                    Balance = acc.Balance,
                    Status = acc.Status,
                    OpenedAt = acc.OpenedAt
                });
            }
            catch { /* nhẹ nhàng bỏ qua */ }
        }

        private async void btnLoadStatement_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentAccountNo))
                {
                    MessageBox.Show("Chưa xác định tài khoản.");
                    return;
                }
                var dto = new StatementQueryDto
                {
                    AccountNo = _currentAccountNo,
                    From = dtFrom.Value.Date,
                    To = dtTo.Value.Date.AddDays(1).AddSeconds(-1)
                };
                var list = await BankApi.StatementAsync(dto);
                gridStatement.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sao kê: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ApiClient.ClearToken();
            MessageBox.Show("Đăng xuất thành công!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }

    // View model gọn để bind UI
    public class AccountSummary
    {
        public string AccountNo { get; set; }
        public AccountClass AccountClass { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        public DateTime OpenedAt { get; set; }
    }
}




