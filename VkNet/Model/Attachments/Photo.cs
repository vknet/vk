using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Фотография.
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/photo
	/// </remarks>
	[Serializable]
	public class Photo : MediaAttachment
	{
		static Photo()
		{
			RegisterType(type: typeof(Photo), match: "photo");
		}

		/// <summary>
		/// Идентификатор альбома, в котором находится фотография.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, загрузившего фото (если фотография размещена в
		/// сообществе). Для фотографий, размещенных
		/// от имени сообщества.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Текст описания фотографии.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Дата добавления фотографии.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Размеры фотографий.
		/// </summary>
		public ReadOnlyCollection<PhotoSize> Sizes { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером 75x75px.
		/// </summary>
		public Uri Photo75 { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером 130x130px.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером 604x604px.
		/// </summary>
		public Uri Photo604 { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером 807x807px.
		/// </summary>
		public Uri Photo807 { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером 1280x1024px.
		/// </summary>
		public Uri Photo1280 { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером  2560x2048px.
		/// </summary>
		public Uri Photo2560 { get; set; }

		/// <summary>
		/// Ширина оригинала фотографии в пикселах
		/// </summary>
		public int? Width { get; set; }

		/// <summary>
		/// Высота оригинала фотографии в пикселах.
		/// </summary>
		public int? Height { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Photo FromJson(VkResponse response)
		{
			var photo = new Photo
			{
					Id = response[key: "photo_id"] ?? response[key: "pid"] ?? response[key: "id"]
					, AlbumId = response[key: "album_id"] ?? response[key: "aid"]
					, OwnerId = response[key: "owner_id"]
					, Photo75 = response[key: "photo_75"] ?? response[key: "src_small"]
					, Photo130 = response[key: "photo_130"] ?? response[key: "src"]
					, Photo604 = response[key: "photo_604"] ?? response[key: "src_big"]
					, Photo807 = response[key: "photo_807"] ?? response[key: "src_xbig"]
					, Photo1280 = response[key: "photo_1280"] ?? response[key: "src_xxbig"]
					, Photo2560 = response[key: "photo_2560"] ?? response[key: "src_xxxbig"]
					, Width = response[key: "width"]
					, Height = response[key: "height"]
					, Text = response[key: "text"]
					, CreateTime = response[key: "date"] ?? response[key: "created"]
					, UserId = Utilities.GetNullableLongId(response: response[key: "user_id"])
					, PostId = Utilities.GetNullableLongId(response: response[key: "post_id"])
					, AccessKey = response[key: "access_key"]
					, PlacerId = Utilities.GetNullableLongId(response: response[key: "placer_id"])
					, TagCreated = response[key: "tag_created"]
					, TagId = response[key: "tag_id"]
					, Likes = response[key: "likes"]
					, Comments = response[key: "comments"]
					, CanComment = response[key: "can_comment"]
					, Tags = response[key: "tags"]
					, PhotoSrc = response[key: "photo_src"]
					, PhotoHash = response[key: "photo_hash"]
					, SmallPhotoSrc = response[key: "src_small"]
					, Latitude = response[key: "lat"]
					, Longitude = response[key: "long"]
					, Sizes = response[key: "sizes"].ToReadOnlyCollectionOf<PhotoSize>(selector: x => x)
			};

			return photo;
		}

	#endregion

	#region опциональные поля

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// Идентификатор записи, у которой данная фотография является прикреплением???
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, сделавшего отметку
		/// </summary>
		public long? PlacerId { get; set; }

		/// <summary>
		/// Дата создания отметки
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? TagCreated { get; set; }

		/// <summary>
		/// Идентификатор отметки
		/// </summary>
		public long? TagId { get; set; }

		/// <summary>
		/// Лайки
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Возможность комментирования фотографии
		/// </summary>
		public bool? CanComment { get; set; }

		/// <summary>
		/// Комментарии
		/// </summary>
		public Comments Comments { get; set; }

		/// <summary>
		/// Теги
		/// </summary>
		public Tags Tags { get; set; }

		/// <summary>
		/// Источник изображения.
		/// </summary>
		public Uri PhotoSrc { get; set; }

		/// <summary>
		/// Хеш изображения.
		/// </summary>
		public string PhotoHash { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// Uri фотографии с максимальным размером.
		/// </summary>
		public Uri BigPhotoSrc { get; set; }

		/// <summary>
		/// Uri фотографии с минимальным размером.
		/// </summary>
		public Uri SmallPhotoSrc { get; set; }

	#endregion
	}
}