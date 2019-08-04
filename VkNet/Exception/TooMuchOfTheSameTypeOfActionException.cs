using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при превышении лимита однотипных действий
	/// Нужно сократить число однотипных обращений. Для более эффективной работы Вы
	/// можете использовать execute или JSONP.
	/// Код ошибки - 9
	/// </summary>
	[Serializable]
	public sealed class TooMuchOfTheSameTypeOfActionException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public TooMuchOfTheSameTypeOfActionException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.TooMuchOfTheSameTypeOfAction;
	}
}