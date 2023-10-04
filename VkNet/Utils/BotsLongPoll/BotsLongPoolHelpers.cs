#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPoll;

/// <summary>
/// Методы для обработки событий лонгпула у сообществ.
/// </summary>
public static class BotsLongPollHelpers
{
	/// <summary>
	/// Метод для получения обновлений группы из массива JObject, который не бросает исключений, но вместе с обновлениями возвращает ошибки при десериализации, если таковые имеются.
	/// </summary>
	/// <param name="jObjectUpdates">Этот массив получается из метода api.Groups.GetBotsLongPollHistory&lt;BotsLongPollHistoryResponse&lt;JObject&gt;&gt;().Updates</param>
	/// <returns>
	/// Возвращает список обновлений группы
	/// </returns>
	public static List<GroupUpdateEvent> GetGroupUpdateEvents(IEnumerable<JObject> jObjectUpdates)
	{
		var updates = new List<GroupUpdateEvent>();

		foreach (var jObjectUpdate in jObjectUpdates)
		{
			try
			{
				var update = jObjectUpdate.ToObject<GroupUpdate>();

				updates.Add(new()
				{
					Update = update,
					RawUpdate = jObjectUpdate
				});
			}
			catch (System.Exception ex)
			{
				updates.Add(new()
				{
					Exception = ex,
					RawUpdate = jObjectUpdate
				});
			}
		}

		return updates;
	}
}

/// <summary>
/// Методы для обработки событий лонгпула у сообществ.
/// </summary>
[Obsolete(ObsoleteText.ObsoleteLongPool, true)]
public static class BotsLongPoolHelpers {}