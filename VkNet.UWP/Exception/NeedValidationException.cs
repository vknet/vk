using VkNet.Utils;

namespace VkNet.Exception
{
    using System;
    using System.Runtime.Serialization;

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
	/// Код ошибки - 17
    /// </summary>
    [DataContract]
    public class NeedValidationException : VkApiException
    {
        /// <summary>
        /// Адрес который необходимо открыть в браузере.
        /// </summary>
        public Uri RedirectUri { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса VkApiAuthorizationException
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        /// <param name="strRedirectUri">Адрес который необходимо открыть в браузере.</param>
        public NeedValidationException(string message, string strRedirectUri) : base(message)
        {
            RedirectUri = new Uri(strRedirectUri);
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса NeedValidationException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public NeedValidationException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
			RedirectUri = response["redirect_uri"];
		}
	}
}