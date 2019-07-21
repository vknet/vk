using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
	public interface IGiftsCategory : IGiftsCategoryAsync
	{
		/// <inheritdoc cref="IGiftsCategoryAsync.GetAsync" />
		VkCollection<GiftItem> Get(long userId, int? count = null, int? offset = null);
	}
}