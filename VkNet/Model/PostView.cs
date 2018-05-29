using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о просмотрах записи.
	/// </summary>
	[Serializable]
	public class PostView
	{
		/// <summary>
		/// Число просмотров записи.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PostView FromJson(VkResponse response)
		{
			return new PostView
			{
					Count = response[key: "count"]
			};
		}
	}
}