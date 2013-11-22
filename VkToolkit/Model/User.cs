using System;

using VkToolkit.Enums;
using VkToolkit.Utils;
using VkToolkit.Exception;

namespace VkToolkit.Model
{
    using System.Collections.Generic;

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
        /// Короткий адрес страницы пользователя. Если он не назначен, то "id'+uid, например, id35828305.
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
        /// Url квадратной фотографии пользователя, имеющей ширину 50 пикселей.
        /// </summary>
        public string Photo50 { get; set; }
        /// <summary>
        /// Url квадратной фотографии пользователя, имеющей ширину 100 пикселей.
        /// </summary>
        public string Photo100 { get; set; }
        /// <summary>
        /// Url квадратной фотографии пользователя, имеющей ширину 200 пикселей.
        /// </summary>
        public string Photo200 { get; set; }
        /// <summary>
        /// Url квадратной фотографии пользователя, имеющей ширину 400 пикселей.
        /// </summary>
        public string Photo400 { get; set; }
        /// <summary>
        /// Url квадратной фотографии пользователя, имеющей максимальную ширину.
        /// </summary>
        public string PhotoMax { get; set; }
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

        internal static User FromJson(VkResponse user)
        {
            var result = new User();

            if (user["uid"] != null)
                result.Id = user["uid"];
            if (user["id"] != null)
                result.Id = user["id"];

            result.FirstName = user["first_name"];
            result.LastName = user["last_name"];

            if (user["name"] != null)
            {
                // split for name and surname
                var parts = ((string)user["name"]).Split(' ');
                if (parts.Length < 2)
                    throw new VkApiException("Invalid name in response");

                result.FirstName = parts[0];
                result.LastName = parts[1];
            }

            result.Sex = user["sex"];
            result.Nickname = user["nickname"];
            result.ScreenName = user["screen_name"];
            result.BirthDate = user["bdate"];
            result.City = user["city"];
            result.Country = user["country"];
            result.Timezone = user["timezone"];
            result.Photo50 = user["photo_50"];
            result.Photo100 = user["photo_100"];
            result.Photo200 = user["photo_200"] ?? user["photo_200_orig"];
            result.Photo400 = user["photo_400_orig"];
            result.PhotoMax = user["photo_max"] ?? user["photo_max_orig"];
            result.HasMobile = user["has_mobile"];
            result.MobilePhone = user["mobile_phone"];
            result.Language = user["language"];
            result.Online = user["online"];
            result.OnlineMobile = user["online_mobile"];
            result.OnlineApp = user["online_app"];
            result.CanPost = user["can_post"];
            result.CanSeeAllPosts = user["can_see_all_posts"];
            result.CanSeeAudio = user["can_see_audio"];
            result.CanWritePrivateMessage = user["can_write_private_message"];
            result.HomePhone = user["home_phone"];
            result.Connections = user;
            result.Site = user["site"];
            result.Status = user["status"];
            result.LastSeen = user["last_seen"] != null ? user["last_seen"]["time"] : null;
            result.Education = user;
            result.Relation = user["relation"];
            result.RelationPartner = user["relation_partner"];
            result.StandInLife = user["personal"];
            result.Interests = user["interests"];
            result.Music = user["music"];
            result.Activities = user["activities"];
            result.Movies = user["movies"];
            result.Tv = user["tv"];
            result.Books = user["books"];
            result.Games = user["games"];
            result.Universities = user["universities"];
            result.Schools = user["schools"];
            result.About = user["about"];
            result.Relatives = user["relatives"];
            result.Quotes = user["quotes"];
            result.Counters = user["counters"];
            result.InvitedBy = user["invited_by"];

            return result;
        }
    }
}