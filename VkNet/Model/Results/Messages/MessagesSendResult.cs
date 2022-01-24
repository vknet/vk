using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// результат выполнения запроса messages.send
	/// </summary>
	[Serializable]
	public class MessagesSendResult
	{
		/// <summary>
		/// Идентификатор назначения;
		/// </summary>
		public long? PeerId { get; set; }

		/// <summary>
		/// Идентификатор сообщения
		/// </summary>
		public long? MessageId { get; set; }

		/// <summary>
		/// Код ошибки если есть (в наличии в версии 5.101)
		/// </summary>
		public int ErrorCode { get; set; }

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
			// В новых версиях изменился формат ответа, поддержка для других версий
			var res = new MessagesSendResult();

			if (response.ContainsKey("peer_id"))
				res.PeerId = response[key: "peer_id"];
			if (response.ContainsKey("message_id"))
				res.MessageId = response[key: "message_id"];

			if (response.ContainsKey("error"))
			{
				var error = response[key: "error"];
				if (error.ContainsKey("code"))
				{
					res.ErrorCode = error[key: "code"];
					res.Error = error[key: "description"];
				} else
				{
					try
					{
						res.Error = response[key: "error"];
					}
#pragma warning disable S2486 // Generic exceptions should not be ignored
					catch
					{
						// TODO: ensure no error or handle
					}
#pragma warning restore S2486 // Generic exceptions should not be ignored
				}
			}

			return res;
		}
	}
}