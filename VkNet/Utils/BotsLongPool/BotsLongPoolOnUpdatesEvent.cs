#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPool;

/// <summary>
/// Обёртка для BotsLongPoolUpdatesProviderParams.OnUpdates, в которой содержится вся информация о текущем массиве событий лонгпула для бота в сообществе.
/// </summary>
public class BotsLongPoolOnUpdatesEvent
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