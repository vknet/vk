using System;
using System.Collections.ObjectModel;
using VkNet.Model;

namespace VkNet.Exception
{
	/// <summary>
	/// Базовый класс, для всех исключений, которые могут произойти при вызове методов
	/// API ВКонтакте.
	/// </summary>
	[Serializable]
	public abstract class VkApiMethodInvokeException : VkApiException
	{
		private readonly VkError _error;

		/// <inheritdoc />
		protected VkApiMethodInvokeException(VkError error) : base(error.ErrorMessage)
		{
			_error = error;
		}

		/// <summary>
		/// Код ошибки
		/// </summary>
		internal new abstract int ErrorCode { get; }

		/// <summary>
		/// Параметры запроса
		/// </summary>
		public new ReadOnlyCollection<RequestParam> RequestParams => _error.RequestParams;

		/// <inheritdoc />
		public override string Message => _error.ErrorMessage;
	}
}