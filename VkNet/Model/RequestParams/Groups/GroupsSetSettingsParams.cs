using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Параметры метода groups.setSettings
/// </summary>
[Serializable]
public class GroupsSetSettingsParams
{
	/// <summary>
	/// идентификатор сообщества.
	/// положительное число, обязательный параметр
	/// </summary>
	[JsonProperty("group_id")]
	public ulong GroupId { get; set; }

	/// <summary>
	/// сообщения сообщества
	/// </summary>
	[JsonProperty("messages")]
	public bool Messages { get; set; }

	/// <summary>
	/// возможности ботов (использование клавиатуры, добавление в беседу)
	/// </summary>
	[JsonProperty("bots_capabilities")]
	public bool BotsCapabilities { get; set; }

	/// <summary>
	/// кнопка «Начать» в диалоге с сообществом.
	/// Работает, в случае если bots_capabilities=1.
	/// Если эта настройка включена, то при заходе в беседу с Вашим сообществом в
	/// первый раз пользователь увидит кнопку с командой «Начать», которая отправляет
	/// команду start. Payload этого сообщения будет выглядеть так:
	/// {"command":"start"}
	/// </summary>
	[JsonProperty("bots_start_button")]
	public bool BotsStartButton { get; set; }

	/// <summary>
	/// добавление бота в беседы.
	/// Работает, в случае если bots_capabilities=1
	/// </summary>
	[JsonProperty("bots_add_to_chat")]
	public bool BotsAddToChats { get; set; }
}