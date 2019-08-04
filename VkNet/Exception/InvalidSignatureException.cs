using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если подпись неверна.
	/// Проверьте правильность формирования подписи запроса:
	/// https://vk.com/dev/api_nohttps
	/// Код ошибки - 4
	/// </summary>
	[Serializable]
	public sealed class InvalidSignatureException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidSignatureException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidSignature;
	}
}