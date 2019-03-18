using System;

namespace VkNet.Exception
{
	/// <inheritdoc />
	[Serializable]
	public class VkAuthorizationException : System.Exception
	{
		/// <inheritdoc />
		public VkAuthorizationException()
		{
		}

		/// <inheritdoc />
		public VkAuthorizationException(string message) : base(message)
		{
		}
	}
}