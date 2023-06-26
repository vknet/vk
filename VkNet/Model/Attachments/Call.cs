using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Вложение "Звонок".
/// </summary>
[Serializable]
[DebuggerDisplay("[{InitiatorId} - {ReceiverId}: {State}]")]
public class Call : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "call";

	/// <summary>
	/// Идентификатор инициатора звонка.
	/// </summary>
	[JsonProperty("initiator_id")]
	public long InitiatorId { get; set; }

	/// <summary>
	/// Идентификатор получателя звонка.
	/// <remarks>
	/// Для чатов - если инициатором звонка является не тот же самый аккаунт, с которого делается запрос,
	/// это поле содержит Id чата, локальном для инициатора, а не для текущего аккаунта.
	/// Это означает, что получатель звонка может отличаться от Id чата, в который было отправлено сообщение, содержащее звонок.
	/// </remarks>
	/// </summary>
	[JsonProperty("receiver_id")]
	public long ReceiverId { get; set; }

	/// <summary>
	/// Состояние вызова.
	/// <remarks>
	/// Известно только про состояние <b>reached</b>
	/// </remarks>
	/// </summary>
	[JsonProperty("state")]
	public string State { get; set; }

	/// <summary>
	/// Длительность вызова в секундах
	/// </summary>
	[JsonProperty("duration")]
	public long? Duration { get; set; }

	/// <summary>
	/// Время начала звонка.
	/// <remarks>
	/// Обычно совпадает с временем создания соответствующего сообщения.
	/// </remarks>
	/// </summary>
	[JsonProperty("time")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime Time { get; set; }

	/// <summary>
	/// Было ли использовано видео в звонке
	/// </summary>
	[JsonProperty("video")]
	public bool? Video { get; set; }
}