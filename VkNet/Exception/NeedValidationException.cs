using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается в случаях,
	/// когда требуется дополнительная проверка пользователя,
	/// например при авторизации из подозрительного места
	/// В этом случае необходимо открыть браузер со страницей, указанной в поле
	/// redirect_uri и ждать,
	/// пока пользователь будет направлен на страницу blank.html с параметром success=1
	/// в случае успеха и fail=1
	/// в случае, если пользователь отменил проверку своего аккаунта.
	/// Для тестового вызова проверки добавьте параметр test_redirect_uri=1.
	/// Код ошибки - 17
	/// </summary>
	[Serializable]
	public class NeedValidationException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiAuthorizationException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="strRedirectUri"> Адрес который необходимо открыть в браузере. </param>
		public NeedValidationException(string message, string strRedirectUri) : base(message: message)
		{
			RedirectUri = new Uri(uriString: strRedirectUri);
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса NeedValidationException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public NeedValidationException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
			RedirectUri = response[key: "redirect_uri"];
		}

		/// <summary>
		/// Адрес который необходимо открыть в браузере.
		/// </summary>
		public Uri RedirectUri { get; }
	}
}