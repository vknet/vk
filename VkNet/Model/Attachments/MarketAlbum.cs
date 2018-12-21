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
		/// <inheritdoc />
		protected override string Alias => "market_album";

		/// <summary>
		/// Название подборки
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Обложка подборки, объект, описывающий фотографию.
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Число товаров в подборке.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Дата обновления подборки в формате Unixtime.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MarketAlbum FromJson(VkResponse response)
		{
			return new MarketAlbum
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Photo = response["photo"],
				Count = response["count"],
				UpdatedTime = response["updated_time"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MarketAlbum" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MarketAlbum" /></returns>
		public static implicit operator MarketAlbum(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}