using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// 
	/// </summary>
	public class WallGetObject
	{
		/// <summary>
		/// Посты.
		/// </summary>
		public ReadOnlyCollection<Post> wallPosts
		{ get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		public ReadOnlyCollection<User> profiles
		{ get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		public ReadOnlyCollection<Group> groups
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
				wallPosts = response["items"].ToReadOnlyCollectionOf<Post>(r => r),
				profiles = response["profiles"].ToReadOnlyCollectionOf<User>(r => r),
				groups = response["groups"].ToReadOnlyCollectionOf<Group>(r => r)
			};

			return wallGetObject;
		}
	}
}