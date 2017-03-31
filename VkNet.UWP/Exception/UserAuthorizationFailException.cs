namespace VkNet.Exception
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Исключение, которое выбрасывается при отсутствии авторизации на выполнение запрошенной операции.
    /// </summary>
    [DataContract]
    public class UserAuthorizationFailException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса UserAuthorizationFailException
        /// </summary>
        public UserAuthorizationFailException(string message) : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса UserAuthorizationFailException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="code">Код ошибки, полученный от сервера ВКонтакте.</param>
        public UserAuthorizationFailException(string message, int code) : base(message, code)
        {
        }
    }
}