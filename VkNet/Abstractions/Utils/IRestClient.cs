using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace VkNet.Abstractions.Utils
{
	/// <summary>
	/// Rest Client
	/// </summary>
	public interface IRestClient
	{
		/// <summary>
		/// Proxy
		/// </summary>
		IWebProxy Proxy { get; set; }

		/// <summary>
		/// Таймаут на время выполнения запроса в секундах. Значение по умолчанию 300
		/// секунд.
		/// </summary>
		TimeSpan Timeout { get; set; }

		/// <summary>
		/// Get request
		/// </summary>
		/// <param name="uri"> Uri </param>
		/// <param name="parameters"> </param>
		/// <returns> String result </returns>
		Task<HttpResponseMessage> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters);

		/// <summary>
		/// POST запрос
		/// </summary>
		/// <param name="uri"> Uri </param>
		/// <param name="parameters"> Параметры </param>
		/// <returns> Строковый результат </returns>
		Task<HttpResponseMessage> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters);
	}
}