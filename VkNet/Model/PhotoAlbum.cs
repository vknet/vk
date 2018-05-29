using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Альбом для фотографий
	/// </summary>
	[Serializable]
	public class PhotoAlbum
	{
		/// <summary>
		/// Идентификатор созданного альбома
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор фотографии, которая является обложкой альбома
		/// </summary>
		public long? ThumbId { get; set; }

		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит альбом
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Название альбома
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Описание альбома
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Дата создания альбома
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Created { get; set; }

		/// <summary>
		/// Дата обновления альбома
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Updated { get; set; }

		/// <summary>
		/// Количество фотографий в альбоме
		/// </summary>
		public int? Size { get; set; }

		/// <summary>
		/// Настройки приватности для альбома в формате настроек приватности; (не приходит
		/// для системных альбомов)
		/// </summary>
		public ReadOnlyCollection<Privacy> PrivacyView { get; set; }

		/// <summary>
		/// Настройки приватности для комментирования альбома
		/// </summary>
		public ReadOnlyCollection<Privacy> PrivacyComment { get; set; }

		/// <summary>
		/// Может ли текущий пользователь добавлять фотографии в альбом
		/// </summary>
		public bool? CanUpload { get; set; }

		/// <summary>
		/// Адрес на изображение с предпросмотром
		/// </summary>
		public string ThumbSrc { get; set; }

		/// <summary>
		/// Размеры фотографий.
		/// </summary>
		public IEnumerable<PhotoSize> Sizes { get; set; }

		/// <summary>
		/// Комментирование запрещено.
		/// </summary>
		public bool? CommentsDisabled { get; set; }

		/// <summary>
		/// Загружать могут только администраторы.
		/// </summary>
		public bool UploadByAdminsOnly { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this PhotoAlbum
		/// </summary>
		/// <remarks>
		/// Получено экспериментально.
		/// </remarks>
		public bool ThumbIsLast { get; set; }

	#region Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PhotoAlbum FromJson(VkResponse response)
		{
			VkResponseArray privacy = response[key: "privacy_view"];
			VkResponseArray privacyComment = response[key: "privacy_comment"];

			return new PhotoAlbum
			{
					Id = response[key: "album_id"] ?? response[key: "aid"] ?? response[key: "id"]
					, ThumbId = Utilities.GetNullableLongId(response: response[key: "thumb_id"])
					, OwnerId = Utilities.GetNullableLongId(response: response[key: "owner_id"])
					, Title = response[key: "title"]
					, Description = response[key: "description"]
					, Created = response[key: "created"]
					, Updated = response[key: "updated"]
					, Size = response[key: "size"]
					, PrivacyView = privacy.ToReadOnlyCollectionOf<Privacy>(selector: x => x)
					, PrivacyComment = privacyComment.ToReadOnlyCollectionOf<Privacy>(selector: x => x)
					, CanUpload = response[key: "can_upload"]
					, ThumbSrc = response[key: "thumb_src"]
					, Sizes = response[key: "sizes"].ToReadOnlyCollectionOf<PhotoSize>(selector: x => x)
					, CommentsDisabled = response[key: "comments_disabled"]
					, UploadByAdminsOnly = response[key: "upload_by_admins_only"]
					, ThumbIsLast = response[key: "thumb_is_last"]
			};
		}

	#endregion
	}
}