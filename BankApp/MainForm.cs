// MainForm.cs
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankClient.Api;
using BankClient.Models;

namespace BankClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

          

            // Customers
            btnSearchCustomers.Click += btnSearchCustomers_Click;
            btnCreateCustomer.Click += btnCreateCustomer_Click;

            // Admin: Create Login User for Customer
            btnCreateLoginUser.Click += btnCreateLoginUser_Click;

            // Accounts
            btnOpenAccount.Click += btnOpenAccount_Click;
            btnGetAccount.Click += btnGetAccount_Click;

            // Transactions
            btnDeposit.Click += btnDeposit_Click;
            btnWithdraw.Click += btnWithdraw_Click;
            btnTransfer.Click += btnTransfer_Click;

            // Statement
            btnLoadStatement.Click += btnLoadStatement_Click;
        }

        

        // ========= CUSTOMERS =========
        private async void btnSearchCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var list = await BankApi.SearchCustomersAsync(txtSearch.Text.Trim());
                gridCustomers.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private async void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new CustomerCreateDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Email = txtCusEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                if (string.IsNullOrWhiteSpace(dto.FullName) || string.IsNullOrWhiteSpace(dto.Email))
                {
                    MessageBox.Show("FullName và Email là bắt buộc.");
                    return;
                }

                var created = await BankApi.CreateCustomerAsync(dto);
                txtCreatedCustomerId.Text = created.Id;

                // >>> tự đổ sang khu Create Login User
                txtLoginCustomerId.Text = created.Id;
                txtLoginEmail.Text = created.Email ?? "";

                MessageBox.Show("Tạo khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo khách hàng: " + ex.Message);
            }
        }

        // ========= ADMIN: CREATE LOGIN USER FOR CUSTOMER =========
        private async void btnCreateLoginUser_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtLoginEmail.Text.Trim();
                var pwd = txtLoginPassword.Text; // password tạm do admin đặt
                var customerId = txtLoginCustomerId.Text.Trim();

                if (string.IsNullOrWhiteSpace(customerId))
                {
                    MessageBox.Show("Vui lòng nhập/ chọn CustomerId.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd))
                {
                    MessageBox.Show("Email và Password không được để trống.");
                    return;
                }

                // Gọi API Admin-only: POST /api/auth/register
                await ApiClient.PostAsync("api/auth/register", new
                {
                    Email = email,
                    Password = pwd,
                    CustomerId = customerId
                });

                MessageBox.Show("Đã tạo user đăng nhập cho khách hàng.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo user: " + ex.Message);
            }
        }

        // ========= ACCOUNTS =========
        private async void btnOpenAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerIdForAccount.Text))
                {
                    MessageBox.Show("Vui lòng nhập CustomerId.");
                    return;
                }

                var dto = new AccountOpenDto
                {
                    CustomerId = txtCustomerIdForAccount.Text.Trim(),
                    AccountClass = (AccountClass)cboAccountType.SelectedItem,
                    Currency = string.IsNullOrWhiteSpace(txtCurrency.Text) ? "VND" : txtCurrency.Text.Trim()
                    // Nếu mở kỳ hạn: dto.TermMonths, dto.Payout
                };

                var acc = await BankApi.OpenAccountAsync(dto);
                txtOpenedAccountNo.Text = acc.AccountNo;
                MessageBox.Show("Mở tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở tài khoản: " + ex.Message);
            }
        }

        private async void btnGetAccount_Click(object sender, EventArgs e)
        {
            try
            {
                var accountNo = txtGetAccountNo.Text.Trim();
                if (string.IsNullOrWhiteSpace(accountNo))
                {
                    MessageBox.Show("Vui lòng nhập AccountNo.");
                    return;
                }

                var acc = await BankApi.GetAccountAsync(accountNo);
                lblAccountInfo.Text = $"Số dư: {acc.Balance:n0} {acc.Currency} | Trạng thái: {acc.Status}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy thông tin tài khoản: " + ex.Message);
            }
        }

        // ========= TRANSACTIONS =========
        private async Task DoCashAsync(Func<CashDto, Task> action, TextBox accountNo, TextBox amount, TextBox note)
        {
            if (string.IsNullOrWhiteSpace(accountNo.Text))
                throw new Exception("Vui lòng nhập AccountNo.");

            if (!decimal.TryParse(amount.Text.Trim(), out var amt) || amt <= 0)
                throw new Exception("Số tiền không hợp lệ (> 0).");

            var dto = new CashDto
            {
                AccountNo = accountNo.Text.Trim(),
                Amount = amt,
                Note = note.Text.Trim()
            };

            await action(dto);
        }

        private async void btnDeposit_Click(object sender, EventArgs e)
        {
            try
            {
                await DoCashAsync(BankApi.DepositAsync, txtDepAccount, txtDepAmount, txtDepNote);
                MessageBox.Show("Nạp tiền thành công!");
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
                await DoCashAsync(BankApi.WithdrawAsync, txtWdrAccount, txtWdrAmount, txtWdrNote);
                MessageBox.Show("Rút tiền thành công!");
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
                if (string.IsNullOrWhiteSpace(txtTrFrom.Text) || string.IsNullOrWhiteSpace(txtTrTo.Text))
                {
                    MessageBox.Show("Vui lòng nhập FromAccountNo và ToAccountNo.");
                    return;
                }
                if (!decimal.TryParse(txtTrAmount.Text.Trim(), out var amt) || amt <= 0)
                {
                    MessageBox.Show("Số tiền không hợp lệ (> 0).");
                    return;
                }

                var dto = new TransferDto
                {
                    FromAccountNo = txtTrFrom.Text.Trim(),
                    ToAccountNo = txtTrTo.Text.Trim(),
                    Amount = amt,
                    Note = txtTrNote.Text.Trim()
                };

                await BankApi.TransferAsync(dto);
                MessageBox.Show("Chuyển khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển khoản: " + ex.Message);
            }
        }

        // ========= STATEMENT =========
        private async void btnLoadStatement_Click(object sender, EventArgs e)
        {
            try
            {
                var accountNo = txtStmAccount.Text.Trim();
                if (string.IsNullOrWhiteSpace(accountNo))
                {
                    MessageBox.Show("Vui lòng nhập AccountNo.");
                    return;
                }

                var from = dtFrom.Value.Date;
                var to = dtTo.Value.Date.AddDays(1).AddSeconds(-1); // inclusive

                var dto = new StatementQueryDto
                {
                    AccountNo = accountNo,
                    From = from,
                    To = to
                };

                var list = await BankApi.StatementAsync(dto);
                gridStatement.DataSource = list; // AutoGenerateColumns = true
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sao kê: " + ex.Message);
            }
        }
    }
}





