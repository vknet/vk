using System;
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
	private LoadingErrorException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}