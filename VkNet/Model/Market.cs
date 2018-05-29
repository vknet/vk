using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о продукте.
	/// </summary>
	[Serializable]
	public class Market
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца товара
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Название товара
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Текст описания товара
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Цена
		/// </summary>
		public Price Price { get; set; }

		/// <summary>
		/// Категория товара
		/// </summary>
		public MarketCategory Category { get; set; }

		/// <summary>
		/// URL изображения-обложки товара
		/// </summary>
		public Uri ThumbPhoto { get; set; }

		/// <summary>
		/// Дата создания товара в формате Unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Статус доступности товара
		/// </summary>
		public ProductAvailability Availability { get; set; }

		/// <summary>
		/// Изображения товара
		/// </summary>
		public ReadOnlyCollection<Photo> Photos { get; set; }

		/// <summary>
		/// Возможность комментировать товар для текущего пользователя
		/// </summary>
		public bool? CanComment { get; set; }

		/// <summary>
		/// Возможность сделать репост товара для текущего пользователя
		/// </summary>
		public bool? CanRepost { get; set; }

		/// <summary>
		/// Информация об отметках «Мне нравится»
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Market FromJson(VkResponse response)
		{
			var result = new Market
			{
					Id = response[key: "id"] ?? -1
					, OwnerId = response[key: "owner_id"]
					, Title = response[key: "title"]
					, Description = response[key: "description"]
					, Price = response[key: "price"]
					, Category = response[key: "category"]
					, ThumbPhoto = response[key: "thumb_photo"]
					, Date = response[key: "date"]
					, Availability = response[key: "availability"]
					, Photos = response[key: "photos"].ToReadOnlyCollectionOf<Photo>(selector: x => x)
					, CanComment = response[key: "can_comment"]
					, CanRepost = response[key: "can_repost"]
					, Likes = response[key: "likes"]
			};

			return result;
		}
	}
}