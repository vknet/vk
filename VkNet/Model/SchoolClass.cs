using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// ����� � �����
/// </summary>
[Serializable]
public class SchoolClass
{
	/// <summary>
	/// ����� �������������, ������� ����������� ������.
	/// </summary>
	[JsonProperty("class")]
	public long Class { get; set; }

	/// <summary>
	/// ������� ����������� �� ������ �������� ������������.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }
}