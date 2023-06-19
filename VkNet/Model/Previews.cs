using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// ����� Uri � ��������� � ��������� �����������.
/// ������������ � User
/// </summary>
[Serializable]
[JsonConverter(typeof(PhotoJsonConverter))]
public class Previews
{
	/// <summary>
	/// url квадратной фотографии пользователя, имеющей ширину 50 пикселей. В случае
	/// отсутствия у пользователя фотографии
	/// возвращается http://vk.com/images/camera_c.gif
	/// </summary>
	[JsonProperty("photo_50")]
	public Uri Photo50 { get; set; }

	/// <summary>
	/// url квадратной фотографии пользователя, имеющей ширину 100 пикселей. В случае
	/// отсутствия у пользователя фотографии
	/// возвращается http://vk.com/images/camera_b.gif.
	/// </summary>
	[JsonProperty("photo_100")]
	public Uri Photo100 { get; set; }

	/// <summary>
	/// Uri ���������� ����������, ������� ������ 130 ��������.
	/// </summary>
	[JsonProperty("photo_130")]
	public Uri Photo130 { get; set; }

	/// <summary>
	/// url квадратной фотографии пользователя, имеющей ширину 200 пикселей. Если
	/// фотография была загружена давно,
	/// изображения с такими размерами может не быть, в этом случае ответ не будет
	/// содержать этого поля.
	/// </summary>
	[JsonProperty("photo_200")]
	public Uri Photo200 { get; set; }

	/// <summary>
	/// url фотографии пользователя, имеющей ширину 400 пикселей.
	/// Если у пользователя отсутствует фотография такого размера, ответ не будет
	/// содержать этого поля.
	/// </summary>
	[JsonProperty("photo_400_orig")]
	public Uri Photo400 { get; set; }

	/// <summary>
	/// url квадратной фотографии пользователя с максимальной шириной.
	/// Может быть возвращена фотография, имеющая ширину как 200, так и 100 пикселей.
	/// В случае отсутствия у пользователя фотографии возвращается
	/// http://vk.com/images/camera_b.gif.
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
}