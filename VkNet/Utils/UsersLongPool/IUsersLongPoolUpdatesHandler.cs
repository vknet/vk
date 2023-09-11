#nullable enable
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Utils.UsersLongPool;

/// <summary>
/// Обработчик лонгпула пользовательских сообщений
/// </summary>
public interface IUsersLongPoolUpdatesHandler
{
	/// <summary>
	/// Запуск отслеживания событий
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	Task RunAsync(CancellationToken token = default);
}