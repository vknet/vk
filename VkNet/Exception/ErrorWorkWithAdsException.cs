using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при ошибке работы с рекламным кабинетом.
	/// Код ошибки - 603
	/// </summary>
	[Serializable]
	public sealed class ErrorWorkWithAdsException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ErrorWorkWithAdsException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.ErrorWorkWithAds;
	}
}