﻿using System;
using VkNet.Enums.Filters;

namespace VkNet
{
    /// <summary>
    /// Интерфейс параметров авторизации
    /// </summary>
    public interface IAuthParams
    {
        /// <summary>
        /// Токен доступа, полученный извне
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Идентификатор приложения с помощью которого будет авторизован пользователь
        /// </summary>
        ulong ApplicationId { get; set; }

        /// <summary>
        /// Ключ капчи (если необходимо)
        /// </summary>
        string CaptchaKey { get; set; }

        /// <summary>
        /// Идентификатор капчи (если установлена)
        /// </summary>
        long? CaptchaSid { get; set; }

        /// <summary>
        /// Имя узла прокси-сервера.
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Номер порта используемого Host.
        /// </summary>
        int? Port { get; set; }

        /// <summary>
        /// Логин для прокси с авторизацией. Если прокси без авторизации - оставить пустым
        /// </summary>   
        string ProxyLogin { get; set; }

        /// <summary>
        /// Пароль для прокси с авторищацией. Если прокси без авторизации - оставить пустым
        /// </summary>
        string ProxyPassword { get; set; }

        /// <summary>
        /// Права доступа приложений
        /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Права_доступа_приложений"/>
        /// </summary>
        Settings Settings { get; set; }

        /// <summary>
        /// Время, в течении которого действует токен доступа полученный извне (0 - бесконечно, по умолчанию)
        /// Используется при авторизации с помощью токена доступа, полученного извне
        /// </summary>
        int TokenExpireTime { get; set; }

        /// <summary>
        /// Функция двух факторной авторизации
        /// </summary>
        Func<string> TwoFactorAuthorization { get; set; }

        /// <summary>
        /// Идентификатор пользователя, установившего приложение 
        /// Используется при авторизации с помощью токена доступа, полученного извне
        /// </summary>
        long UserId { get; set; }
    }
}