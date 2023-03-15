using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// платёж через VK Pay
/// </summary>
[Serializable]
public class VkPayTransaction : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя-отправителя перевода.
	/// </summary>
	[JsonProperty("from_id")]
	public long? FromId { get; set; }

	/// <summary>
	/// Cумма перевода в тысячных рубля.
	/// </summary>
	[JsonProperty("amount")]
	public long Amount { get; set; }

	/// <summary>
	/// Комментарий к переводу.
	/// </summary>
	[CanBeNull]
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Время отправки перевода в Unixtime.
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("date")]
	public DateTime Date { get; set; }
}