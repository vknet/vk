using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Ёлемент блока видеокаталога
	/// </summary>
	public class VideoCatalogItem
	{
		/// <summary>
		/// идентификатор элемента. положительное число.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// идентификатор владельца элемента. int (числовое значение).
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// заголовок. строка.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// тип элемента. ћожет принимать значени€: video Ч видеоролик; album Ч альбом. строка.
		/// </summary>
		public VideoCatalogItemType Type { get; set; }

		/// <summary>
		/// длительность в секундах. положительное число.
		/// </summary>
		public long? Duration { get; set; }

		/// <summary>
		/// описание. строка.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// дата добавлени€. положительное число.
		/// </summary>
		public long? Date { get; set; }

		/// <summary>
		/// число просмотров. положительное число.
		/// </summary>
		public long? Views { get; set; }

		/// <summary>
		/// число комментариев. положительное число.
		/// </summary>
		public long? Comments { get; set; }

		/// <summary>
		/// URL изображени€-обложки видео с размером 130x98px.строка.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// URL изображени€-обложки видео с размером 320x240px. строка.
		/// </summary>
		public Uri Photo320 { get; set; }

		/// <summary>
		/// URL изображени€-обложки видео с размером 640x480px (если размер есть). строка.
		/// </summary>
		public Uri Photo640 { get; set; }

		/// <summary>
		/// наличие возможности добавить видео в свой список. флаг, может принимать значени€ 1 или 0.
		/// </summary>
		public bool? CanAdd { get; set; }

		/// <summary>
		/// наличие возможности редактировать видео. флаг, может принимать значени€ 1 или 0.
		/// </summary>
		public bool? CanEdit { get; set; }

		/// <summary>
		/// число видеозаписей в альбоме. положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// URL изображени€-обложки альбома с размером 272x150px. строка.
		/// </summary>
		public Uri Photo160 { get; set; }

		/// <summary>
		/// врем€ последнего обновлени€ альбома. положительное число.
		/// </summary>
		public long? UpdatedTime { get; set; }

		/// <summary>
		/// –азобрать из json.
		/// </summary>
		/// <param name="response">ќтвет сервера.</param>
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
			};

			return item;
		}
	}
}