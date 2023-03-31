using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VkNet.Exception;

/// <summary>
/// История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.
/// </summary>
[Serializable]
public sealed class LongPollOutdateException : LongPollException
{
	/// <summary>
	/// Значение для кода ошибки - 1
	/// </summary>
	public string Ts { get; set; }

	/// <inheritdoc />
	public LongPollOutdateException(string ts) : base(OutdateException,
		"История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.") =>
		Ts = ts;

	/// <inheritdoc/>
	private LongPollOutdateException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base()
	{

	}

	/// <inheritdoc />
	[UsedImplicitly]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}