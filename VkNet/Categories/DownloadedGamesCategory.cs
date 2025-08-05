using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Categories;

/// <inheritdoc cref="IDownloadedGamesCategory" />
public partial class DownloadedGamesCategory : IDownloadedGamesCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> API. </param>
	public DownloadedGamesCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public GetPaidStatusResult GetPaidStatus(ulong? userId = null) => _vk.Call<GetPaidStatusResult>("downloadedgames.getPaidStatus",
		new()
		{
			{
				"user_id", userId
			}
		});
}