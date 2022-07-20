using System;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода Messages.Get
	/// </summary>
	[Serializable]
	public class MessagesGetParams
	{
		/// <summary>
		/// Количество сообщений, которое необходимо получить.
		/// (по умолчанию 20, максимальное значение 200)
		/// </summary>
		public uint Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества сообщений
		/// </summary>
		public ulong? Offset { get; set; }

		/// <summary>
		/// Максимальное время, прошедшее с момента отправки сообщения до текущего момента
		/// в секундах.
		/// 0, если Вы хотите получить сообщения любой давности.
		/// </summary>
		public ulong? TimeOffset { get; set; }

		/// <summary>
		/// Фильтр возвращаемых сообщений.
		/// </summary>
		public MessagesFilter? Filters { get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не
		/// обрезаются).
		/// </summary>
		public uint? PreviewLength { get; set; }

		/// <summary>
		/// Идентификатор сообщения, полученного перед тем, которое нужно вернуть последним
		/// (при условии, что после него было получено не более count сообщений, иначе
		/// необходимо использовать с параметром
		/// offset)
		/// </summary>
		public long? LastMessageId { get; set; }
	}
}