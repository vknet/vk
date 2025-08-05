using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат метода Podcasts.search
/// </summary>
[Serializable]
public class PodcastsSearchResult
{
	/// <summary>
	/// Количество найденных подкастов
	/// </summary>
	[JsonProperty("results_total")]
	public ulong ResultsTotal { get; set; }
	/// <summary>
	/// Информация о подкасте, выданная поиском
	/// </summary>
	[JsonProperty("podcasts")]
	public ReadOnlyCollection<PodcastSearchInfo> Podcasts { get; set; }
}