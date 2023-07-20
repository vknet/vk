using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при передаче неизвестного метода
/// Проверьте, правильно ли указано название вызываемого метода:
/// http://vk.com/dev/methods.
/// Код ошибки - 3
/// </summary>
[Serializable]
[VkError(VkErrorCode.UnknownMethod)]
public sealed class UnknownMethodException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public UnknownMethodException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private UnknownMethodException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}