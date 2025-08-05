using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Abstractions.Category;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IStoreCategory"/>
public partial class StoreCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="StoreCategory" />
	/// </summary>
	public StoreCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public Task<bool> AddStickersToFavoriteAsync(StoreAddStickerToFavoriteParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddStickersToFavorite(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<Sticker>> GetFavoriteStickersAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(
			GetFavoriteStickers, token);

	/// <inheritdoc />
	public Task<VkCollection<Product>> GetProductsAsync(StoreGetProductsParams @params, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetProducts(@params), token);

	/// <inheritdoc />
	public Task<StickersKeywords> GetStickersKeywordsAsync(StoreGetStickersKeywordsParams @params, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetStickersKeywords(@params), token);

	/// <inheritdoc />
	public Task<bool> RemoveStickersFromFavoriteAsync(StoreRemoveStickersFromFavoriteParams @params, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveStickersFromFavorite(@params), token);
}