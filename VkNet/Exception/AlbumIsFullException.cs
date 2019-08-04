using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если альбом переполнен.
	/// Перед продолжением работы нужно удалить лишние объекты из альбома или
	/// использовать другой альбом.
	/// Код ошибки - 300
	/// </summary>
	[Serializable]
	public sealed class AlbumIsFullException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AlbumIsFullException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.AlbumIsFull;
	}
}