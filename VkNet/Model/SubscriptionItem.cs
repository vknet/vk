using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
	[Serializable]
    public class SubscriptionItem
    {
		[JsonProperty(propertyName: "id")]
		public ulong Id { get; set; }

		[JsonProperty(propertyName: "item_id")]
		public string ItemId { get; set; }

		[JsonProperty(propertyName: "status")]
		public string Status { get; set; }

		[JsonProperty(propertyName: "price")]
		public long Price	{ get; set; }

		[JsonProperty(propertyName: "period")]
		public int Period { get; set; }

		[JsonProperty(propertyName: "create_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		[JsonProperty(propertyName: "update_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? UpdateTime { get; set; }

		[JsonProperty(propertyName: "period_start_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? PeriodStartTime { get; set; }

		private DateTime? _nextBillTime;
		[JsonProperty(propertyName: "next_bill_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? NextBillTime
		{
			get
			{
				if (Status.Equals("active")) return _nextBillTime;
				return null;
			}
			set
			{
				if (_nextBillTime == value) return;
				if (Status.Equals("active"))
					_nextBillTime = value;
			}
		}

		[JsonProperty(propertyName: "trial_expire_time")]
		public DateTime? TrialExpireTime { get; set; }

		[JsonProperty(propertyName: "pending_cancel")]
		public bool PendingCancel { get; set; }

		[JsonProperty(propertyName: "cancel_reason")]
		public CancelSubscriptionReason CancelReason { get; set; }

		[JsonProperty(propertyName: "test_mode")]
		public bool TestMode { get; set; }
	}
}