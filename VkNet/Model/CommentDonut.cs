using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о VK Donut в объекте комментария.
	/// </summary>
	[Serializable]
	public class CommentDonut
	{
		/// <summary>
		/// Является ли комментатор подписчиком VK Donut
		/// </summary>
		[JsonProperty("is_don")]
		public bool IsDon { get; set; }

		/// <summary>
		/// Заглушка для пользователей, которые не оформили подписку VK Donut.
		/// Отображается вместо содержимого записи.
		/// </summary>
		[JsonProperty("placeholder")]
		public string Placeholder { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CommentDonut FromJson(VkResponse response)
		{
			return new CommentDonut
			{
				IsDon = response["is_don"],
				Placeholder = response["placeholder"]
			};
		}
	}
}
