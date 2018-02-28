using System;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения запроса получения записей со стены
	/// </summary>
	[Serializable]
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
		public static WallGetObject FromJson(VkResponse response)
		{
			WallGetObject wallGetObject;
			if (response.ContainsKey("items"))
			{
			    wallGetObject = new WallGetObject
			    {
			        WallPosts = response["items"].ToReadOnlyCollectionOf<Post>(r => r),
			        Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(r => r),
			        Groups = response["groups"].ToReadOnlyCollectionOf<Group>(r => r),
			        TotalCount = response["count"] ?? 1UL
			    };
			}
			else
			{
				wallGetObject = new WallGetObject
				{
					WallPosts = response.ToReadOnlyCollectionOf<Post>(r => r)

                };
			    wallGetObject.TotalCount = (ulong) wallGetObject.WallPosts.Count;
			}

			return wallGetObject;
		}
	}
}