using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Количество различных объектов у пользователя.
	/// См. описание http://vk.com/dev/fields
	/// http://vk.com/dev/fields_groups
	/// Раздел counters.
	/// </summary>
	[Serializable]
	public class Counters
	{
		/// <summary>
		/// Количество фотоальбомов.
		/// </summary>
		public int? Albums { get; set; }

		/// <summary>
		/// Количество видеозаписей.
		/// </summary>
		public int? Videos { get; set; }

		/// <summary>
		/// Количество аудиозаписей.
		/// </summary>
		public int? Audios { get; set; }

		/// <summary>
		/// Количество фотографий.
		/// </summary>
		public int? Photos { get; set; }

		/// <summary>
		/// Количество заметок.
		/// </summary>
		public int? Notes { get; set; }

		/// <summary>
		/// Количество друзей.
		/// </summary>
		public int? Friends { get; set; }

		/// <summary>
		/// Количество сообществ.
		/// </summary>
		public int? Groups { get; set; }

		/// <summary>
		/// Количество друзей онлайн.
		/// </summary>
		public int? OnlineFriends { get; set; }

		/// <summary>
		/// Количество общих друзей.
		/// </summary>
		public int? MutualFriends { get; set; }

		/// <summary>
		/// Количество видеозаписей с пользователем.
		/// </summary>
		public int? UserVideos { get; set; }

		/// <summary>
		/// Количество подписчиков.
		/// </summary>
		public int? Followers { get; set; }

		/// <summary>
		/// Количество фотографий с пользователем.
		/// </summary>
		public int? UserPhotos { get; set; }

		/// <summary>
		/// Количество подписок (только пользователи).
		/// </summary>
		public int? Subscriptions { get; set; }

		/// <summary>
		/// Количество тем обсуждений сообщества.
		/// </summary>
		public int? TopicsCount { get; set; }

		/// <summary>
		/// Количество документов.
		/// </summary>
		public int? DocumentsCount { get; set; }

	#region Поля, установленные экспериментально

		/// <summary>
		/// Количество публичных страниц, на которые подписан пользователь.
		/// </summary>
		public int? Pages { get; set; }

	#endregion

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Counters FromJson(VkResponse response)
		{
			var counters = new Counters
			{
					Albums = response[key: "albums"]
					, Videos = response[key: "videos"]
					, Audios = response[key: "audios"]
					, Photos = response[key: "photos"]
					, Notes = response[key: "notes"]
					, Friends = response[key: "friends"]
					, Groups = response[key: "groups"]
					, OnlineFriends = response[key: "online_friends"]
					, MutualFriends = response[key: "mutual_friends"]
					, UserVideos = response[key: "user_videos"]
					, Followers = response[key: "followers"]
					, UserPhotos = response[key: "user_photos"]
					, Subscriptions = response[key: "subscriptions"]
					, TopicsCount = response[key: "topics"]
					, DocumentsCount = response[key: "docs"]
					, Pages = response[key: "pages"]
					, Messages = response[key: "messages"]
					, Gifts = response[key: "gifts"]
					, Events = response[key: "events"]
					, Notifications = response[key: "notifications"]
					, Sdk = response[key: "sdk"]
					, AppRequests = response[key: "app_requests"]
			};

			return counters;
		}

	#endregion

	#region	  Счетчики из метода https://vk.com/dev/account.getCounters

		/// <summary>
		/// Количество сообщений
		/// </summary>
		public int? Messages { get; set; }

		/// <summary>
		/// Количество подарков
		/// </summary>
		public int? Gifts { get; set; }

		/// <summary>
		/// Количество событий
		/// </summary>
		public int? Events { get; set; }

		/// <summary>
		/// Количество уведомлений
		/// </summary>
		public int? Notifications { get; set; }

		/// <summary>
		/// SDK.
		/// </summary>
		public int? Sdk { get; set; }

		/// <summary>
		/// Запросов к приложению.
		/// </summary>
		public int? AppRequests { get; set; }

	#endregion
	}
}