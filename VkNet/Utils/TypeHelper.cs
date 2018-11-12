using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using VkNet.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Infrastructure;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для типов
	/// </summary>
	public static class TypeHelper
	{
		/// <summary>
		/// DI регистрация зависимостей по умолчанию
		/// </summary>
		/// <param name="container"> DI контейнер </param>
		public static void RegisterDefaultDependencies(this IServiceCollection container)
		{
			container.TryAddSingleton<IBrowser, Browser>();
			container.TryAddSingleton<IAuthorizationFlow, Browser>();
			container.TryAddSingleton<INeedValidationHandler, Browser>();
			container.TryAddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
			container.TryAddSingleton<IRestClient, RestClient>();
			container.TryAddSingleton<IWebProxy>(t => null);
			container.TryAddSingleton<IVkApiVersionManager, VkApiVersionManager>();
			container.TryAddSingleton<ICaptchaHandler, CaptchaHandler>();
			container.TryAddSingleton<ILanguageService, LanguageService>();
			container.TryAddSingleton<ICaptchaSolver>(sp => null);
			container.TryAddSingleton<HttpClient>();
			container.TryAddSingleton<IRateLimiter, RateLimiter>();
			container.TryAddSingleton<IAwaitableConstraint>(sp => new CountByIntervalAwaitableConstraint(3, TimeSpan.FromSeconds(1)));
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <typeparam name="T"> Тип ответа </typeparam>
		/// <returns> Результат выполнения функции. </returns>
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
					catch (OperationCanceledException)
					{
						tcs.SetCanceled();
					}
					catch (System.Exception ex)
					{
						tcs.SetException(ex);
					}
				})
				.ConfigureAwait(false);

			return tcs.Task;
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <returns> Результат выполнения функции. </returns>
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
				catch (OperationCanceledException)
				{
					tcs.SetCanceled();
				}
				catch (System.Exception ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}
	}
}