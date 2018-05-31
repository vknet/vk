using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class MessagesSendResult
	{
		/// <summary>
		/// Идентификатор назначения;
		/// </summary>
		public int? PeerId { get; set; }

		/// <summary>
		/// Идентификатор сообщения
		/// </summary>
		public int? MessageId { get; set; }

		/// <summary>
		/// Cообщение об ошибке, если сообщение не было доставлено получателю.
		/// </summary>
		public string Error { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MessagesSendResult FromJson(VkResponse response)
		{
			return new MessagesSendResult
			{
					PeerId = response[key: "peer_id"]
					, MessageId = response[key: "message_id"]
					, Error = response[key: "error"]
			};
		}
	}
}