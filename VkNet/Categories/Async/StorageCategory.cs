using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StorageCategory
	{
		/// <inheritdoc />
		public Task<ReadOnlyCollection<StorageObject>> GetAsync(IEnumerable<string> keys = null,
																ulong? userId = null,
																bool? global = null,
																CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<StorageObject>>("storage.get",
				new VkParameters
				{
					{ "keys", keys },
					{ "user_id", userId },
					{ "global", global }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<string>> GetKeysAsync(ulong? userId = null,
															bool? global = null,
															ulong? offset = null,
															ulong? count = null,
															CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<string>>("storage.getKeys",
				new VkParameters
				{
					{ "user_id", userId },
					{ "global", global },
					{ "offset", offset },
					{ "count", count }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> SetAsync(string key,
									string value = null,
									ulong? userId = null,
									bool? global = null,
									CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("storage.set",
				new VkParameters
				{
					{ "key", key },
					{ "value", value },
					{ "user_id", userId },
					{ "global", global }
				},
				cancellationToken: cancellationToken);
		}
	}
}