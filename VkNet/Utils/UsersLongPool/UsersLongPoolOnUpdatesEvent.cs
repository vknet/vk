#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.UsersLongPool;

/// <summary>
/// Обёртка для UsersLongPoolUpdatesHandlerParams.OnUpdates, в которой содержится вся информация о текущем массиве событий лонгпула для пользователя.
/// </summary>
public class UsersLongPoolOnUpdatesEvent
{
	/// <summary>
	/// Обновление в событиях пользователя.
	/// </summary>
	public LongPollHistoryResponse<JObject> Response;

	/// <summary>
	/// Обработанные сообщения из Response
	/// </summary>
	public List<UserMessageEvent> Messages;
}