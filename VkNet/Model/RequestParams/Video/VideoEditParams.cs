using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.edit
	/// </summary>
	[Serializable]
	public class VideoEditParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание, идентификатор
		/// сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию
		/// идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи. целое число, обязательный параметр.
		/// </summary>
		public long VideoId { get; set; }

		/// <summary>
		/// Новое название для видеозаписи. строка.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Новое описание для видеозаписи. строка.
		/// </summary>
		public string Desc { get; set; }

		/// <summary>
		/// Настройки приватности просмотра видеозаписи в специальном формате. Приватность
		/// доступна для видеозаписей, которые
		/// пользователь загрузил в профиль. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<Privacy> PrivacyView { get; set; }

		/// <summary>
		/// Настройки приватности комментирования видеозаписи в специальном формате.
		/// Приватность доступна для видеозаписей, которые пользователь загрузил в профиль.
		/// список строк, разделенных через
		/// запятую.
		/// </summary>
		public IEnumerable<Privacy> PrivacyComment { get; set; }

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