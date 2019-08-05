using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которые выбрасывается при попытке выполнить запрос с частотой,
	/// превышающей максимально допустимую
	/// ВКонтакте.
	/// В настоящее время действует ограничение (один раз в три секунды) на количество
	/// однотипных запросов (вызовов методов
	/// с одним и тем же именем). Если это ограничение превышается, то сервер ВКонтакте
	/// возвращает ошибку с кодом 6 -
	/// Too many requests per second.
	/// Код ошибки - 6
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.TooManyRequestsPerSecond)]
	public sealed class TooManyRequestsException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public TooManyRequestsException(VkError response) : base(response)
		{
		}
	}
}