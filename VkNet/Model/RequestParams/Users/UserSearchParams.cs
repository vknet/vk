﻿using System.Web;

namespace VkNet.Model.RequestParams
{
	using Enums;
	using Enums.Filters;
	using Enums.SafetyEnums;

	using Utils;

	/// <summary>
	/// Параметры метода users.search
	/// </summary>
	public struct UserSearchParams
	{
		/// <summary>
		/// Параметры метода users.search.
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public UserSearchParams(bool gag = true)
		{
			Sort = UserSort.ByPopularity;
			Offset = 0;
			Count = 20;
			Sex = Sex.Unknown;
			Query = null;
			Fields = null;
			City = null;
			Country = null;
			Hometown = null;
			UniversityCountry = null;
			University = null;
			UniversityYear = null;
			UniversityFaculty = null;
			UniversityChair = null;
			Status = null;
			AgeFrom = null;
			AgeTo = null;
			BirthDay = null;
			BirthMonth = null;
			BirthYear = null;
			Online = false;
			HasPhoto = false;
			SchoolCountry = null;
			SchoolCity = null;
			SchoolClass = null;
			School = null;
			SchoolYear = null;
			Religion = null;
			Interests = null;
			Company = null;
			Position = null;
			GroupId = null;
			FromList = null;
		}

		/// <summary>
		/// Строка поискового запроса. Например, Вася Бабич.
		/// </summary>
		public string Query
		{ get; set; }

		/// <summary>
		/// Сортировка результатов.
		/// </summary>
		public UserSort Sort
		{ get; set; }

		/// <summary>
		/// Смещение относительно первого найденного пользователя для выборки определенного подмножества.
		/// </summary>
		public uint? Offset
		{ get; set; }

		/// <summary>
		/// Количество возвращаемых пользователей. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов.
		/// </summary>
		public uint? Count
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть.
		/// </summary>
		public ProfileFields Fields
		{ get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		public int? City
		{ get; set; }

		/// <summary>
		/// Идентификатор страны.
		/// </summary>
		public int? Country
		{ get; set; }

		/// <summary>
		/// Название города строкой.
		/// </summary>
		public string Hometown
		{ get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили ВУЗ.
		/// </summary>
		public int? UniversityCountry
		{ get; set; }

		/// <summary>
		/// Идентификатор ВУЗа.
		/// </summary>
		public int? University
		{ get; set; }

		/// <summary>
		/// Год окончания ВУЗа.
		/// </summary>
		public uint? UniversityYear
		{ get; set; }

		/// <summary>
		/// Идентификатор факультета.
		/// </summary>
		public int? UniversityFaculty
		{ get; set; }

		/// <summary>
		/// Идентификатор кафедры.
		/// </summary>
		public int? UniversityChair
		{ get; set; }

		/// <summary>
		/// Пол.
		/// </summary>
		public Sex Sex
		{ get; set; }

		/// <summary>
		/// Семейное положение.
		/// </summary>
		public MaritalStatus? Status
		{ get; set; }

		/// <summary>
		/// Начиная с какого возраста.
		/// </summary>
		public ushort? AgeFrom
		{ get; set; }

		/// <summary>
		/// До какого возраста.
		/// </summary>
		public ushort? AgeTo
		{ get; set; }

		/// <summary>
		/// День рождения.
		/// </summary>
		public ushort? BirthDay
		{ get; set; }

		/// <summary>
		/// Месяц рождения.
		/// </summary>
		public ushort? BirthMonth
		{ get; set; }

		/// <summary>
		/// Год рождения.
		/// </summary>
		public uint? BirthYear
		{ get; set; }

		/// <summary>
		/// <c>true</c> — только в сети, <c>false</c> — все пользователи. флаг.
		/// </summary>
		public bool? Online
		{ get; set; }

		/// <summary>
		/// <c>true</c> — только с фотографией, <c>false</c> — все пользователи. флаг.
		/// </summary>
		public bool? HasPhoto
		{ get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили школу.
		/// </summary>
		public int? SchoolCountry
		{ get; set; }

		/// <summary>
		/// Идентификатор города, в котором пользователи закончили школу.
		/// </summary>
		public int? SchoolCity
		{ get; set; }

		/// <summary>
		/// Класс в школе.
		/// </summary>
		public int? SchoolClass
		{ get; set; }

		/// <summary>
		/// Идентификатор школы, которую закончили пользователи.
		/// </summary>
		public int? School
		{ get; set; }

		/// <summary>
		/// Год окончания школы.
		/// </summary>
		public uint? SchoolYear
		{ get; set; }

		/// <summary>
		/// Религиозные взгляды.
		/// </summary>
		public string Religion
		{ get; set; }

		/// <summary>
		/// Интересы.
		/// </summary>
		public string Interests
		{ get; set; }

		/// <summary>
		/// Название компании, в которой работают пользователи.
		/// </summary>
		public string Company
		{ get; set; }

		/// <summary>
		/// Название должности.
		/// </summary>
		public string Position
		{ get; set; }

		/// <summary>
		/// Идентификатор группы, среди пользователей которой необходимо проводить поиск.
		/// </summary>
		public ulong? GroupId
		{ get; set; }

		/// <summary>
		/// Разделы среди которых нужно осуществить поиск.
		/// </summary>
		public UserSection FromList
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(UserSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "q", HttpUtility.HtmlEncode(p.Query) },
				{ "sort", p.Sort },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "fields", p.Fields },
				{ "city", p.City },
				{ "country", p.Country },
				{ "hometown", HttpUtility.HtmlEncode(p.Hometown) },
				{ "university_country", p.UniversityCountry },
				{ "university", p.University },
				{ "university_year", p.UniversityYear },
				{ "university_faculty", p.UniversityFaculty },
				{ "university_chair", p.UniversityChair },
				{ "sex", p.Sex },
				{ "status", p.Status },
				{ "age_from", p.AgeFrom },
				{ "age_to", p.AgeTo },
				{ "birth_day", p.BirthDay },
				{ "birth_month", p.BirthMonth },
				{ "birth_year", p.BirthYear },
				{ "online", p.Online },
				{ "has_photo", p.HasPhoto },
				{ "school_country", p.SchoolCountry },
				{ "school_city", p.SchoolCity },
				{ "school_class", p.SchoolClass },
				{ "school", p.School },
				{ "school_year", p.SchoolYear },
				{ "religion", HttpUtility.HtmlEncode(p.Religion) },
				{ "interests", HttpUtility.HtmlEncode(p.Interests) },
				{ "company", HttpUtility.HtmlEncode(p.Company) },
				{ "position", HttpUtility.HtmlEncode(p.Position) },
				{ "group_id", p.GroupId },
				{ "from_list", p.FromList }
			};

			return parameters;
		}
	}
}