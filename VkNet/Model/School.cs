namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Школа, в которой учился пользователь.
    /// См. описание <see href="http://vk.com/dev/fields"/>. Раздел schools.
    /// </summary>
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

        internal static School FromJson(VkResponse response)
        {
            var school = new School();

            school.Id = Utilities.GetNullableLongId(response["id"]);
            school.Country = Utilities.GetNullableLongId(response["country"]);
            school.City = Utilities.GetNullableLongId(response["city"]);
            school.Name = response["name"] ?? response["title"];
            school.YearFrom = response["year_from"];
            school.YearTo = response["year_to"];
            school.YearGraduated = response["year_graduated"];
            school.Class = response["class"];
            school.Speciality = response["speciality"];
            school.Type = response["type"];
            school.TypeStr = response["type_str"];

            return school;
        }

        #endregion
    }
}