using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Статья
	/// </summary>
	[Serializable]
	public class Article : MediaAttachment
	{
		/// <summary>
		/// Имя владельца
		/// </summary>
		[JsonProperty("owner_name")]
		public string OwnerName { get; set; }

		/// <summary>
		/// URI к фотографии владельца
		/// </summary>
		[JsonProperty("owner_photo")]
		public Uri OwnerPhoto { get; set; }

		/// <summary>
		/// Состояние
		/// </summary>
		[JsonProperty("state")]
		public string State { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("can_report")]
		public bool? CanReport { get; set; }

		/// <summary>
		/// Заголовок
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Подзаголовок
		/// </summary>
		[JsonProperty("subtitle")]
		public string Subtitle { get; set; }

		/// <summary>
		/// Количество показов
		/// </summary>
		[JsonProperty("views")]
		public int? Views { get; set; }

		/// <summary>
		/// Количество поделившихся
		/// </summary>
		[JsonProperty("shares")]
		public int? Shares { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool? IsFavorite { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("view_url")]
		public Uri ViewUrl { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("published_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? PublishedDate { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("photo")]
		public Photo Photo { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Article FromJson(VkResponse response)
		{
			return new Article
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				OwnerName = response["owner_name"],
				OwnerPhoto = response["owner_photo"],
				State = response["state"],
				CanReport = response["can_report"],
				Title = response["title"],
				Subtitle = response["subtitle"],
				Views = response["views"],
				Shares = response["shares"],
				IsFavorite = response["is_favorite"],
				Url = response["url"],
				ViewUrl = response["view_url"],
				AccessKey = response["access_key"],
				PublishedDate = response["published_date"],
				Photo = response["photo"]
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator Article(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(AccessKey)
				? base.ToString()
				: $"{base.ToString()}_{AccessKey}";
		}
	}
}