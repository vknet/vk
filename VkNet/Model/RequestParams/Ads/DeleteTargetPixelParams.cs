using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Создаёт пиксель ретаргетинга.
	/// </summary>
	[Serializable]
	public class DeleteTargetPixelParams
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
		/// Id пикселя.
		/// </summary>
		[JsonProperty("target_pixel_id")]
		public long TargetPixelId { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(DeleteTargetPixelParams p)
		{
			var parameters = new VkParameters
			{
				{"account_id", p.AccountId},
				{"client_id", p.ClientId},
				{"target_pixel_id", p.TargetPixelId}
			};
			return parameters;
		}
	}
}