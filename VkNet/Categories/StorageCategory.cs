using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Categories;

/// <inheritdoc cref="IStorageCategory" />
public partial class StorageCategory : IStorageCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public StorageCategory(VkApi vk = null) => _vk = vk;

	/// <inheritdoc />
	public ReadOnlyCollection<StorageObject> Get(IEnumerable<string> keys = null, ulong? userId = null, bool? global = null) =>
		_vk.Call<ReadOnlyCollection<StorageObject>>("storage.get"
			, new()
			{
				{
					"keys", keys
				},
				{
					"user_id", userId
				},
				{
					"global", global
				}
			});

	/// <inheritdoc />
	public ReadOnlyCollection<string> GetKeys(ulong? userId = null, bool? global = null, ulong? offset = null, ulong? count = null) =>
		_vk.Call<ReadOnlyCollection<string>>("storage.getKeys"
			, new()
			{
				{
					"user_id", userId
				},
				{
					"global", global
				},
				{
					"offset", offset
				},
				{
					"count", count
				}
			});

	/// <inheritdoc />
	public bool Set(string key, string value = null, ulong? userId = null, bool? global = null) => _vk.Call<bool>("storage.set"
		, new()
		{
			{
				"key", key
			},
			{
				"value", value
			},
			{
				"user_id", userId
			},
			{
				"global", global
			}
		});
}