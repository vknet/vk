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
		public Task<VkCollection<long>> GetListAsync(LikesGetListParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetList(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<UserOrGroup> GetListExAsync(LikesGetListParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetListEx(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> AddAsync(LikesAddParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Add(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> DeleteAsync(LikeObjectType type
											, long itemId
											, long? ownerId = null
											, long? captchaSid = null
											, string captchaKey = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Delete(type: type, itemId: itemId, ownerId: ownerId, captchaSid: captchaSid, captchaKey: captchaKey));
		}

		/// <inheritdoc />
		public Task<bool> IsLikedAsync(LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					IsLiked(copied: out var copied, type: type, itemId: itemId, userId: userId, ownerId: ownerId));
		}
	}
}