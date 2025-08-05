using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Market
{
	public class MarketGetTest : CategoryBaseTest
	{
		protected override string Folder => "Market";

		[Fact]
		public void MarketGet()
		{
			Url = "https://api.vk.com/method/market.get";

			ReadCategoryJsonPath(nameof(Api.Markets.Get));

			var result = Api.Markets.Get(new()
			{
				OwnerId = -85689507,
				Count = 2,
				Offset = 0,
				DateFrom = "10.08.2022",
				DateTo = "10.06.2023"
			});

			result.Should().
				NotBeNull();

			result.Count.
				Should().
				Be(2);

			result[0].Title.
				Should().
				Be("Жетон Bronze");

			result[0].Price.
				Amount.
				Should().
				Be(89000);

			result[0].Category.
				Name.
				Should().
				Be("Кошельки, ключницы и брелки");

			result[0].Category.
				Section.
				Name.
				Should().
				Be("Гардероб");

			result[1].Title.
				Should().
				Be("Жетон Black");

			result[1].Price.
				Amount.
				Should().
				Be(89000);

			result[1].Description.
				Should().
				Be("Брендированный жетон в расцветке Black");

			result[1].OwnerId.
				Should().
				Be(-85689507);
		}
	}
}
