using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при попытке загрузки на сервер неправильного файла аудиозаписи.
/// Попробуйте загрузить файл ещё раз.
/// Код ошибки - 4611
/// </summary>
[Serializable]
[VkError(VkErrorCode.InvalidFile)]
public sealed class InvalidFileException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public InvalidFileException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private InvalidFileException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}