namespace VkToolkit.Model
{
    using System;
    using System.Collections.Generic;

    using VkToolkit.Enums;
    using VkToolkit.Exception;
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о пользователя.
    /// См. описание <see cref="http://vk.com/dev/fields"/>.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Прозвище (ник) пользователя.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Короткий адрес страницы пользователя. Если он не назначен, то "id"+uid, например, id35828305.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Дата рождения пользователя. Возвращается в формате DD.MM.YYYY или DD.MM (если год рождения скрыт).
        /// Если дата рождения скрыта целиком, поле отсутствует в ответе.
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Идентификатор города, указанного на странице пользователя в разделе «Контакты».
        /// Если город не указан, или основная информация страницы скрыта настройками приватности, то 0.
        /// </summary>
        public long? City { get; set; }

        /// <summary>
        /// Идентификатор страны, указанной на странице пользователя в разделе «Контакты». 
        /// Если страна не указана или основная информация страницы скрыта настройками приватности, то 0.
        /// </summary>
        public long? Country { get; set; }

        /// <summary>
        /// Часовой пояс пользователя.
        /// </summary>
        public int? Timezone { get; set; }

        /// <summary>
        /// Информация о ссылках на предпросмотр фотографий пользователя.
        /// </summary>
        public Previews PhotoPreviews { get; set; }

        /// <summary>
        /// Признак указал ли пользователь номер своего мобильного телефона.
        /// </summary>
        public bool? HasMobile { get; set; }

        /// <summary>
        /// Номер мобильного телефона (если нет записи или скрыт, то null).
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Идентификатор языка, установленный в настройках.
        /// </summary>
        public long? Language { get; set; }

        /// <summary>
        /// Признак находится ли пользователь сейчас на сайте.
        /// </summary>
        public bool? Online { get; set; }

        /// <summary>
        /// Признак использует ли пользователь мобильное приложение либо мобильную версию сайта.
        /// </summary>
        public bool? OnlineMobile { get; set; }

        /// <summary>
        /// Если пользователь зашёл через приложение, то Id приложения иначе null.
        /// </summary>
        public long? OnlineApp { get; set; }

        /// <summary>
        /// Признак разрешено ли оставлять записи на стене у пользователя.
        /// </summary>
        public bool CanPost { get; set; }

        /// <summary>
        /// Признак разрешено ли видеть чужие записи на стене пользователя.
        /// </summary>
        public bool CanSeeAllPosts { get; set; }

        /// <summary>
        /// Признак разрешено ли видеть чужие аудиозаписи на стене пользователя.
        /// </summary>
        public bool CanSeeAudio { get; set; }

        /// <summary>
        /// Признак разрешено ли написание личных сообщений данному пользователю.
        /// </summary>
        public bool CanWritePrivateMessage { get; set; }

        /// <summary>
        /// Номер домашнего телефона (если нет записи или скрыт, то null).
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// Данные о подключенных сервисах пользователя, таких как: skype, facebook, twitter, instagram.
        /// </summary>
        public Connections Connections { get; set; }

        /// <summary>
        /// Сайт пользователя.
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Строка со статусом пользователя.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Время последнего посещения сайта.
        /// </summary>
        public DateTime? LastSeen { get; set; }

        /// <summary>
        /// Сведения об образовании пользователя.
        /// </summary>
        public Education Education { get; set; }

        /// <summary>
        /// Семейное положение.
        /// </summary>
        public RelationType Relation { get; set; }

        /// <summary>
        /// Партнер в семейных отношениях.
        /// </summary>
        public User RelationPartner { get; set; }

        /// <summary>
        /// Жизненные интересы.
        /// </summary>
        public StandInLife StandInLife { get; set; }

        /// <summary>
        /// Интересы пользователя.
        /// </summary>
        public string Interests { get; set; }

        /// <summary>
        /// Любимая музыка пользователя.
        /// </summary>
        public string Music { get; set; }

        /// <summary>
        /// Чем занимается пользователь.
        /// </summary>
        public string Activities { get; set; }

        /// <summary>
        /// Любимые фильмы пользователя.
        /// </summary>
        public string Movies { get; set; }

        /// <summary>
        /// Любимые телешоу пользователя.
        /// </summary>
        public string Tv { get; set; }

        /// <summary>
        /// Любимые книги пользователя.
        /// </summary>
        public string Books { get; set; }

        /// <summary>
        /// Любимые игры пользователя.
        /// </summary>
        public string Games { get; set; }

        /// <summary>
        /// Высшие учебные заведения, в которых учился текущий пользователь.
        /// </summary>
        public List<University> Universities { get; set; }

        /// <summary>
        /// Школы, в которых учился пользователь.
        /// </summary>
        public List<School> Schools { get; set; }

        /// <summary>
        /// Информация пользователя о себе.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Родственники пользователя.
        /// </summary>
        public List<Relative> Relatives { get; set; }

        /// <summary>
        /// Избранные пользователем цитаты.
        /// </summary>
        public string Quotes { get; set; }

        /// <summary>
        /// Различные счетчики пользователя.
        /// </summary>
        public Counters Counters { get; set; }

        /// <summary>
        /// Идентификатор пользователя, пригласившего пользователя в беседу (для GetChatUsers).
        /// </summary>
        public long? InvitedBy { get; set; }

        #region Методы

        internal static User FromJson(VkResponse response)
        {
            var user = new User();

            if (response["uid"] != null)
                user.Id = response["uid"];
            if (response["id"] != null)
                user.Id = response["id"];

            user.FirstName = response["first_name"];
            user.LastName = response["last_name"];

            if (response["name"] != null)
            {
                // split for name and surname
                var parts = ((string)response["name"]).Split(' ');
                if (parts.Length < 2)
                    throw new VkApiException("Invalid name in response");

                user.FirstName = parts[0];
                user.LastName = parts[1];
            }

            user.Sex = response["sex"];
            user.Nickname = response["nickname"];
            user.ScreenName = response["screen_name"];
            user.BirthDate = response["bdate"];
            user.City = response["city"];
            user.Country = response["country"];
            user.Timezone = response["timezone"];
            user.PhotoPreviews = response;
            user.HasMobile = response["has_mobile"];
            user.MobilePhone = response["mobile_phone"];
            user.Language = response["language"];
            user.Online = response["online"];
            user.OnlineMobile = response["online_mobile"];
            user.OnlineApp = response["online_app"];
            user.CanPost = response["can_post"];
            user.CanSeeAllPosts = response["can_see_all_posts"];
            user.CanSeeAudio = response["can_see_audio"];
            user.CanWritePrivateMessage = response["can_write_private_message"];
            user.HomePhone = response["home_phone"];
            user.Connections = response;
            user.Site = response["site"];
            user.Status = response["status"];
            user.LastSeen = response["last_seen"] != null ? response["last_seen"]["time"] : null;
            user.Education = response;
            user.Relation = response["relation"];
            user.RelationPartner = response["relation_partner"];
            user.StandInLife = response["personal"];
            user.Interests = response["interests"];
            user.Music = response["music"];
            user.Activities = response["activities"];
            user.Movies = response["movies"];
            user.Tv = response["tv"];
            user.Books = response["books"];
            user.Games = response["games"];
            user.Universities = response["universities"];
            user.Schools = response["schools"];
            user.About = response["about"];
            user.Relatives = response["relatives"];
            user.Quotes = response["quotes"];
            user.Counters = response["counters"];
            user.InvitedBy = response["invited_by"];

            return user;
        }

        #endregion

    }
}