using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Истекло время действия ключа, нужно заново получить key методом groups.getLongPollServer.
	/// </summary>
	[Serializable]
	public class BotsLongPollKeyExpiredException : LongPollException
	{
		/// <inheritdoc />
		public BotsLongPollKeyExpiredException() : base(2, "Истекло время действия ключа, нужно заново получить key методом groups.getLongPollServer.") { }
	}
}