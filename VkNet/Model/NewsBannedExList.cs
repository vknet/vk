using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Расширеный список забаненых новостей.
	/// </summary>
	[Serializable]
	public class NewsBannedExList
	{
		/// <summary>
		/// В поле groups содержится массив идентификаторов сообществ, которые пользователь
		/// скрыл из ленты новостей.
		/// </summary>
		public ReadOnlyCollection<Group> Groups { get; set; }

		/// <summary>
		/// В поле members содержится массив идентификаторов друзей, которые пользователь
		/// скрыл из ленты новостей.
		/// </summary>
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsBannedExList FromJson(VkResponse response)
		{
			VkResponseArray names = response[key: "groups"];
			VkResponseArray profiles = response[key: "profiles"];

			var bannedList = new NewsBannedExList
			{
					Groups = names.ToReadOnlyCollectionOf<Group>(selector: x => x)
					, Profiles = profiles.ToReadOnlyCollectionOf<User>(selector: x => x)
			};

			return bannedList;
		}
	}
}