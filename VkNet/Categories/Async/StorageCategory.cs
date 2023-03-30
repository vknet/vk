using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StorageCategory
{
	/// <inheritdoc />
	public Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null,
															ulong? userId = null,
															bool? global = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(keys, userId, global), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null,
														bool? global = null,
														ulong? offset = null,
														ulong? count = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetKeys(userId, global, offset, count), token);

	/// <inheritdoc />
	public Task<bool> SetAsync(string key,
								string value = null,
								ulong? userId = null,
								bool? global = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Set(key, value, userId, global));
}