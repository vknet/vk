using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которые выбрасывается при попытке добавить в друзья пользователя,
/// который не найден.
/// Код ошибки - 177
/// </summary>
[Serializable]
[VkError(VkErrorCode.CannotAddUserNotFound)]
public sealed class CannotAddUserNotFoundException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public CannotAddUserNotFoundException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private CannotAddUserNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}