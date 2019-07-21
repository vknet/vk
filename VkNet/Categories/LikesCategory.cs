using System;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class LikesCategory : ILikesCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// API для работы с лайками.
		/// </summary>
		/// <param name="vk"> The vk. </param>
		public LikesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<long> GetList(LikesGetListParams @params, bool skipAuthorization = false)
		{
			return GetListAsync(@params, skipAuthorization, CancellationToken.None).GetAwaiter().GetResult();
		}

		//TODO: сделать кастомный JsonConverter
		/// <inheritdoc />
		public UserOrGroup GetListEx(LikesGetListParams @params)
		{
			return GetListExAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public long Add(LikesAddParams @params)
		{
			return AddAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public long Delete(LikeObjectType type, long itemId, long? ownerId = null, long? captchaSid = null, string captchaKey = null)
		{
			return DeleteAsync(type, itemId, ownerId, captchaSid, captchaKey, CancellationToken.None).GetAwaiter().GetResult();
		}

		//TODO: сделать объект с полями liked, copied.
		/// <inheritdoc />
		public bool IsLiked(out bool copied, LikeObjectType type, long itemId, long? userId = null, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "item_id", itemId },
				{ "user_id", userId },
				{ "owner_id", ownerId }
			};

			var resp = _vk.Call("likes.isLiked", parameters);

			copied = resp["copied"];

			return resp["liked"];
		}
	}
}