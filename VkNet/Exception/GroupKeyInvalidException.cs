using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <inheritdoc />
	/// <summary>
	/// Ключ доступа сообщества недействителен.
	/// Код ошибки - 27
	/// </summary>
	[Serializable]
	public class GroupKeyInvalidException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public GroupKeyInvalidException(VkResponse error) : base(message: error)
		{
		}
	}
}