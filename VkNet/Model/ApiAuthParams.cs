using System;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace VkNet
{
    /// <summary>
    /// Параметры авторизации
    /// </summary>
    [Serializable]
    public class ApiAuthParams : IApiAuthParams
    {
        /// <summary>
        /// Идентификатор приложения с помощью которого будет авторизован пользователь
        /// </summary>
        public ulong ApplicationId { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Права доступа приложений
        /// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Права_доступа_приложений"/>
        /// </summary>
        public Settings Settings { get; set; }
        /// <summary>
        /// Функция двух факторной авторизации
        /// </summary>
        public Func<string> TwoFactorAuthorization { get; set; }
        /// <summary>
        /// Токен доступа, полученный извне
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Время, в течении которого действует токен доступа полученный извне (0 - бесконечно, по умолчанию)
        /// Используется при авторизации с помощью токена доступа, полученного извне
        /// </summary>
        public int TokenExpireTime { get; set; }
        /// <summary>
        /// Идентификатор пользователя, установившего приложение 
        /// Используется при авторизации с помощью токена доступа, полученного извне
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Идентификатор капчи (если установлена)
        /// </summary>
        public long? CaptchaSid { get; set; }
        /// <summary>
        /// Ключ капчи (если необходимо)
        /// </summary>
        public string CaptchaKey { get; set; }
        /// <summary>
        /// Имя узла прокси-сервера.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Номер порта используемого Host.
        /// </summary>
        public int? Port { get; set; }
        /// <summary>
        /// Логин для прокси с авторизацией. Если прокси без авторизации - оставить пустым
        /// </summary>                                                                    
        public string ProxyLogin { get; set; }
        /// <summary>
        /// Пароль для прокси с авторищацией. Если прокси без авторизации - оставить пустым
        /// </summary>
        public string ProxyPassword { get; set; }
    }
}