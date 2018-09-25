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
		/// Код ошибки
		/// </summary>
		public int Code { get; set; }

		/// <inheritdoc />
		public LongPollException() { }

		/// <inheritdoc />
		public LongPollException(int code, string message) : base(message)
		{
			Code = code;
		}
	}
}