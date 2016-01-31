namespace VkNet.Model
{
    using System;

    using Utils;

    /// <summary>
    /// Информация о репостах записи.
    /// См. описание <see href="http://vk.com/dev/post"/>. Раздел reposts.
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
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Reposts FromJson(VkResponse response)
		{
			var reposts = new Reposts
			{
				Count = response["count"],
				UserReposted = response["user_reposted"]
			};

			return reposts;
		}

		#endregion
	}
}