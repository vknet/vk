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
	[VkError(VkErrorCode.PermissionDenied)]
	public sealed class AccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AccessDeniedException(VkError response) : base(response)
		{
		}
	}
}