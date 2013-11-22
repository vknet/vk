namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    public class School
    {
        /// <summary>
        /// Идентификатор школы.
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Идентификатор страны, в которой расположен школа.
        /// </summary>
        public long? Country { get; set; }
        /// <summary>
        /// Идентификатор города, в котором расположен школа.
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
        /// Идентификатор типа школы
        /// </summary>
        public long? Type { get; set; }
        /// <summary>
        /// Название типа школы.
        /// </summary>
        public string TypeStr { get; set; }

        internal static School FromJson(VkResponse status)
        {
            var result = new School();

            result.Id = status["id"];
            result.Country = status["country"];
            result.City = status["city"];
            result.Name = status["name"];
            result.YearFrom = status["year_from"];
            result.YearTo = status["year_to"];
            result.YearGraduated = status["year_graduated"];
            result.Class = status["class"];
            result.Speciality = status["speciality"];
            result.Type = status["type"];
            result.TypeStr = status["type_str"];

            return result;
        }
    }
}