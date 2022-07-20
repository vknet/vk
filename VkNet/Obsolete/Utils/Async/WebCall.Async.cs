using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VkNet.Exception;

// ReSharper disable once CheckNamespace
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
			using (var call = new WebCall(url, new Cookies(), webProxy))
			{
				var response = await call._request.GetAsync(url).ConfigureAwait(false);

				return await call.MakeRequestAsync(response, new Uri(url), webProxy)
					.ConfigureAwait(false);
			}
		}

		/// <summary>
		/// Выполнить POST запрос асинхронно.
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="parameters"> Параметры запроса. </param>
		/// <param name="webProxy"> Хост. </param>
		/// <returns> Результат </returns>
		public static async Task<WebCallResult> PostCallAsync(string url, IEnumerable<KeyValuePair<string, string>> parameters,
															IWebProxy webProxy)
		{
			using (var call = new WebCall(url, new Cookies(), webProxy))
			{
				var request = await call._request
					.PostAsync(url, new FormUrlEncodedContent(parameters))
					.ConfigureAwait(false);

				return await call.MakeRequestAsync(request, new Uri(url), webProxy)
					.ConfigureAwait(false);
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
			using (var call = new WebCall(form.ActionUrl, form.Cookies, webProxy, false))
			{
				SpecifyHeadersForFormRequest(form, call);

				var request = await call._request.PostAsync(form.ActionUrl,
						new FormUrlEncodedContent(form.GetFormFields()))
					.ConfigureAwait(false);

				return await call.MakeRequestAsync(request, new Uri(form.ActionUrl), webProxy)
					.ConfigureAwait(false);
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
			using (var call = new WebCall(url, _result.Cookies, webProxy))
			{
				var headers = call._request.DefaultRequestHeaders;
				headers.Add("Method", "GET");
				headers.Add("ContentType", "text/html");

				var response = await call._request.GetAsync(url).ConfigureAwait(false);

				return await call.MakeRequestAsync(response, new Uri(url), webProxy)
					.ConfigureAwait(false);
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
			using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

			if (stream == null)
			{
				throw new VkApiException("Response is null.");
			}

			var encoding = Encoding.UTF8;
			_result.SaveResponse(response.RequestMessage.RequestUri, stream, encoding);

			var cookies = _result.Cookies.Container;

			_result.SaveCookies(cookies.GetCookies(uri));

			if (IsAbsoluteUrl(response.Headers.Location?.ToString()))
			{
				return response.StatusCode == HttpStatusCode.Redirect
					? await RedirectToAsync(response.Headers.Location?.AbsoluteUri, webProxy).ConfigureAwait(false)
					: _result;
			}

			return response.StatusCode == HttpStatusCode.Redirect
				? await RedirectToAsync(_result.RequestUrl.GetLeftPart(UriPartial.Authority) + response.Headers.Location, webProxy)
					.ConfigureAwait(false)
				: _result;
		}

		private static bool IsAbsoluteUrl(string url)
		{
			return !string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out var _);
		}

		private string GetDomain(Uri uri)
		{
			return uri.GetLeftPart(UriPartial.Authority);
		}
	}
}