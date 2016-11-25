#if UWP
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
    public sealed class WebCall : IDisposable
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
#else
namespace VkNet.Utils
{
    using System.Net;
    using System.Text;
    using Exception;

    /// <summary>
    /// WebCall
    /// </summary>
    internal sealed class WebCall
    {
        /// <summary>
        /// Получить HTTP запрос.
        /// </summary>
        private HttpWebRequest Request { get; }

        /// <summary>
        /// Результат.
        /// </summary>
        private WebCallResult Result { get; }

        /// <summary>
        /// WebCall.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="cookies">Cookies.</param>
        /// <param name="webProxy">Хост.</param>
        private WebCall(string url, Cookies cookies, IWebProxy webProxy = null)
        {
            Request = (HttpWebRequest)WebRequest.Create(url);
            Request.Accept = "text/html";
            Request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            Request.CookieContainer = cookies.Container;

            if (webProxy != null)
            {
                Request.Proxy = webProxy;
            }

            Result = new WebCallResult(url, cookies);
        }

        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        public static WebCallResult MakeCall(string url, IWebProxy webProxy = null)
        {
            var call = new WebCall(url, new Cookies(), webProxy);

            return call.MakeRequest(webProxy);
        }

        /// <summary>
        /// Выполнить POST запрос.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="parameters">Параметры запроса.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        public static WebCallResult PostCall(string url, string parameters, IWebProxy webProxy = null)
        {
            var call = new WebCall(url, new Cookies(), webProxy)
            {
                Request =
                {
                    Method = "POST",
                    ContentType = "application/x-www-form-urlencoded"
                }
            };

            var data = Encoding.UTF8.GetBytes(parameters);
            call.Request.ContentLength = data.Length;

            using (var requestStream = call.Request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            return call.MakeRequest(webProxy);
        }

        /// <summary>
        /// Post запрос из формы.
        /// </summary>
        /// <param name="form">Форма.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        public static WebCallResult Post(WebForm form, IWebProxy webProxy = null)
        {
            var call = new WebCall(form.ActionUrl, form.Cookies, webProxy);

            var request = call.Request;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var formRequest = form.GetRequest();
            request.ContentLength = formRequest.Length;
            request.Referer = form.OriginalUrl;
            request.GetRequestStream().Write(formRequest, 0, formRequest.Length);
            request.AllowAutoRedirect = false;

            return call.MakeRequest(webProxy);
        }

        /// <summary>
        /// Пере адресация.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        private WebCallResult RedirectTo(string url, IWebProxy webProxy = null)
        {
            var call = new WebCall(url, Result.Cookies, webProxy);

            var request = call.Request;
            request.Method = "GET";
            request.ContentType = "text/html";
            request.Referer = Request.Referer;

            return call.MakeRequest(webProxy);
        }

        /// <summary>
        /// Выполнить запрос.
        /// </summary>
        /// <param name="webProxy">Хост.</param>
        /// <returns>Результат</returns>
        /// <exception cref="VkApiException">Response is null.</exception>
        private WebCallResult MakeRequest(IWebProxy webProxy = null)
        {
            using (var response = GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (stream == null)
                    {
                        throw new VkApiException("Response is null.");
                    }

                    var encoding = response.CharacterSet != null ? Encoding.GetEncoding(response.CharacterSet) : Encoding.UTF8;
                    Result.SaveResponse(response.ResponseUri, stream, encoding);

                    Result.SaveCookies(response.Cookies);

                    return response.StatusCode == HttpStatusCode.Redirect
                        ? RedirectTo(response.Headers["Location"], webProxy)
                        : Result;
                }
            }
        }

        /// <summary>
        /// Получить запрос.
        /// </summary>
        /// <returns>Запрос</returns>
        /// <exception cref="VkApiException">Ошибка запроса</exception>
        private HttpWebResponse GetResponse()
        {
            try
            {
                return (HttpWebResponse)Request.GetResponse();
            } catch (WebException ex)
            {
                throw new VkApiException(ex.Message, ex);
            }
        }
    }
} 
#endif
