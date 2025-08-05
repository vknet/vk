#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPoll;

/// <summary>
/// Обёртка для BotsLongPollUpdatesProviderParams.OnUpdates, в которой содержится вся информация о текущем массиве событий лонгпула для бота в сообществе.
/// </summary>
public class BotsLongPollOnUpdatesEvent
{
	/// <summary>
	/// Обновление в событиях группы.
	/// </summary>
	public BotsLongPollHistoryResponse<JObject> Response;

	/// <summary>
	/// Обработанные обновления из Response
	/// </summary>
	public List<GroupUpdateEvent> Updates;
}

/// <summary>
/// Обёртка для BotsLongPollUpdatesProviderParams.OnUpdates, в которой содержится вся информация о текущем массиве событий лонгпула для бота в сообществе.
/// </summary>
[Obsolete(ObsoleteText.ObsoleteLongPool, true)]
public static class BotsLongPoolOnUpdatesEvent {}