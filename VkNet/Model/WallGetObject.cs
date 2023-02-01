using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат выполнения запроса получения записей со стены
/// </summary>
[Serializable]
public class WallGetObject
{
	/// <summary>
	/// Общее количество записей на стене.
	/// </summary>
	[JsonProperty("count")]
	public ulong TotalCount { get; set; }

		/// <summary>
	/// Посты.
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<Post> WallPosts { get; set; }

	/// <summary>
	/// Профили.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// Группы.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static WallGetObject FromJson(VkResponse response)
	{
		WallGetObject wallGetObject;

		if (response.ContainsKey(key: "items"))
		{
			wallGetObject = new()
			{
				WallPosts = response[key: "items"]
					.ToReadOnlyCollectionOf<Post>(selector: r => r),
				Profiles = response[key: "profiles"]
					.ToReadOnlyCollectionOf<User>(selector: r => r),
				Groups = response[key: "groups"]
					.ToReadOnlyCollectionOf<Group>(selector: r => r),
				TotalCount = response[key: "count"] ?? 1UL
			};
		} else
		{
			wallGetObject = new()
			{
				WallPosts = response.ToReadOnlyCollectionOf<Post>(selector: r => r)
			};

			wallGetObject.TotalCount = (ulong) wallGetObject.WallPosts.Count;
		}

		return wallGetObject;
	}
}