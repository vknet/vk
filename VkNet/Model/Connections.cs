using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region Методы

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static Connections FromJson(VkResponse response)
	{
		var connections = new Connections
		{
			Skype = response["skype"],
			Facebook = response["facebook"],
			FacebookName = response["facebook_name"],
			Twitter = response["twitter"],
			Instagram = response["instagram"]
		};

		return connections;
	}

	#endregion
}