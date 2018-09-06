/*using System;
using System.Reflection;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace VkNet.Utils
{
	/// <summary>
	/// Helpers для асинхронных методов
	/// </summary>
	/// <remarks>
	/// https://github.com/StephenCleary/AsyncEx/blob/master/src/Nito.AsyncEx.Context/AsyncContext.cs
	/// </remarks>
	public static class AsyncHelpers
	{
		/// <summary>
		/// Checks if given method is an async method.
		/// </summary>
		/// <param name="method">A method to check</param>
		public static bool IsAsync(this MethodInfo method)
		{
			return method.ReturnType == typeof(Task)
					|| method.ReturnType.GetTypeInfo().IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>);
		}

		/// <summary>
		/// Runs a async method synchronously.
		/// </summary>
		/// <param name="func">A function that returns a result</param>
		/// <typeparam name="TResult">Result type</typeparam>
		/// <returns>Result of the async operation</returns>
		public static TResult RunSync<TResult>(Func<Task<TResult>> func)
		{
			return AsyncContext.Run(func);
		}

		/// <summary>
		/// Runs a async method synchronously.
		/// </summary>
		/// <param name="action">An async action</param>
		public static void RunSync(Func<Task> action)
		{
			AsyncContext.Run(action);
		}
	}
}*/