using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Education
    {
        /// <summary>
        /// Идентификатор ВУЗа.
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
        /// <summary>
        /// Форма обучения.
        /// </summary>
        public string EducationForm { get; set; }
        /// <summary>
        /// Текущий статус пользователя в ВУЗе.
        /// </summary>
        public string EducationStatus { get; set; }

        internal static Education FromJson(VkResponse user)
        {
            if (user["university"] == "0")
                return null;

            var result = new Education();

            result.UniversityId = user["university"];
            result.FacultyId = user["faculty"];
            result.Graduation = user["graduation"];
            result.UniversityName = user["university_name"];
            result.FacultyName = user["faculty_name"];
            result.EducationForm = user["education_form"];
            result.EducationStatus = user["education_status"];

            if (result.UniversityId.HasValue && result.UniversityId == 0)
                result.UniversityId = null;

            if (result.FacultyId.HasValue && result.FacultyId == 0)
                result.FacultyId = null;

            if (result.Graduation.HasValue && result.Graduation == 0)
                result.Graduation = null;

            return result;
        }
    }
}