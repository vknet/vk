using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Каталог товаров
	/// </summary>
	[Serializable]
	public class MarketAlbum : MediaAttachment
	{
		static MarketAlbum()
		{
			RegisterType(typeof(MarketAlbum), "market_album");
		}
		/// <summary>
		/// Название подборки. строка
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Обложка подборки, объект photo.
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Число товаров в подборке; int (числовое значение)
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Дата обновления подборки в формате unixtime. положительное число
		/// </summary>
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static MarketAlbum FromJson(VkResponse response)
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