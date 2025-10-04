// BankApi.cs
using System.Threading.Tasks;
using BankClient.Models;

namespace BankClient.Api
{
    public static class BankApi
    {
        // LOGIN: không requireAuth; đọc token theo nhiều key; gắn Bearer ngay sau login
        public static async Task<string> LoginAsync(string email, string password)
        {
            var obj = await ApiClient.PostAsync<dynamic>(
                "api/auth/login",
                new LoginDto { Email = email, Password = password },
                requireAuth: false
            );

            string tok = null;
            try
            {
                tok = (string)(
                      (obj.token ?? obj.Token
                    ?? obj.access_token ?? obj.accessToken
                    ?? obj.jwt));
            }
            catch { /* ignore */ }

            if (string.IsNullOrWhiteSpace(tok))
                throw new System.Exception("Login thành công nhưng không nhận được token từ server.");

            ApiClient.SetBearer(tok);
            return tok;
        }

        // Test token sau login (yêu cầu Bearer)
        public static Task<string> MeAsync() =>
            ApiClient.GetAsync<string>("api/auth/me", requireAuth: true);

        // ===== CUSTOMERS (Admin-only) =====
        public static Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto dto) =>
            ApiClient.PostAsync<CustomerDto>("api/customers", dto, requireAuth: true);

        public static Task<CustomerDto[]> SearchCustomersAsync(string q) =>
    ApiClient.GetAsync<CustomerDto[]>($"api/customers?q={System.Uri.EscapeDataString(q ?? "")}", requireAuth: true);

        // ===== ACCOUNTS =====
        public static Task<AccountDto> OpenAccountAsync(AccountOpenDto dto) =>
            ApiClient.PostAsync<AccountDto>("api/accounts/open", dto, requireAuth: true);

        public static Task<AccountDto> GetAccountAsync(string accountNo) =>
            ApiClient.GetAsync<AccountDto>($"api/accounts/{accountNo}", requireAuth: true);

        // ===== TRANSACTIONS =====
        public static Task DepositAsync(CashDto dto) =>
            ApiClient.PostAsync("api/accounts/deposit", dto, requireAuth: true);

        public static Task WithdrawAsync(CashDto dto) =>
            ApiClient.PostAsync("api/accounts/withdraw", dto, requireAuth: true);

        public static Task TransferAsync(TransferDto dto) =>
            ApiClient.PostAsync("api/accounts/transfer", dto, requireAuth: true);

        // ===== STATEMENT =====
        public static Task<TransactionDto[]> StatementAsync(StatementQueryDto dto) =>
            ApiClient.PostAsync<TransactionDto[]>("api/accounts/statement", dto, requireAuth: true);
    }
}




