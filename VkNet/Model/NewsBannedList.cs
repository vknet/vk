using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Список забаненых новостей.
	/// </summary>
	public class NewsBannedList
	{
		/// <summary>
		/// В поле groups содержится массив идентификаторов сообществ, которые пользователь скрыл из ленты новостей.
		/// </summary>
		public ReadOnlyCollection<ulong> Groups
		{ get; set; }

		/// <summary>
		/// В поле members содержится массив идентификаторов друзей, которые пользователь скрыл из ленты новостей.
		/// </summary>
		public ReadOnlyCollection<ulong> Members
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsBannedList FromJson(VkResponse response)
		{
			VkResponseArray names = response["groups"];
			VkResponseArray members = response["members"];
			var bannedList = new NewsBannedList
			{
				Groups = names.ToReadOnlyCollectionOf<ulong>(x => x),
				Members = members.ToReadOnlyCollectionOf<ulong>(x => x)
			};

			return bannedList;
		}
	}
}
