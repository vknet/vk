using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если нет прав на выполнение операций с
	/// рекламным кабинетом.
	/// Код ошибки - 600
	/// </summary>
	[Serializable]
	public sealed class AdsAccessDeniedException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AdsAccessDeniedException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.AdsAccessDenied;
	}
}