using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если один из необходимых параметров был не
	/// передан или неверен.
	/// Проверьте список требуемых параметров и их формат на странице с описанием
	/// метода.
	/// Код ошибки - 100
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.ParameterMissingOrInvalid)]
	public sealed class ParameterMissingOrInvalidException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public ParameterMissingOrInvalidException(VkError response) : base(response)
		{
		}
	}
}