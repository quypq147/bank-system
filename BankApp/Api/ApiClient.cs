// ApiClient.cs
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Api
{
    public static class ApiClient
    {
        private static HttpClient _http;
        public static string Token { get; private set; }
        public static string BaseUrl { get; private set; }

        static ApiClient()
        {
            var cfg = ConfigurationManager.AppSettings["ApiBaseUrl"];
            BaseUrl = string.IsNullOrWhiteSpace(cfg) ? "http://localhost:5014/" : cfg.Trim();
            if (!BaseUrl.EndsWith("/")) BaseUrl += "/";

            _http = NewHttp(BaseUrl);
        }

        private static HttpClient NewHttp(string baseUrl)
        {
            var h = new HttpClient { BaseAddress = new Uri(baseUrl) };
            h.DefaultRequestHeaders.Accept.Clear();
            h.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return h;
        }

        public static void SetBaseUrl(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl)) return;
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            BaseUrl = baseUrl;
            _http?.Dispose();
            _http = NewHttp(BaseUrl);

            if (!string.IsNullOrWhiteSpace(Token))
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        public static void SetBearer(string token)
        {
            Token = token;
            _http.DefaultRequestHeaders.Authorization =
                string.IsNullOrWhiteSpace(token) ? null : new AuthenticationHeaderValue("Bearer", token);
        }

        private static string U(string url) => string.IsNullOrWhiteSpace(url) ? "/" : (url.StartsWith("/") ? url : "/" + url);

        private static void EnsureAuthIfRequired(bool requireAuth)
        {
            if (!requireAuth) return;
            var auth = _http.DefaultRequestHeaders.Authorization;
            if (auth == null || string.IsNullOrWhiteSpace(auth.Parameter))
                throw new Exception("Chưa đăng nhập: Bearer token chưa được gắn vào header.");
        }

        private static Exception BuildHttpError(HttpResponseMessage res, string body, string method, string url)
        {
            var authHeader = _http.DefaultRequestHeaders.Authorization?.ToString() ?? "(null)";
            res.Headers.TryGetValues("WWW-Authenticate", out var v);
            var wwwAuth = v is null ? "(none)" : string.Join(" | ", v);
            var reqUri = res.RequestMessage?.RequestUri?.ToString() ?? "(null)";

            var diag = new StringBuilder()
                .AppendLine($"{(int)res.StatusCode} {res.ReasonPhrase}  [{method} {reqUri}]")
                .AppendLine($"BaseAddress: {BaseUrl}")
                .AppendLine($"Sent Authorization: {authHeader}")
                .AppendLine($"WWW-Authenticate: {wwwAuth}")
                .AppendLine("Body:")
                .AppendLine(body)
                .ToString();
            return new Exception(diag);
        }

        public static async Task<T> GetAsync<T>(string url, bool requireAuth = false)
        {
            EnsureAuthIfRequired(requireAuth);
            using (var res = await _http.GetAsync(U(url)))
    {
        var body = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw BuildHttpError(res, body, "GET", url);

        // SPECIAL CASE: khi T là string, trả raw body
        if (typeof(T) == typeof(string))
            return (T)(object)body;

        return JsonConvert.DeserializeObject<T>(body);
    }
}

public static async Task<T> PostAsync<T>(string url, object payload, bool requireAuth = false)
{
    EnsureAuthIfRequired(requireAuth);
    var json = JsonConvert.SerializeObject(payload);
    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
    using (var res = await _http.PostAsync(U(url), content))
    {
        var body = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw BuildHttpError(res, body, "POST", url);

        // SPECIAL CASE: khi T là string, trả raw body
        if (typeof(T) == typeof(string))
            return (T)(object)body;

        return JsonConvert.DeserializeObject<T>(body);
    }
}

public static async Task PostAsync(string url, object payload, bool requireAuth = false)
{
    EnsureAuthIfRequired(requireAuth);
    var json = JsonConvert.SerializeObject(payload);
    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
    using (var res = await _http.PostAsync(U(url), content))
    {
        var body = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode) throw BuildHttpError(res, body, "POST", url);
    }
}
    }
}





