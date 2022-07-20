using VkNet.Model.Results.DownloadedGames;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IDownloadedGamesCategoryAsync"/>
	public interface IDownloadedGamesCategory : IDownloadedGamesCategoryAsync
	{
		/// <inheritdoc cref = "IDownloadedGamesCategoryAsync.GetPaidStatusAsync"/>
		GetPaidStatusResult GetPaidStatus(ulong? userId = null);
	}
}