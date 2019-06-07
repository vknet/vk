using System;
using System.Threading;
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
		public async Task<VkCollection<long>> GetListAsync(LikesGetListParams @params,
															bool skipAuthorization = false,
															CancellationToken cancellationToken = default)
		{
			@params.Extended = false;

			return (await _vk.CallAsync("likes.getList", @params, skipAuthorization, cancellationToken)
					.ConfigureAwait(false))
				.ToVkCollectionOf<long>(x => x);
		}

		/// <inheritdoc />

		//TODO: сделать кастомный JsonConverter
		public async Task<UserOrGroup> GetListExAsync(LikesGetListParams @params, CancellationToken cancellationToken = default)
		{
			@params.Extended = true;

			return await _vk.CallAsync("likes.getList", @params, true, cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<long> AddAsync(LikesAddParams @params, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("likes.add", @params, cancellationToken: cancellationToken).ConfigureAwait(false);

			return response["likes"];
		}

		/// <inheritdoc />
		[Obsolete(ObsoleteText.CaptchaNeeded)]
		public async Task<long> DeleteAsync(LikeObjectType type,
											long itemId,
											long? ownerId = null,
											long? captchaSid = null,
											string captchaKey = null,
											CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "item_id", itemId },
				{ "owner_id", ownerId },
				{ "captcha_sid", captchaSid },
				{ "captcha_key", captchaKey }
			};

			var response = await _vk.CallAsync("likes.delete", parameters, cancellationToken: cancellationToken).ConfigureAwait(false);

			return response["likes"];
		}

		/// <inheritdoc />

		//TODO: сделать объект с полями liked, copied.
		public async Task<bool> IsLikedAsync(LikeObjectType type,
											long itemId,
											long? userId = null,
											long? ownerId = null,
											CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "item_id", itemId },
				{ "user_id", userId },
				{ "owner_id", ownerId }
			};

			var resp = await _vk.CallAsync("likes.isLiked", parameters, cancellationToken: cancellationToken).ConfigureAwait(false);

			return resp["liked"];
		}
	}
}