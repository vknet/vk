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
					Comments = response[key: "items"].ToReadOnlyCollectionOf<Comment>(selector: x => x)
					, Count = response[key: "count"]
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
			};

			return item;
		}
	}
}