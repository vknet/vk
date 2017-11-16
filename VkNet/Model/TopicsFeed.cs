using System.Collections.ObjectModel;

namespace VkNet.Model
{
	/// <summary>
	/// Новости
	/// </summary>
	public class TopicsFeed
	{
        /// <summary>
		/// Количество.
		/// </summary>
		public int Count { get; set; }

        /// <summary>
        /// Массив комментариев.
        /// </summary>
        public ReadOnlyCollection<Comment> Items
		{ get; set; }

		/// <summary>
		/// Информация о пользователях, которые находятся в списке комментариев.
		/// </summary>
		public ReadOnlyCollection<User> Profiles
		{ get; set; }

        /// <summary>
        /// Информация о группах, которые находятся в списке комментариев.
        /// </summary>
        public ReadOnlyCollection<Group> Groups
		{ get; set; }
		
	}
}
