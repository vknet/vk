using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода users.search
	/// </summary>
	[Serializable]
	public class UserSearchParams
	{
		/// <summary>
		/// Строка поискового запроса. Например, Вася Бабич.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Сортировка результатов.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public UserSort Sort { get; set; }

		/// <summary>
		/// Смещение относительно первого найденного пользователя для выборки определенного
		/// подмножества.
		/// </summary>
		public uint? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых пользователей. Обратите внимание — даже при
		/// использовании параметра offset для получения
		/// информации доступны только первые 1000 результатов.
		/// </summary>
		public uint? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть.
		/// </summary>
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		public int? City { get; set; }

		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public int? Country { get; set; }

		/// <summary>
		/// Название города строкой.
		/// </summary>
		public string Hometown { get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили ВУЗ.
		/// </summary>
		public int? UniversityCountry { get; set; }

		/// <summary>
		/// Идентификатор ВУЗа.
		/// </summary>
		public int? University { get; set; }

		/// <summary>
		/// Год окончания ВУЗа.
		/// </summary>
		public uint? UniversityYear { get; set; }

		/// <summary>
		/// Идентификатор факультета.
		/// </summary>
		public int? UniversityFaculty { get; set; }

		/// <summary>
		/// Идентификатор кафедры.
		/// </summary>
		public int? UniversityChair { get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		public Sex Sex { get; set; }

		/// <summary>
		/// Семейное положение.
		/// </summary>
		public MaritalStatus? Status { get; set; }

		/// <summary>
		/// Начиная с какого возраста.
		/// </summary>
		public ushort? AgeFrom { get; set; }

		/// <summary>
		/// До какого возраста.
		/// </summary>
		public ushort? AgeTo { get; set; }

		/// <summary>
		/// День рождения.
		/// </summary>
		public ushort? BirthDay { get; set; }

		/// <summary>
		/// Месяц рождения.
		/// </summary>
		public ushort? BirthMonth { get; set; }

		/// <summary>
		/// Год рождения.
		/// </summary>
		public uint? BirthYear { get; set; }

		/// <summary>
		/// <c> true </c> — только в сети, <c> false </c> — все пользователи. флаг.
		/// </summary>
		public bool? Online { get; set; }

		/// <summary>
		/// <c> true </c> — только с фотографией, <c> false </c> — все пользователи. флаг.
		/// </summary>
		public bool? HasPhoto { get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили школу.
		/// </summary>
		public int? SchoolCountry { get; set; }

		/// <summary>
		/// Идентификатор города, в котором пользователи закончили школу.
		/// </summary>
		public int? SchoolCity { get; set; }

		/// <summary>
		/// Класс в школе.
		/// </summary>
		public int? SchoolClass { get; set; }

		/// <summary>
		/// Идентификатор школы, которую закончили пользователи.
		/// </summary>
		public int? School { get; set; }

		/// <summary>
		/// Год окончания школы.
		/// </summary>
		public uint? SchoolYear { get; set; }

		/// <summary>
		/// Религиозные взгляды.
		/// </summary>
		public string Religion { get; set; }

		/// <summary>
		/// Интересы.
		/// </summary>
		public string Interests { get; set; }

		/// <summary>
		/// Название компании, в которой работают пользователи.
		/// </summary>
		public string Company { get; set; }

		/// <summary>
		/// Название должности.
		/// </summary>
		public string Position { get; set; }

		/// <summary>
		/// Идентификатор группы, среди пользователей которой необходимо проводить поиск.
		/// </summary>
		public ulong? GroupId { get; set; }

		/// <summary>
		/// Разделы среди которых нужно осуществить поиск.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public UserSection FromList { get; set; }
	}
}