using System;
using Newtonsoft.Json;
using VkNet.Utils;

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

	#region ������

	/// <summary>
	/// ��������� �� json.
	/// </summary>
	/// <param name="response"> ����� �������. </param>
	/// <returns> </returns>
	public static SchoolClass FromJson(VkResponse response)
	{
		var schoolClass = new SchoolClass
		{
			Class = response[key: 0],
			Text = response[key: 1]
		};

		return schoolClass;
	}

	#endregion
}