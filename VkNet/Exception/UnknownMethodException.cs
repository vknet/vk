using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается при передаче неизвестного метода
	/// Проверьте, правильно ли указано название вызываемого метода:
	/// http://vk.com/dev/methods.
	/// Код ошибки - 3
	/// </summary>
	[Serializable]
	public sealed class UnknownMethodException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public UnknownMethodException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.UnknownMethod;
	}
}