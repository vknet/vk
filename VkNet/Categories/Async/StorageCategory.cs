using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StorageCategory
	{
		/// <inheritdoc />
		public async Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null
																	, ulong? userId = null
																	, bool? global = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Storage.Get(keys: keys, userId: userId, global: global));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null
																	, bool? global = null
																	, ulong? offset = null
																	, ulong? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Storage.GetKeys(userId: userId, global: global, offset: offset, count: count));
		}

		/// <inheritdoc />
		public async Task<bool> SetAsync(string key, string value = null, ulong? userId = null, bool? global = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Storage.Set(key: key, value: value, userId: userId, global: global));
		}
	}
}