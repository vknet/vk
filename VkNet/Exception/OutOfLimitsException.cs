using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Выход за пределы
/// Код ошибки - 103
/// </summary>
/// <seealso cref="VkNet.Exception.VkApiException" />
[Serializable]
[VkError(VkErrorCode.OutOfLimits)]
public sealed class OutOfLimitsException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public OutOfLimitsException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private OutOfLimitsException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}