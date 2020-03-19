using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Создаёт пиксель ретаргетинга.
	/// </summary>
	[Serializable]
	public class CreateTargetPixelParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Id клиента, в рекламном кабинете которого будет создаваться пиксель.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Название пикселя — строка до 64 символов.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Домен сайта, на котором будет размещен пиксель.
		/// </summary>
		[JsonProperty("domain")]
		public string Domain { get; set; }

		/// <summary>
		/// Идентификатор категории сайта, на котором будет размещен пиксель.
		/// </summary>
		[JsonProperty("category_id")]
		public long CategoryId { get; set; }
	}
}