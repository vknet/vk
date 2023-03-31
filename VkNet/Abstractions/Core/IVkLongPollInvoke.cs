using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Вызов LongPoll API
/// </summary>
public interface IVkLongPollInvoke
{
	/// <summary>
	/// Вызвать ожидание событий LongPoll API.
	/// </summary>
	/// <param name="server"> Сервер. </param>
	/// <param name="parameters"> Параметры. </param>
	/// /// <param name="jsonConverters"> JsonConverters </param>
	/// <returns> </returns>
	VkResponse CallLongPoll(string server, VkParameters parameters, params JsonConverter[] jsonConverters);

	/// <summary>
	/// Вызвать ожидание событий LongPoll API.
	/// </summary>
	/// <param name="server"> Сервер. </param>
	/// <param name="parameters"> Параметры. </param>
	/// /// <param name="jsonConverters"> JsonConverters </param>
	/// <returns> </returns>
	T CallLongPoll<T>(string server, VkParameters parameters, params JsonConverter[] jsonConverters);

	/// <summary>
	/// Вызвать ожидание событий LongPoll API.
	/// </summary>
	/// <param name="server"> Сервер. </param>
	/// <param name="parameters"> Параметры. </param>
	/// <param name="token"></param>
	/// <returns> </returns>
	Task<VkResponse> CallLongPollAsync(string server, VkParameters parameters, CancellationToken token = default);

	/// <summary>
	/// Прямой вызов LongPoll API
	/// </summary>
	/// <param name="server"> Сервер </param>
	/// <param name="parameters"> Вход. параметры LongPoll. </param>
	/// <exception cref="ArgumentException"> </exception>
	/// <returns> Ответ сервера в формате JSON. </returns>
	string InvokeLongPoll(string server, Dictionary<string, string> parameters);

	/// <summary>
	/// Прямой вызов LongPoll API
	/// </summary>
	/// <param name="server"> Сервер </param>
	/// <param name="parameters"> Вход. параметры LongPoll. </param>
	/// <exception cref="ArgumentException"> </exception>
	/// <returns> Ответ сервера в формате JSON. </returns>
	JObject InvokeLongPollExtended(string server, Dictionary<string, string> parameters);

	/// <summary>
	/// Прямой вызов LongPoll API в асинхронном режиме
	/// </summary>
	/// <param name="server"> Сервер </param>
	/// <param name="parameters"> Вход. параметры LongPoll. </param>
	/// <param name="token"></param>
	/// <exception cref="ArgumentException"> </exception>
	/// <returns> Ответ сервера в формате JSON. </returns>
	Task<string> InvokeLongPollAsync(string server, Dictionary<string, string> parameters, CancellationToken token = default);

	/// <summary>
	/// Прямой вызов LongPoll API в асинхронном режиме
	/// </summary>
	/// <param name="server"> Сервер </param>
	/// <param name="parameters"> Вход. параметры LongPoll. </param>
	/// <param name="token"></param>
	/// <exception cref="ArgumentException"> </exception>
	/// <returns> Ответ сервера в формате JSON. </returns>
	Task<JObject> InvokeLongPollExtendedAsync(string server, Dictionary<string, string> parameters, CancellationToken token = default);
}