using System;
using System.Linq;
using System.Reflection;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	public class VkErrorFactory
	{
		/// <summary>
		/// Создать ошибку
		/// </summary>
		/// <param name="error"> Ошибка VK </param>
		/// <returns>
		/// <see cref="VkApiMethodInvokeException" />
		/// </returns>
		public static VkApiMethodInvokeException Create(VkError error)
		{
			var vkApiMethodInvokeExceptions = typeof(VkApiMethodInvokeException).Assembly
				.GetTypes()
				.FirstOrDefault(x =>
					x.IsSubclassOf(typeof(VkApiMethodInvokeException))
					&& HasErrorCode(error.ErrorCode, x));

			return (VkApiMethodInvokeException) Activator.CreateInstance(vkApiMethodInvokeExceptions, error);
		}

		private static bool HasErrorCode(int error, Type x)
		{
			if (x == null)
			{
				return false;
			}

			var value = 0;
		#if NET40
			value = (int) (x.InvokeMember(nameof(VkApiMethodInvokeException.ErrorCode),
								BindingFlags.GetProperty | ,
								null,
								x,
								new object[]
								{
								},
								CultureInfo.InvariantCulture)
							?? 0);
		#else
			value = (int) (x.GetRuntimeProperty(nameof(VkApiMethodInvokeException.ErrorCode))
								?.GetValue(x, null)
							?? 0);
		#endif
			return value == error;
		}
	}
}