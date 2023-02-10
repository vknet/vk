using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Расширеный список забаненых новостей.
/// </summary>
[Serializable]
public class NewsBannedExList
{
	/// <summary>
	/// В поле groups содержится массив идентификаторов сообществ, которые пользователь
	/// скрыл из ленты новостей.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }

	/// <summary>
	/// В поле members содержится массив идентификаторов друзей, которые пользователь
	/// скрыл из ленты новостей.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }
}