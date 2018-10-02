using System;

namespace VkNet.Exception
{
	/// <summary>
	/// История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.
	/// </summary>
	[Serializable]
	public class BotsLongPollOutdateException : LongPollException
	{
		/// <summary>
		/// Значение для кода ошибки - 1
		/// </summary>
		public ulong Ts { get; set; }

		/// <inheritdoc />
		public BotsLongPollOutdateException(ulong ts) : base(OutdateException,
			"История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.")
		{
			Ts = ts;
		}
	}
}