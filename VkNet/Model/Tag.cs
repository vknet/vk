using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
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
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// ������ �������: true - ��������������, false - �� ��������������.
		/// </summary>
		public bool? IsViewed { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
		/// ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? X { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
		/// ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? Y { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
		/// ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? X2 { get; set; }

		/// <summary>
		/// ���������� ������������� �������, �� ������� ������� ������� (������� �����
		/// ���� � ������ ������ ����) � ���������.
		/// </summary>
		public decimal? Y2 { get; set; }

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
					Id = response[key: "tag_id"]
					, TaggedName = response[key: "tagged_name"]
					, UserId = response[key: "user_id"] ?? response[key: "uid"]
					, PlacerId = response[key: "placer_id"]
					, Date = response[key: "tag_created"] ?? response[key: "date"]
					, IsViewed = response[key: "viewed"]
					, X = response[key: "x"]
					, Y = response[key: "y"]
					, X2 = response[key: "x2"]
					, Y2 = response[key: "y2"]
			};

			return result;
		}

	#endregion
	}
}