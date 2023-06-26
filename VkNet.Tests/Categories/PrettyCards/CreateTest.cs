using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.PrettyCards;

public class CreateTest : CategoryBaseTest
{
	protected override string Folder => "PrettyCards";

	[Fact]
	public void Create()
	{
		Url = "https://api.vk.com/method/prettyCards.create";

		ReadCategoryJsonPath(nameof(Api.PrettyCards.Create));

		var result = Api.PrettyCards.Create(new()
		{
			OwnerId = -126102803,
			Photo = "-126102803_457239118",
			Price = "123",
			PriceOld = "140",
			Title = "123",
			Link = "tel:+79111234567",
			Button = Button.Call
		});

		result.Should()
			.NotBeNull();

		result.CardId.Should()
			.Be("545435");

		result.OwnerId.Should()
			.Be(-126102803);
	}
}