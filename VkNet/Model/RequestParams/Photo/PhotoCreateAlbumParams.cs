using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	[Serializable]
	public class PhotoCreateAlbumParams
	{
		/// <summary>
		/// Название альбома.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор сообщества, в котором создаётся альбом.
		/// </summary>
		public long? GroupId { get; set; }

		/// <summary>
		/// Текст описания альбома.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Настройки приватности просмотра альбома в специальном формате.
		/// </summary>
		public List<Privacy> PrivacyView { get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате.
		/// </summary>
		public List<Privacy> PrivacyComment { get; set; }

		/// <summary>
		/// Кто может загружать фотографии в альбом (только для альбома сообщества).
		/// </summary>
		public bool? UploadByAdminsOnly { get; set; }

		/// <summary>
		/// Отключено ли комментирование альбома (только для альбома сообщества).
		/// </summary>
		public bool? CommentsDisabled { get; set; }
	}
}