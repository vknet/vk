using System;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Groups
{
	/// <summary>
	/// Параметры метода <see cref="IGroupsCategory"/>.<see cref="IGroupsCategory.AddAddressAsync"/>
	/// </summary>
	[Serializable]
	public class AddAddressParams
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
		/// Заголовок адреса строка, обязательный параметр, максимальная длина 255
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Строка адреса Невский проспект, дом 28 строка, обязательный параметр, максимальная длина 255
		/// </summary>
		[JsonProperty("address")]
		public string Address { get; set; }

		/// <summary>
		/// Дополнительное описание адреса.
		/// </summary>
		/// <example>
		/// Второй этаж, налево строка, максимальная длина 400
		/// </example>
		[JsonProperty("additional_address")]
		public string AdditionalAddress { get; set; }

		/// <summary>
		/// Идентификатор  страны.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetCountriesAsync"/> положительное число,
		/// обязательный параметр, минимальное значение 1
		/// </remarks>
		[JsonProperty("country_id")]
		public ulong CountryId { get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetCitiesAsync"/> положительное число,
		/// обязательный параметр, минимальное значение 1
		/// </remarks>
		[JsonProperty("city_id")]
		public ulong CityId { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90).
		/// </summary>
		/// <remarks>
		/// Дробное число, обязательный параметр, минимальное значение -90, максимальное значение 90
		/// </remarks>
		[JsonProperty("latitude")]
		public double Latitude { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180).
		/// </summary>
		/// <remarks>
		/// Дробное число, обязательный параметр, минимальное значение -180, максимальное значение 180
		/// </remarks>
		[JsonProperty("longitude")]
		public double Longitude { get; set; }

		/// <summary>
		/// Номер телефона строка
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
		/// Идентификатор станции метро.
		/// </summary>
		/// <remarks>
		/// Для получения можно использовать <see cref="IDatabaseCategory"/>.<see cref="IDatabaseCategory.GetMetroStationsAsync"/>
		/// положительное число, минимальное значение 0
		/// </remarks>
		[JsonProperty("metro_id")]
		public ulong? MetroId { get; set; }

		/// <summary>
		/// Для типа timetable можно передать расписание в формате json.
		/// Время передается в минутах от 0 часов.
		/// Ключ по дню означает, что день рабочий. open_time, close_time - начало и конец рабочего дня. break_open_time, break_close_time —  время перерыва.
		/// </summary>
		[JsonProperty("timetable")]
		public Timetable Timetable { get; set; }

		/// <summary>
		/// Установить адрес основным. Информация об основном адресе сразу показывается в сообществе.
		/// Для получения информации об остальных адресах нужно перейти к списку адресов.
		/// </summary>
		[JsonProperty("is_main_address")]
		public bool? IsMainAddress { get; set; }
	}
}