using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со звонками
/// </summary>
public interface ICallsCategoryAsync
{
	/// <summary>
	/// Принудительно завершить звонок
	/// </summary>
	/// <param name="params">Параметры запроса</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>После успешного выполнения возвращает <c> true </c>.</returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://dev.vk.com/ru/method/calls.forceFinish
	/// </remarks>
	Task<bool> ForceFinishAsync(CallsForceFinishParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Создать новый звонок от имени пользователя или сообщества
	/// </summary>
	/// <param name="params">Параметры запроса</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>После успешного выполнения возвращает объект CallStartResult</returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://dev.vk.com/ru/method/calls.start
	/// </remarks>
	Task<CallStartResult> StartAsync(CallsStartParams @params,
									CancellationToken token = default);
}