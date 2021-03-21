using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о продукте.
	/// </summary>
	[Serializable]
	public class Market : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "market";

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
		/// Габариты товара.
		/// </summary>
		public Dimensions Dimensions { get; set; }

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
		[JsonConverter(typeof(UnixDateTimeConverter))]
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
		/// Cсылка на товар во внешних ресурсах.
		/// </summary>
		public Uri Url { get; set; }

		/// <summary>
		/// Текст на кнопке товара.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MarketItemButtonTitle ButtonTitle { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Market FromJson(VkResponse response)
		{
			return new Market
			{
				Id = response["id"] ?? -1,
				OwnerId = response["owner_id"],
				Title = response["title"],
				Description = response["description"],
				Price = response["price"],
				Category = response["category"],
				ThumbPhoto = response["thumb_photo"],
				Date = response["date"],
				Availability = response["availability"],
				Photos = response["photos"].ToReadOnlyCollectionOf<Photo>(x => x),
				CanComment = response["can_comment"],
				CanRepost = response["can_repost"],
				Likes = response["likes"],
				Url = response["url"],
				ButtonTitle = response["button_title"]
			};
		}
	}
}