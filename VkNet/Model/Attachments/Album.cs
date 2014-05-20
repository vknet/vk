using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Альбом с фотографиями пользователя.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Альбом с фотографиями".
    /// </summary>
    public class Album : MediaAttachment
	{
		static Album()
		{
			RegisterType(typeof (Album), "album");
		}

		/// <summary>
        /// Обложка альбома.
        /// </summary>
        public Photo Thumb { get; set; }

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

			album.Id = response["aid"] ?? response["id"];
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