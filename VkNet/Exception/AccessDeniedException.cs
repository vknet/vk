using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при попытке добавить себя в черный список и
/// других типичных запросах.
/// Убедитесь, что Вы используете верные идентификаторы, и доступ к контенту для
/// текущего пользователя есть в полной
/// версии сайта.
/// Код ошибки - 15
/// </summary>
[Serializable]
[VkError(VkErrorCode.AccessDenied)]
public sealed class AccessDeniedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public AccessDeniedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private AccessDeniedException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}