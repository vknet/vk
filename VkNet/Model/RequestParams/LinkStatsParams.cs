using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса LinkStats
	/// </summary>
	[Serializable]
	public class LinkStatsParams
	{
		/// <summary>
		/// Сокращенная ссылка (часть URL после "vk.cc/").
		/// </summary>
		[JsonProperty(propertyName: "key")]
		public string Key { get; set; }

		/// <summary>
		/// Ключ доступа к приватной статистике ссылки.
		/// </summary>
		[JsonProperty(propertyName: "access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// Единица времени для подсчета статистики.
		/// </summary>
		[JsonProperty(propertyName: "interval")]
		public LinkStatInterval Interval { get; set; }

		/// <summary>
		/// Длительность периода для получения статистики в выбранных единицах (из
		/// параметра interval).
		/// </summary>
		[JsonProperty(propertyName: "intervals_count")]
		public uint IntervalsCount { get; set; }

		/// <summary>
		/// 1 — возвращать расширенную статистику (пол/возраст/страна/город),
		/// 0 — возвращать только количество переходов.
		/// </summary>
		[JsonProperty(propertyName: "extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(LinkStatsParams p)
		{
			return new VkParameters
			{
					{ "key", p.Key }
					, { "access_key", p.AccessKey }
					, { "interval", p.Interval }
					, { "intervals_count", p.IntervalsCount }
					, { "extended", p.Extended }
			};
		}
	}
}