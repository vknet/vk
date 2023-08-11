using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Базовая информация о подкасте выданная поисковиком
	/// </summary>
	[Serializable]
	public class PodcastSearchInfo
	{
		/// <summary>
		/// URL адрес подкаста
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }

		/// <summary>
		/// URL владельца подкаста
		/// </summary>
		[JsonProperty("owner_url")]
		public string OwnerUrl { get; set; }

		/// <summary>
		/// Название подкаста
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Имя владельца подкаста
		/// </summary>
		[JsonProperty("owner_name")]
		public string OwnerName { get; set; }

		/// <summary>
		/// Коллекция логотипов подкаста
		/// </summary>
		[JsonProperty("cover")]
		public Cover Covers { get; set; }	
	}
}
