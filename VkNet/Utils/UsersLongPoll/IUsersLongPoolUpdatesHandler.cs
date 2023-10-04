#nullable enable
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Utils.UsersLongPoll;

/// <summary>
/// Обработчик лонгпула пользовательских сообщений
/// </summary>
public interface IUsersLongPollUpdatesHandler
{
	/// <summary>
	/// Запуск отслеживания событий
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	Task RunAsync(CancellationToken token = default);
}