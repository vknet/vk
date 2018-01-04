using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class StatusCategory
    {
        /// <inheritdoc />
        public async Task<Status> GetAsync(long userId, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Status.Get(userId, groupId));
        }

        /// <inheritdoc />
        public async Task<bool> SetAsync(string text, long? groupId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Status.Set(text, groupId));
        }
    }
}