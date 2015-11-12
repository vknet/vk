using System.Collections.ObjectModel;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	public class CreateAlbumParams
	{
		/// <summary>
		/// Название альбома.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Идентификатор сообщества, в котором создаётся альбом.
		/// </summary>
		public long? GroupId
		{ get; set; }

		/// <summary>
		/// Текст описания альбома.
		/// </summary>
		public string Description
		{ get; set; }

		/// <summary>
		/// Настройки приватности просмотра альбома в специальном формате.
		/// </summary>
		public ReadOnlyCollection<Privacy> View
		{ get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате.
		/// </summary>
		public ReadOnlyCollection<Privacy> Privacy
		{ get; set; }

		/// <summary>
		/// Кто может загружать фотографии в альбом (только для альбома сообщества).
		/// </summary>
		public bool? UploadByAdminsOnly
		{ get; set; }

		/// <summary>
		/// Отключено ли комментирование альбома (только для альбома сообщества).
		/// </summary>
		public bool? CommentsDisabled
		{ get; set; }
	}
}
