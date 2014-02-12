namespace VkNet.Model
{
    using System;

    using VkNet.Utils;

    /// <summary>
    /// Альбом с фотографиями пользователя.
    /// См. описание <see cref="http://vk.com/dev/attachments_w"/>. Раздел "Альбом с фотографиями".
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Идентификатор альбома.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Обложка альбома.
        /// </summary>
        public Photo Thumb { get; set; }

        /// <summary>
        /// Идентификатор владельца альбома. Отрицательное значение означает, что альбом принадлежит сообществу (группе).
        /// </summary>
        public long? OwnerId { get; set; }

        /// <summary>
        /// Название альбома.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание альбома.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата и время создания альбома.
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Дата и время последнего обновления альбома.
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// Количество фотографий в альбоме.
        /// </summary>
        public int Size { get; set; }

        #region Методы

        internal static Album FromJson(VkResponse response)
        {
            var album = new Album();

            album.Id = response["aid"];
            album.Thumb = response["thumb"];
            album.OwnerId = response["owner_id"];
            album.Title = response["title"];
            album.Description = response["description"];
            album.CreateTime = response["created"];
            album.UpdateTime = response["updated"];
            album.Size = response["size"];

            return album;
        }

        #endregion
    }
}