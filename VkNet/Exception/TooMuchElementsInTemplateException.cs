using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace VkNet.Exception;

/// <summary>
/// Исключение, выбрасываемое при выходе за лимит количества элементов в шаблоне
/// </summary>
[Serializable]
public class TooMuchElementsInTemplateException : VkApiException
{
	/// <inheritdoc />
	public TooMuchElementsInTemplateException(string message) : base(message)
	{
	}

	/// <inheritdoc />
	protected TooMuchElementsInTemplateException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}

	/// <inheritdoc />
	[UsedImplicitly]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}