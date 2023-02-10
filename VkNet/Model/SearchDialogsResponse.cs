using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Ответ при поиске диалогов по строке поиска.
/// См. описание http://vk.com/dev/messages.searchDialogs
/// </summary>
[Serializable]
public class SearchDialogsResponse
{
	/// <summary>
	/// Список найденных пользователей.
	/// </summary>
	[JsonProperty("profiles")]
	public IList<User> Users { get; set; }

	/// <summary>
	/// Список найденных бесед.
	/// </summary>
	[JsonProperty("chats")]
	public IList<Chat> Chats { get; set; }

	/// <summary>
	/// Список найденных сообществ.
	/// </summary>
	[JsonProperty("groups")]
	public IList<Group> Groups { get; set; }

	#region Методы

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static SearchDialogsResponse FromJson(VkResponse response)
	{
		var result = new SearchDialogsResponse
		{
			Users = new List<User>(),
			Chats = new List<Chat>(),
			Groups = new List<Group>()
		};

		VkResponseArray responseArray = response;

		foreach (var record in responseArray)
		{
			string type = record[key: "type"];

			switch (type)
			{
				case "profile":

				{
					result.Users.Add(item: record);

					break;
				}

				case "chat":

				{
					result.Chats.Add(item: record);

					break;
				}

				case "email":

				{
					// TODO: Add email support.
					continue;
				}

				case "group":

				{
					result.Groups.Add(item: record);

					break;
				}
			}
		}

		return result;
	}

	#endregion
}