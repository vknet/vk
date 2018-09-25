using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Информация утрачена, нужно запросить новые key и ts методом groups.getLongPollServer.
	/// </summary>
	[Serializable]
	public class BotsLongPollInfoLostException : LongPollException
	{
		/// <inheritdoc />
		public BotsLongPollInfoLostException() : base(3, "Информация утрачена, нужно запросить новые key и ts методом groups.getLongPollServer.") { }
	}
}