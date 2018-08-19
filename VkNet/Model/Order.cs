using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// API Order object.
	/// </summary>
	[Serializable]
	public class Order
	{
		/// <summary>
		/// Amount
		/// </summary>
		[JsonProperty("amount")]
		public int? Amount { get; set; }

		/// <summary>
		/// Receiver ID
		/// </summary>
		[JsonProperty("receiver_id")]
		public int? ReceiverId { get; set; }

		/// <summary>
		/// Order ID
		/// </summary>
		[JsonProperty("id")]
		public int? Id { get; set; }

		/// <summary>
		/// Order item
		/// </summary>
		[JsonProperty("item")]
		public string Item { get; set; }

		/// <summary>
		/// App order ID
		/// </summary>
		[JsonProperty("app_order_id")]
		public int? AppOrderId { get; set; }

		/// <summary>
		/// Cancel transaction ID
		/// </summary>
		[JsonProperty("cancel_transaction_id")]
		public int? CancelTransactionId { get; set; }

		/// <summary>
		/// Order status
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		/// <summary>
		/// User ID
		/// </summary>
		[JsonProperty("user_id")]
		public int? UserId { get; set; }

		/// <summary>
		/// Transaction ID
		/// </summary>
		[JsonProperty("transaction_id")]
		public int? TransactionId { get; set; }

		/// <summary>
		/// Date of creation in Unixtime
		/// </summary>
		[JsonProperty("date")]
		public int? Date { get; set; }
	}
}