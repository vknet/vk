using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с подарками.
/// </summary>
public interface IGiftsCategory : IGiftsCategoryAsync
{
	/// <inheritdoc cref="IGiftsCategoryAsync.GetAsync" />
	VkCollection<GiftItem> Get(long? userId = null, int? count = null, int? offset = null);
}