using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Вы не администратор в данном чате.
/// </summary>
/// <remarks>
/// Код ошибки - 925
/// </remarks>
[Serializable]
[VkError(VkErrorCode.YouAreNotAdminOfThisChat)]
public sealed class YouAreNotAdminOfThisChatException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public YouAreNotAdminOfThisChatException(VkError error) : base(error)
	{
	}

	private YouAreNotAdminOfThisChatException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}