namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о родственнике.
    /// См. описание <see cref="http://vk.com/dev/fields"/>. Раздел relatives.
    /// </summary>
    public class Relative
    {
        /// <summary>
        /// Идентификатор родственника.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тип родственника (sibling и т.п.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Имя родственника, если он не является пользователем ВКонтакте.
        /// </summary>
        public string Name { get; set; }

        #region Методы

        internal static Relative FromJson(VkResponse response)
        {
            var relative = new Relative();

            relative.Id = response["id"];
            relative.Type = response["type"];
            relative.Name = response["name"];

            return relative;
        }

        #endregion
    }
}