using VkNet.Abstractions.Category;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IStoreCategory" />
public partial class StoreCategory : IStoreCategory
{
	/// <inheritdoc />
	public bool AddStickersToFavorite(StoreAddStickerToFavoriteParams @params) =>
		_vk.Call<bool>("store.addStickersToFavorite", new()
		{
			{
				"sticker_ids", @params.StickerIds
			}
		});

	/// <inheritdoc />
	public VkCollection<Sticker> GetFavoriteStickers() =>
		_vk.Call<VkCollection<Sticker>>("store.getFavoriteStickers", new());

	/// <inheritdoc />
	public VkCollection<Product> GetProducts(StoreGetProductsParams @params) =>
		_vk.Call<VkCollection<Product>>("store.getProducts", new()
		{
			{
				"type", @params.Type
			},
			{
				"merchant", @params.Merchant
			},
			{
				"product_ids", @params.ProductIds
			},
			{
				"filters", @params.Filters
			},
			{
				"extended", @params.Extended
			}
		});

	/// <inheritdoc />
	public StickersKeywords GetStickersKeywords(StoreGetStickersKeywordsParams @params) =>
		_vk.Call<StickersKeywords>("store.getStickersKeywords", new()
		{
			{
				"stickers_ids", @params.StickerIds
			},
			{
				"products_ids", @params.ProductIds
			},
			{
				"aliases", @params.Aliases
			},
			{
				"all_products", @params.AllProducts
			},
			{
				"need_stickers", @params.NeedStickers
			}
		});

	/// <inheritdoc />
	public bool RemoveStickersFromFavorite(StoreRemoveStickersFromFavoriteParams @params) =>
		_vk.Call<bool>("store.removeStickersFromFavorite", new()
		{
			{
				"sticker_ids", @params.StickerIds
			}
		});
}