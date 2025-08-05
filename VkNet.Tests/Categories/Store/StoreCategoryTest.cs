using System;
using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Store;

public class StoreCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Store";

	[Fact]
	public void AddStickersToFavorite()
	{
		Url = "https://api.vk.com/method/store.addStickersToFavorite";

		ReadCategoryJsonPath(nameof(AddStickersToFavorite));

		var result = Api.Store.AddStickersToFavorite(new()
		{
			StickerIds = ["126", "70"]
		});

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void GetFavoriteStickers()
	{
		Url = "https://api.vk.com/method/store.getFavoriteStickers";

		ReadCategoryJsonPath(nameof(GetFavoriteStickers));

		var result = Api.Store.GetFavoriteStickers();

		result.Count.Should()
			.Be(2);

		var first = result[0];

		first.Id.Should()
			.Be(126);

		first.InnerType.Should()
			.Be("base_sticker_new");

		first.IsAllowed.Should()
			.BeTrue();

		var second = result[1];

		second.Id.Should()
			.Be(70);

		second.InnerType.Should()
			.Be("base_sticker_new");

		second.IsAllowed.Should()
			.BeFalse();
	}

	[Fact]
	public void GetProducts()
	{
		Url = "https://api.vk.com/method/store.getProducts";

		ReadCategoryJsonPath(nameof(GetProducts));

		var result = Api.Store.GetProducts(new()
		{
			Type = ProductType.Stickers,
			ProductIds = ["148"],
			Filters = [ProductStatusFilter.Purchased, ProductStatusFilter.Active],
			Extended = true
		});

		result.Count.Should()
			.Be(1);

		var product = result[0];

		product.Id.Should()
			.Be(148);

		product.Type.Should()
			.Be(ProductType.Stickers);

		product.IsNew.Should()
			.BeFalse();

		product.Copyright.Should()
			.Be("ООО «ВКонтакте» 2017");

		product.Purchased.Should()
			.BeTrue();

		product.Active.Should()
			.BeTrue();

		product.PurchaseDate.Should()
			.Be(DateTime.Parse("2024-01-10 12:52:23 PM"));

		product.Title.Should()
			.Be("#ПушкинНашеВсё");

		product.Stickers.Count.Should()
			.Be(24);

		product.Icon.BaseUrl.Should()
			.Be("https://vk.com/sticker/packs/148/icon");

		product.Previews.Count.Should()
			.Be(5);
	}

	[Fact]
	public void GetStickersKeywords()
	{
		Url = "https://api.vk.com/method/store.getStickersKeywords";

		ReadCategoryJsonPath(nameof(GetStickersKeywords));

		var result = Api.Store.GetStickersKeywords(new()
		{
			StickerIds = ["126"],
			Aliases = true,
			AllProducts = false,
			NeedStickers = true
		});

		result.Dictionary.Count.Should()
			.Be(1);

		result.Dictionary[0].Words.Count.Should()
			.Be(51);

		result.Dictionary[0].UserStickers.Count.Should()
			.Be(1);

		var sticker = result.Dictionary[0].UserStickers[0];

		sticker.InnerType.Should()
			.Be("base_sticker_new");

		sticker.Id.Should()
			.Be(126);

		sticker.IsAllowed.Should()
			.BeTrue();
	}

	[Fact]
	public void RemoveStickersFromFavorite()
	{
		Url = "https://api.vk.com/method/store.removeStickersFromFavorite";

		ReadCategoryJsonPath(nameof(RemoveStickersFromFavorite));

		var result = Api.Store.RemoveStickersFromFavorite(new()
		{
			StickerIds = ["126", "70"]
		});

		result.Should()
			.BeTrue();
	}
}