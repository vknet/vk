namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    public class University
    {
        /// <summary>
        /// Идентификатор ВУЗа.
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Идентификатор страны, в которой расположен ВУЗ.
        /// </summary>
        public long? Country { get; set; }
        /// <summary>
        /// Идентификатор города, в котором расположен ВУЗ.
        /// </summary>
        public long? City { get; set; }
        /// <summary>
        /// Наименование ВУЗа.
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
        /// Название кафедры.
        /// </summary>
        public string ChairName { get; set; }
        /// <summary>
        /// Год окончания обучения.
        /// </summary>
        public int? Graduation { get; set; }
        /// <summary>
        /// Форма обучения.
        /// </summary>
        public string EducationForm { get; set; }
        /// <summary>
        /// Статус пользователя в ВУЗе.
        /// </summary>
        public string EducationStatus { get; set; }

        internal static University FromJson(VkResponse status)
        {
            var result = new University();

            result.Id = status["id"];
            result.Country = status["country"];
            result.City = status["city"];
            result.Name = status["name"];
            result.Faculty = status["faculty"];
            result.FacultyName = status["faculty_name"];
            result.Chair = status["chair"];
            result.ChairName = status["chair_name"];
            result.Graduation = status["graduation"];
            result.EducationForm = status["education_form"];
            result.EducationStatus = status["education_status"];

            return result;
        }
    }
}