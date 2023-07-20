using VkNet.Model;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IDownloadedGamesCategoryAsync"/>
public interface IDownloadedGamesCategory : IDownloadedGamesCategoryAsync
{
	/// <inheritdoc cref = "IDownloadedGamesCategoryAsync.GetPaidStatusAsync"/>
	GetPaidStatusResult GetPaidStatus(ulong? userId = null);
}