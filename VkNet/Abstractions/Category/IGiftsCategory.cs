using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IGiftsCategoryAsync" />
	public interface IGiftsCategory : IGiftsCategoryAsync
	{
		/// <inheritdoc cref="IGiftsCategoryAsync.GetAsync" />
		VkCollection<GiftItem> Get(long? userId = null, int? count = null, int? offset = null);
	}
}