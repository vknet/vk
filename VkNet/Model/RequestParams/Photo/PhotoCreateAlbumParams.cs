using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	public struct PhotoCreateAlbumParams
	{
		/// <summary>
		/// Список параметров для метода photos.createAlbum .
		/// </summary>
		/// <param name="gag">Заглушка инициализатора конструктора.</param>
		public PhotoCreateAlbumParams(bool gag = true)
		{
			View = new List<Privacy>();
			Privacy = new List<Privacy>();
			Title = null;
			GroupId = null;
			Description = null;
			UploadByAdminsOnly = null;
			CommentsDisabled = null;
		}

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
		internal static VkParameters ToVkParameters(PhotoCreateAlbumParams p)
		{
			if (p.View == null)
			{
				p.View = new List<Privacy>();
			}
			if (p.Privacy == null)
			{
				p.Privacy = new List<Privacy>();
			}
			if (p.Title.Length < 2)
			{
				throw new System.Exception("Параметр title обязательный, минимальная длина 2 символа");
			}
			var parameters = new VkParameters
			{
				{ "title", p.Title },
				{ "group_id", p.GroupId },
				{ "description", p.Description },
				{ "privacy_view", string.Join(",", p.View) },
				{ "privacy_comment", string.Join(",", p.Privacy) },
				{ "upload_by_admins_only", p.UploadByAdminsOnly },
				{ "comments_disabled", p.CommentsDisabled }
			};

			return parameters;
		}
	}
}
