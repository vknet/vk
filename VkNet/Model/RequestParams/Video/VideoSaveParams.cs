﻿using System;
using System.Collections.Generic;

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
	}
}