using System;
using System.IO;
using System.Net;
using System.Text;

// ReSharper disable once CheckNamespace
namespace VkNet.Utils
{
	/// <summary>
	/// </summary>
	[Obsolete(ObsoleteText.ObsoleteClass)]
	public sealed class WebCallResult
	{
		/// <summary>
		/// Инициализация класса WebCallResult
		/// </summary>
		/// <param name="url"> URL. </param>
		/// <param name="cookies"> Куки. </param>
		public WebCallResult(string url, Cookies cookies)
		{
			RequestUrl = new Uri(url);
			Cookies = cookies;
			Response = string.Empty;
		}

		/// <summary>
		/// URL запроса.
		/// </summary>
		public Uri RequestUrl { get; }

		/// <summary>
		/// Куки.
		/// </summary>
		public Cookies Cookies { get; }

		/// <summary>
		/// Получить URL ответа.
		/// </summary>
		public Uri ResponseUrl { get; private set; }

		/// <summary>
		/// Ответ.
		/// </summary>
		public string Response { get; private set; }

		/// <summary>
		/// Сохранить куки.
		/// </summary>
		/// <param name="cookies"> Куки. </param>
		public void SaveCookies(CookieCollection cookies)
		{
			Cookies.AddFrom(ResponseUrl, cookies);
		}

		/// <summary>
		/// Сохранить ответ.
		/// </summary>
		/// <param name="responseUrl"> URL ответ. </param>
		/// <param name="stream"> Поток. </param>
		/// <param name="encoding"> Кодировка. </param>
		public void SaveResponse(Uri responseUrl, Stream stream, Encoding encoding)
		{
			ResponseUrl = responseUrl;

			using (var reader = new StreamReader(stream, encoding))
			{
				Response = reader.ReadToEnd();
			}
		}
	}
}