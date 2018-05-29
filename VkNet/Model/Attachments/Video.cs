using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Видеозапись пользователя или группы.
	/// </summary>
	/// <remarks>
	/// См. описание http://vk.com/dev/video_object
	/// </remarks>
	[DebuggerDisplay(value: "Id = {Id}, Title = {Title}")]
	[Serializable]
	public class Video : MediaAttachment
	{
		/// <summary>
		/// Видеозапись пользователя или группы.
		/// </summary>
		static Video()
		{
			RegisterType(type: typeof(Video), match: "video");
		}

		/// <summary>
		/// Название видеозаписи.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст описания видеозаписи.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Длительность ролика в секундах.
		/// </summary>
		public int? Duration { get; set; }

		/// <summary>
		/// Uri изображения-обложки ролика с размером 130x98px.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// Uri изображения-обложки ролика с размером 320x240px.
		/// </summary>
		public Uri Photo320 { get; set; }

		/// <summary>
		/// Uri изображения-обложки ролика с размером 640x480px (если размер есть).
		/// </summary>
		public Uri Photo640 { get; set; }

		/// <summary>
		/// Uri изображения-обложки ролика с размером 800x450px (если размер есть).
		/// </summary>
		public Uri Photo800 { get; set; }

		/// <summary>
		/// Дата добавления видеозаписи.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Дата добавления видеозаписи пользователем или группой в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? AddingDate { get; set; }

		/// <summary>
		/// Количество просмотров.
		/// </summary>
		public int? Views { get; set; }

		/// <summary>
		/// Количество комментариев.
		/// </summary>
		public int? Comments { get; set; }

		/// <summary>
		/// Адрес страницы с плеером, который можно использовать для воспроизведения ролика
		/// в браузере.
		/// Поддерживается flash и html5, плеер всегда масштабируется по размеру окна.
		/// </summary>
		public Uri Player { get; set; }

		/// <summary>
		/// Платформа
		/// </summary>
		public string Platform { set; get; }

		/// <summary>
		/// поле возвращается, если пользователь может редактировать видеозапись, всегда
		/// содержит 1.
		/// </summary>
		[JsonProperty(propertyName: "can_edit")]
		public bool? CanEdit { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
		/// </summary>
		public bool? CanAdd { get; set; }

		/// <summary>
		/// поле возвращается, если видеозапись приватная (например, была загружена в
		/// личное сообщение), всегда содержит 1.
		/// </summary>
		[JsonProperty(propertyName: "is_private")]
		public bool? IsPrivate { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		public string AccessKey { set; get; }

		/// <summary>
		/// Поле возвращается в том случае, если видеоролик находится в процессе обработки,
		/// всегда содержит 1.
		/// </summary>
		public bool? Processing { set; get; }

		/// <summary>
		/// Поле возвращается в том случае, если видеозапись является прямой трансляцией,
		/// всегда содержит 1. Обратите внимание,
		/// в этом случае в поле duration содержится значение 0.
		/// </summary>
		public bool? Live { get; set; }

		/// <summary>
		/// (для live = 1). Поле свидетельствует о том, что трансляция скоро начнётся.
		/// </summary>
		[JsonProperty(propertyName: "upcoming")]
		public bool? Upcoming { get; set; }

	#region Недокументированные

		/// <summary>
		/// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
		/// </summary>
		public bool? CanComment { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь сделать репост данной видеозаписи.
		/// </summary>
		public bool? CanRepost { get; set; }

		/// <summary>
		/// Информация о лайках к видеозаписи.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Признак является ли видеозапись зацикленной.
		/// </summary>
		public bool? Repeat { get; set; }

		/// <summary>
		/// Идентификатор видеоальбома VideoAlbum
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Uri, по которому необходимо выполнить загрузку видеов (см. метод
		/// VideoCategory.Save
		/// </summary>
		public Uri UploadUrl { get; set; }

		/// <summary>
		/// Отметка к видеозаписи.
		/// </summary>
		public Tag Tag { get; set; }

		/// <summary>
		/// Ссылки на файлы
		/// </summary>
		public VideoFiles Files { get; set; }

		/// <summary>
		/// Информация о репостах записи
		/// </summary>
		public Reposts Reposts { get; set; }

		/// <summary>
		/// Ширина
		/// </summary>
		public int? Width { get; set; }

		/// <summary>
		/// Высота
		/// </summary>
		public int? Height { get; set; }

	#endregion

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Video FromJson(VkResponse response)
		{
			return new Video
			{
					Id = response[key: "video_id"] ?? response[key: "vid"] ?? response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, Title = response[key: "title"]
					, Description = response[key: "description"]
					, Duration = response[key: "duration"]
					, Photo130 = response[key: "photo_130"]
					, Photo320 = response[key: "photo_320"]
					, Photo640 = response[key: "photo_640"]
					, Photo800 = response[key: "photo_800"]
					, Date = response[key: "date"]
					, Views = response[key: "views"]
					, Comments = response[key: "comments"]
					, Player = response[key: "player"]
					, AccessKey = response[key: "access_key"]
					, Processing = response[key: "processing"]
					, Live = response[key: "live"]
					,

					// Устаревшие или не документированные
					CanAdd = response[key: "can_add"]
					, CanComment = response[key: "can_comment"]
					, CanRepost = response[key: "can_repost"]
					, Repeat = response[key: "repeat"]
					, Likes = response[key: "likes"]
					, AlbumId = Utilities.GetNullableLongId(response: response[key: "album_id"])
					, UploadUrl = response[key: "upload_url"]
					, Tag = response
					, AddingDate = response[key: "adding_date"]
					, Files = response[key: "files"]
					, Reposts = response[key: "reposts"]
					, Platform = response[key: "platform"]
					, Width = response[key: "width"]
					, Height = response[key: "height"]
					, CanEdit = response[key: "can_edit"]
					, IsPrivate = response[key: "is_private"]
					, Upcoming = response[key: "upcoming"]
			};
		}

		/// <summary>
		/// Привести объект к строке.
		/// </summary>
		public override string ToString()
		{
			return $"video{OwnerId}_{Id}";
		}

	#endregion
	}
}