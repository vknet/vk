using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.editAlbum
	/// </summary>
	public struct PhotoEditAlbumParams
	{
		/// <summary>
		/// Список параметров для метода photos.editAlbum
		/// </summary>
		/// <param name="gag">Заглушка инициализатора конструктора.</param>
		public PhotoEditAlbumParams(bool gag = true)
		{
			View = new List<Privacy>();
			Privacy = new List<Privacy>();
			AlbumId = 0;
			Title = null;
			Description = null;
			OwnerId = null;
			UploadByAdminsOnly = null;
			CommentsDisabled = null;
		}
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
		public List<Privacy> View
		{ get; set; }

		/// <summary>
		/// Настройки приватности комментирования альбома в специальном формате.
		/// </summary>
		public List<Privacy> Privacy
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

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		public static VkParameters ToVkParameters(PhotoEditAlbumParams p)
		{
			if (p.View == null)
			{
				p.View = new List<Privacy>();
			}
			if (p.Privacy == null)
			{
				p.Privacy = new List<Privacy>();
			}
			var parameters = new VkParameters
			{
				{ "album_id", p.AlbumId },
				{ "title", p.Title },
				{ "description", p.Description },
				{ "owner_id", p.OwnerId },
				{ "privacy_view", string.Join(",", p.View) },
				{ "privacy_comment", string.Join(",", p.Privacy) },
				{ "upload_by_admins_only", p.UploadByAdminsOnly },
				{ "comments_disabled", p.CommentsDisabled }
			};

			return parameters;
		}
	}
}
