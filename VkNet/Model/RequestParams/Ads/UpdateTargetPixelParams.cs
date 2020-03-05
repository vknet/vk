using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.updateTargetGroup
	/// </summary>
	[Serializable]
	public class UpdateTargetPixelParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор пикселя. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("target_pixel_id")]
		public long TargetPixelId { get; set; }

		/// <summary>
		/// Новое название пикселя — строка до 64 символов. обязательный параметр, строка
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Новый домен сайта, на котором будет размещен код пикселя. строка
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Новый идентификатор категории сайта, на котором будет размещен пиксель. Для получения списка возможных идентификаторов можно использовать метод ads.getSuggestions (раздел interest_categories). обязательный параметр, целое число
		/// </summary>
		[JsonProperty("category_id")]
		public long CategoryId { get; set; }

		/// <summary>
		/// Только для рекламных агентств.
		/// id клиента, в рекламном кабинете которого находится пиксель. целое число
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }
	}
}