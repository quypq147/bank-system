using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BankClient
{
    /// <summary>
    /// C# 7.3–compatible ApiClient:
    /// - No nullable reference types.
    /// - Provides SetToken/SetBearer/ClearToken.
    /// - GetAsync<T>(url, bool requireAuth = true)
    /// - PostAsync(url, body, bool requireAuth = true)
    /// - PostAsync<TOut>(url, body, bool requireAuth = true)
    /// Also keeps simple JSON helpers.
    /// </summary>
    public static class ApiClient
    {
        private static readonly HttpClient _http = new HttpClient
        {
            // TODO: chỉnh base URL đúng backend của bạn
            BaseAddress = new Uri("http://localhost:5014/")
        };

        public static string Token; // may be null at runtime (no nullable annotations in C# 7.3)

        public static void SetToken(string jwt)
        {
            Token = jwt;
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", jwt);
        }

        // Alias cho code cũ (BankApi gọi SetBearer)
        public static void SetBearer(string jwt)
        {
            SetToken(jwt);
        }

        public static void ClearToken()
        {
            Token = null;
            _http.DefaultRequestHeaders.Authorization = null;
        }

        private static void EnsureAuth(bool requireAuth)
        {
            if (!requireAuth) return;
            if (string.IsNullOrWhiteSpace(Token))
                throw new InvalidOperationException("Missing bearer token. Please login first.");
            // Header được set trong SetToken/SetBearer
        }

        // ======= Overloads tương thích với BankApi.cs =======

        public static async Task<TOut> GetAsync<TOut>(string url, bool requireAuth = true)
        {
            EnsureAuth(requireAuth);
            var res = await _http.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var obj = await res.Content.ReadFromJsonAsync<TOut>();
            if (object.Equals(obj, default(TOut)))
                throw new InvalidOperationException("Empty response body.");
            return obj;
        }

        public static async Task PostAsync(string url, object body, bool requireAuth = true)
        {
            EnsureAuth(requireAuth);
            var res = await _http.PostAsJsonAsync(url, body);
            res.EnsureSuccessStatusCode();
        }

        public static async Task<TOut> PostAsync<TOut>(string url, object body, bool requireAuth = true)
        {
            EnsureAuth(requireAuth);
            var res = await _http.PostAsJsonAsync(url, body);
            res.EnsureSuccessStatusCode();
            var obj = await res.Content.ReadFromJsonAsync<TOut>();
            if (object.Equals(obj, default(TOut)))
                throw new InvalidOperationException("Empty response body.");
            return obj;
        }

        // ======= Helpers JSON tuỳ chọn =======
        public static async Task<T> GetJsonAsync<T>(string url)
        {
            var res = await _http.GetAsync(url);
            res.EnsureSuccessStatusCode();
            var obj = await res.Content.ReadFromJsonAsync<T>();
            if (object.Equals(obj, default(T)))
                throw new InvalidOperationException("Empty response body.");
            return obj;
        }

        public static async Task<HttpResponseMessage> PostJsonAsync<T>(string url, T body)
        {
            var res = await _http.PostAsJsonAsync(url, body);
            res.EnsureSuccessStatusCode();
            return res;
        }

        public static async Task<TOut> PostAndReadAsync<TIn, TOut>(string url, TIn body)
        {
            var res = await _http.PostAsJsonAsync(url, body);
            res.EnsureSuccessStatusCode();
            var obj = await res.Content.ReadFromJsonAsync<TOut>();
            if (object.Equals(obj, default(TOut)))
                throw new InvalidOperationException("Empty response body.");
            return obj;
        }
    }
}
