﻿using System;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы этого класса позволяют производить действия с аккаунтом пользователя.
    /// </summary>
    public partial class AccountCategory
    {
        /// <summary>
        /// Подписывает устройство на базе iOS, Android или Windows Phone на получение Push-уведомлений.
        /// </summary>
        /// <param name="token">Идентификатор устройства, используемый для отправки уведомлений. (для mpns идентификатор должен представлять из себя URL для отправки уведомлений)</param>
        /// <param name="deviceModel">Строковое название модели устройства.</param>
        /// <param name="systemVersion">Строковая версия операционной системы устройства.</param>
        /// <param name="noText">Не передавать текст сообщения в push уведомлении. (по умолчанию текст передается)</param>
        /// <param name="subscribe">Список типов уведомлений, которые следует присылать. По умолчанию присылаются: <see cref="SubscribeFilter.Message"/>, <see cref="SubscribeFilter.Friend"/>.</param>
        /// <returns>Возвращает результат выполнения метода.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/account.registerDevice" />.
        /// </remarks>
        [ApiVersion("5.45")]
        [Obsolete("Функция устарела. Пожалуйста используйте функцию RegisterDevice(AccountRegisterDevice @params)")]
        public bool RegisterDevice([NotNull]string token, string deviceModel, string systemVersion, bool? noText = null, SubscribeFilter subscribe = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => token);

            var parameters = new VkParameters
                            {
                                {"token", token},
                                {"device_model", deviceModel},
                                {"system_version", systemVersion},
                                {"no_text", noText},
                                {"subscribe", subscribe}
                            };

            return _vk.Call("account.registerDevice", parameters);
        }

        /// <summary>
        ///  Редактирует информацию текущего профиля.
        /// </summary>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="lastName">Фамилия пользователя</param>
        /// <param name="maidenName">Девичья фамилия пользователя</param>
        /// <param name="sex">Пол пользователя</param>
        /// <param name="relation">Семейное положение пользователя</param>
        /// <param name="relationPartnerId">Идентификатор пользователя, с которым связано семейное положение</param>
        /// <param name="birthDate">Дата рождения пользователя</param>
        /// <param name="birthDateVisibility">Видимость даты рождения</param>
        /// <param name="homeTown">Родной город пользователя</param>
        /// <param name="countryId">Идентификатор страны пользователя</param>
        /// <param name="cityId">Идентификатор города пользователя</param>
        /// <returns>Результат выполнения операции.</returns>
        /// <remarks> Если передаются <paramref name="firstName"/> или <paramref name="lastName"/>, рекомендуется
        /// использовать перегрузку с соотвествующим out параметром типа <see cref="ChangeNameRequest"/> для получения объекта заявки на смену имени.</remarks>
        [ApiVersion("5.45")]
        [Obsolete("Данный метод устарел, пожалуйста используйте метод SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveInfo @params)")]
        public bool SaveProfileInfo(string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
            RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
            string homeTown = null, long? countryId = null, long? cityId = null)
        {
            ChangeNameRequest request;
            var parameters = new AccountSaveProfileInfoParams
            {
                FirstName = firstName,
                LastName = lastName,
                MaidenName = maidenName,
                Sex = sex.Value,
                Relation = relation.Value,
                RelationPartner = relationPartnerId.HasValue ? new User { Id = relationPartnerId.Value } : null,
                BirthDate = birthDate.HasValue ? birthDate.Value.ToShortDateString() : null,
                BirthdayVisibility = birthDateVisibility.Value,
                HomeTown = homeTown,
                Country = new Country { Id = countryId },
                City = new City
                {
                    Id = cityId
                }
            };
            return SaveProfileInfo(out request, parameters);
        }

        /// <summary>
        ///  Редактирует информацию текущего профиля.
        /// </summary>
        /// <param name="changeNameRequest">Если в параметрах передавалось имя или фамилия пользователя,
        /// в этом параметре будет возвращен объект типа <see cref="ChangeNameRequest"/>, содержащий информацию о заявке на смену имени.</param>
        /// <param name="firstName">Имя пользователя</param>
        /// <param name="lastName">Фамилия пользователя</param>
        /// <param name="maidenName">Девичья фамилия пользователя</param>
        /// <param name="sex">Пол пользователя</param>
        /// <param name="relation">Семейное положение пользователя</param>
        /// <param name="relationPartnerId">Идентификатор пользователя, с которым связано семейное положение</param>
        /// <param name="birthDate">Дата рождения пользователя</param>
        /// <param name="birthDateVisibility">Видимость даты рождения</param>
        /// <param name="homeTown">Родной город пользователя</param>
        /// <param name="countryId">Идентификатор страны пользователя</param>
        /// <param name="cityId">Идентификатор города пользователя</param>
        /// <returns>Результат выполнения операции.</returns>
        [ApiVersion("5.45")]
        [Obsolete("Данный метод устарел, пожалуйста используйте метод SaveProfileInfo(out ChangeNameRequest changeNameRequest, AccountSaveInfo @params)")]
        public bool SaveProfileInfo(out ChangeNameRequest changeNameRequest, string firstName = null, string lastName = null, string maidenName = null, Sex? sex = null,
            RelationType? relation = null, long? relationPartnerId = null, DateTime? birthDate = null, BirthdayVisibility? birthDateVisibility = null,
            string homeTown = null, long? countryId = null, long? cityId = null)
        {
            var parameters = new AccountSaveProfileInfoParams
            {
                FirstName = firstName,
                LastName = lastName,
                MaidenName = maidenName,
                Sex = sex.Value,
                Relation = relation.Value,
                RelationPartner = relationPartnerId.HasValue ? new User
                {
                    Id = relationPartnerId.Value
                } : null,
                BirthDate = birthDate.HasValue ? birthDate.Value.ToShortDateString() : null,
                BirthdayVisibility = birthDateVisibility.Value,
                HomeTown = homeTown,
                Country = new Country { Id = countryId },
                City = new City { Id = cityId }
            };

            return SaveProfileInfo(out changeNameRequest, parameters);
        }
    }
}