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
	public sealed class InvalidServerException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidServerException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidServer;
	}
}