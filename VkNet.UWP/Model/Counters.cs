using System.Runtime.Serialization;

namespace VkNet.Model
{
	using System;
	using Utils;

	/// <summary>
	/// Количество различных объектов у пользователя.
	/// См. описание <see href="http://vk.com/dev/fields"/> и <see href="http://vk.com/pages?oid=-1&amp;p=Описание_полей_параметра_fields"/> и
	/// <see href="http://vk.com/dev/fields_groups"/>.
	/// Раздел counters.
	/// </summary>
	[DataContract]
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

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Counters FromJson(VkResponse response)
		{
			var counters = new Counters
			{
				Albums = response["albums"],
				Videos = response["videos"],
				Audios = response["audios"],
				Photos = response["photos"],
				Notes = response["notes"],
				Friends = response["friends"],
				Groups = response["groups"],
				OnlineFriends = response["online_friends"],
				MutualFriends = response["mutual_friends"],
				UserVideos = response["user_videos"],
				Followers = response["followers"],
				UserPhotos = response["user_photos"],
				Subscriptions = response["subscriptions"],
				TopicsCount = response["topics"],
				DocumentsCount = response["docs"],
				Pages = response["pages"],
				Messages = response["messages"],
				Gifts = response["gifts"],
				Events = response["events"],
				Notifications = response["notifications"],
				Sdk = response["sdk"],
				AppRequests = response["app_requests"]
			};

			return counters;
		}

		#endregion
	}
}