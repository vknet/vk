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
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		private WebCall(string url, Cookies cookies, string host = null, int? port = null)
		{
			Request = (HttpWebRequest)WebRequest.Create(url);
			Request.Accept = "text/html";
			Request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
			Request.CookieContainer = cookies.Container;

			if (host != null && port != null)
				Request.Proxy = new WebProxy(host, port.Value);

			if (Request.Proxy != null)
			{
				// Авторизация с реквизитами по умолчанию (для NTLM прокси)
				Request.Proxy.Credentials = CredentialCache.DefaultCredentials;
			}

			Result = new WebCallResult(url, cookies);
		}

		/// <summary>
		/// Выполнить запрос.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		/// <returns>Результат</returns>
		public static WebCallResult MakeCall(string url, string host = null, int? port = null)
		{
			var call = new WebCall(url, new Cookies(), host, port);

			return call.MakeRequest(host, port);
		}

#if false // async version for PostCall
#endif

		/// <summary>
		/// Выполнить POST запрос.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="parameters">Параметры запроса.</param>
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		/// <returns>Результат</returns>
		public static WebCallResult PostCall(string url, string parameters, string host = null, int? port = null)
		{
			var call = new WebCall(url, new Cookies(), host, port)
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
				requestStream.Write(data, 0, data.Length);

			return call.MakeRequest(host, port);
		}

		/// <summary>
		/// Post запрос из формы.
		/// </summary>
		/// <param name="form">Форма.</param>
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		/// <returns>Результат</returns>
		public static WebCallResult Post(WebForm form, string host = null, int? port = null)
		{
			var call = new WebCall(form.ActionUrl, form.Cookies, host, port);

			var request = call.Request;
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			var formRequest = form.GetRequest();
			request.ContentLength = formRequest.Length;
			request.Referer = form.OriginalUrl;
			request.GetRequestStream().Write(formRequest, 0, formRequest.Length);
			request.AllowAutoRedirect = false;

			return call.MakeRequest(host, port);
		}

		/// <summary>
		/// Пере адресация.
		/// </summary>
		/// <param name="url">URL.</param>
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		/// <returns>Результат</returns>
		private WebCallResult RedirectTo(string url, string host = null, int? port = null)
		{
			var call = new WebCall(url, Result.Cookies, host, port);

			var request = call.Request;
			request.Method = "GET";
			request.ContentType = "text/html";
			request.Referer = Request.Referer;

			return call.MakeRequest(host, port);
		}

		/// <summary>
		/// Выполнить запрос.
		/// </summary>
		/// <param name="host">Хост.</param>
		/// <param name="port">Порт.</param>
		/// <returns>Результат</returns>
		/// <exception cref="VkApiException">Response is null.</exception>
		private WebCallResult MakeRequest(string host = null, int? port = null)
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
						? RedirectTo(response.Headers["Location"], host, port)
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