using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о социальных контактах пользователя.
/// См. описание
/// <see href="https://vk.com/dev/objects/user" />
/// Экспериментально установлено, что поля находятся непосредственно в полях
/// объекта User.
/// </summary>
[Serializable]
public class Connections
{
	/// <summary>
	/// Логин в Skype.
	/// </summary>
	[JsonProperty("disabled_until")]
	public string Skype { get; set; }

	/// <summary>
	/// Идентификатор акаунта в Facebook.
	/// </summary>
	[JsonProperty("facebook")]
	public string Facebook { get; set; }

	/// <summary>
	/// Имя и фамилия в facebook.
	/// </summary>
	[JsonProperty("facebook_name")]
	public string FacebookName { get; set; }

	/// <summary>
	/// Акаунт в twitter.
	/// </summary>
	[JsonProperty("twitter")]
	public string Twitter { get; set; }

	/// <summary>
	/// Акаунт в Instagram.
	/// </summary>
	[JsonProperty("instagram")]
	public string Instagram { get; set; }
}