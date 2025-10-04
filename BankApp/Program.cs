// Program.cs (BankClient)
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BankClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK) return;

                var token = login.JwtToken; // đã được set trong LoginForm khi login thành công
                var roles = ExtractRoles(token);

                // Nếu có Admin -> mở MainForm (admin); ngược lại -> UserForm (customer)
                if (roles.Any(r => string.Equals(r, "Admin", StringComparison.OrdinalIgnoreCase)))
                {
                    Application.Run(new MainForm());    // admin UI (giữ nguyên form bạn đã dùng)
                }
                else
                {
                    Application.Run(new UserForm());    // customer UI (form mới bên dưới)
                }
            }
        }

        // Giải mã JWT để lấy roles (hỗ trợ cả "role": [], và URI claim)
        private static string[] ExtractRoles(string jwt)
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

                    // "role": "Admin" | ["Admin","Customer"]
                    if (root.TryGetProperty("role", out var roleProp))
                    {
                        if (roleProp.ValueKind == JsonValueKind.String)
                            return new[] { roleProp.GetString() }; // Removed ! operator
                        if (roleProp.ValueKind == JsonValueKind.Array)
                            return roleProp.EnumerateArray()
                                .Where(x => x.ValueKind == JsonValueKind.String)
                                .Select(x => x.GetString())
                                .Where(x => x != null)
                                .ToArray();
                    }

                    // ClaimTypes.Role URI
                    var roleUri = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
                    if (root.TryGetProperty(roleUri, out var roleUriProp))
                    {
                        if (roleUriProp.ValueKind == JsonValueKind.String)
                            return new[] { roleUriProp.GetString() };
                        if (roleUriProp.ValueKind == JsonValueKind.Array)
                            return roleUriProp.EnumerateArray()
                                .Where(x => x.ValueKind == JsonValueKind.String)
                                .Select(x => x.GetString())
                                .Where(x => x != null)
                                .ToArray();
                    }
                    return Array.Empty<string>();
                }
            }
            catch { return Array.Empty<string>(); }
        }
    }
}

