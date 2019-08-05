using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при работе с неверным ID.
	/// Убедитесь, что Вы используете верный идентификатор. Получить ID по короткому
	/// имени можно методом
	/// utils.resolveScreenName.
	/// Код ошибки - 113
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.InvalidUserId)]
	public sealed class InvalidUserIdException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidUserIdException(VkError response) : base(response)
		{
		}
	}
}