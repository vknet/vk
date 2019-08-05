using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если сервер загрузки неверен.
	/// Код ошибки - 118
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.InvalidServer)]
	public sealed class InvalidServerException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidServerException(VkError response) : base(response)
		{
		}
	}
}