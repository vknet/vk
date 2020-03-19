using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода messages.sendSticker
	/// </summary>
	[Serializable]
	public class MessagesSendStickerParams
	{
		/// <summary>
		/// Идентификатор пользователя. целое число.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Короткий адрес пользователя (например, illarionov). строка.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Идентификатор назначения. целое число.
		/// </summary>
		public long? PeerId { get; set; }

		/// <summary>
		/// Идентификатор беседы, в которую отправляется стикер. положительное число.
		/// </summary>
		public long? ChatId { get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинакового сообщения. Сохраняется
		/// вместе с сообщением и доступен в истории сообщений. целое число, доступен
		/// начиная с версии 5.45.
		/// </summary>
		public long? RandomId { get; set; }

		/// <summary>
		/// Идентификатор стикера. положительное число, обязательный параметр.
		/// </summary>
		public long StickerId { get; set; }
	}
}