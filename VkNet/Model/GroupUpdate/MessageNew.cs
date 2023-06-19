using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Объект, который содержит сообщение и информацию о доступных пользователю функциях.
/// </summary>
[Serializable]
public class MessageNew : IGroupUpdate
{
	/// <summary>
	/// Сообщение.
	/// </summary>
	[JsonProperty("message")]
	public Message Message { get; set; }

	/// <summary>
	/// Информация о доступных пользователю функциях.
	/// </summary>
	[JsonProperty("client_info")]
	public ClientInfo ClientInfo { get; set; }
}