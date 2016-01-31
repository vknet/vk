using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ��������� ����������� ������ �� ����� � ���������� � ���.
	/// </summary>
	public class RepostResult
	{
		/// <summary>
		/// ��������� �����������
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// ������������� ��������� ������
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// ����� ����������� �������� ������ � ������ ���������������
		/// </summary>
		public int? RepostsCount { get; set; }

		/// <summary>
		/// ����� ������� "��� ��������" � �������� ������
		/// </summary>
		public int? LikesCount { get; set; }


		#region ������
		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		internal static RepostResult FromJson(VkResponse response)
		{
			var result = new RepostResult
			{
				Success = response["success"],
				PostId = response["post_id"],
				RepostsCount = response["reposts_count"],
				LikesCount = response["likes_count"]
			};

			return result;
		}

		#endregion

	}
}