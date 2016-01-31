﻿using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Предложения новостей.
	/// </summary>
	public class NewsSuggestions
	{
		/// <summary>
		/// Предложения по пользователям.
		/// </summary>
		public List<User> Users
		{ get; set; }

		/// <summary>
		/// Предложения по группам.
		/// </summary>
		public List<Group> Groups
		{ get; set; }


		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsSuggestions FromJson(VkResponse response)
		{
			var newsSuggestions = new NewsSuggestions
			{
				Users = new List<User>(),
				Groups = new List<Group>()
			};
			VkResponseArray result = response;
			foreach (var item in result)
			{

				switch (item["type"].ToString())
				{
					case "page":
					case "group":
						{
							Group @group = item;
							newsSuggestions.Groups.Add(@group);
						}
						break;
					case "profile":
						{
							User user = item;
							newsSuggestions.Users.Add(user);
						}
						break;
					default:
						{
							throw new System.Exception(string.Format("Типа '{0}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/vknet/vk/issues", item["type"]));
						}
				}
			}
			return newsSuggestions;
		}
	}
}
