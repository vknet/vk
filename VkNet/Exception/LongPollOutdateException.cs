using System;

namespace VkNet.Exception
{
	/// <summary>
	/// История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.
	/// </summary>
	[Serializable]
	public class LongPollOutdateException : LongPollException
	{
		/// <summary>
		/// Значение для кода ошибки - 1
		/// </summary>
		public string Ts { get; set; }

		/// <inheritdoc />
		public LongPollOutdateException(string ts) : base(OutdateException,
			"История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.")
		{
			Ts = ts;
		}
	}
}