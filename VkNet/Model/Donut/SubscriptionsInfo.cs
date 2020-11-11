using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Subscriptions
	/// </summary>
	[Serializable]
	public class SubscriptionsInfo
	{
		/// <summary>
		/// Массив объектов подписок.
		/// </summary>
		[JsonProperty("subscritions")]
		public VkCollection<Subscription> Subscriptions { get; set; }

		/// <summary>
		/// Количество подписок.
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов пользователей.
		/// </summary>
		[JsonProperty("profiles")]
		public VkCollection<User> Profiles { get; set; }

		/// <summary>
		/// Массив объектов сообществ.
		/// </summary>
		[JsonProperty("groups")]
		public VkCollection<Group> Groups { get; set; }

		public static SubscriptionsInfo FromJson(VkResponse response)
		{
			var subscriptions = new SubscriptionsInfo
			{
				Subscriptions = response[key: "subscritions"].ToVkCollectionOf<Subscription>(selector: r => r),
				Count = response[key: "count"],
				Profiles = response[key: "profiles"].ToVkCollectionOf<User>(selector: r => r),
				Groups = response[key: "groups"].ToVkCollectionOf<Group>(selector: r => r)
			};

			return subscriptions;
		}
	}
}
