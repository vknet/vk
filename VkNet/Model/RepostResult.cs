using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса wall.Repost
	/// </summary>
	[Serializable]
	public class RepostResult
	{
		/// <summary>
		/// всегда содержит 1;
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// идентификатор созданной записи;
		/// </summary>
		public long? PostId { get; set; }

		/// <summary>
		/// количество репостов объекта с учетом осуществленного;
		/// </summary>
		public int? RepostsCount { get; set; }

		/// <summary>
		/// число отметок «Мне нравится» у объекта.
		/// </summary>
		public int? LikesCount { get; set; }

	#region ������

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response"> ����� �������. </param>
		/// <returns> </returns>
		public static RepostResult FromJson(VkResponse response)
		{
			var result = new RepostResult
			{
					Success = response[key: "success"]
					, PostId = response[key: "post_id"]
					, RepostsCount = response[key: "reposts_count"]
					, LikesCount = response[key: "likes_count"]
			};

			return result;
		}

	#endregion
	}
}