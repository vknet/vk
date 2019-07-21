using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class GiftsCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<GiftItem>> GetAsync(long userId,
													int? count = null,
													int? offset = null,
													CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<VkCollection<GiftItem>>("gifts.get",
				new VkParameters
				{
					{ "user_id", userId },
					{ "count", count },
					{ "offset", offset }
				},
				cancellationToken: cancellationToken);
		}
	}
}