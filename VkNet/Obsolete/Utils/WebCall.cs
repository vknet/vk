//#define DEBUG_HTTP // Директива для подробного анализа HTTP запросов при возникновении ошибок с авторизацией

using System;
using System.Collections.Generic;
#if DEBUG_HTTP
using System.IO;
#endif
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VkNet.Exception;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// WebCall
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteClass)]
	internal sealed partial class WebCall : IDisposable
	{
	#if DEBUG_HTTP
		const string HTTP_LOG_PATH = "debug_http.log";
		const bool WRITE_TO_FILE = false; // По умолчанию запись логов в файл отключена

		static internal void LogWebCallRequestInfo(string method, string url, IEnumerable<KeyValuePair<string, string>> parameters, IWebProxy webProxy)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{method} {url} [PROXY: {(webProxy != null)}]");
			if (parameters != null)
			{
				foreach (var p in parameters) {
					sb.AppendLine($"{p.Key}: {p.Value}");
				}
			}
			sb.AppendLine();
			Console.WriteLine($"{nameof(VkApi)} [{nameof(WebCall)}]: " + sb.ToString());
			if (WRITE_TO_FILE) {
				File.AppendAllText(HTTP_LOG_PATH, $"{DateTime.Now}: " + sb.ToString(), Encoding.UTF8);
			}
		}

		static internal void LogWebCallResultDebugInfo(string method, string url, HttpResponseMessage response, WebCallResult res, long executionTimeMS)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{method} {url} - {(int)response.StatusCode} {response.ReasonPhrase} in {executionTimeMS} msec.");
			foreach (var header in response.Content.Headers)
				sb.AppendLine($"{header.Key}: {string.Join("; ", header.Value)}");
			sb.AppendLine(res.Response);
			sb.AppendLine();
			Console.WriteLine($"{nameof(VkApi)} [{nameof(WebCall)}]: " + sb.ToString());
			if (WRITE_TO_FILE)
				File.AppendAllText(HTTP_LOG_PATH, $"{DateTime.Now}: " + sb.ToString(), Encoding.UTF8);
		}

	#endif

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
					Accept =
					{
						MediaTypeWithQualityHeaderValue.Parse("text/html")
					}
				}
			};

			_result = new WebCallResult(url, cookies);
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
		#if DEBUG_HTTP
			LogWebCallRequestInfo("GET", url, null, webProxy);
			var watch = System.Diagnostics.Stopwatch.StartNew();
		#endif

			using (var call = new WebCall(url, new Cookies(), webProxy))
			{
				var response = call._request.GetAsync(url).GetAwaiter().GetResult();
				var res = call.MakeRequest(response, new Uri(url), webProxy);

			#if DEBUG_HTTP
				watch.Stop();
				LogWebCallResultDebugInfo("GET", url, response, res, watch.ElapsedMilliseconds);
			#endif

				return res;
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
		#if DEBUG_HTTP
			LogWebCallRequestInfo("POST", url, parameters, webProxy);
			var watch = System.Diagnostics.Stopwatch.StartNew();
		#endif

			using (var call = new WebCall(url, new Cookies(), webProxy))
			{
				var response = call._request
					.PostAsync(url, new FormUrlEncodedContent(parameters))
					.GetAwaiter()
					.GetResult();

				var res = call.MakeRequest(response, new Uri(url), webProxy);

			#if DEBUG_HTTP
				watch.Stop();
				LogWebCallResultDebugInfo("POST", url, response, res, watch.ElapsedMilliseconds);
			#endif

				return res;
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
		#if DEBUG_HTTP
			LogWebCallRequestInfo("POST", form.ActionUrl, form.GetFormFields(), webProxy);
			var watch = System.Diagnostics.Stopwatch.StartNew();
		#endif

			using (var call = new WebCall(form.ActionUrl, form.Cookies, webProxy, false))
			{
				SpecifyHeadersForFormRequest(form, call);

				var response = call._request
					.PostAsync(form.ActionUrl, new FormUrlEncodedContent(form.GetFormFields()))
					.GetAwaiter()
					.GetResult();

				var res = call.MakeRequest(response, new Uri(form.ActionUrl), webProxy);

			#if DEBUG_HTTP
				watch.Stop();
				LogWebCallResultDebugInfo("POST", form.ActionUrl, response, res, watch.ElapsedMilliseconds);
			#endif

				return res;
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
		#if DEBUG_HTTP
			LogWebCallRequestInfo("REDIRECT GET", url, null, webProxy);
			var watch = System.Diagnostics.Stopwatch.StartNew();
		#endif

			using (var call = new WebCall(url, _result.Cookies, webProxy))
			{
				var headers = call._request.DefaultRequestHeaders;
				headers.Add("Method", "GET");
				headers.Add("ContentType", "text/html");

				var response = call._request.GetAsync(url).GetAwaiter().GetResult();
				var res = call.MakeRequest(response, new Uri(url), webProxy);

			#if DEBUG_HTTP
				watch.Stop();
				LogWebCallResultDebugInfo("REDIRECT GET", url, response, res, watch.ElapsedMilliseconds);
			#endif

				return res;
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
			using (var stream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
			{
				if (stream == null)
				{
					throw new VkApiException("Response is null.");
				}

				var encoding = Encoding.UTF8;
				_result.SaveResponse(response.RequestMessage.RequestUri, stream, encoding);

				var cookies = _result.Cookies.Container;

				_result.SaveCookies(cookies.GetCookies(uri));

				return response.StatusCode == HttpStatusCode.Redirect
					? RedirectTo(response.Headers.Location.AbsoluteUri, webProxy)
					: _result;
			}
		}

		private static void SpecifyHeadersForFormRequest(WebForm form, WebCall call)
		{
			var formRequest = form.GetRequest();

			var headers = call._request.DefaultRequestHeaders;
			headers.Add("Method", "POST");
			headers.Add("ContentType", "application/x-www-form-urlencoded");

			headers.Add("ContentLength", formRequest.Length.ToString());
			headers.Referrer = new Uri(form.OriginalUrl);
		}
	}
}