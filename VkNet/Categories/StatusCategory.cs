using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IStatusCategory" />
public partial class StatusCategory : IStatusCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="StatusCategory" />
	/// </summary>
	public StatusCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	[Pure]
	public Status Get(long userId, long? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			},
			{
				"group_id", groupId
			}
		};

		return _vk.Call<Status>("status.get", parameters);
	}

	/// <inheritdoc />
	public bool Set(string text, long? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"text", text
			},
			{
				"group_id", groupId
			}
		};

		return _vk.Call<bool>("status.set", parameters);
	}
}