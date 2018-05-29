using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Подборка товаров
	/// </summary>
	[Serializable]
	public class MarketAlbum : MediaAttachment
	{
		static MarketAlbum()
		{
			RegisterType(type: typeof(MarketAlbum), match: "market_album");
		}

		/// <summary>
		/// название подборки
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// обложка подборки, объект, описывающий фотографию.
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// число товаров в подборке.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// дата обновления подборки в формате Unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MarketAlbum FromJson(VkResponse response)
		{
			var application = new MarketAlbum
			{
					Id = response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, Title = response[key: "title"]
					, Photo = response[key: "photo"]
					, Count = response[key: "count"]
					, UpdatedTime = response[key: "updated_time"]
			};

			return application;
		}
	}
}