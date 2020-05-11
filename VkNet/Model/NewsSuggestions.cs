using System;
using System.Collections.Generic;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Предложения новостей.
	/// </summary>
	[Serializable]
	public class NewsSuggestions
	{
		/// <summary>
		/// Предложения по пользователям.
		/// </summary>
		public List<User> Users { get; set; }

		/// <summary>
		/// Предложения по группам.
		/// </summary>
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsSuggestions FromJson(VkResponse response)
		{
			var newsSuggestions = new NewsSuggestions
			{
					Users = new List<User>()
					, Groups = new List<Group>()
			};

			VkResponseArray result = response;

			foreach (var item in result)
			{
				switch (item[key: "type"].ToString())
				{
					case "page":
					case "group":

					{
						Group group = item;
						newsSuggestions.Groups.Add(item: group);
					}

						break;
					case "profile":

					{
						User user = item;
						newsSuggestions.Users.Add(item: user);
					}

						break;
					default:

					{
						throw new VkApiException(message: string.Format(format:
								"Типа '{0}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/vknet/vk/issues"
								, arg0: item[key: "type"]));
					}
				}
			}

			return newsSuggestions;
		}
	}
}