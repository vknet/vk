using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при отказе в доступе на выполнение операции
	/// сервером ВКонтакте.
	/// Код ошибки - 500
	/// </summary>
	[Serializable]
	public sealed class AccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.PermissionDenied;
	}
}