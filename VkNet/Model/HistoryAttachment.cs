using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Вложения материалов диалога или беседы
	/// </summary>
	[Serializable]
	public class HistoryAttachment
	{
		/// <summary>
		/// Идентификатор сообщения, в котором было отправлено вложение.
		/// </summary>
		public int MessageId { get; set; }

		/// <summary>
		/// Информация о вложении.
		/// </summary>
		public Attachment Attachment { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static HistoryAttachment FromJson(VkResponse response)
		{
			return new HistoryAttachment
			{
					MessageId = response[key: "message_id"]
					, Attachment = response[key: "attachment"]
			};
		}
	}
}