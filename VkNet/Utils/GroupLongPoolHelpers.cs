#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils;

/// <summary>
/// Методы для обработки событий лонгпула у сообществ.
/// </summary>
public static class GroupLongPoolHelpers
{

	/// <summary>
	/// Метод для получения обновлений группы из массива JObject, который не бросает исключений, но вместе с обновлениями возвращает ошибки при десериализации, если таковые имеются.
	/// </summary>
	/// <param name="jObjectUpdates">Этот массив получается из метода api.Groups.GetBotsLongPollHistory&lt;BotsLongPollHistoryResponse&lt;JObject&gt;&gt;().Updates</param>
	/// <returns>
	/// Возвращает список обновлений группы
	/// </returns>
	public static List<(GroupUpdate? Update, System.Exception? Exception)> GetGroupUpdatesAndErrors(List<JObject> jObjectUpdates)
	{
		var updates = new List<(GroupUpdate? Update, System.Exception? Exception)>();

		foreach (var jObjectUpdate in jObjectUpdates)
		{
			try
			{
				var update = jObjectUpdate.ToObject<GroupUpdate>();
				updates.Add((Update: update, Exception: null));
			}
			catch (System.Exception ex)
			{
				updates.Add((Update: null, Exception: ex));
			}
		}

		return updates;
	}
}