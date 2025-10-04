// LoginForm.cs
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankClient.Api;
using BankClient.Models;

namespace BankClient
{
    public partial class LoginForm : Form
    {
        public string JwtToken { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            // Sự kiện (phòng Designer chưa auto-wire)
            this.Load += LoginForm_Load;
            btnLogin.Click += btnLogin_Click;
            chkShowPwd.CheckedChanged += chkShowPwd_CheckedChanged;

            // Enter để submit, Esc để đóng
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancel; // nút ẩn để Esc hoạt động

            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Gợi ý dev
            txtEmail.Text = "admin@bank.local";
            txtPassword.Text = "P@ssw0rd!";
            lblStatus.Text = "Nhập email & mật khẩu để đăng nhập";
        }

        private void SetBusy(bool isBusy, string status = null)
        {
            btnLogin.Enabled = !isBusy;
            txtEmail.Enabled = !isBusy;
            txtPassword.Enabled = !isBusy;
            chkShowPwd.Enabled = !isBusy;

            if (status != null) lblStatus.Text = status;
            progress.Visible = isBusy;
            progress.Style = isBusy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await DoLoginAsync();
        }

        private async Task DoLoginAsync()
        {
            var email = txtEmail.Text.Trim();
            var pwd = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.");
                return;
            }

            try
            {
                SetBusy(true, "Đang đăng nhập...");

                var token = await BankApi.LoginAsync(email, pwd); // ✅ Login trước
                Console.WriteLine("[CLIENT] Token nhận được:\n" + token);
                JwtToken = token;

                var roles = TryExtractRoles(token);
                lblStatus.Text = roles.Length > 0
                    ? $"Đăng nhập thành công ({string.Join(", ", roles)})"
                    : "Đăng nhập thành công!";

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Đăng nhập thất bại";
                var msg = ex.Message ?? "";
                if (msg.Contains("401") || msg.IndexOf("Unauthorized", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    MessageBox.Show(
                        "401 Unauthorized\n• Sai email/mật khẩu hoặc tài khoản chưa tồn tại.\n• Vui lòng liên hệ Admin để được cấp tài khoản.",
                        "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi đăng nhập:\n" + ex.Message, "Login Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                SetBusy(false);
            }
        }
        


        private void chkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPwd.Checked ? '\0' : '●';
        }

        /// <summary>
        /// Giải mã JWT để lấy roles. Hỗ trợ cả "role": [...] và ClaimTypes.Role (URI).
        /// </summary>
        private string[] TryExtractRoles(string jwt)
        {
            try
            {
                var parts = jwt.Split('.');
                if (parts.Length < 2) return Array.Empty<string>();

                string Base64UrlToString(string s)
                {
                    s = s.Replace('-', '+').Replace('_', '/');
                    switch (s.Length % 4) { case 2: s += "=="; break; case 3: s += "="; break; }
                    var bytes = Convert.FromBase64String(s);
                    return Encoding.UTF8.GetString(bytes);
                }

                var payloadJson = Base64UrlToString(parts[1]);
                using (var doc = JsonDocument.Parse(payloadJson))
                {
                    var root = doc.RootElement;

                    // 1) "role": "Admin" hoặc ["Admin", "Customer"]
                    if (root.TryGetProperty("role", out var roleProp))
                    {
                        if (roleProp.ValueKind == JsonValueKind.String)
                        {
                            string v = roleProp.GetString();
                            return v != null ? new[] { v } : Array.Empty<string>();
                        }

                        if (roleProp.ValueKind == JsonValueKind.Array)
                            return roleProp.EnumerateArray()
                                .Where(x => x.ValueKind == JsonValueKind.String)
                                .Select(x => x.GetString())
                                .Where(v => v != null)
                                .ToArray();
                    }

                    // 2) ClaimTypes.Role (URI)
                    var roleUri = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
                    if (root.TryGetProperty(roleUri, out var roleUriProp))
                    {
                        if (roleUriProp.ValueKind == JsonValueKind.String)
                        {
                            var v = roleUriProp.GetString();
                            return v != null ? new[] { v } : Array.Empty<string>();
                        }
                        if (roleUriProp.ValueKind == JsonValueKind.Array)
                            return roleUriProp.EnumerateArray()
                                .Where(x => x.ValueKind == JsonValueKind.String)
                                .Select(x => x.GetString())
                                .Where(v => v != null)
                                .ToArray();
                    }

                    return Array.Empty<string>();
                }
            }
            catch
            {
                return Array.Empty<string>();
            }
        }
    }
}



