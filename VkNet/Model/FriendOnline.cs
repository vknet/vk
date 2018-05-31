using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса Friends.FriendOnline
	/// </summary>
	[Serializable]
	public class FriendOnline
	{
		/// <summary>
		/// Online
		/// </summary>
		public ReadOnlyCollection<long> Online { get; set; }

		/// <summary>
		/// Online с мобильного телефона.
		/// </summary>
		public ReadOnlyCollection<long> MobileOnline { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static FriendOnline FromJson(VkResponse response)
		{
			if (response.ContainsKey(key: "online"))
			{
				return new FriendOnline
				{
						MobileOnline = response[key: "online_mobile"].ToReadOnlyCollectionOf<long>(selector: x => x)
						, Online = response[key: "online"].ToReadOnlyCollectionOf<long>(selector: x => x)
				};
			}

			return new FriendOnline
			{
					Online = response.ToReadOnlyCollectionOf<long>(selector: x => x)
			};
		}
	}
}