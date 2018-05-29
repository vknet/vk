using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент пользовательского списка новостей
	/// </summary>
	[Serializable]
	public class NewsUserListItem
	{
		/// <summary>
		/// Идентификатор списка.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название списка, заданное пользователем.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Отключены ли копии постов;
		/// </summary>
		public bool? NoReposts { get; set; }

		/// <summary>
		/// Идентификаторы пользователей и сообществ, включенных в список.
		/// </summary>
		public IEnumerable<long> SourceIds { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsUserListItem FromJson(VkResponse response)
		{
			var newsUserListItem = new NewsUserListItem
			{
					Id = response[key: "id"]
					, Title = response[key: "title"]
					, NoReposts = response[key: "no_reposts"]
			};

			VkResponseArray sourceIds = response[key: "source_ids"];

			if (sourceIds.Count == 0)
			{
				newsUserListItem.SourceIds = new List<long>();
			} else
			{
				newsUserListItem.SourceIds = sourceIds.ToReadOnlyCollectionOf<long>(selector: x => x);
			}

			return newsUserListItem;
		}
	}
}