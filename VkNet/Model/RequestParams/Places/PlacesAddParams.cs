using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Places Add Params
	/// </summary>
	[Serializable]
	public class PlacesAddParams
	{
		/// <summary>
		/// Название нового места
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// Географическая широта нового места, заданная в градусах (от -90 до 90)
		/// </summary>
		[JsonProperty(propertyName: "latitude")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Географическая долгота нового места, заданная в градусах (от -180 до 180)
		/// </summary>
		[JsonProperty(propertyName: "longitude")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Строка с адресом нового места (например, Невский просп. 1)
		/// </summary>
		[JsonProperty(propertyName: "address")]
		public string Address { get; set; }

		/// <summary>
		/// Идентификатор типа нового места, полученный методом places.getTypes
		/// </summary>
		[JsonProperty(propertyName: "type")]
		public ulong Type { get; set; }

		/// <summary>
		/// Идентификатор страны нового места, полученный методом places.getCountries
		/// </summary>
		[JsonProperty(propertyName: "country")]
		public ulong Country { get; set; }

		/// <summary>
		/// Идентификатор города нового места, полученный методом places.getCities
		/// </summary>
		[JsonProperty(propertyName: "city")]
		public ulong City { get; set; }
	}
}