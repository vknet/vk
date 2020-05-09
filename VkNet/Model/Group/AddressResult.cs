using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class AddressResult
	{
		/// <summary>
		///
		/// </summary>
		[JsonProperty("id")]
		public ulong Id { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("additional_address")]
		public string AdditionalAddress { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("city_id")]
		public long? CityId { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("country_id")]
		public long? CountryId { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("metro_station_id")]
		public long? MetroStationId { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("phone")]
		public string Phone { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("time_offset")]
		public long? TimeOffset { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("timetable")]
		public Timetable Timetable { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("work_info_status")]
		public string WorkInfoStatus { get; set; }
	}
}