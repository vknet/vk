using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class StorageCategory
	{
		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null, ulong? userId = null, bool? global = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Storage.Get(keys, userId, global));
		}

		/// <inheritdoc/>
		public async Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null, bool? global = null, ulong? offset = null, ulong? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Storage.GetKeys(userId, global, offset, count));
		}

		/// <inheritdoc/>
		public async Task<bool> SetAsync(string key, string value = null, ulong? userId = null, bool? global = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Storage.Set(key, value, userId, global));
		}
	}
}