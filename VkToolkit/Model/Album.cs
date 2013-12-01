namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Utils;

    /// <summary>
    /// Альбом с фотографиями пользователя.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Идентификатор альбома.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Превьюшка альбома.
        /// </summary>
        public Photo Thumb { get; set; }
        /// <summary>
        /// Идентификатор владельца альбома. Отрицательное значение означает, что альбом принадлежит группе.
        /// </summary>
        public long? OwnerId { get; set; }
        /// <summary>
        /// Название альбома.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание альбома
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

        internal static Album FromJson(VkResponse response)
        {
            Album album = new Album();

            album.Id = response["aid"];
            album.Thumb = response["thumb"];
            album.OwnerId = response["owner_id"];            
            album.Title = response["title"];
            album.Description = response["description"];
            album.CreateTime = response["created"];
            album.UpdateTime = response["updated"];

            return album;
        }
    }
}