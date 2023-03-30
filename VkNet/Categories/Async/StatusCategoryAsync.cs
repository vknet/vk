using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StatusCategory
{
	/// <inheritdoc />
	public Task<Status> GetAsync(long userId,
								long? groupId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(userId, groupId), token);

	/// <inheritdoc />
	public Task<bool> SetAsync(string text,
								long? groupId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Set(text, groupId), token);
}