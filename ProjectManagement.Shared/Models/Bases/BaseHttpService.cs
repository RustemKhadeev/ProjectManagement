using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ProjectManagement.Shared.Models.Bases
{
    public abstract class BaseHttpService
    {
        private readonly HttpClient _client;
        protected abstract string BasePath { get; }

        protected BaseHttpService(HttpClient client)
        {
            _client = client;
        }

        private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object? model)
        {
            var message = new HttpRequestMessage(method, uri);
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                return message;

            message.Content = CreateContent(model);
            return message;
        }

        private static HttpContent CreateContent(object? model)
        {
            if (model is HttpContent cont)
                return cont;

            var content = new ByteArrayContent(model == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("UTF-8");

            return content;
        }

        protected async Task<BaseResponse<T>> SendAsync<T>(string action, HttpMethod method, object? model = null)
            where T : class, new()
        {
            try
            {
                var uri = $"{BasePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var response = await _client.SendAsync(message);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return new BaseResponse<T>();

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    var ret = new BaseResponse<T>();
                    ret.Error.Add("У Вас не хватает прав на просмотр содержимого.");

                    return ret;
                }

                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<BaseResponse<T>>(content);

                if (res == null)
                {
                    var ret = new BaseResponse<T>();
                    ret.Error.Add($"Convertation response from '{uri}' to type {typeof(T)} failed.");

                    return ret;
                }

                return res;
            }
            catch (Exception exc)
            {
                var ret = new BaseResponse<T>();
                ret.Error.Add(exc.ToString());

                return ret;
            }
        }
    }
}
