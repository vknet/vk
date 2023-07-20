using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при ошибке загрузки документа.
/// Код ошибки - 22
/// </summary>
[Serializable]
[VkError(VkErrorCode.LoadingError)]
public sealed class LoadingErrorException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public LoadingErrorException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private LoadingErrorException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}