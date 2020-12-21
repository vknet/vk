using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Вы не администратор в данном чате.
	/// </summary>
	/// <remarks>
	/// Код ошибки - 925
	/// </remarks>
	[Serializable]
	[VkError(VkErrorCode.YouAreNotAdminOfThisChat)]
	public class YouAreNotAdminOfThisChatException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public YouAreNotAdminOfThisChatException(VkError error) : base(error)
		{
		}
	}
}