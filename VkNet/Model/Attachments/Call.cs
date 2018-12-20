using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Звонок.
	/// </summary>
	[Serializable]
	[DebuggerDisplay("[{InitiatorId} - {ReceiverId}: {State}]")]
	public class Call : MediaAttachment
	{
		/// <summary>
		/// Звонок.
		/// </summary>
		static Call()
		{
			RegisterType(type: typeof(Call), match: "call");
		}

		/// <summary>
		/// Идентификатор инициатора звонка.
		/// </summary>
		[JsonProperty("initiator_id")]
		public long InitiatorId { get; set; }

		/// <summary>
		/// Идентификатор получателя звонка.
		/// </summary>
		[JsonProperty("receiver_id")]
		public long ReceiverId { get; set; }

		/// <summary>
		/// Тип вызова.
		/// </summary>
		[JsonProperty("state")]
		public string State { get; set; }

		/// <summary>
		/// Время вызова.
		/// </summary>
		[JsonProperty("time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime Time { get; set; }

	#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Call FromJson(VkResponse response)
		{
			var call = new Call
			{
				InitiatorId = response["initiator_id"],
				ReceiverId = response["receiver_id"],
				State = response["state"],
				Time = response["time"]
			};

			return call;
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Call(VkResponse response)
		{
			return response != null && response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}