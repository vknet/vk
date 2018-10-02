using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Информация утрачена, нужно запросить новые key и ts методом groups.getLongPollServer.
	/// </summary>
	[Serializable]
	public class LongPollInfoLostException : LongPollException
	{
		/// <inheritdoc />
		public LongPollInfoLostException() : base(InfoLostException,
			"Информация утрачена, нужно запросить новые key и ts")
		{
		}
	}
}