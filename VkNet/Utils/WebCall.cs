using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VkNet.Exception;

namespace VkNet.Utils
{
	/// <summary>
	/// WebCall
	/// </summary>
	internal sealed partial class WebCall : IDisposable
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
		/// <param name="url"> URL. </param>
		/// <param name="cookies"> Cookies. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <param name="allowAutoRedirect"> Разрешить авто редиррект </param>
		private WebCall(string url, Cookies cookies, IWebProxy webProxy = null, bool allowAutoRedirect = true)
		{
			var baseAddress = new Uri(uriString: url);

			var handler = new HttpClientHandler
			{
					CookieContainer = cookies.Container
					, UseCookies = true
					, Proxy = webProxy
					, AllowAutoRedirect = allowAutoRedirect
			};

			_request = new HttpClient(handler: handler)
			{
					BaseAddress = baseAddress
					, DefaultRequestHeaders =
					{
							Accept = { MediaTypeWithQualityHeaderValue.Parse(input: "text/html") }
					}
			};

			_result = new WebCallResult(url: url, cookies: cookies);
		}

	#region Implementation of IDisposable

		/// <summary>
		/// </summary>
		public void Dispose()
		{
			_request?.Dispose();
		}

	#endregion

		/// <summary>
		/// Выполнить запрос.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="webProxy"> Данные прокси сервера. </param>
		/// <returns> Результат </returns>
		public static WebCallResult MakeCall(string url, IWebProxy webProxy = null)
		{
			using (var call = new WebCall(url: url, cookies: new Cookies(), webProxy: webProxy))
			{
				var response = call._request.GetAsync(requestUri: url).Result;

				return call.MakeRequest(response: response, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Выполнить POST запрос.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="parameters"> Параметры запроса. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		public static WebCallResult PostCall(string url, IEnumerable<KeyValuePair<string, string>> parameters, IWebProxy webProxy)
		{
			using (var call = new WebCall(url: url, cookies: new Cookies(), webProxy: webProxy))
			{
				var request = call._request.PostAsync(requestUri: url, content: new FormUrlEncodedContent(nameValueCollection: parameters))
						.Result;

				return call.MakeRequest(response: request, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Post запрос из формы.
		/// </summary>
		/// <param name="form"> Форма. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		public static WebCallResult Post(WebForm form, IWebProxy webProxy)
		{
			using (var call = new WebCall(url: form.ActionUrl, cookies: form.Cookies, webProxy: webProxy, allowAutoRedirect: false))
			{
				SpecifyHeadersForFormRequest(form: form, call: call);

				var request = call._request.PostAsync(requestUri: form.ActionUrl
								, content: new FormUrlEncodedContent(nameValueCollection: form.GetFormFields()))
						.Result;

				return call.MakeRequest(response: request, uri: new Uri(uriString: form.ActionUrl), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Пере адресация.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		private WebCallResult RedirectTo(string url, IWebProxy webProxy = null)
		{
			using (var call = new WebCall(url: url, cookies: _result.Cookies, webProxy: webProxy))
			{
				var headers = call._request.DefaultRequestHeaders;
				headers.Add(name: "Method", value: "GET");
				headers.Add(name: "ContentType", value: "text/html");

				var response = call._request.GetAsync(requestUri: url).Result;

				return call.MakeRequest(response: response, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Выполнить запрос.
		/// </summary>
		/// <param name="uri"> Uri из которого получаем куки </param>
		/// <param name="webProxy"> Хост. </param>
		/// <param name="response"> Ответ сервера </param>
		/// <returns> Результат </returns>
		/// <exception cref="VkApiException"> Response is null. </exception>
		private WebCallResult MakeRequest(HttpResponseMessage response, Uri uri, IWebProxy webProxy)
		{
			using (var stream = response.Content.ReadAsStreamAsync().Result)
			{
				if (stream == null)
				{
					throw new VkApiException(message: "Response is null.");
				}

				var encoding = Encoding.UTF8;
				_result.SaveResponse(responseUrl: response.RequestMessage.RequestUri, stream: stream, encoding: encoding);

				var cookies = _result.Cookies.Container;

				_result.SaveCookies(cookies: cookies.GetCookies(uri: uri));

				return response.StatusCode == HttpStatusCode.Redirect
						? RedirectTo(url: response.Headers.Location.AbsoluteUri, webProxy: webProxy)
						: _result;
			}
		}

		private static void SpecifyHeadersForFormRequest(WebForm form, WebCall call)
		{
			var formRequest = form.GetRequest();

			var headers = call._request.DefaultRequestHeaders;
			headers.Add(name: "Method", value: "POST");
			headers.Add(name: "ContentType", value: "application/x-www-form-urlencoded");

			headers.Add(name: "ContentLength", value: formRequest.Length.ToString());
			headers.Referrer = new Uri(uriString: form.OriginalUrl);
		}
	}
}