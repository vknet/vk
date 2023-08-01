using System;
using System.Collections.Generic;

namespace VkNet.Model;

/// <summary>
/// Обновление в событиях группы.
/// <br/>
/// В обобщении можно указать тип JObject для того, чтобы избежать ошибок при десериализации.
/// <br/>
/// После чего можно воспользоваться методом GroupLongPoolHelpers.GetGroupUpdatesAndErrors. Он вернёт ошибки, если таковые имеются, но не бросит исключений.
/// </summary>
[Serializable]
public class BotsLongPollHistoryResponse<TGroupUpdate>
{
	/// <summary>
	/// Номер последнего события, начиная с которого нужно получать данные;
	/// </summary>
	public ulong Ts { get; set; }

	/// <summary>
	/// Обновления группы
	/// </summary>
	public List<TGroupUpdate> Updates { get; set; }
}

/// <inheritdoc />
[Serializable]
public class BotsLongPollHistoryResponse : BotsLongPollHistoryResponse<GroupUpdate>
{
}