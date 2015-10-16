using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VkNet.Model
{
	/// <summary>
	/// Новости
	/// </summary>
	public class NewsFeed
	{
		/// <summary>
		/// массив новостей для текущего пользователя;.
		/// </summary>
		public ReadOnlyCollection<NewsItem> Items
		{ get; set; }

		/// <summary>
		/// информация о пользователях, которые находятся в списке новостей;.
		/// </summary>
		public ReadOnlyCollection<User> Profiles
		{ get; set; }

		/// <summary>
		/// информация о группах, которые находятся в списке новостей;.
		/// </summary>
		public ReadOnlyCollection<Group> Groups
		{ get; set; }

		/// <summary>
		/// содержит offset, который необходимо передать, для того, чтобы получить следующую часть новостей;.
		/// </summary>
		public ulong? NewOffset
		{ get; set; }

		/// <summary>
		/// содержит start_from, который необходимо передать, для того, чтобы получить следующую часть новостей. Позволяет избавиться от дубликатов, которые могут возникнуть при появлении новых новостей между вызовами этого метода..
		/// </summary>
		public string NextFrom
		{ get; set; }
	}
}
