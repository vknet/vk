using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Список методов секции downloadedGames
/// </summary>
public interface IDownloadedGamesCategory : IDownloadedGamesCategoryAsync
{
	/// <inheritdoc cref = "IDownloadedGamesCategoryAsync.GetPaidStatusAsync"/>
	GetPaidStatusResult GetPaidStatus(ulong? userId = null);
}