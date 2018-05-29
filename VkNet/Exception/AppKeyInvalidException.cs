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
		public AppKeyInvalidException(VkResponse error) : base(message: error)
		{
		}
	}
}