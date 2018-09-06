using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
			RegisterType(type: typeof(Album), match: "album");
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
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Дата и время последнего обновления альбома.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// Количество фотографий в альбоме.
		/// </summary>
		public int Size { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Album FromJson(VkResponse response)
		{
			return new Album
			{
					Id = response[key: "album_id"] ?? response[key: "aid"] ?? response[key: "id"]
					, Thumb = response[key: "thumb"]
					, OwnerId = response[key: "owner_id"]
					, Title = response[key: "title"]
					, Description = response[key: "description"]
					, CreateTime = response[key: "created"]
					, UpdateTime = response[key: "updated"]
					, Size = response[key: "size"]
			};
		}

	#endregion
	}
}