namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Количество различных объектов у пользователя. 
    /// См. описание <see cref="http://vk.com/dev/fields"/> и 
    /// <see cref="http://vk.com/pages?oid=-1&p=%D0%9E%D0%BF%D0%B8%D1%81%D0%B0%D0%BD%D0%B8%D0%B5_%D0%BF%D0%BE%D0%BB%D0%B5%D0%B9_%D0%BF%D0%B0%D1%80%D0%B0%D0%BC%D0%B5%D1%82%D1%80%D0%B0_fields"/>. 
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

        // ------ Установлено в результате экспериментов ------

        /// <summary>
        /// Количество публичных страниц, на которые подписан пользователь.
        /// </summary>
        public int? Pages { get; set; }

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

            counters.Pages = response["pages"]; // установлено экcпериментальным путем

            return counters;
        }

        #endregion
    }
}