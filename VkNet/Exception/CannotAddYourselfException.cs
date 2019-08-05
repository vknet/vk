using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке добавить себя в друзья.
	/// Код ошибки - 174
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.CannotAddYourself)]
	public sealed class CannotAddYourselfException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public CannotAddYourselfException(VkError response) : base(response)
		{
		}
	}
}