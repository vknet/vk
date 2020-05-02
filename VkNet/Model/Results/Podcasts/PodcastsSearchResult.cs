using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода Podcasts.search
	/// </summary>
	[Serializable]
	public class PodcastsSearchResult
	{
		/// <summary>
		/// Подкасты.
		/// </summary>
		[JsonProperty("podcasts")]
		public ReadOnlyCollection<Podcast> Podcasts { get; set; }

		/// <summary>
		/// Эпизоды.
		/// </summary>
		[JsonProperty("episodes")]
		public ReadOnlyCollection<Podcast> Episodes { get; set; }

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