using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StatusCategory
	{
		/// <inheritdoc />
		public Task<Status> GetAsync(long userId, long? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<Status>("status.get",
				new VkParameters
				{
					{ "user_id", userId },
					{ "group_id", groupId }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> SetAsync(string text, long? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("status.set",
				new VkParameters
				{
					{ "text", text },
					{ "group_id", groupId }
				},
				cancellationToken: cancellationToken);
		}
	}
}