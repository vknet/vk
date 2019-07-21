using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StorageCategory : IStorageCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		public StorageCategory(IVkApiInvoke api)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public ReadOnlyCollection<StorageObject> Get(IEnumerable<string> keys = null, ulong? userId = null, bool? global = null)
		{
			return GetAsync(keys, userId, global, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public ReadOnlyCollection<string> GetKeys(ulong? userId = null, bool? global = null, ulong? offset = null, ulong? count = null)
		{
			return GetKeysAsync(userId, global, offset, count, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool Set(string key, string value = null, ulong? userId = null, bool? global = null)
		{
			return SetAsync(key, value, userId, global, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}