using System;
using System.Collections.Generic;

namespace VkNet.Model
{
	/// <summary>
	/// Новости
	/// </summary>
	[Serializable]
	public class NewsFeed
	{
		/// <summary>
		/// Массив новостей для текущего пользователя.
		/// </summary>
		public IEnumerable<NewsItem> Items { get; set; }

		/// <summary>
		/// Информация о пользователях, которые находятся в списке новостей.
		/// </summary>
		public IEnumerable<User> Profiles { get; set; }

		/// <summary>
		/// Информация о группах, которые находятся в списке новостей.
		/// </summary>
		public IEnumerable<Group> Groups { get; set; }

		/// <summary>
		/// Содержит offset, который необходимо передать, для того, чтобы получить
		/// следующую часть новостей.
		/// </summary>
		public ulong? NewOffset { get; set; }

		/// <summary>
		/// Содержит start_from, который необходимо передать, для того, чтобы получить
		/// следующую часть новостей. Позволяет
		/// избавиться от дубликатов, которые могут возникнуть при появлении новых новостей
		/// между вызовами этого метода.
		/// </summary>
		public string NextFrom { get; set; }
	}
}