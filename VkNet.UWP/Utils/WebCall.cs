using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using VkNet.Exception;

namespace VkNet.Utils
{
    /// <summary>
    /// WebCall
    /// </summary>
    internal sealed class WebCall : IDisposable
    {
        /// <summary>
        /// Получить HTTP запрос.
        /// </summary>
        private readonly HttpClient _request;

        /// <summary>
        /// Результат.
        /// </summary>
        private readonly WebCallResult _result;

        /// <summary>
        /// WebCall.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="cookies">Cookies.</param>
        /// <param name="webProxy">Хост.</param>
        /// <param name="allowAutoRedirect">Разрешить авто редиррект</param>
        private WebCall(string url, Cookies cookies, IWebProxy webProxy = null, bool allowAutoRedirect = true)
        {
            var baseAddress = new Uri(url);

            var handler = new HttpClientHandler
            {
                CookieContainer = cookies.Container,
                UseCookies = true,
                Proxy = webProxy,
                AllowAutoRedirect = allowAutoRedirect
            };
            _request = new HttpClient(handler)
            {
                BaseAddress = baseAddress,
                DefaultRequestHeaders =
                    {
                        Accept = {MediaTypeWithQualityHeaderValue.Parse("text/html")}
                    }
            };
            _result = new WebCallResult(url, cookies);
        }

        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="webProxy">Данные прокси сервера.</param>
        /// <returns>Результат</returns>
        public static WebCallResult MakeCall(string url, IWebProxy webProxy = null)
        {
            using (var call = new WebCall(url, new Cookies(), webProxy))
            {
                var response = call._request.GetAsync(url).Result;
                return call.MakeRequest(response, new Uri(url), webProxy);
            }
        }

        /// <summary>
        /// Выполнить POST запрос.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="parameters">Параметры запроса.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        public static WebCallResult PostCall(string url, string parameters, IWebProxy webProxy)
        {
            using (var call = new WebCall(url, new Cookies(), webProxy))
            {
                var data = Encoding.UTF8.GetBytes(parameters);

                var headers = call._request.DefaultRequestHeaders;
                headers.Add("Method", "POST");
                headers.Add("ContentType", "application/x-www-form-urlencoded");
                headers.Add("ContentLength", data.Length.ToString());

                var paramList = new Dictionary<string, string>();
                foreach (var param in parameters.Split('&'))
                {
                    if (paramList.ContainsKey(param))
                    {
                        continue;
                    }

                    var paramPair = param.Split('=');
                    var key = paramPair[0] + "";
                    var value = paramPair[1] + "";
                    paramList.Add(key, value);
                }

                var request = call._request.PostAsync(url, new FormUrlEncodedContent(paramList)).Result;
                return call.MakeRequest(request, new Uri(url), webProxy);
            }
        }

        /// <summary>
        /// Post запрос из формы.
        /// </summary>
        /// <param name="form">Форма.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        public static WebCallResult Post(WebForm form, IWebProxy webProxy)
        {
            using (var call = new WebCall(form.ActionUrl, form.Cookies, webProxy, false))
            {
                var formRequest = form.GetRequest();

                var headers = call._request.DefaultRequestHeaders;
                headers.Add("Method", "POST");
                headers.Add("ContentType", "application/x-www-form-urlencoded");

                headers.Add("ContentLength", formRequest.Length.ToString());
                headers.Referrer = new Uri(form.OriginalUrl);

                var paramList = new Dictionary<string, string>();
                foreach (var param in form.GetRequestAsStringArray())
                {
                    if (paramList.ContainsKey(param))
                    {
                        continue;
                    }

                    var paramPair = param.Split('=');
                    var key = paramPair[0] + "";
                    var value = paramPair[1] + "";
                    paramList.Add(key, value);
                }

                var request = call._request.PostAsync(form.ActionUrl, new FormUrlEncodedContent(paramList)).Result;
                return call.MakeRequest(request, new Uri(form.ActionUrl), webProxy);
            }
        }

        /// <summary>
        /// Пере адресация.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        private WebCallResult RedirectTo(string url, IWebProxy webProxy = null)
        {
            using (var call = new WebCall(url, _result.Cookies, webProxy))
            {
                var headers = call._request.DefaultRequestHeaders;
                headers.Add("Method", "GET");
                headers.Add("ContentType", "text/html");

                var response = call._request.GetAsync(url).Result;

                return call.MakeRequest(response, new Uri(url), webProxy);
            }
        }

        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="uri">Uri из которого получаем куки</param>
        /// <param name="webProxy">Хост.</param>
        /// <param name="response">Ответ сервера</param>
        /// <returns>Результат</returns>
        /// <exception cref="VkApiException">Response is null.</exception>
        private WebCallResult MakeRequest(HttpResponseMessage response, Uri uri, IWebProxy webProxy)
        {
            using (var stream = response.Content.ReadAsStreamAsync().Result)
            {
                if (stream == null)
                {
                    throw new VkApiException("Response is null.");
                }

                var encoding = Encoding.UTF8;
                _result.SaveResponse(response.RequestMessage.RequestUri, stream, encoding);

                var cookies = new CookieContainer();

                _result.SaveCookies(cookies.GetCookies(uri));
                return response.StatusCode == HttpStatusCode.Redirect
                        ? RedirectTo(response.Headers.Location.AbsoluteUri, webProxy)
                        : _result;
            }
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            _request?.Dispose();
        }

        #endregion
    }
}