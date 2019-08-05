using System;
using VkNet.Model;
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
	[VkError(VkErrorCode.NeedValidationOfUser)]
	public sealed class NeedValidationException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public NeedValidationException(VkError response) : base(response)
		{
			if (response == null)
			{
				return;
			}

			RedirectUri = response.RedirectUri;
		}

		/// <summary>
		/// Адрес который необходимо открыть в браузере.
		/// </summary>
		public Uri RedirectUri { get; }
	}
}