using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// ����������� � ������
	/// </summary>
	[Serializable]
	public class MarketComment
	{
		/// <summary>
		/// ������ ������������.
		/// </summary>
		public ReadOnlyCollection<Comment> Comments { get; set; }

		/// <summary>
		/// ���������� ������������.
		/// </summary>
		public long Count { get; set; }

		/// <summary>
		/// ������ �������������.
		/// </summary>
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// ������ ���������.
		/// </summary>
		public ReadOnlyCollection<Group> Groups { get; set; }

		/// <summary>
		/// ��������� �� json.
		/// </summary>
		/// <param name="response"> ����� �������. </param>
		/// <returns> </returns>
		public static MarketComment FromJson(VkResponse response)
		{
			var item = new MarketComment
			{
				Comments = response["items"].ToReadOnlyCollectionOf<Comment>(x => x),
				Count = response["count"],
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x)
			};

			return item;
		}
	}
}