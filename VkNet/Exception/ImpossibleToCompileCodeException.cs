using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если невозможно скомпилировать код.
	/// Код ошибки - 12
	/// </summary>
	[Serializable]
	public sealed class ImpossibleToCompileCodeException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ImpossibleToCompileCodeException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.ImpossibleToCompileCode;
	}
}