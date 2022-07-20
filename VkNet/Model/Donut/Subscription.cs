using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Subscription
	/// </summary>
	[Serializable]
	public class Subscription
	{
		/// <summary>
		/// Идентификатор сообщества, доном которого является пользователь.
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Дата следующего платежа в формате "unixtime".
		/// </summary>
		[JsonProperty("next_payment_date")]
		public long NextPaymentDate { get; set; }

		/// <summary>
		/// Стоимость подписки.
		/// </summary>
		[JsonProperty("amount")]
		public long Amount { get; set; }

		/// <summary>
		/// Статус подписки.
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Subscription FromJson(VkResponse response)
		{
			var subscription = new Subscription
			{
				OwnerId = response[key: "owner_id"],
				NextPaymentDate = response[key: "next_payment_date"],
				Amount = response[key: "amount"],
				Status = response[key: "status"]
			};

			return subscription;
		}
	}
}
