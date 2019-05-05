using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Abstractions
{
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
		/// <returns> </returns>
		VkResponse CallLongPoll(string server, VkParameters parameters);

		/// <summary>
		/// Вызвать ожидание событий LongPoll API.
		/// </summary>
		/// <param name="server"> Сервер. </param>
		/// <param name="parameters"> Параметры. </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns> </returns>
		Task<VkResponse> CallLongPollAsync(string server, VkParameters parameters, CancellationToken cancellationToken = default);

		/// <summary>
		/// Прямой вызов LongPoll API
		/// </summary>
		/// <param name="server"> Сервер </param>
		/// <param name="parameters"> Вход. параметры LongPoll. </param>
		/// <exception cref="ArgumentException"> </exception>
		/// <returns> Ответ сервера в формате JSON. </returns>
		string InvokeLongPoll(string server, Dictionary<string, string> parameters);

		/// <summary>
		/// Прямой вызов LongPoll API в асинхронном режиме
		/// </summary>
		/// <param name="server"> Сервер </param>
		/// <param name="parameters"> Вход. параметры LongPoll. </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <exception cref="ArgumentException"> </exception>
		/// <returns> Ответ сервера в формате JSON. </returns>
		Task<string> InvokeLongPollAsync(string server, Dictionary<string, string> parameters, CancellationToken cancellationToken = default);
	}
}