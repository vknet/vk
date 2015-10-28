using VkNet.Enums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	public class CreateAlbumParams
	{
		/// <summary>
		/// Название альбома. строка, обязательный параметр, минимальная длина 2.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Идентификатор сообщества, в котором создаётся альбом. целое число.
		/// </summary>
		public long? GroupId
		{ get; set; }

		/// <summary>
		/// Текст описания альбома. строка.
		/// </summary>
		public string Description
		{ get; set; }

		/// <summary>
		/// Настройки приватности просмотра альбома в специальном формате. список строк, разделенных через запятую, по умолчанию all, доступен начиная с версии 5.30.
		/// </summary>
		public CommentPrivacy? PrivacyView
		{ get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате. список строк, разделенных через запятую, по умолчанию all, доступен начиная с версии 5.30.
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
