using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к аудио запрещен.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id
	/// положительный, для сообществ —
	/// отрицательный), и доступ к запрашиваемому контенту для текущего пользователя
	/// есть в полной версии сайта.
	/// Код ошибки - 201
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AudioAccessDenied)]
	public sealed class AudioAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AudioAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}