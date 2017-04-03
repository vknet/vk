namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которые выбрасывается при попытке добавить себя в друзья. Код ошибки - 174
    /// </summary>
    [DataContract]
    public class CannotAddYourselfException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYourselfException
        /// </summary>
        public CannotAddYourselfException()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYourselfException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public CannotAddYourselfException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYourselfException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="innerException">Внутреннее исключение.</param>
        public CannotAddYourselfException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CannotAddYourselfException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public CannotAddYourselfException(string message, int code) : base(message, code)
        {
        }
    }
}
