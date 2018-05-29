using System;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода Message.GetHistory
	/// http://vk.com/dev/messages.getHistory
	/// </summary>
	[Serializable]
	public class MessagesGetHistoryParams
	{
		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества сообщений,
		/// должен быть 0 или положительным, если не передан параметр start_message_id, и
		/// должен быть 0 или отрицательным, если
		/// передан.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество сообщений, которое необходимо получить (но не более 200)
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Идентификатор пользователя, историю переписки с которым необходимо вернуть.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор назначения.
		/// </summary>
		public long? PeerId { get; set; }

		/// <summary>
		/// Если значение > 0, то это идентификатор сообщения, начиная с которого нужно
		/// вернуть историю переписки,
		/// если же передано значение -1, то к значению параметра offset прибавляется
		/// количество входящих непрочитанных
		/// сообщений в конце диалога
		/// </summary>
		public long? StartMessageId { get; set; }

		/// <summary>
		/// Возвращать сообщения в хронологическом порядке или обратном (по умолчанию в
		/// обратном). Недоступен при переданном
		/// start_message_id.
		/// </summary>
		public bool? Reversed { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(MessagesGetHistoryParams p)
		{
			return new VkParameters
			{
					{ "offset", p.Offset }
					, { "count", p.Count }
					, { "user_id", p.UserId }
					, { "peer_id", p.PeerId }
					, { "start_message_id", p.StartMessageId }
					, { "rev", p.Reversed }
			};
		}
	}
}