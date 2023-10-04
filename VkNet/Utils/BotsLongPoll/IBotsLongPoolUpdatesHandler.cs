#nullable enable
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Utils.BotsLongPoll;

/// <summary>
/// Обработчик лонгпула групповых сообщений
/// </summary>
public interface IBotsLongPollUpdatesHandler
{
	/// <summary>
	/// Запуск отслеживания событий
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	Task RunAsync(CancellationToken token = default);
}

/// <summary>
/// Обработчик лонгпула групповых сообщений
/// </summary>
[Obsolete(ObsoleteText.ObsoleteLongPool, true)]
public interface IBotsLongPoolUpdatesHandler {}