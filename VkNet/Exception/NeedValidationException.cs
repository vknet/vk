namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

    using Enums.Filters;

    /// <summary>
    /// Исключение, которое выбрасывается в случаях, 
    /// когда требуется дополнительная проверка пользователя, 
    /// например при авторизации из подозрительного места
    /// 
    /// В этом случае необходимо открыть браузер со страницей, указанной в поле redirect_uri и ждать, 
    /// пока пользователь будет направлен на страницу blank.html с параметром success=1 в случае успеха и fail=1 
    /// в случае, если пользователь отменил проверку своего аккаунта. 
    /// Для тестового вызова проверки добавьте параметр test_redirect_uri=1.
    /// 
    /// </summary>
    [Serializable]
    public class NeedValidationException : VkApiException
    {
        /// <summary>
        /// Адрес который необходимо открыть в браузере.
        /// </summary>
        public Uri redirectUri { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkApiAuthorizationException"/>.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="strRedirectUri">Адрес который необходимо открыть в браузере.</param>
        public NeedValidationException(string message, string strRedirectUri) : base(message)
        {
            redirectUri = new Uri(strRedirectUri);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AccessTokenInvalidException"/> на основе ранее сериализованных данных.
        /// </summary>
        /// <param name="info">Содержит все данные, необходимые для десериализации.</param>
        /// <param name="context">Описывает источник и назначение данного сериализованного потока и предоставляет дополнительный,
        /// определяемый вызывающим, контекст.</param>
        protected NeedValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}