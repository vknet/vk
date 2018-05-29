using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;
using VkNet.Abstractions.Utils;
using VkNet.Exception;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для типов
	/// </summary>
	public static class TypeHelper
	{
#if NET40

		/// <summary>
		/// Получить информацию о типе
		/// </summary>
		/// <param name="type">Тип</param>
		/// <returns>Тип</returns>
		public static Type GetTypeInfo(this Type type)
		{
			return type;
		}

#endif
		/// <summary>
		/// DI регистрация зависимостей по умолчанию
		/// </summary>
		/// <param name="container">DI контейнер</param>
		public static void RegisterDefaultDependencies(this IServiceCollection container)
		{
			if (container.All(x => x.ServiceType != typeof(IBrowser)))
			{
				container.TryAddSingleton<IBrowser, Browser>();
			}

			if (container.All(x => x.ServiceType != typeof(ILogger)))
			{
				container.TryAddSingleton(InitLogger());
			}

			if (container.All(x => x.ServiceType != typeof(IRestClient)))
			{
				container.TryAddScoped<IRestClient, RestClient>();
			}

			if (container.All(x => x.ServiceType != typeof(IWebProxy)))
			{
				container.TryAddScoped<IWebProxy>(t => null);
			}
		}

		/// <summary>
		/// Инициализация логгера.
		/// </summary>
		/// <returns>Логгер</returns>
		private static ILogger InitLogger()
		{
			var consoleTarget = new ColoredConsoleTarget
			{
				UseDefaultRowHighlightingRules = true,
				Layout = @"${level} ${longdate} ${logger} ${message}"
			};

			var config = new LoggingConfiguration();
			config.AddTarget("console", consoleTarget);
			var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
			config.LoggingRules.Add(rule1);

			LogManager.Configuration = config;
			return LogManager.GetLogger("VkApi");
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func">Синхронный метод.</param>
		/// <typeparam name="T">Тип ответа</typeparam>
		/// <returns>Результат выполнения функции.</returns>
		public static Task<T> TryInvokeMethodAsync<T>(Func<T> func)
		{
			var tcs = new TaskCompletionSource<T>();

			Task.Factory.StartNew(() =>
			{
				try
				{
					var result = func.Invoke();
					tcs.SetResult(result);
				}
				catch (VkApiException ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func">Синхронный метод.</param>
		/// <returns>Результат выполнения функции.</returns>
		public static Task TryInvokeMethodAsync(Action func)
		{
			var tcs = new TaskCompletionSource<Task>();

			Task.Factory.StartNew(() =>
			{
				try
				{
					func.Invoke();
					tcs.SetResult(null);
				}
				catch (VkApiException ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}
	}
}