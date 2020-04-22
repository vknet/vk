using System;
using System.Collections.Generic;
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
	[DebuggerDisplay("Id = {Id}, Title = {Title}")]
	[Serializable]
	public class Video : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "video";

		/// <summary>
		/// Идентификатор вложения.
		/// </summary>
		[JsonProperty("video_id")]
		private long? VideoId
		{
			get => Id;
			set => Id = value;
		}

		/// <summary>
		/// Название видеозаписи.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Текст описания видеозаписи.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		/// Длительность ролика в секундах.
		/// </summary>
		[JsonProperty("duration")]
		public int? Duration { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения-обложки ролика с размером 130x98px.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_130")]
		public Uri Photo130 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения-обложки ролика с размером 320x240px.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_320")]
		public Uri Photo320 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения-обложки ролика с размером 640x480px (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_640")]
		public Uri Photo640 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения-обложки ролика с размером 800x450px (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_800")]
		public Uri Photo800 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения-обложки ролика с размером до 1280 px по ширине (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> Image")]
		[JsonProperty("photo_1280")]
		public Uri Photo1280 { get; set; }

		/// <summary>
		/// Список изображений первого кадра ролика.
		/// </summary>
		[JsonProperty("first_frame")]
		public IEnumerable<VideoImage> FirstFrame { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения первого кадра ролика с размером 130x98px.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> FirstFrame")]
		[JsonProperty("first_frame_130")]
		public Uri FirstFrame130 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения первого кадра ролика с размером 320x240px.
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> FirstFrame")]
		[JsonProperty("first_frame_320")]
		public Uri FirstFrame320 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения первого кадра ролика с размером 640x480px (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> FirstFrame")]
		[JsonProperty("first_frame_640")]
		public Uri FirstFrame640 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения первого кадра ролика с размером 800x450px (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> FirstFrame")]
		[JsonProperty("first_frame_800")]
		public Uri FirstFrame800 { get; set; }

		/// <summary>
		/// <c>Uri</c> изображения первого кадра ролика с шириной до 1028 px (если размер есть).
		/// </summary>
		[Obsolete("Это свойство устарело в версии api 5.101. Используйте свойство IEnumerable<VideoImage> FirstFrame")]
		[JsonProperty("first_frame_1280")]
		public Uri FirstFrame1280 { get; set; }

		/// <summary>
		/// Дата добавления видеозаписи.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Дата добавления видеозаписи пользователем или группой в формате Unixtime.
		/// </summary>
		[JsonProperty("adding_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? AddingDate { get; set; }

		/// <summary>
		/// Количество просмотров.
		/// </summary>
		[JsonProperty("views")]
		public int? Views { get; set; }

		/// <summary>
		/// Количество комментариев.
		/// </summary>
		[JsonProperty("comments")]
		public int? Comments { get; set; }

		/// <summary>
		/// Адрес страницы с плеером, который можно использовать для воспроизведения ролика
		/// в браузере.
		/// Поддерживается flash и html5, плеер всегда масштабируется по размеру окна.
		/// </summary>
		[JsonProperty("player")]
		public Uri Player { get; set; }

		/// <summary>
		/// Платформа
		/// </summary>
		[JsonProperty("platform")]
		public string Platform { set; get; }

		/// <summary>
		/// Поле возвращается, если пользователь может редактировать видеозапись, всегда
		/// содержит 1.
		/// </summary>
		[JsonProperty("can_edit")]
		public bool? CanEdit { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
		/// </summary>
		[JsonProperty("can_add")]
		public bool? CanAdd { get; set; }

		/// <summary>
		/// Поле возвращается, если видеозапись приватная (например, была загружена в
		/// личное сообщение), всегда содержит 1.
		/// </summary>
		[JsonProperty("is_private")]
		public bool? IsPrivate { get; set; }

		/// <summary>
		/// Список изображений обложки видеозаписи.
		/// </summary>
		[JsonProperty("image")]
		public IEnumerable<VideoImage> Image { get; set; }

		/// <summary>
		/// Поле возвращается в том случае, если видеоролик находится в процессе обработки,
		/// всегда содержит 1.
		/// </summary>
		[JsonProperty("processing")]
		public bool? Processing { set; get; }

		/// <summary>
		/// Поле возвращается в том случае, если видеозапись является прямой трансляцией,
		/// всегда содержит 1. Обратите внимание,
		/// в этом случае в поле <c>duration</c> содержится значение 0.
		/// </summary>
		[JsonProperty("live")]
		public bool? Live { get; set; }

		/// <summary>
		/// (для <c>live = 1</c>). Поле свидетельствует о том, что трансляция скоро начнётся.
		/// </summary>
		[JsonProperty("upcoming")]
		public bool? Upcoming { get; set; }

		/// <summary>
		/// <c>true</c>, если объект добавлен в закладки у текущего пользователя.
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Video FromJson(VkResponse response)
		{
			return response != null
				? JsonConvert.DeserializeObject<Video>(response.ToString())
				: null;
		}

		/// <summary>
		/// Преобразование класса <see cref="Video" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Video" /></returns>
		public static implicit operator Video(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion

	#region Недокументированные

		/// <summary>
		/// Признак может ли текущий пользователь добавлять комментарии к видеозаписи.
		/// </summary>
		[JsonProperty("can_comment")]
		public bool? CanComment { get; set; }

		/// <summary>
		/// Признак может ли текущий пользователь сделать репост данной видеозаписи.
		/// </summary>
		[JsonProperty("can_repost")]
		public bool? CanRepost { get; set; }

		/// <summary>
		/// Информация о лайках к видеозаписи.
		/// </summary>
		[JsonProperty("likes")]
		public Likes Likes { get; set; }

		/// <summary>
		/// Признак является ли видеозапись зацикленной.
		/// </summary>
		[JsonProperty("repeat")]
		public bool? Repeat { get; set; }

		/// <summary>
		/// Идентификатор видеоальбома <c>VideoAlbum</c>
		/// </summary>
		[JsonProperty("album_id")]
		public long? AlbumId { get; set; }

		/// <summary>
		/// <c>Uri</c>, по которому необходимо выполнить загрузку видеов (см. метод
		/// <c>VideoCategory.Save</c>
		/// </summary>
		[JsonProperty("upload_url")]
		public Uri UploadUrl { get; set; }

		/// <summary>
		/// Отметка к видеозаписи.
		/// </summary>
		[JsonProperty("tag")]
		public Tag Tag { get; set; }

		/// <summary>
		/// Ссылки на файлы
		/// </summary>
		[JsonProperty("files")]
		public VideoFiles Files { get; set; }

		/// <summary>
		/// Информация о репостах записи
		/// </summary>
		[JsonProperty("reposts")]
		public Reposts Reposts { get; set; }

		/// <summary>
		/// Ширина
		/// </summary>
		[JsonProperty("width")]
		public int? Width { get; set; }

		/// <summary>
		/// Высота
		/// </summary>
		[JsonProperty("height")]
		public int? Height { get; set; }

	#endregion
	}
}