using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	/// <summary>
	/// Ключ доступа приложения недействителен.
	/// Код ошибки - 28
	/// </summary>
	[Serializable]
	public class AppKeyInvalidException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public AppKeyInvalidException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}