using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к статусу запрещен.
	/// Код ошибки - 220
	/// </summary>
	[Serializable]
	public sealed class StatusAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public StatusAccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.StatusAccessDenied;
	}
}