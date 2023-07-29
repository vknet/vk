using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Abstractions.Utils;

/// <summary>
/// Rest Client
/// </summary>
public interface IRestClient : IDisposable
{
	/// <summary>
	/// Get request
	/// </summary>
	/// <param name="uri"> Uri </param>
	/// <param name="parameters">Параметры </param>
	/// <param name="encoding">Кодировка</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns> String result </returns>
	Task<HttpResponse<string>> GetAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding,
										CancellationToken token = default);

	/// <summary>
	/// POST запрос
	/// </summary>
	/// <param name="uri"> Uri </param>
	/// <param name="parameters"> Параметры </param>
	/// <param name="encoding">Кодировка</param>
	/// <param name="headers"> Заголовки </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns> Строковый результат </returns>
	Task<HttpResponse<string>> PostAsync(Uri uri, IEnumerable<KeyValuePair<string, string>> parameters, Encoding encoding,
										IEnumerable<KeyValuePair<string, string>> headers = null, CancellationToken token = default);
}