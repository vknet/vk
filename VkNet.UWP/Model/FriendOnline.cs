using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Пользователи онлайн по типу (мобильные / пк)
	/// </summary>
	public class FriendOnline
	{
		/// <summary>
		/// Online с ПК
		/// </summary>
		public ReadOnlyCollection<long> Online { get; set; }

		/// <summary>
		/// Online с мобильного устройства.
		/// </summary>
		public ReadOnlyCollection<long> MobileOnline { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static FriendOnline FromJson(VkResponse response)
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