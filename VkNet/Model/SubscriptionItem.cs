using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using VkNet.Enums;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент подписки
	/// </summary>
	[Serializable]
    public class SubscriptionItem
    {
		/// <summary>
		/// Идентификатор подписки
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public ulong Id { get; set; }

		/// <summary>
		/// Идентификатор товара в приложении
		/// </summary>
		[JsonProperty(propertyName: "item_id")]
		public string ItemId { get; set; }

		/// <summary>
		///  Статус подписки. Возможные значения:
		///  active — подписка активна.
		/// </summary>
		[JsonProperty(propertyName: "status")]
		public SubscriptionStatus Status { get; set; }

		/// <summary>
		/// Стоимость подписки
		/// </summary>
		[JsonProperty(propertyName: "price")]
		public long Price	{ get; set; }

		/// <summary>
		/// Период подписки
		/// </summary>
		[JsonProperty(propertyName: "period")]
		public int Period { get; set; }

		/// <summary>
		/// Дата создания в Unixtime
		/// </summary>
		[JsonProperty(propertyName: "create_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? CreateTime { get; set; }

		/// <summary>
		/// Дата обновления в Unixtime
		/// </summary>
		[JsonProperty(propertyName: "update_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// Дата начала периода в Unixtime
		/// </summary>
		[JsonProperty(propertyName: "period_start_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? PeriodStartTime { get; set; }

		private DateTime? _nextBillTime;
		/// <summary>
		/// Дата следующего платежа в Unixtime (если status = active)
		/// </summary>
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

		/// <summary>
		/// Дата истечения триал-периода (если есть)
		/// </summary>
		[JsonProperty(propertyName: "trial_expire_time")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? TrialExpireTime { get; set; }

		/// <summary>
		/// true, если подписка ожидает отмены.
		/// </summary>
		[JsonProperty(propertyName: "pending_cancel")]
		public bool PendingCancel { get; set; }

		/// <summary>
		/// Причина отмены (если есть). Возможные значения:
		/// user_decision — по инициативе пользователя;
		/// app_decision — по инициативе приложения;
		/// payment_fail — из-за проблемы с платежом;
		/// unknown — причина неизвестна.
		/// </summary>
		[JsonProperty(propertyName: "cancel_reason")]
		public CancelSubscriptionReason CancelReason { get; set; }

		/// <summary>
		/// true, если используется тестовый режим.
		/// </summary>
		[JsonProperty(propertyName: "test_mode")]
		public bool TestMode { get; set; }
	}
}