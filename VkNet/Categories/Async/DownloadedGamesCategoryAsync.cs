using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

public partial class DownloadedGamesCategory
{
	/// <inheritdoc />
	public Task<GetPaidStatusResult> GetPaidStatusAsync(ulong? userId = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPaidStatus(userId), token);
}