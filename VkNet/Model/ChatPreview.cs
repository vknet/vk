using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Превью чата
/// </summary>
[Serializable]
public class ChatPreview
{
	/// <summary>
	/// Информация о чате.
	/// </summary>
	[JsonProperty(propertyName: "preview")]
	public ChatPreviewField Preview { get; set; }

	/// <summary>
	/// Массив объектов пользователей
	/// </summary>
	[JsonProperty(propertyName: "profiles")]
	public IEnumerable<User> Profiles { get; set; }

	/// <summary>
	/// Массив объектов сообществ
	/// </summary>
	[JsonProperty(propertyName: "groups")]
	public IEnumerable<Group> Groups { get; set; }

	/// <summary>
	/// Массив объектов, описывающих e-mail.
	/// </summary>
	[JsonProperty(propertyName: "emails")]
	public IEnumerable<Email> Emails { get; set; }
}