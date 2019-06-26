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
		[JsonProperty("id")]
		public ulong Id { get; set; }

		[JsonProperty("additional_address")]
		public string AdditionalAddress { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("city_id")]
		public long? CityId { get; set; }

		[JsonProperty("country_id")]
		public long? CountryId { get; set; }

		[JsonProperty("latitude")]
		public double? Latitude { get; set; }

		[JsonProperty("longitude")]
		public double? Longitude { get; set; }

		[JsonProperty("metro_station_id")]
		public long? MetroStationId { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("time_offset")]
		public long? TimeOffset { get; set; }

		[JsonProperty("timetable")]
		public Timetable Timetable { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("work_info_status")]
		public string WorkInfoStatus { get; set; }
	}
}