using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при необходимости ввода капчи для вызова метода
	/// Код ошибки - 14
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CaptchaNeeded)]
	public sealed class CaptchaNeededException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CaptchaNeededException(VkError response) : base(response)
		{
			if (response == null)
			{
				return;
			}

			Sid = response.CaptchaSid;
			Img = response.CaptchaImg;
		}

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		public ulong Sid { get; }

		/// <summary>
		/// Uri-адрес изображения с капчей
		/// </summary>
		public Uri Img { get; }
	}
}