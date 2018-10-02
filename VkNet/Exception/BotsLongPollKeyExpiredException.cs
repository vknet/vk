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
		public BotsLongPollKeyExpiredException() : base(KeyExpiredException,
			"Истекло время действия ключа, нужно заново получить key методом groups.getLongPollServer.")
		{
		}
	}
}