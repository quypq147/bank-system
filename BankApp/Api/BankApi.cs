// BankApi.cs  — FIX: đọc token từ JsonElement thay vì dynamic (C# 7.3 compatible)
using System.Text.Json;
using System.Threading.Tasks;
using BankClient.Models;

namespace BankClient.Api
{
    public static class BankApi
    {
        // LOGIN: không requireAuth; đọc token theo nhiều key; gắn Bearer ngay sau login
        public static async Task<string> LoginAsync(string email, string password)
        {
            // Nhận về JsonElement thay vì dynamic
            var obj = await ApiClient.PostAsync<JsonElement>(
                "api/auth/login",
                new LoginDto { Email = email, Password = password },
                requireAuth: false
            );

            // Thử các key thường gặp: token / Token / access_token / accessToken / jwt
            string tok = TryGetString(obj, "token")
                      ?? TryGetString(obj, "Token")
                      ?? TryGetString(obj, "access_token")
                      ?? TryGetString(obj, "accessToken")
                      ?? TryGetString(obj, "jwt");

            // Nếu backend trả về plain-string (không phải object), cũng chấp nhận
            if (string.IsNullOrWhiteSpace(tok) && obj.ValueKind == JsonValueKind.String)
                tok = obj.GetString();

            if (string.IsNullOrWhiteSpace(tok))
                throw new System.Exception("Login thành công nhưng không nhận được token từ server.");

            ApiClient.SetBearer(tok);
            return tok;
        }

        private static string TryGetString(JsonElement root, string name)
        {
            if (root.ValueKind == JsonValueKind.Object)
            {
                JsonElement v;
                if (root.TryGetProperty(name, out v) && v.ValueKind == JsonValueKind.String)
                    return v.GetString();
            }
            return null;
        }

        // Test token sau login (yêu cầu Bearer)
        public static Task<string> MeAsync()
        {
            return ApiClient.GetAsync<string>("api/auth/me", requireAuth: true);
        }

        // ===== CUSTOMERS (Admin-only) =====
        public static Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto dto)
        {
            return ApiClient.PostAsync<CustomerDto>("api/customers", dto, requireAuth: true);
        }

        public static Task<CustomerDto[]> SearchCustomersAsync(string q)
        {
            var query = System.Uri.EscapeDataString(q ?? "");
            return ApiClient.GetAsync<CustomerDto[]>($"api/customers?q={query}", requireAuth: true);
        }

        // ===== ACCOUNTS =====
        public static Task<AccountDto[]> GetAccountsOfCustomerAsync(string customerId) =>
        ApiClient.GetAsync<AccountDto[]>($"api/customers/{customerId}/accounts", requireAuth: true);

        public static Task<AccountDto> OpenAccountAsync(AccountOpenDto dto)
        {
            return ApiClient.PostAsync<AccountDto>("api/accounts/open", dto, requireAuth: true);
        }

        public static Task<AccountDto> GetAccountAsync(string accountNo)
        {
            return ApiClient.GetAsync<AccountDto>($"api/accounts/{accountNo}", requireAuth: true);
        }

        // ===== TRANSACTIONS =====
        public static Task DepositAsync(CashDto dto)
        {
            return ApiClient.PostAsync("api/accounts/deposit", dto, requireAuth: true);
        }

        public static Task WithdrawAsync(CashDto dto)
        {
            return ApiClient.PostAsync("api/accounts/withdraw", dto, requireAuth: true);
        }

        public static Task TransferAsync(TransferDto dto)
        {
            return ApiClient.PostAsync("api/accounts/transfer", dto, requireAuth: true);
        }

        // ===== STATEMENT =====
        public static Task<TransactionDto[]> StatementAsync(StatementQueryDto dto)
        {
            return ApiClient.PostAsync<TransactionDto[]>("api/accounts/statement", dto, requireAuth: true);
        }
    }
}





