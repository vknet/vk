using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат запроса Friends.FriendOnline
/// </summary>
[Serializable]
public class FriendOnline
{
	/// <summary>
	/// Online
	/// </summary>
	[JsonProperty("online")]
	public ReadOnlyCollection<long> Online { get; set; }

	/// <summary>
	/// Online с мобильного телефона.
	/// </summary>
	[JsonProperty("online_mobile")]
	public ReadOnlyCollection<long> MobileOnline { get; set; }
}