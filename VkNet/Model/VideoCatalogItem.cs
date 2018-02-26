using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Объект, описывающий элемент видеокаталога
	/// </summary>
	[Serializable]
	public class VideoCatalogItem
	{
		/// <summary>
		/// идентификатор элемента.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// идентификатор владельца элемента.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// название элемента.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// тип элемента.
		/// </summary>
		public VideoCatalogItemType Type { get; set; }

		/// <summary>
		/// текст описания.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// длительность ролика в секундах.
		/// </summary>
		public long? Duration { get; set; }

		/// <summary>
		/// URL изображения-обложки ролика шириной 130px.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// URL изображения-обложки ролика шириной 320px.
		/// </summary>
		public Uri Photo320 { get; set; }

		/// <summary>
		/// URL изображения-обложки ролика шириной 640px (если размер есть).
		/// </summary>
		public Uri Photo640 { get; set; }
		
		/// <summary>
		/// URL изображения-обложки ролика шириной 800px (если размер есть).
		/// </summary>
		[JsonProperty("photo_800")]
		public Uri Photo800 { get; set; }

		/// <summary>
		/// дата создания видеозаписи в формате Unixtime.
		/// </summary>
		public DateTime? Date { get; set; }
		
		/// <summary>
		/// дата добавления видеозаписи пользователем или группой в формате Unixtime.
		/// </summary>
		[JsonProperty("adding_date")]
		public DateTime? AddingDate { get; set; }

		/// <summary>
		/// количество просмотров видеозаписи.
		/// </summary>
		public long? Views { get; set; }

		/// <summary>
		/// количество комментариев к видеозаписи.
		/// </summary>
		public long? Comments { get; set; }

		/// <summary>
		/// наличие возможности добавить ролик в свой список.
		/// </summary>
		public bool? CanAdd { get; set; }

		/// <summary>
		/// наличие возможности редактировать видео.
		/// </summary>
		public bool? CanEdit { get; set; }
		
		/// <summary>
		/// приватность ролика (0 — нет, 1 — есть).
		/// </summary>
		[JsonProperty("is_private")]
		public bool? IsPrivate { get; set; }

		/// <summary>
		/// число видеозаписей в альбоме.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// URL изображения-обложки альбома с размером 272x150px.
		/// </summary>
		public Uri Photo160 { get; set; }

		/// <summary>
		/// время последнего обновления альбома в формате unixtime.
		/// </summary>
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		public static VideoCatalogItem FromJson(VkResponse response)
		{
			var item = new VideoCatalogItem
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Type = response["type"],

				Duration = response["duration"],
				Description = response["description"],
				Date = response["date"],
				Views = response["views"],
				Comments = response["comments"],
				Photo130 = response["photo_130"],
				Photo320 = response["photo_320"],
				Photo640 = response["photo_640"],
				CanAdd = response["can_add"],
				CanEdit = response["can_edit"],

				Count = response["count"],
				Photo160 = response["photo_160"],
				UpdatedTime = response["updated_time"],
				IsPrivate = response["is_private"],
				AddingDate = response["adding_date"],
				Photo800 = response["photo_800"]
			};

			return item;
		}
	}
}