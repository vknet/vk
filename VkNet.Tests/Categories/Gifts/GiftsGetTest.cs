using System;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Gifts;

public class GiftsGetTest : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "Gifts";

	[Fact]
	public void Get_NormalCase()
	{
		Url = "https://api.vk.com/method/gifts.get";
		ReadCategoryJsonPath(nameof(Get_NormalCase));

		var gifts = Api.Gifts.Get(32190123);

		gifts.TotalCount.Should()
			.BeGreaterThanOrEqualTo(0);

		var gift = gifts.FirstOrDefault();

		gift.Should()
			.NotBeNull();

		gift.Id.Should()
			.Be(-577952355);

		gift.FromId.Should()
			.Be(103942820);

		gift.Message.Should()
			.Be("С Днём Рождения!!! Пущай в доме твоём всегда будут уют, тепло, весёлость и вкусняшки ^.^");

		gift.Date.Value.Should()
			.Be(DateHelper.TimeStampToDateTime(1452854355));

		gift.Gift.Id.Should()
			.Be(658);

		gift.Gift.Thumb256.Should()
			.Be(new Uri("https://vk.com/images/gift/658/256.jpg"));

		gift.Gift.Thumb96.Should()
			.Be(new Uri("https://vk.com/images/gift/658/96.png"));

		gift.Gift.Thumb48.Should()
			.Be(new Uri("https://vk.com/images/gift/658/48.png"));

		gift.Privacy.Should()
			.Be(GiftPrivacy.All);

		gift.GiftHash.Should()
			.Be(
				"XZuJeI8mbdkphj7QQ8I7n*Bh1bnuJQqwraxWyjYdp45ZWPhzrn6pTPlUirsRlvyPq7iwAd5/I6iWNYl8pch6jZVRjT5BnpGtN8flF00CFI58XXEJboNLTyfvO4pFL48psGgKdgRJJgi8cL7zfcGZhVMYXG/lrCHVP9GoLXdOSso-");
	}
}