using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается в случае, если параметр принимал
	/// недействительное значение.
	/// Код ошибки - 120
	/// </summary>
	[Serializable]
	public sealed class InvalidParameterException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public InvalidParameterException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.InvalidParameter;
	}
}