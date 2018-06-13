using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StatusCategory
	{
		/// <inheritdoc />
		public Task<Status> GetAsync(long userId, long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Status.Get(userId: userId, groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> SetAsync(string text, long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Status.Set(text: text, groupId: groupId));
		}
	}
}