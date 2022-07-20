using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.GroupUpdate;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ на запрос wall.getComment
	/// </summary>
	[Serializable]
	public class WallGetCommentResult
    {
		/// <summary>
		/// Объект комментария
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<WallReply> Comment { get; set; }

		/// <summary>
		/// Массив пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Массив групп
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }

	}
}
