using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class GiftsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<GiftItem>> GetAsync(long? userId = null,
												int? count = null,
												int? offset = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(userId, count, offset));
}