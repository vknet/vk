using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ������������ ������ �� ���� (��������� / ��)
	/// </summary>
	public class FriendOnline
	{
		/// <summary>
		/// Online � ��
		/// </summary>
		public ReadOnlyCollection<long> Online { get; set; }

		/// <summary>
		/// Online � ���������� ����������.
		/// </summary>
		public ReadOnlyCollection<long> MobileOnline { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response">����� �������.</param>
		/// <returns></returns>
		internal static FriendOnline FromJson(VkResponse response)
		{
			VkResponseArray mobile = response["online_mobile"];
			VkResponseArray pc = response["online"];
			var item = new FriendOnline
			{
				MobileOnline = mobile.ToReadOnlyCollectionOf<long>(x => x),
				Online = pc.ToReadOnlyCollectionOf<long>(x => x)
			};

			return item;
		}
	}
}