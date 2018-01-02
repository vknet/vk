using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class LikesCategory
    {
        /// <inheritdoc />
        public async Task<VkCollection<long>> GetListAsync(LikesGetListParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Likes.GetList(@params, skipAuthorization));
        }

        /// <inheritdoc />
        public async Task<UserOrGroup> GetListExAsync(LikesGetListParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Likes.GetListEx(@params));
        }

        /// <inheritdoc />
        public async Task<long> AddAsync(LikesAddParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Likes.Add(@params));
        }

        /// <inheritdoc />
        public async Task<long> DeleteAsync(LikeObjectType type, long itemId, long? ownerId = null, long? captchaSid = null,
            string captchaKey = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Likes.Delete(type, itemId, ownerId, captchaSid, captchaKey));
        }

        /// <inheritdoc />
        public async Task<bool> IsLikedAsync(LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Likes.IsLiked(out var copied, type,itemId,userId, ownerId));
        }
    }
}