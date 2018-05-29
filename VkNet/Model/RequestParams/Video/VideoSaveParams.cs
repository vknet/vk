using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.save
	/// </summary>
	[Serializable]
	public class VideoSaveParams
	{
		/// <summary>
		/// Название видеофайла. строка, по умолчанию No name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Описание видеофайла. строка.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Указывается 1 в случае последующей отправки видеозаписи личным сообщением.
		/// После загрузки с этим параметром
		/// видеозапись не будет отображаться в списке видеозаписей пользователя и не будет
		/// доступна другим пользователям по
		/// id. По умолчанию 0. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? IsPrivate { get; set; }

		/// <summary>
		/// Требуется ли после сохранения опубликовать запись с видео на стене (1 —
		/// требуется, 0 — не требуется). флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? Wallpost { get; set; }

		/// <summary>
		/// Uri для встраивания видео с внешнего сайта, например, с youtube. В этом случае
		/// нужно вызвать полученный upload_url
		/// не прикрепляя файл, достаточно просто обратиться по этому адресу. строка.
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в которое будет сохранен видеофайл. По умолчанию файл
		/// сохраняется на страницу текущего
		/// пользователя. положительное число.
		/// </summary>
		public long? GroupId { get; set; }

		/// <summary>
		/// Идентификатор альбома, в который будет загружен видео файл. положительное
		/// число.
		/// </summary>
		public long? AlbumId { get; set; }

		/// <summary>
		/// Настройки приватности просмотра видеозаписи в специальном формате. Приватность
		/// доступна для видеозаписей, которые
		/// пользователь загрузил в профиль. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<string> PrivacyView { get; set; }

		/// <summary>
		/// Настройки приватности комментирования видеозаписи в специальном формате.
		/// Приватность доступна для видеозаписей, которые пользователь загрузил в профиль.
		/// список строк, разделенных через
		/// запятую.
		/// </summary>
		public IEnumerable<string> PrivacyComment { get; set; }

		/// <summary>
		/// Закрыть комментарии (для видео из сообществ). флаг, может принимать значения 1
		/// или 0.
		/// </summary>
		public bool? NoComments { get; set; }

		/// <summary>
		/// Зацикливание воспроизведения видеозаписи. флаг, может принимать значения 1 или
		/// 0.
		/// </summary>
		public bool? Repeat { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(VideoSaveParams p)
		{
			var parameters = new VkParameters
			{
					{ "name", p.Name }
					, { "description", p.Description }
					, { "is_private", p.IsPrivate }
					, { "wallpost", p.Wallpost }
					, { "link", p.Link }
					, { "group_id", p.GroupId }
					, { "album_id", p.AlbumId }
					, { "privacy_view", p.PrivacyView }
					, { "privacy_comment", p.PrivacyComment }
					, { "no_comments", p.NoComments }
					, { "repeat", p.Repeat }
			};

			return parameters;
		}
	}
}