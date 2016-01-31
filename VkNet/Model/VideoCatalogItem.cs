using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ������� ����� �������������
	/// </summary>
	public class VideoCatalogItem
	{
		/// <summary>
		/// ������������� ��������. ������������� �����.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// ������������� ��������� ��������. int (�������� ��������).
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// ���������. ������.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// ��� ��������. ����� ��������� ��������: video � ����������; album � ������. ������.
		/// </summary>
		public VideoCatalogItemType Type { get; set; }


		/// <summary>
		/// ������������ � ��������. ������������� �����.
		/// </summary>
		public long? Duration { get; set; }

		/// <summary>
		/// ��������. ������.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// ���� ����������. ������������� �����.
		/// </summary>
		public long? Date { get; set; }

		/// <summary>
		/// ����� ����������. ������������� �����.
		/// </summary>
		public long? Views { get; set; }

		/// <summary>
		/// ����� ������������. ������������� �����.
		/// </summary>
		public long? Comments { get; set; }

		/// <summary>
		/// URL �����������-������� ����� � �������� 130x98px.������.
		/// </summary>
		public Uri Photo130 { get; set; }

		/// <summary>
		/// URL �����������-������� ����� � �������� 320x240px. ������.
		/// </summary>
		public Uri Photo320 { get; set; }

		/// <summary>
		/// URL �����������-������� ����� � �������� 640x480px (���� ������ ����). ������.
		/// </summary>
		public Uri Photo640 { get; set; }

		/// <summary>
		/// ������� ����������� �������� ����� � ���� ������. ����, ����� ��������� �������� 1 ��� 0.
		/// </summary>
		public bool? CanAdd { get; set; }

		/// <summary>
		/// ������� ����������� ������������� �����. ����, ����� ��������� �������� 1 ��� 0.
		/// </summary>
		public bool? CanEdit { get; set; }


		/// <summary>
		/// ����� ������������ � �������. ������������� �����.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// URL �����������-������� ������� � �������� 272x150px. ������.
		/// </summary>
		public Uri Photo160 { get; set; }

		/// <summary>
		/// ����� ���������� ���������� �������. ������������� �����.
		/// </summary>
		public long? UpdatedTime { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		internal static VideoCatalogItem FromJson(VkResponse response)
		{
			var item = new VideoCatalogItem
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Type = response["type"],

				Duration = response["duration"],
				Description = response["description"],
				Date = response["date"],
				Views = response["views"],
				Comments = response["comments"],
				Photo130 = response["photo_130"],
				Photo320 = response["photo_320"],
				Photo640 = response["photo_640"],
				CanAdd = response["can_add"],
				CanEdit = response["can_edit"],

				Count = response["count"],
				Photo160 = response["photo_160"],
				UpdatedTime = response["updated_time"],
			};

			return item;
		}
	}
}