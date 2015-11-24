using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VkNet.Model.Attachments
{
	using System;

	using Utils;

	/// <summary>
	/// Фотография.
	/// </summary>
	/// <remarks>
	/// См. описание <see href="http://vk.com/dev/photo"/> и <see href="http://vk.com/dev/attachments_w"/> раздел "Альбом с фотографиями".
	/// </remarks>
	public class Photo : MediaAttachment
	{
		static Photo()
		{
			RegisterType(typeof (Photo), "photo");
		}

		/// <summary>
		/// Идентификатор альбома, в котором находится фотография.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером 75x75px.
		/// </summary>
		public Uri Photo75 { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером 130x130px.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером 604x604px.
		/// </summary>
		public Uri Photo604 { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером 807x807px.
		/// </summary>
		public Uri Photo807 { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером 1280x1024px. 
		/// </summary>
		public Uri Photo1280 { get; set; }

		/// <summary>
		/// Url фотографии с максимальным размером  2560x2048px.
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

		/// <summary>
		/// Текст описания фотографии. 
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Дата добавления фотографии.
		/// </summary>
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// Идентификатор пользователя, загрузившего фото (если фотография размещена в сообществе). Для фотографий, размещенных от имени сообщества.
		/// </summary>
		public long? UserId { get; set; }

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
		public Uri PhotoHash { get; set; }

		/// <summary>
		/// Размеры фотографий.
		/// </summary>
		public ReadOnlyCollection<PhotoSize> Sizes
		{ get; set; }
		/// <summary>
		/// Географическая широта отметки, заданная в градусах
		/// </summary>
		public double? Latitude;

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах
		/// </summary>
		public double? Longitude;


		/// <summary>
		/// Url фотографии с максимальным размером.
		/// </summary>
		public Uri BigPhotoSrc
		{ get; set; }

		/// <summary>
		/// Url фотографии с минимальным размером.
		/// </summary>
		public Uri SmallPhotoSrc
		{ get; set; }
		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Photo FromJson(VkResponse response)
		{
			var photo = new Photo
			{
				Id = response["pid"] ?? response["id"],
				AlbumId = response["album_id"] ?? response["aid"],
				OwnerId = response["owner_id"],
				Photo75 = response["photo_75"] ?? response["src_small"],
				Photo130 = response["photo_130"] ?? response["src"],
				Photo604 = response["photo_604"] ?? response["src_big"],
				Photo807 = response["photo_807"] ?? response["src_xbig"],
				Photo1280 = response["photo_1280"] ?? response["src_xxbig"],
				Photo2560 = response["photo_2560"] ?? response["src_xxxbig"],
				Width = response["width"],
				Height = response["height"],
				Text = response["text"],
				CreateTime = response["date"] ?? response["created"],
				UserId = Utilities.GetNullableLongId(response["user_id"]),
				PostId = Utilities.GetNullableLongId(response["post_id"]),
				AccessKey = response["access_key"],
				PlacerId = Utilities.GetNullableLongId(response["placer_id"]),
				TagCreated = response["tag_created"],
				TagId = response["tag_id"],
				Likes = response["likes"],
				Comments = response["comments"],
				CanComment = response["can_comment"],
				Tags = response["tags"],
				PhotoSrc = response["photo_src"],
				PhotoHash = response["photo_hash"],
				SmallPhotoSrc = response["src_small"],
				Latitude = response["lat"],
				Longitude = response["long"],
				Sizes = response["sizes"].ToReadOnlyCollectionOf<PhotoSize>(x => x)
			};
			return photo;
		}

		#endregion
	}
}