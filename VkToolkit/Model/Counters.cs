using VkToolkit.Utils;

namespace VkToolkit.Model
{
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
        /// Количество заметок.
        /// </summary>
        public int? Notes { get; set; }
        /// <summary>
        /// Количество фотографий.
        /// </summary>
        public int? Photos { get; set; }
        /// <summary>
        /// Количество сообществ.
        /// </summary>
        public int? Groups { get; set; }
        /// <summary>
        /// Количество друзей.
        /// </summary>
        public int? Friends { get; set; }
        /// <summary>
        /// Количество друзей онлайн.
        /// </summary>
        public int? OnlineFriends { get; set; }
        /// <summary>
        /// Количество общих друзей.
        /// </summary>
        public int? MutualFriends { get; set; }
        /// <summary>
        /// Количество фотографий с пользователем.
        /// </summary>
        public int? UserPhotos { get; set; }
        /// <summary>
        /// Количество видеозаписей с пользователем.
        /// </summary>
        public int? UserVideos { get; set; }
        /// <summary>
        /// Количество подписчиков.
        /// </summary>
        public int? Followers { get; set; }
        /// <summary>
        /// Количество подписок (только пользователи).
        /// </summary>
        public int? Subscriptions { get; set; }
        /// <summary>
        /// Количество публичных страниц, на которые подписан пользователь.
        /// </summary>
        public int? Pages { get; set; }

        internal static Counters FromJson(VkResponse counters)
        {
            var result = new Counters();

            result.Albums = counters["albums"];
            result.Videos = counters["videos"];
            result.Audios = counters["audios"];
            result.Notes = counters["notes"];
            result.Photos = counters["photos"];
            result.Groups = counters["groups"];
            result.Friends = counters["friends"];
            result.OnlineFriends = counters["online_friends"];
            result.MutualFriends = counters["mutual_friends"];
            result.UserPhotos = counters["user_photos"];
            result.UserVideos = counters["user_videos"];
            result.Followers = counters["followers"];
            result.Subscriptions = counters["subscriptions"];
            result.Pages = counters["pages"];

            return result;
        }
    }
}