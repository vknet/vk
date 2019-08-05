using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	/// <summary>
	/// Ключ доступа приложения недействителен.
	/// Код ошибки - 28
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.AppKeyInvalid)]
	public class AppKeyInvalidException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AppKeyInvalidException(VkError response) : base(response)
		{
		}
	}
}