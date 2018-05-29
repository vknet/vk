using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
    /// <summary>
    /// данные о сообществе.
    /// </summary>
    [Serializable]
    public class SearchGroup
    {
        /// <summary>
        /// идентификатор сообщества
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// название сообщества
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// короткий адрес
        /// </summary>
        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        /// <summary>
        /// информация о том, является ли группа/встреча закрытой (0 — открытая, 1 — закрытая, 2 — частная)
        /// </summary>
        [JsonProperty("is_closed")]
        public GroupAccess IsClosed { get; set; }

        /// <summary>
        /// информация о том, является ли текущий пользователь администратором сообщества (1 — является, 0 — не является);
        /// </summary>
        [JsonProperty("is_admin")]
        public bool? IsAdmin { get; set; }

        /// <summary>
        /// информация о том, является ли текущий пользователь участником сообщества (1 — является, 0 — не является)
        /// </summary>
        [JsonProperty("is_member")]
        public bool? IsMember { get; set; }

        /// <summary>
        /// тип сообщества
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public GroupType Type { get; set; }

        /// <summary>
        /// URL квадратной фотографии сообщества с размером 50х50px
        /// </summary>
        [JsonProperty("photo")]
        public string Photo { get; set; }

        /// <summary>
        /// URL квадратной фотографии сообщества с размером 50х50px
        /// </summary>
        [JsonProperty("photo_50")]
        private string Photo50
		{
			get { return Photo; }
			set { Photo = value; }
		}

		/// <summary>
        /// URL квадратной фотографии сообщества с размером 100х100px
        /// </summary>
        [JsonProperty("photo_medium")]
        public string PhotoMedium { get; set; }

        /// <summary>
        /// URL квадратной фотографии сообщества с размером 100х100px
        /// </summary>
        [JsonProperty("photo_100")]
        private string Photo100
		{
			get { return PhotoMedium; }
			set { PhotoMedium = value; }
		}

		/// <summary>
        /// URL фотографии сообщества в максимальном доступном размере.
        /// </summary>
        [JsonProperty("photo_big")]
        public string PhotoBig { get; set; }

        /// <summary>
        /// URL фотографии сообщества в максимальном доступном размере.
        /// </summary>
        [JsonProperty("photo_200")]
        public string Photo200
		{
			get { return PhotoBig; }
			set { PhotoBig = value; }
		}
	}
}