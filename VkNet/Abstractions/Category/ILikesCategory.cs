using System;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="ILikesCategoryAsync" />
	public interface ILikesCategory : ILikesCategoryAsync
	{
		/// <inheritdoc cref="ILikesCategoryAsync.GetListAsync" />
		VkCollection<long> GetList(LikesGetListParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="ILikesCategoryAsync.GetListExAsync" />
		UserOrGroup GetListEx(LikesGetListParams @params);

		/// <inheritdoc cref="ILikesCategoryAsync.AddAsync" />
		long Add(LikesAddParams @params);

		/// <inheritdoc cref="ILikesCategoryAsync.DeleteAsync(LikeObjectType, long, long?)" />
		long Delete(LikeObjectType type, long itemId, long? ownerId = null);

		/// <inheritdoc cref="ILikesCategoryAsync.DeleteAsync(LikeObjectType, long, long?,long?,string)" />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		long Delete(LikeObjectType type, long itemId, long? ownerId = null, long? captchaSid = null, string captchaKey = null);

		/// <inheritdoc cref="ILikesCategoryAsync.IsLikedAsync" />
		bool IsLiked(out bool copied, LikeObjectType type, long itemId, long? userId = null, long? ownerId = null);
	}
}