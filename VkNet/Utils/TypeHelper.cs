using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Infrastructure;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;
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
			container.TryAddSingleton<INeedValidationHandler, NeedValidationHandler>();
			container.TryAddSingleton<HttpClient>();
			container.TryAddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
			container.TryAddSingleton<IRestClient, RestClient>();
			container.TryAddSingleton<IWebProxy>(_ => null);
			container.TryAddSingleton<IVkApiVersionManager, VkApiVersionManager>();
			container.TryAddSingleton<ICaptchaHandler, CaptchaHandler>();
			container.TryAddSingleton<ILanguageService, LanguageService>();
			container.TryAddSingleton<ICaptchaSolver>(_ => null);
			container.TryAddSingleton<IRateLimiter, RateLimiter>();
			container.TryAddSingleton<IAwaitableConstraint, CountByIntervalAwaitableConstraint>();
			container.RegisterImplicitFlowAuthorization();
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <typeparam name="T"> Тип ответа </typeparam>
		/// <returns> Результат выполнения функции. </returns>
		public static Task<T> TryInvokeMethodAsync<T>(Func<T> func)
		{
			return Task.Run(func);
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <returns> Результат выполнения функции. </returns>
		public static Task TryInvokeMethodAsync(Action func)
		{
			return Task.Run(func);
		}

		private static void RegisterImplicitFlowAuthorization(this IServiceCollection services)
		{
			services.TryAddSingleton<IAuthorizationFlow, ImplicitFlow>();
			services.TryAddSingleton<IVkAuthorization<ImplicitFlowPageType>, ImplicitFlowVkAuthorization>();
			services.TryAddSingleton<IAuthorizationFormHtmlParser, AuthorizationFormHtmlParser>();
			services.TryAddSingleton<IAuthorizationFormFactory, AuthorizationFormFactory>();

			services.AddSingleton<IAuthorizationForm, ImplicitFlowCaptchaLoginForm>();
			services.AddSingleton<IAuthorizationForm, ImplicitFlowLoginForm>();
			services.AddSingleton<IAuthorizationForm, TwoFactorForm>();
			services.AddSingleton<IAuthorizationForm, ConsentForm>();
		}
	}
}