using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IShortVideoCategory" />
public partial class ShortVideoCategory
{
	/// <inheritdoc/>
	public Task<ShortVideoUploadServer> CreateAsync(string description,
													ulong fileSize = 16384,
													long? groupId = null,
													bool? wallPost = null,
													CancellationToken token = default) => TypeHelper.TryInvokeMethodAsync(() =>
		Create(description, fileSize, groupId, wallPost), token);
}