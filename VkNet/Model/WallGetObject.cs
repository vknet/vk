using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения запроса получения записей со стены
	/// </summary>
	public class WallGetObject
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		public ulong TotalCount { get; set; }
		/// <summary>
		/// Посты.
		/// </summary>
		public ReadOnlyCollection<Post> WallPosts
		{ get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		public ReadOnlyCollection<User> Profiles
		{ get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		public ReadOnlyCollection<Group> Groups
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static WallGetObject FromJson(VkResponse response)
		{
			var wallGetObject = new WallGetObject
			{
				TotalCount = response["count"],
				WallPosts = response["items"].ToReadOnlyCollectionOf<Post>(r => r),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(r => r),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(r => r)
			};

			return wallGetObject;
		}
	}
}