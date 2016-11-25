using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Класс в школе
    /// </summary>
    public class SchoolClass
    {
        /// <summary>
        /// Число пользователей, которым понравилась запись.
        /// </summary>
        public long Class { get; set; }

        /// <summary>
        /// Признак понравилась ли запись текущему пользователю.
        /// </summary>
        public string Text { get; set; }

        #region Методы
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static SchoolClass FromJson(VkResponse response)
        {
            var schoolClass = new SchoolClass
            {
                Class = response[0],
                Text = response[1]
            };

            return schoolClass;
        }

        #endregion
    }
}