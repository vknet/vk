using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Расширенный объект видео для закладок
	/// </summary>
	public class FaveVideoEx
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }
		/// <summary>
		/// Видеозаписи.
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<Video> Videos
		{ get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles
		{ get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static FaveVideoEx FromJson(VkResponse response)
		{
			var wallGetObject = new FaveVideoEx
			{
				Count = response["count"],
				Videos = response["items"].ToReadOnlyCollectionOf<Video>(r => r),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(r => r),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(r => r)
			};

			return wallGetObject;
		}
	}
}