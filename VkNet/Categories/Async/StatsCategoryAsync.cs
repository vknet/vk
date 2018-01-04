using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    // <inheritdoc />
    public partial class StatsCategory
    {
        /// <inheritdoc />
        public async Task<ReadOnlyCollection<StatsPeriod>> GetByGroupAsync(long groupId, DateTime dateFrom,
            DateTime? dateTo = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Stats.GetByGroup(groupId, dateFrom, dateTo));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<StatsPeriod>> GetByAppAsync(long appId, DateTime dateFrom,
            DateTime? dateTo = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Stats.GetByApp(appId, dateFrom, dateTo));
        }

        /// <inheritdoc />
        public async Task<bool> TrackVisitorAsync()
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Stats.TrackVisitor());
        }

        /// <inheritdoc />
        public async Task<PostReach> GetPostReachAsync(long ownerId, long postId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Stats.GetPostReach(ownerId, postId));
        }
    }
}