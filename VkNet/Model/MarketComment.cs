using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// ����������� � ������
/// </summary>
[Serializable]
public class MarketComment
{
	/// <summary>
	/// ������ ������������.
	/// </summary>
	[JsonProperty("items")]
	public ReadOnlyCollection<Comment> Comments { get; set; }

	/// <summary>
	/// ���������� ������������.
	/// </summary>
	[JsonProperty("count")]
	public long Count { get; set; }

	/// <summary>
	/// ������ �������������.
	/// </summary>
	[JsonProperty("profiles")]
	public ReadOnlyCollection<User> Profiles { get; set; }

	/// <summary>
	/// ������ ���������.
	/// </summary>
	[JsonProperty("groups")]
	public ReadOnlyCollection<Group> Groups { get; set; }

	/// <summary>
	/// ��������� �� json.
	/// </summary>
	/// <param name="response"> ����� �������. </param>
	/// <returns> </returns>
	public static MarketComment FromJson(VkResponse response)
	{
		var item = new MarketComment
		{
			Comments = JsonConvert.DeserializeObject<ReadOnlyCollection<Comment>>(response["items"].ToString()),
			Count = response["count"],
			Profiles = response["profiles"]
				.ToReadOnlyCollectionOf<User>(x => x),
			Groups = response["groups"]
				.ToReadOnlyCollectionOf<Group>(x => x)
		};

		return item;
	}
}