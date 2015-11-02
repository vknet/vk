using VkNet.Enums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.editAlbum
	/// </summary>
	public class EditAlbumParams
	{
		/// <summary>
		/// Идентификатор альбома. целое число, положительное число, обязательный параметр.
		/// </summary>
		public ulong AlbumId
		{ get; set; }

		/// <summary>
		/// Новое название альбома. строка.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Новый текст описания альбома. строка.
		/// </summary>
		public string Description
		{ get; set; }

		/// <summary>
		/// Идентификатор владельца альбома (пользователь или сообщество). целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long OwnerId
		{ get; set; }

		/// <summary>
		/// Настройки приватности просмотра альбома в специальном формате. список строк, разделенных через запятую, доступен начиная с версии 5.30.
		/// </summary>
		public CommentPrivacy? PrivacyView
		{ get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате. список строк, разделенных через запятую, доступен начиная с версии 5.30.
		/// </summary>
		public CommentPrivacy? PrivacyComment
		{ get; set; }

		/// <summary>
		/// Кто может загружать фотографии в альбом (только для альбома сообщества). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? UploadByAdminsOnly
		{ get; set; }

		/// <summary>
		/// Отключено ли комментирование альбома (только для альбома сообщества). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? CommentsDisabled
		{ get; set; }
	}
}
