using System;
using System.Runtime.Serialization;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Исключение, которое выбрасывается, если видеоальбом переполнен.
/// Перед продолжением работы нужно удалить лишние объекты из альбома или
/// использовать другой альбом.
/// Код ошибки - 302
/// </summary>
[Serializable]
[VkError(VkErrorCode.VideoAlbumIsFull)]
public sealed class VideoAlbumIsFullException : VkApiMethodInvokeException
{
	/// <inheritdoc />
	public VideoAlbumIsFullException(VkError response) : base(response)
	{
	}

	/// <inheritdoc />
	private VideoAlbumIsFullException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(new())
	{

	}
}