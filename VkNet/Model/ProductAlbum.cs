using System;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ������� �������
	/// </summary>
	public class ProductAlbum
	{
		/// <summary>
		/// ������������� ��������. ������������� �����
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// ������������� ��������� ��������. int (�������� ��������)
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// �������� ��������. ������
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// ������� ��������, ������ photo.
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// ����� ������� � ��������; int (�������� ��������)
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// ���� ���������� �������� � ������� unixtime. ������������� �����
		/// </summary>
		public DateTime? UpdatedTime { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		internal static ProductAlbum FromJson(VkResponse response)
		{
			var application = new ProductAlbum
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Photo = response["photo"],
				Count = response["count"],
				UpdatedTime = response["updated_time"]
			};

			return application;
		}
	}
}