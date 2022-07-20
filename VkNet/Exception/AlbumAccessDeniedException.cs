using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отсутствии доступа к альбому.
	/// Доступ к альбому запрещён.
	/// Убедитесь, что Вы используете верные идентификаторы (для пользователей owner_id
	/// положительный, для сообществ —
	/// отрицательный), и доступ к запрашиваемому контенту для текущего пользователя
	/// есть в полной версии сайта.
	/// Код ошибки - 200
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AlbumAccessDenied)]
	public sealed class AlbumAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AlbumAccessDeniedException(VkError response) : base(response)
		{
		}
	}
}