using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	[Serializable]
	public class AccountGetBannedResult
	{
		/// <summary>
		/// Общее количество записей на стене.
		/// </summary>.
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Посты.
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<User> Items { get; set; }

		/// <summary>
		/// Профили.
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Группы.
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }

		/*/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AccountGetBannedResult FromJson(VkResponse response)
		{
			return new AccountGetBannedResult
			{
				Items = response[key: "items"].ToReadOnlyCollectionOf<User>(selector: r => r),
				Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: r => r),
				Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: r => r),
				TotalCount = response[key: "count"] ?? 1UL
			};
		}*/
	}
}