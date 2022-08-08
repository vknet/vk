using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class StorageCategory
{
	/// <inheritdoc />
	public Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null
															, ulong? userId = null
															, bool? global = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(keys, userId, global));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null
														, bool? global = null
														, ulong? offset = null
														, ulong? count = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetKeys(userId, global, offset, count));

	/// <inheritdoc />
	public Task<bool> SetAsync(string key, string value = null, ulong? userId = null, bool? global = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			Set(key, value, userId, global));
}