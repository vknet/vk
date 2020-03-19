using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о лайках к записи.
	/// См. описание http://vk.com/dev/post
	/// </summary>
	[Serializable]
	public class Likes
	{
		/// <summary>
		/// Число пользователей, которым понравилась запись.
		/// </summary>
		[JsonProperty("count")]
		public int Count { get; set; }

		/// <summary>
		/// Признак понравилась ли запись текущему пользователю.
		/// </summary>
		[JsonProperty("user_likes")]
		public bool UserLikes { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь поставить отметку "Мне нравится".
		/// </summary>
		[JsonProperty("can_like")]
		public bool CanLike { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь сделать репост записи (опубликовать у
		/// себя запись).
		/// </summary>
		[JsonProperty("can_publish")]
		public bool? CanPublish { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Likes FromJson(VkResponse response)
		{
			var likes = new Likes
			{
					Count = response[key: "count"]
					, UserLikes = response[key: "user_likes"]
					, CanLike = response[key: "can_like"]
					, CanPublish = response[key: "can_publish"]
			};

			return likes;
		}

	#endregion
	}
}