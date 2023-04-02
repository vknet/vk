using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при превышении лимита однотипных действий
/// Нужно сократить число однотипных обращений. Для более эффективной работы Вы
/// можете использовать execute или JSONP.
/// Код ошибки - 9
/// </summary>
[Serializable]
[VkError(VkErrorCode.TooMuchOfTheSameTypeOfAction)]
public sealed class TooMuchOfTheSameTypeOfActionException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public TooMuchOfTheSameTypeOfActionException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private TooMuchOfTheSameTypeOfActionException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}