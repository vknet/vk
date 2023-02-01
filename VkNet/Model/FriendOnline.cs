using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static FriendOnline FromJson(VkResponse response)
	{
		if (response.ContainsKey(key: "online"))
		{
			return new()
			{
				MobileOnline = response[key: "online_mobile"]
					.ToReadOnlyCollectionOf<long>(selector: x => x),
				Online = response[key: "online"]
					.ToReadOnlyCollectionOf<long>(selector: x => x)
			};
		}

		return new()
		{
			Online = response.ToReadOnlyCollectionOf<long>(selector: x => x)
		};
	}
}