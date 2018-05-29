using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о высшем учебном заведении пользователя.
	/// См. описание http://vk.com/dev/fields
	/// </summary>
	[Serializable]
	public class Education
	{
		/// <summary>
		/// Идентификатор университета.
		/// </summary>
		public long? UniversityId { get; set; }

		/// <summary>
		/// Название ВУЗа.
		/// </summary>
		public string UniversityName { get; set; }

		/// <summary>
		/// Идентификатор факультета.
		/// </summary>
		public long? FacultyId { get; set; }

		/// <summary>
		/// Название факультета.
		/// </summary>
		public string FacultyName { get; set; }

		/// <summary>
		/// Год окончания.
		/// </summary>
		public int? Graduation { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Education FromJson(VkResponse response)
		{
			if (response[key: "university"] == null || response[key: "university"].ToString() == "0")
			{
				return null;
			}

			var education = new Education
			{
					UniversityId = Utilities.GetNullableLongId(response: response[key: "university"])
					, UniversityName = response[key: "university_name"]
					, FacultyId = Utilities.GetNullableLongId(response: response[key: "faculty"])
					, FacultyName = response[key: "faculty_name"]
					, Graduation = (int?) Utilities.GetNullableLongId(response: response[key: "graduation"])
			};

			if (education.UniversityId.HasValue && education.UniversityId == 0)
			{
				education.UniversityId = null;
			}

			if (education.FacultyId.HasValue && education.FacultyId == 0)
			{
				education.FacultyId = null;
			}

			if (education.Graduation.HasValue && education.Graduation == 0)
			{
				education.Graduation = null;
			}

			education.EducationForm = response[key: "education_form"]; // установлено экcпериментальным путем
			education.EducationStatus = response[key: "education_status"]; // установлено экcпериментальным путем

			return education;
		}

	#endregion

	#region Поля, установленные экспериментально

		/// <summary>
		/// Форма обучения.
		/// </summary>
		public string EducationForm { get; set; }

		/// <summary>
		/// Текущий статус пользователя в высшем учебном заведении.
		/// </summary>
		public string EducationStatus { get; set; }

	#endregion
	}
}