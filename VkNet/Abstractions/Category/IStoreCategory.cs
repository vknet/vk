using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions.Category;

/// <summary>
/// Методы для работы со стикерами и продуктами
/// </summary>
public interface IStoreCategory : IStoreCategoryAsync
{
	/// <inheritdoc cref="IStoreCategoryAsync.AddStickersToFavoriteAsync"/>
	bool AddStickersToFavorite(StoreAddStickerToFavoriteParams @params);

	/// <inheritdoc cref="IStoreCategoryAsync.GetFavoriteStickersAsync"/>
	VkCollection<Sticker> GetFavoriteStickers();

	/// <inheritdoc cref="IStoreCategoryAsync.GetProductsAsync"/>
	VkCollection<Product> GetProducts(StoreGetProductsParams @params);

	/// <inheritdoc cref="IStoreCategoryAsync.GetStickersKeywordsAsync"/>
	StickersKeywords GetStickersKeywords(StoreGetStickersKeywordsParams @params);

	/// <inheritdoc cref="IStoreCategoryAsync.RemoveStickersFromFavoriteAsync"/>
	bool RemoveStickersFromFavorite(StoreRemoveStickersFromFavoriteParams @params);
}