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
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Likes.GetList(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public async Task<UserOrGroup> GetListExAsync(LikesGetListParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Likes.GetListEx(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> AddAsync(LikesAddParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Likes.Add(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> DeleteAsync(LikeObjectType type
											, long itemId
											, long? ownerId = null
											, long? captchaSid = null
											, string captchaKey = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Likes.Delete(type: type, itemId: itemId, ownerId: ownerId, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public async Task<bool> IsLikedAsync(LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Likes.IsLiked(copied: out var copied, type: type, itemId: itemId, userId: userId, ownerId: ownerId));
		}
	}
}