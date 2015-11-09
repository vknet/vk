using VkNet.Enums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.editAlbum
	/// </summary>
	public class EditAlbumParams
	{
		/// <summary>
		/// Идентификатор альбома.
		/// </summary>
		public ulong AlbumId
		{ get; set; }

		/// <summary>
		/// Новое название альбома.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Новый текст описания альбома.
		/// </summary>
		public string Description
		{ get; set; }

		/// <summary>
		/// Идентификатор владельца альбома (пользователь или сообщество).
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Настройки приватности просмотра альбома в специальном формате.
		/// </summary>
		public CommentPrivacy? PrivacyView
		{ get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате.
		/// </summary>
		public CommentPrivacy? PrivacyComment
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
