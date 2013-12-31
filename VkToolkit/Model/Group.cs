namespace VkToolkit.Model
{
    using System;

    using VkToolkit.Enums;
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о сообществе (группе).
    /// См. описание <see cref="http://vk.com/dev/fields_groups"/>.
    /// TODO: Доделать позже.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор сообщества (положительное число).
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название сообщества.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Короткий адрес страницы сообщества, например, apiclub. Если он не назначен, то 'club'+gid, например, club35828305.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Публичность группы.
        /// </summary>
        public GroupPublicity? IsClosed { get; set; }

        /// <summary>
        /// Признак яляется ли текущий пользователь руководителем сообщества.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Уровень административных полномочий текущего пользователя в сообществе (действительно, если IsAdmin = true).
        /// </summary>
        public AdminLevel? AdminLevel { get; set; }

        /// <summary>
        /// Признак является ли текущий пользователь участником сообщества.
        /// </summary>
        public bool? IsMember { get; set; }

        /// <summary>
        /// Тип сообщества.
        /// </summary>
        public GroupType Type { get; set; }

        /// <summary>
        /// Информация о ссылках на предпросмотр фотографий сообщества.
        /// </summary>
        public Previews PhotoPreviews { get; set; }

        // -------------- Опциональные поля ------------------

        /// <summary>
        /// Идентификатор города, указанного в информации о сообществе. Возвращается идентификатор города, который можно использовать для 
        /// получения его названия с помощью метода <see cref="PlacesCategory.GetCityById"/>. Если город не указан, возвращается 0. 
        /// </summary>
        public long? City { get; set; }

        /// <summary>
        /// Идентификатор страны, указанной в информации о сообществе. Возвращается идентификатор страны, который можно использовать для 
        /// получения ее названия с помощью метода <see cref="PlacesCategory.GetCountryById"/>. Если страна не указана, возвращается 0.
        /// </summary>
        public long? Country { get; set; }

        public string Link { get; set; }

        // additional information
        public long? CityId { get; set; }

        public long? CountryId { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public string WikiPage { get; set; }

        #region Методы

        internal static Group FromJson(VkResponse response)
        {
            var group = new Group();

            group.Id = response["gid"];
            group.Name = response["name"];
            group.ScreenName = response["screen_name"];
            group.IsClosed = response["is_closed"];
            group.IsAdmin = response["is_admin"];
            group.AdminLevel = response["admin_level"];
            group.IsMember = response["is_member"];
            group.Type = GetGroupType(response["type"]);
            group.PhotoPreviews = response;

            group.Link = response["link"];
            group.Description = response["description"];
            group.WikiPage = response["wiki_page"];
            group.CityId = response["city"];
            group.CountryId = response["country"];
            group.StartDate = response["start_date"];

            return group;
        }

        internal static GroupType GetGroupType(string type)
        {
            switch (type)
            {
                case "page":
                    return GroupType.Page;
                case "event":
                    return GroupType.Event;
                case "group":
                    return GroupType.Group;
                default:
                    return GroupType.Undefined;
            }
        }

        #endregion
    }
}