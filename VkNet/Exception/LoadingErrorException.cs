using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при ошибке загрузки документа.
	/// Код ошибки - 22
	/// </summary>
	[Serializable]
	public class LoadingErrorException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public LoadingErrorException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.LoadingError;
	}
}