using System;

namespace VkNet.Exception
{
	/// <summary>
	/// Ошибка при получении истории обновлений
	/// </summary>
	[Serializable]
	public class LongPollException : System.Exception
	{
		/// <summary>
		/// История событий устарела или была частично утеряна, приложение может получать события далее, используя новое значение ts из ответа.
		/// </summary>
		public const int OutdateException = 1;

		/// <summary>
		/// Истекло время действия ключа, нужно заново получить key
		/// </summary>
		public const int KeyExpiredException = 2;

		/// <summary>
		/// Информация утрачена, нужно запросить новые key и ts
		/// </summary>
		public const int InfoLostException = 3;

		/// <summary>
		/// Код ошибки
		/// </summary>
		public int Code { get; set; }

		/// <inheritdoc />
		public LongPollException()
		{
		}

		/// <inheritdoc />
		public LongPollException(int code, string message) : base(message)
		{
			Code = code;
		}
	}
}