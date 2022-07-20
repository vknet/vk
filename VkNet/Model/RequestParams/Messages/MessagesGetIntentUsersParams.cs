using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Messages
{
	/// <summary>
	/// Параметры метода messages.getIntentUsers
	/// </summary>
	[Serializable]
	public class MessagesGetIntentUsersParams
	{
		/// <summary>
		/// Тип интента, который требует подписку:
		/// promo_newsletter
		/// non_promo_newsletter
		/// confirmed_notification
		/// строка, обязательный параметр
		/// </summary>
		[JsonProperty("intent")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public MessageIntent Intent { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("name_case")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание.
		/// Доступные значения: photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me, can_be_invited_group. список слов, разделенных через запятую
		/// </summary>
		[JsonProperty("fields")]
		public UsersFields Fields { get; set; }

		/// <summary>
		/// ID подписки, необходимый для confirmed_notification положительное число, максимальное значение 100
		/// </summary>
		[JsonProperty("subscribe_id")]
		public ulong SubscribeId { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества. положительное число, по умолчанию 0
		/// </summary>
		[JsonProperty("offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество подписчиков, информацию о которых необходимо получить положительное число, по умолчанию 20, максимальное значение 200
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительные для профилей. По умолчанию: 0. флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("extended")]
		public bool Extended { get; set; }
	}
}