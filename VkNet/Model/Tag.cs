namespace VkNet.Model
{
	using System;
	using System.Diagnostics;

	using Utils;

	/// <summary>
	/// ������� � �����������.
	/// </summary>
	[DebuggerDisplay("Id = {Id}, TaggedName = {TaggedName}")]
	public class Tag
	{
		/// <summary>
		/// ������������� �������.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// �������� �������.
		/// </summary>
		public string TaggedName { get; set; }

		/// <summary>
		/// ������������� ������������, �������� ������������� �������.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// ������������� ������������, ���������� �������.
		/// </summary>
		public long? PlacerId { get; set; }

		/// <summary>
		/// ���� ���������� �������.
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// ������ �������: true - ��������������, false - �� ��������������.
		/// </summary>
		public bool? IsViewed { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? X { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? Y { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? X2 { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? Y2 { get; set; }
		#region ������
		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="tag">����� �������.</param>
		/// <returns></returns>
		internal static Tag FromJson(VkResponse tag)
		{
			var result = new Tag
			{
				Id = tag["tag_id"],
				TaggedName = tag["tagged_name"],
				UserId = tag["uid"],
				PlacerId = tag["placer_id"],
				Date = tag["tag_created"] ?? tag["date"],
				IsViewed = tag["viewed"],
				X = tag["x"],
				Y = tag["y"],
				X2 = tag["x2"],
				Y2 = tag["y2"]
			};

			return result;
		}

		#endregion
	}
}