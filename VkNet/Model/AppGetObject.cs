using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
	/// Результат выполнения запроса получения приложений
	/// </summary>
    public class AppGetObject
    {
        /// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		public ulong TotalCount { get; set; }

        /// <summary>
        /// Приложения.
        /// </summary>
        public VkCollection<App> Apps { get; set; }

        /// <summary>
        /// Друзья.
        /// </summary>
        public VkCollection<User> Friends { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static AppGetObject FromJson(VkResponse response)
        {
            AppGetObject appGetObject;
            if (response.ContainsKey("items"))
            {
                appGetObject = new AppGetObject
                {
                    TotalCount = response["count"],
                    Apps = response["items"].ToVkCollectionOf<App>(r => r),
                    Friends = response["profiles"].ToVkCollectionOf<User>(r => r)
                };
            } else
            {
                appGetObject = new AppGetObject
                {
                    TotalCount = response["count"],
                    Apps = response["items"].ToVkCollectionOf<App>(r => r)
                };
            }

            return appGetObject;
        }
    }
}