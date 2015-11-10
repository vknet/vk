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

		#endregion

		#region Методы

		internal static Counters FromJson(VkResponse response)
        {
            var counters = new Counters();

            counters.Albums = response["albums"];
            counters.Videos = response["videos"];
            counters.Audios = response["audios"];
            counters.Photos = response["photos"];
            counters.Notes = response["notes"];
            counters.Friends = response["friends"];
            counters.Groups = response["groups"];
            counters.OnlineFriends = response["online_friends"];
            counters.MutualFriends = response["mutual_friends"];
            counters.UserVideos = response["user_videos"];
            counters.Followers = response["followers"];
            counters.UserPhotos = response["user_photos"];
            counters.Subscriptions = response["subscriptions"];
            counters.TopicsCount = response["topics"];
            counters.DocumentsCount = response["docs"];

            counters.Pages = response["pages"]; // установлено экcпериментальным путем

			#region Метод https://vk.com/dev/account.getCounters
			counters.Messages = response["messages"];
			counters.Gifts = response["gifts"];
			counters.Events = response["events"];
			counters.Notifications = response["notifications"];
			#endregion



            return counters;
        }

        #endregion
    }
}