using VkNet.Abstractions;
using VkNet.Model.Results.DownloadedGames;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
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
		public DownloadedGamesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public GetPaidStatusResult GetPaidStatus(ulong? userId = null)
		{
			return _vk.Call<GetPaidStatusResult>("downloadedgames.getPaidStatus",
				new VkParameters
				{
					{ "user_id", userId }
				});
		}
	}
}