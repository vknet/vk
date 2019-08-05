using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если метод был выключен.
	/// Все актуальные методы ВК API, которые доступны в настоящий момент, перечислены
	/// здесь: http://vk.com/dev/methods.
	/// Код ошибки - 23
	/// </summary>
	[Serializable]
	[VkError(VkErrorCode.MethodHasBeenSwitchedOff)]
	public sealed class MethodHasBeenSwitchedOffException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public MethodHasBeenSwitchedOffException(VkError response) : base(response)
		{
		}
	}
}