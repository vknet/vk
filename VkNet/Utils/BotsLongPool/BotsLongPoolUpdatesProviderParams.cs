#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPool;

/// <summary>
/// Параметры для конструктора BotsLongPoolUpdatesProvider
/// </summary>
public class BotsLongPoolUpdatesProviderParams
{
	/// <summary>
	/// ID вашего бота (группы)
	/// </summary>
	public ulong GroupId;

	/// <summary>
	/// Номер, с которого начинать получать события.
	/// Рекомендуется помещать сюда значение из response.Ts в функции OnUpdates.
	/// </summary>
	public string? Ts = null;

	/// <summary>
	/// Авторизованный экземпляр VKApi.
	/// </summary>
	public IVkApi Api;

	/// <summary>
	/// Эта функция вызывается при критических ошибках в лонгпуле (например JsonSerializationException)
	/// </summary>
	public Action<System.Exception>? OnException = null;

	/// <summary>
	/// Ошибки при получении конкретного события из response.
	/// Первый параметр - response, второй - индекс события, третий - ошибка.
	/// </summary>
	public Action<BotsLongPollHistoryResponse<JObject>, int, System.Exception>? OnGetGroupUpdateException = null;

	/// <summary>
	/// Функция, в которую будут отправлены полученные события. Первый параметр - response, Второй - updates.
	/// </summary>
	public Action<BotsLongPollHistoryResponse<JObject>, List<GroupUpdate>>? OnUpdates = null;

	/// <summary>
	/// Функция, в которую будут отправлены ошибки связанные с интернетом или с доступом к ВКонтакте
	/// </summary>
	public Action<System.Exception>? OnHttpOrServerError = null;

	/// <summary>
	/// Функция, в которую будут отправлены незначительные или временные ошибки (например - SocketException)
	/// </summary>
	public Action<System.Exception>? OnWarn = null;

	/// <summary>
	/// / Функция, которая возвращает true, если работа лонгпула должна быть приостановлена
	/// Понадобится, когда вы безопасно завершаете работу приложения или просто захотите временно остановить бота и не потерять последние события.
	/// </summary>
	public Func<bool>? GetPause = null;
}