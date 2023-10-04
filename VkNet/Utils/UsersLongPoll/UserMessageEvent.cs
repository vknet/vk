#nullable enable
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.UsersLongPoll;

/// <summary>
/// Обёртка для Message, в которой кроме самого сообщения есть и ошибки при парсинге.
/// </summary>
public class UserMessageEvent
{
	/// <summary>
	/// Сообщение
	/// </summary>
	public Message? Message = null;

	/// <summary>
	/// Ошибка парсинга сообщения
	/// </summary>
	public System.Exception? Exception = null;

	/// <summary>
	/// Сообщение в JObject
	/// </summary>
	public JObject RawMessage;
}