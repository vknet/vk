using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат вызова метода <see cref="VkNet.Abstractions.IAccountCategory.GetBanned"/>
	/// </summary>
	[Serializable]
	public class AccountGetBannedResult
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>.
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Посты.
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<long> Items { get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }
	}
}