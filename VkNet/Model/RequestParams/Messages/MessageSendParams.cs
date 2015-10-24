using System.Collections.Generic;
using System.Net.Mail;

namespace VkNet.Model.RequestParams.Messages
{
	/// <summary>
	/// Параметры метода messages.send
	/// </summary>
	public class MessageSendParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому отправляется сообщение. целое число.
		/// </summary>
		public long UserId
		{ get; set; }

		/// <summary>
		/// Короткий адрес пользователя (например, illarionov). строка.
		/// </summary>
		public string Domain
		{ get; set; }

		/// <summary>
		/// Идентификатор беседы, к которой будет относиться сообщение. положительное число.
		/// </summary>
		public ulong? ChatId
		{ get; set; }

		/// <summary>
		/// Идентификаторы получателей сообщения (при необходимости отправить сообщение сразу нескольким пользователям). список целых чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<long> UserIds
		{ get; set; }

		/// <summary>
		/// Текст личного cообщения (является обязательным, если не задан параметр attachment) строка.
		/// </summary>
		public string Message
		{ get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки одинакового сообщения. целое число.
		/// </summary>
		public long? Guid
		{ get; set; }

		/// <summary>
		/// Latitude - широта при добавлении местоположения. дробное число.
		/// </summary>
		public double? Lat
		{ get; set; }

		/// <summary>
		/// Longitude - долгота при добавлении местоположения. дробное число.
		/// </summary>
		public double? Longitude
		{ get; set; }

		/// <summary>
		/// Медиавложения к личному сообщению, перечисленные через запятую. строка.
		/// </summary>
		public Attachment Attachment
		{ get; set; }

		/// <summary>
		/// Идентификаторы пересылаемых сообщений, перечисленные через запятую. Перечисленные сообщения отправителя будут отображаться в теле письма у получателя. строка.
		/// </summary>
		public IEnumerable<ulong> ForwardMessages
		{ get; set; }

		/// <summary>
		/// Идентификатор стикера. положительное число.
		/// </summary>
		public uint? StickerId
		{ get; set; }

	}
}
