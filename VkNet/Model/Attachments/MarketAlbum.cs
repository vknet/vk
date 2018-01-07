using System;
using System.Runtime.Serialization;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Подборка товаров
	/// </summary>
	[Serializable]
	public class MarketAlbum : MediaAttachment
	{
		static MarketAlbum()
		{
			RegisterType(typeof(MarketAlbum), "market_album");
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
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static MarketAlbum FromJson(VkResponse response)
		{
			var application = new MarketAlbum
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Photo = response["photo"],
				Count = response["count"],
				UpdatedTime = response["updated_time"]
			};

			return application;
		}
	}
}