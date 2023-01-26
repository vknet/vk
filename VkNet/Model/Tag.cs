using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
}