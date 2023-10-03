#nullable enable
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.BotsLongPoll;

/// <summary>
/// Обёртка для GroupUpdate, в которой кроме самого обновления есть и ошибки при парсинге.
/// </summary>
public class GroupUpdateEvent
{
	/// <summary>
	/// Обновление группы
	/// </summary>
	public GroupUpdate? Update = null;

	/// <summary>
	/// Ошибка парсинга обновления группы
	/// </summary>
	public System.Exception? Exception = null;

	/// <summary>
	/// Обновление группы в JObject
	/// </summary>
	public JObject RawUpdate;
}