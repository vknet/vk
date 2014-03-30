namespace VkNet.Model
{
    using System;
    using System.Diagnostics;

    using VkNet.Utils;

    /// <summary>
    /// Отметка к видеозаписи.
    /// См. описание <see href="http://vk.com/dev/tag.getTags"/>.
    /// </summary>
    [DebuggerDisplay("Id = {Id}, Name = {Name}")]
    public class Tag
    {
        /// <summary>
        /// Идентификатор отметки.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Название отметки.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор пользователя, которому соответствует отметка.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Идентификатор пользователя, сделавшего отметку.
        /// </summary>
        public long? PlacerId { get; set; }

        /// <summary>
        /// Дата добавления отметки.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Статус отметки: true - подтвержденная, false - не подтвержденная.
        /// </summary>
        public bool? IsViewed { get; set; }

        #region Методы

        internal static Tag FromJson(VkResponse tag)
        {
            var result = new Tag();

            result.Id = tag["tag_id"];
            result.Name = tag["tagged_name"];
            result.UserId = tag["uid"];
            result.PlacerId = tag["placer_id"];
            result.Date = tag["tag_created"] ?? tag["date"];
            result.IsViewed = tag["viewed"];

            return result;
        }

        #endregion
    }
}