using System;
using System.Runtime.InteropServices;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Достигнут количественный лимит на вызов метода
/// Код ошибки - 29
/// </summary>
[VkError(VkErrorCode.RateLimitReached)]
[Serializable]
public sealed class RateLimitReachedException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public RateLimitReachedException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private RateLimitReachedException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(new())
	{

	}
}