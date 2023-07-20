using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается при нахождении ошибок в ответе метода execute.
/// </summary>
[Serializable]
public sealed class ExecuteException : AggregateException
{
	/// <summary>
	/// Поле response из ответа метода execute.
	/// </summary>
	public JRaw Response { get; }

	/// <inheritdoc />
	public ExecuteException(IEnumerable<System.Exception> innerExceptions, JRaw response) : base(innerExceptions) => Response = response;

	/// <inheritdoc />
	private ExecuteException(SerializationInfo serializationInfo, StreamingContext streamingContext)
	{

	}
}