using System;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// ����� Uri � ��������� � ��������� �����������.
/// ������������ � User
/// </summary>
[Serializable]
public class Previews
{
	/// <summary>
	/// Uri ���������� ����������, ������� ������ 50 ��������.
	/// </summary>
	[JsonProperty("photo_50")]
	public Uri Photo50 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������ 100 ��������.
	/// </summary>
	[JsonProperty("photo_100")]
	public Uri Photo100 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������ 130 ��������.
	/// </summary>
	[JsonProperty("photo_130")]
	public Uri Photo130 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������ 200 ��������.
	/// </summary>
	[JsonProperty("photo_200")]
	public Uri Photo200 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������ 400 ��������.
	/// </summary>
	[JsonProperty("photo_400_orig")]
	public Uri Photo400 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������������ ������.
	/// </summary>
	[JsonProperty("photo_max")]
	public Uri PhotoMax { get; set; }

	/// <summary>
	/// Gets or sets the photo.
	/// </summary>
	[JsonProperty("photo")]
	public Photo Photo { get; set; }


	[JsonProperty("photo_medium")]
	private Uri PhotoMedium
	{
		get => Photo100;
		set => Photo100 = value;
	}

	[JsonProperty("photo_200_orig")]
	private Uri Photo200Orig
	{
		get => Photo200;
		set => Photo200 = value;
	}

	#region ������

	/// <summary>
	/// ��������� �� json.
	/// </summary>
	/// <param name="response"> ����� �������. </param>
	/// <returns> </returns>
	public static Previews FromJson(VkResponse response)
	{
		var previews = new Previews
		{
			Photo50 = response[key: "photo_50"],
			Photo100 = response[key: "photo_100"] ?? response[key: "photo_medium"],
			Photo130 = response[key: "photo_130"],
			Photo200 = response[key: "photo_200"] ?? response[key: "photo_200_orig"],
			Photo400 = response[key: "photo_400_orig"]
		};

		if (response.ContainsKey(key: "photo"))
		{
			if (Uri.IsWellFormedUriString(response[key: "photo"]
					.ToString(), UriKind.Absolute))
			{
				previews.Photo50 = response[key: "photo"];
			} else
			{
				previews.Photo = response[key: "photo"];
			}
		}

		previews.PhotoMax = response[key: "photo_max"]
							?? response[key: "photo_max_orig"]
							?? response[key: "photo_big"]
							?? previews.Photo400 ?? previews.Photo200 ?? previews.Photo100 ?? previews.Photo50;

		return previews;
	}

	#endregion
}