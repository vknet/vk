using System;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Groups
{
	/// <summary>
	/// Параметры метода <see cref="IGroupsCategory"/>.<see cref="IGroupsCategoryAsync.EditAddressAsync"/>
	/// </summary>
	[Serializable]
	public class EditAddressParams
	{
		/// <summary>
		/// Идентификатор сообщества, в которое добавляется адрес.
		/// </summary>
		/// <remarks>
		/// Положительное число, обязательный параметр
		/// </remarks>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// Идентификатор адреса
		/// </summary>
		/// <remarks>
		/// Положительное число, обязательный параметр
		/// </remarks>
		[JsonProperty("address_id")]
		public ulong AddressId { get; set; }

		/// <summary>
		/// Заголовок адреса строка, максимальная длина 255
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Строка адреса
		/// </summary>
		/// <example>
		/// Невский проспект, дом 28
		/// </example>
		/// <remarks>
		/// Строка, максимальная длина 255
		/// </remarks>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		/// Дополнительное описание адреса.
		/// </summary>
		/// <example>
		/// Второй этаж, налево
		/// </example>
		/// <remarks>
		/// Строка, максимальная длина 400
		/// </remarks>
		[JsonProperty("additional_address")]
		public string AdditionalAddress { get; set; }

		/// <summary>
		/// Номер телефона
		/// </summary>
		[JsonProperty("phone")]
		public string Phone { get; set; }

		/// <summary>
		/// Тип расписания.
		/// </summary>
		[JsonProperty("work_info_status")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public ScheduleWorkInfoStatus WorkInfoStatus { get; set; }

		/// <summary>
		/// Идентификатор  страны.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetCountriesAsync"/> положительное число, минимальное значение 0
		/// </remarks>
		[JsonProperty("country_id")]
		public ulong CountryId { get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetCitiesAsync"/> положительное число, минимальное значение 0
		/// </remarks>
		[JsonProperty("city_id")]
		public ulong CityId { get; set; }

		/// <summary>
		/// Идентификатор станции метро.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetMetroStationsAsync"/> положительное число, минимальное значение 0
		/// </remarks>
		[JsonProperty("metro_id")]
		public ulong MetroId { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90). дробное число, минимальное значение -90, максимальное значение 90
		/// </summary>
		[JsonProperty("latitude")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180). дробное число, минимальное значение -180, максимальное значение 180
		/// </summary>
		[JsonProperty("longitude")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Для типа timetable можно передать расписание в формате json.
		/// </summary>
		[JsonProperty("timetable")]
		public Timetable Timetable { get; set; }

		/// <summary>
		/// Установить адрес основным. Информация об основном адресе сразу показывается в сообществе.
		/// Для получения информации об остальных адресах нужно перейти к списку адресов. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("is_main_address")]
		public bool IsMainAddress { get; set; }
	}
}