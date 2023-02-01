using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// ������� � �����������.
/// </summary>
[DebuggerDisplay(value: "Id = {Id}, TaggedName = {TaggedName}")]
[Serializable]
public class Tag
{
	/// <summary>
	/// ������������� �������.
	/// </summary>
	[JsonProperty("tag_id")]
	public long? Id { get; set; }

	/// <summary>
	/// �������� �������.
	/// </summary>
	[JsonProperty("tagged_name")]
	public string TaggedName { get; set; }

	/// <summary>
	/// ������������� ������������, �������� ������������� �������.
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// ������������� ������������, ���������� �������.
	/// </summary>
	[JsonProperty("placer_id")]
	public long? PlacerId { get; set; }

	/// <summary>
	/// ���� ���������� �������.
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? Date { get; set; }

	/// <summary>
	/// ������ �������: true - ��������������, false - �� ��������������.
	/// </summary>
	[JsonProperty("viewed")]
	public bool? IsViewed { get; set; }

	/// <summary>
	/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
	/// ���� � ������ ������ ����) � ���������.
	/// </summary>
	[JsonProperty("x")]
	public decimal? X { get; set; }

	/// <summary>
	/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
	/// ���� � ������ ������ ����) � ���������.
	/// </summary>
	[JsonProperty("y")]
	public decimal? Y { get; set; }

	/// <summary>
	/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
	/// ���� � ������ ������ ����) � ���������.
	/// </summary>
	[JsonProperty("x2")]
	public decimal? X2 { get; set; }

	/// <summary>
	/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
	/// ���� � ������ ������ ����) � ���������.
	/// </summary>
	[JsonProperty("v2")]
	public decimal? Y2 { get; set; }

	[JsonProperty("uid")]
	private long? Uid
	{
		get => Id;
		set => Id = value;
	}

	[JsonProperty("tag_created")]
	private DateTime? TagCreated
	{
		get => Date;
		set => Date = value;
	}

	#region ������

	/// <summary>
	/// ��������� �� json.
	/// </summary>
	/// <param name="response"> ����� �������. </param>
	/// <returns> </returns>
	public static Tag FromJson(VkResponse response)
	{
		var result = new Tag
		{
			Id = response[key: "tag_id"],
			TaggedName = response[key: "tagged_name"],
			UserId = response[key: "user_id"] ?? response[key: "uid"],
			PlacerId = response[key: "placer_id"],
			Date = response[key: "tag_created"] ?? response[key: "date"],
			IsViewed = response[key: "viewed"],
			X = response[key: "x"],
			Y = response[key: "y"],
			X2 = response[key: "x2"],
			Y2 = response[key: "y2"]
		};

		return result;
	}

	#endregion
}