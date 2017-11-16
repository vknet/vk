using System.Runtime.Serialization;

namespace VkNet.Model
{
    using Utils;

	/// <summary>
	/// Информация о количестве комментариев к записи.
	/// См. описание http://vk.com/dev/post
	/// </summary>
	[DataContract]
	public class Comments
	{
		/// <summary>
		/// Количество комментариев к записи.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь добавить комментарий к записи.
		/// </summary>
		public bool CanPost { get; set; }

		#region Методы

		#endregion

		/// <summary>
		/// Разобрать из JSON.
		/// </summary>
		/// <param name="response">Ответ от vk.</param>
		/// <returns></returns>
		public static Comments FromJson(VkResponse response)
		{
			return new Comments
            {
                Count = response["count"],
                CanPost = response["can_post"]
            };
        }
	}
}