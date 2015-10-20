using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.Users
{
	/// <summary>
	/// Параметры метода users.search
	/// </summary>
	public class UserSearchParams
	{
		/// <summary>
		/// Параметры метода users.search.
		/// </summary>
		public UserSearchParams()
		{
			Sort = UserSort.ByPopularity;
			Offset = 0;
			Count = 20;
			Sex = Sex.Unknown;
		}

		/// <summary>
		/// Строка поискового запроса. Например, Вася Бабич. строка.
		/// </summary>
		public string Query
		{ get; set; }

		/// <summary>
		/// Сортировка результатов.
		/// </summary>
		public UserSort Sort
		{ get; set; }

		/// <summary>
		/// Смещение относительно первого найденного пользователя для выборки определенного подмножества. положительное число.
		/// </summary>
		public uint Offset
		{ get; set; }

		/// <summary>
		/// Количество возвращаемых пользователей. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов. положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public uint Count
		{ get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. список строк, разделенных через запятую.
		/// </summary>
		public ProfileFields Fields
		{ get; set; }

		/// <summary>
		/// Идентификатор города. положительное число.
		/// </summary>
		public int? City
		{ get; set; }

		/// <summary>
		/// Идентификатор страны. положительное число.
		/// </summary>
		public int? Country
		{ get; set; }

		/// <summary>
		/// Название города строкой. строка.
		/// </summary>
		public string Hometown
		{ get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили ВУЗ. положительное число.
		/// </summary>
		public int? UniversityCountry
		{ get; set; }

		/// <summary>
		/// Идентификатор ВУЗа. положительное число.
		/// </summary>
		public int? University
		{ get; set; }

		/// <summary>
		/// Год окончания ВУЗа. положительное число.
		/// </summary>
		public uint? UniversityYear
		{ get; set; }

		/// <summary>
		/// Идентификатор факультета. положительное число.
		/// </summary>
		public int? UniversityFaculty
		{ get; set; }

		/// <summary>
		/// Идентификатор кафедры. положительное число.
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
		public MaritalStatus Status
		{ get; set; }

		/// <summary>
		/// Начиная с какого возраста. положительное число.
		/// </summary>
		public ushort? AgeFrom
		{ get; set; }

		/// <summary>
		/// До какого возраста. положительное число.
		/// </summary>
		public ushort? AgeTo
		{ get; set; }

		/// <summary>
		/// День рождения. положительное число.
		/// </summary>
		public ushort? BirthDay
		{ get; set; }

		/// <summary>
		/// Месяц рождения. положительное число.
		/// </summary>
		public ushort? BirthMonth
		{ get; set; }

		/// <summary>
		/// Год рождения. положительное число.
		/// </summary>
		public uint? BirthYear
		{ get; set; }

		/// <summary>
		/// 1 — только в сети, 0 — все пользователи. флаг.
		/// </summary>
		public bool Online
		{ get; set; }

		/// <summary>
		/// 1 — только с фотографией, 0 — все пользователи. флаг.
		/// </summary>
		public bool HasPhoto
		{ get; set; }

		/// <summary>
		/// Идентификатор страны, в которой пользователи закончили школу. положительное число.
		/// </summary>
		public int? SchoolCountry
		{ get; set; }

		/// <summary>
		/// Идентификатор города, в котором пользователи закончили школу. положительное число.
		/// </summary>
		public int? SchoolCity
		{ get; set; }

		/// <summary>
		/// Класс в школе. положительное число.
		/// </summary>
		public int? SchoolClass
		{ get; set; }

		/// <summary>
		/// Идентификатор школы, которую закончили пользователи. положительное число.
		/// </summary>
		public int? School
		{ get; set; }

		/// <summary>
		/// Год окончания школы. положительное число.
		/// </summary>
		public uint? SchoolYear
		{ get; set; }

		/// <summary>
		/// Религиозные взгляды. строка.
		/// </summary>
		public string Religion
		{ get; set; }

		/// <summary>
		/// Интересы. строка.
		/// </summary>
		public string Interests
		{ get; set; }

		/// <summary>
		/// Название компании, в которой работают пользователи. строка.
		/// </summary>
		public string Company
		{ get; set; }

		/// <summary>
		/// Название должности. строка.
		/// </summary>
		public string Position
		{ get; set; }

		/// <summary>
		/// Идентификатор группы, среди пользователей которой необходимо проводить поиск. положительное число.
		/// </summary>
		public ulong? GroupId
		{ get; set; }

		/// <summary>
		/// Разделы среди которых нужно осуществить поиск. список строк, разделенных через запятую.
		/// </summary>
		public UserSection FromList
		{ get; set; }

	}
}
