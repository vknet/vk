using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Школа, в которой учился пользователь.
	/// См. описание http://vk.com/dev/fields
	/// </summary>
	[Serializable]
	public class School
	{
		/// <summary>
		/// Идентификатор школы.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор страны, в которой расположена школа.
		/// </summary>
		public long? Country { get; set; }

		/// <summary>
		/// Идентификатор города, в котором расположена школа.
		/// </summary>
		public long? City { get; set; }

		/// <summary>
		/// Наименование школы.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Год начала обучения.
		/// </summary>
		public int? YearFrom { get; set; }

		/// <summary>
		/// Год окончания обучения.
		/// </summary>
		public int? YearTo { get; set; }

		/// <summary>
		/// Год выпуска.
		/// </summary>
		public int? YearGraduated { get; set; }

		/// <summary>
		/// Буква класса.
		/// </summary>
		public string Class { get; set; }

		/// <summary>
		/// Специализация класса.
		/// </summary>
		public string Speciality { get; set; }

		/// <summary>
		/// Идентификатор типа школы.
		/// </summary>
		public long? Type { get; set; }

		/// <summary>
		/// Название типа школы.
		/// </summary>
		public string TypeStr { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static School FromJson(VkResponse response)
		{
			var school = new School
			{
					Id = Utilities.GetNullableLongId(response: response[key: "id"])
					, Country = Utilities.GetNullableLongId(response: response[key: "country"])
					, City = Utilities.GetNullableLongId(response: response[key: "city"])
					, Name = response[key: "name"] ?? response[key: "title"]
					, YearFrom = response[key: "year_from"]
					, YearTo = response[key: "year_to"]
					, YearGraduated = response[key: "year_graduated"]
					, Class = response[key: "class"]
					, Speciality = response[key: "speciality"]
					, Type = response[key: "type"]
					, TypeStr = response[key: "type_str"]
			};

			return school;
		}

	#endregion
	}
}