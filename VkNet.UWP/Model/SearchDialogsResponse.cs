using VkNet.Utils;

namespace VkNet.Model
{
	using System.Collections.Generic;

	/// <summary>
	/// Ответ при поиске диалогов по строке поиска.
	/// См. описание <see href="http://vk.com/dev/messages.searchDialogs"/>.
	/// </summary>
	public class SearchDialogsResponse
	{
		/// <summary>
		/// Список найденных пользователей.
		/// </summary>
		public IList<User> Users { get; set; }

		/// <summary>
		/// Список найденных бесед.
		/// </summary>
		public IList<Chat> Chats { get; set; }

		/// <summary>
		/// Список найденных сообществ.
		/// </summary>
		public IList<Group> Groups { get; set; }

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
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
				string type = record["type"];
				switch (type)
				{
					case "profile":
						{
							result.Users.Add(record);
							break;
						}
					case "chat":
						{
							result.Chats.Add(record);
							break;
						}
					case "email":
						{
							// TODO: Add email support.
							continue;
						}
					case "group":
						{
							result.Groups.Add(record);
							break;
						}
					default:
						{
							break;
						}
				}
			}

			return result;
		}

		#endregion
	}
}