using System;

namespace VkNet.Utils
{
	/// <summary>
	/// Код ошибки vk.com
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class VkErrorAttribute : Attribute
	{
		/// <summary>
		/// Код ошибки vk.com
		/// </summary>
		/// <param name="errorCode"> Код ошибки </param>
		public VkErrorAttribute(int errorCode)
		{
			ErrorCode = errorCode;
		}

		/// <summary>
		/// Код ошибки
		/// </summary>
		public int ErrorCode { get; }
	}
}