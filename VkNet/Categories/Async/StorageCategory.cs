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
		public Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null
																	, ulong? userId = null
																	, bool? global = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Get(keys: keys, userId: userId, global: global));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null
																	, bool? global = null
																	, ulong? offset = null
																	, ulong? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetKeys(userId: userId, global: global, offset: offset, count: count));
		}

		/// <inheritdoc />
		public Task<bool> SetAsync(string key, string value = null, ulong? userId = null, bool? global = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Set(key: key, value: value, userId: userId, global: global));
		}
	}
}