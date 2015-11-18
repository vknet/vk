using System.Collections.ObjectModel;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Расширеный объект видео для закладок
	/// </summary>
	public class FaveVideoEx
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		public long Count { get; set; }
		/// <summary>
		/// Видеозаписи.
		/// </summary>
		public ReadOnlyCollection<Video> Video
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
		internal static FaveVideoEx FromJson(VkResponse response)
		{
			var wallGetObject = new FaveVideoEx
			{
				Count = response["count"],
				Video = response["items"].ToReadOnlyCollectionOf<Video>(r => r),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(r => r),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(r => r)
			};

			return wallGetObject;
		}
	}
}