namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// ����� Url � ��������� � ��������� �����������.
	/// ������������ � <see cref="User"/>, <see cref="Group"/> � <see cref="Message"/>.
	/// </summary>
	[Serializable]
	public class Previews
	{
		/// <summary>
		/// Url ���������� ����������, ������� ������ 50 ��������.
		/// </summary>
		public Uri Photo50 { get; set; }

		/// <summary>
		/// Url ���������� ����������, ������� ������ 100 ��������.
		/// </summary>
		public Uri Photo100 { get; set; }

		/// <summary>
		/// Url ���������� ����������, ������� ������ 130 ��������.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// Url ���������� ����������, ������� ������ 200 ��������.
		/// </summary>
		public Uri Photo200 { get; set; }

		/// <summary>
		/// Url ���������� ����������, ������� ������ 400 ��������.
		/// </summary>
		public Uri Photo400 { get; set; }

		/// <summary>
		/// Url ���������� ����������, ������� ������������ ������.
		/// </summary>
		public Uri PhotoMax { get; set; }

		#region ������
		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		internal static Previews FromJson(VkResponse response)
		{
			var previews = new Previews
			{
				Photo50 = response["photo_50"] ?? response["photo"],
				Photo100 = response["photo_100"] ?? response["photo_medium"],
				Photo130 = response["photo_130"],
				Photo200 = response["photo_200"] ?? response["photo_200_orig"],
				Photo400 = response["photo_400_orig"]
			};

			previews.PhotoMax = response["photo_max"] ?? response["photo_max_orig"] ?? response["photo_big"] ?? previews.Photo400 ?? previews.Photo200 ?? previews.Photo100 ?? previews.Photo50;

			return previews;
		}

		#endregion
	}
}