using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о репостах записи.
	/// См. описание http://vk.com/dev/post
	/// </summary>
	[Serializable]
	public class Reposts
	{
		/// <summary>
		/// Число пользователей, скопировавших запись.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Наличие репоста от текущего пользователя .
		/// </summary>
		public bool UserReposted { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Reposts FromJson(VkResponse response)
		{
			var reposts = new Reposts
			{
					Count = response[key: "count"]
					, UserReposted = response[key: "user_reposted"]
			};

			return reposts;
		}

	#endregion
	}
}