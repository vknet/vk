using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VkNet.Exception;

namespace VkNet.Utils
{
	internal sealed partial class WebCall
	{
		/// <summary>
		/// Выполнить запрос асинхронно.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="webProxy"> Данные прокси сервера. </param>
		/// <returns> Результат </returns>
		public static async Task<WebCallResult> MakeCallAsync(string url, IWebProxy webProxy = null)
		{
			using (var call = new WebCall(url: url, cookies: new Cookies(), webProxy: webProxy))
			{
				var response = await call._request.GetAsync(requestUri: url);

				return await call.MakeRequestAsync(response: response, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Выполнить POST запрос асинхронно.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="parameters"> Параметры запроса. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		public static async Task<WebCallResult> PostCallAsync(string url
															, IEnumerable<KeyValuePair<string, string>> parameters
															, IWebProxy webProxy)
		{
			using (var call = new WebCall(url: url, cookies: new Cookies(), webProxy: webProxy))
			{
				var request = await call._request.PostAsync(requestUri: url
						, content: new FormUrlEncodedContent(nameValueCollection: parameters));

				return await call.MakeRequestAsync(response: request, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Post запрос из формы асинхронно.
		/// </summary>
		/// <param name="form"> Форма. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		public static async Task<WebCallResult> PostAsync(WebForm form, IWebProxy webProxy)
		{
			using (var call = new WebCall(url: form.ActionUrl, cookies: form.Cookies, webProxy: webProxy, allowAutoRedirect: false))
			{
				SpecifyHeadersForFormRequest(form: form, call: call);

				var request = await call._request.PostAsync(requestUri: form.ActionUrl
						, content: new FormUrlEncodedContent(nameValueCollection: form.GetFormFields()));

				return await call.MakeRequestAsync(response: request, uri: new Uri(uriString: form.ActionUrl), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Асинхронная переадресация.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		private async Task<WebCallResult> RedirectToAsync(string url, IWebProxy webProxy = null)
		{
			using (var call = new WebCall(url: url, cookies: _result.Cookies, webProxy: webProxy))
			{
				var headers = call._request.DefaultRequestHeaders;
				headers.Add(name: "Method", value: "GET");
				headers.Add(name: "ContentType", value: "text/html");

				var response = await call._request.GetAsync(requestUri: url);

				return await call.MakeRequestAsync(response: response, uri: new Uri(uriString: url), webProxy: webProxy);
			}
		}

		/// <summary>
		/// Выполнить запрос асинхронно.
		/// </summary>
		/// <param name="uri"> Uri из которого получаем куки </param>
		/// <param name="webProxy"> Хост. </param>
		/// <param name="response"> Ответ сервера </param>
		/// <returns> Результат </returns>
		/// <exception cref="VkApiException"> Response is null. </exception>
		private async Task<WebCallResult> MakeRequestAsync(HttpResponseMessage response, Uri uri, IWebProxy webProxy)
		{
			using (var stream = await response.Content.ReadAsStreamAsync())
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
						? await RedirectToAsync(url: response.Headers.Location.AbsoluteUri, webProxy: webProxy)
						: _result;
			}
		}
	}
}