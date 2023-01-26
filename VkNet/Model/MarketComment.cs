using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

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
}