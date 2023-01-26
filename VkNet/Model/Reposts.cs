using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о репостах записи.
/// См. описание http://vk.com/dev/post
/// </summary>
[Serializable]
public class Reposts
{
	/// <summary>
	/// Число пользователей, скопировавших запись.
	/// </summary>
	[JsonProperty("count")]
	public int Count { get; set; }

	/// <summary>
	/// Наличие репоста от текущего пользователя .
	/// </summary>
	[JsonProperty("user_reposted")]
	public bool UserReposted { get; set; }
}