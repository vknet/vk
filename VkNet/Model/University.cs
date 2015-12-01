namespace VkNet.Model
{
    using System;
    using Utils;

    /// <summary>
    /// Высшее учебное заведение, в котором учился пользователь.
    /// См. описание <see href="http://vk.com/dev/fields"/>. Раздел universities.
    /// </summary>
    [Serializable]
    public class University
    {
        /// <summary>
        /// Идентификатор университета.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор страны, в которой расположен университет.
        /// </summary>
        public long? Country { get; set; }

        /// <summary>
        /// Идентификатор города, в котором расположен университет.
        /// </summary>
        public long? City { get; set; }

        /// <summary>
        /// Наименование университета.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор факультета.
        /// </summary>
        public long? Faculty { get; set; }

        /// <summary>
        /// Название факультета.
        /// </summary>
        public string FacultyName { get; set; }

        /// <summary>
        /// Идентификатор кафедры.
        /// </summary>
        public int? Chair { get; set; }

        /// <summary>
        /// Наименование кафедры.
        /// </summary>
        public string ChairName { get; set; }

        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        public int? Graduation { get; set; }

        #region Поля, установленные экспериментально

        /// <summary>
        /// Форма обучения.
        /// </summary>
        public string EducationForm { get; set; }

        /// <summary>
        /// Статус пользователя в университете.
        /// </summary>
        public string EducationStatus { get; set; }

        #endregion

        #region Методы

        internal static University FromJson(VkResponse response)
		{
			var university = new University
			{
				Id = response["id"],
				Country = response["country"],
				City = response["city"],
				Name = response["name"] ?? response["title"],
				Faculty = response["faculty"],
				FacultyName = response["faculty_name"],
				Chair = response["chair"],
				ChairName = response["chair_name"],
				Graduation = response["graduation"],

				// установлено экcпериментальным путем
				EducationForm = response["education_form"],
				EducationStatus = response["education_status"]
			};

			return university;
		}

		#endregion
	}
}