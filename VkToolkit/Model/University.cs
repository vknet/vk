namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Высшее учебное заведение, в котором учился пользователь.
    /// См. описание <see cref="http://vk.com/dev/fields"/>. Раздел universities.
    /// </summary>
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

        // ------ Установлено в результате экспериментов ------

        /// <summary>
        /// Форма обучения.
        /// </summary>
        public string EducationForm { get; set; }

        /// <summary>
        /// Статус пользователя в университете.
        /// </summary>
        public string EducationStatus { get; set; }

        #region Методы

        internal static University FromJson(VkResponse response)
        {
            var university = new University();

            university.Id = response["id"];
            university.Country = response["country"];
            university.City = response["city"];
            university.Name = response["name"];
            university.Faculty = response["faculty"];
            university.FacultyName = response["faculty_name"];
            university.Chair = response["chair"];
            university.ChairName = response["chair_name"];
            university.Graduation = response["graduation"];

            // установлено экcпериментальным путем
            university.EducationForm = response["education_form"];
            university.EducationStatus = response["education_status"];

            return university;
        }

        #endregion
    }
}