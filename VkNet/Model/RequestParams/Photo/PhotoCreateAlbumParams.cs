using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

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

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(PhotoCreateAlbumParams p)
		{
			if (p.PrivacyView == null)
			{
				p.PrivacyView = new List<Privacy>();
			}

			if (p.PrivacyComment == null)
			{
				p.PrivacyComment = new List<Privacy>();
			}

			if (p.Title.Length < 2)
			{
				throw new System.Exception(message: "Параметр title обязательный, минимальная длина 2 символа");
			}

			var parameters = new VkParameters
			{
					{ "title", p.Title }
					, { "group_id", p.GroupId }
					, { "description", p.Description }
					, { "privacy_view", string.Join(separator: ",", values: p.PrivacyView) }
					, { "privacy_comment", string.Join(separator: ",", values: p.PrivacyComment) }
					, { "upload_by_admins_only", p.UploadByAdminsOnly }
					, { "comments_disabled", p.CommentsDisabled }
			};

			return parameters;
		}
	}
}