using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о месте, в котором была сделана запись.
	/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />
	/// и http://vk.com/dev/fields_groups
	/// </summary>
	[Serializable]
	public class Place
	{
		/// <summary>
		/// Идентификатор места.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Название места.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Географическая широта, заданная в градусах (от -90 до 90).
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота, заданная в градусах (от -90 до 90).
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// Идентификатор типа места, информацию о котором можно получить с помощью метода
		/// DatabaseCategory.GetPlaceTypes
		/// </summary>
		public long? TypeId { get; set; }

		/// <summary>
		/// Идентификатор страны, название которой можно получить с помощью метода
		/// DatabaseCategory.GetCountriesById
		/// </summary>
		public long? CountryId { get; set; }

		/// <summary>
		/// Идентификатор города, название которого можно получить с помощью метода
		/// DatabaseCategory.GetCitiesById
		/// </summary>
		public long? CityId { get; set; }

		/// <summary>
		/// Строка с указанием адреса места в городе.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Данный параметр указывается, если местоположение является прикреплённой картой.
		/// </summary>
		public bool? ShowMap { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Place FromJson(VkResponse response)
		{
			var place = new Place
			{
					Id = response[key: "place_id"] ?? response[key: "id"]
					, Title = response[key: "title"]
					, Latitude = response[key: "latitude"]
					, Longitude = response[key: "longitude"]
					, TypeId = response[key: "type"]
					, CountryId = response[key: "country_id"]
					, CityId = response[key: "city_id"]
					, Address = response[key: "address"]
					, ShowMap = response[key: "showmap"]
					, Country = response[key: "country"]
					, // установлено экcпериментальным путем
					City = response[key: "city"] // установлено экcпериментальным путем
			};

			return place;
		}

	#endregion

	#region Поля, установленные экспериментально

		/// <summary>
		/// Страна, в которой находится место.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Город, в котором находится место.
		/// </summary>
		public string City { get; set; }

	#endregion
	}
}