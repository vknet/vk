﻿using System;
using VkNet.Utils;

namespace VkNet.Exception
{
    /// <summary>
    /// Базовый класс для всех исключений, выбрасываемых библиотекой.
    /// </summary>
    [Serializable]
    public class VkApiException : System.Exception
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int ErrorCode { get; internal set; }

        /// <summary>
        /// Параметры запроса
        /// </summary>
        public VkParameters RequestParams { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        public VkApiException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public VkApiException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiException
        /// </summary>
        /// <param name="response">Ответ от сервера vk</param>
        public VkApiException(VkResponse response) : base(response["error_msg"])
        {
            ErrorCode = response["error_code"];
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса InvalidParameterException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public VkApiException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}