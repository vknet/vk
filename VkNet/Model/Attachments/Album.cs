using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Альбом с фотографиями пользователя.
	/// См. описание http://vk.com/dev/attachments_w
	/// </summary>
	[Serializable]
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public static Album FromJson(VkResponse response)
		{
			return new Album
			{
				Id = response["album_id"] ?? response["aid"] ?? response["id"],
				Thumb = response["thumb"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Description = response["description"],
				CreateTime = response["created"],
				UpdateTime = response["updated"],
				Size = response["size"]
			};
		}

		#endregion
    }
}