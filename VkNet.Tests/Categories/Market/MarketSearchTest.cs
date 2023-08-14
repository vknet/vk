using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Market
{
	public class MarketSearchTest : CategoryBaseTest
	{
		protected override string Folder => "Market";

		[Fact]
		public void MarketSearch()
		{
			Url = "https://api.vk.com/method/market.search";

			ReadCategoryJsonPath(nameof(Api.Markets.Search));

			var result = Api.Markets.Search(new()
			{
				OwnerId = -85689507,
				PriceFrom = 5000,
				Sort = Enums.ProductSort.ByCost,
				Offset = 0,
				Count = 2,
				Status = "0",
				NeedVariants = true
			});

			result.Should().
				NotBeNull();

			result.Count.
				Should().
				Be(2);

			result[0].Title.
				Should().
				Be("Bastet Snowboard");

			result[0].Price.
				Amount.
				Should().
				Be(5000000);

			result[0].Category.
				Name.
				Should().
				Be("Доски для сноубординга");

			result[0].Availability.
				Should().
				Be(0);

			result[1].Title.
				Should().
				Be("Katana NIKIFILINI");

			result[1].Price.
				Amount.
				Should().
				Be(2290000);

			result[1].OwnerId.
				Should().
				Be(-85689507);

			result[1].Category.
				Section.
				Name.
				Should().
				Be("Спорт и отдых");
		}
	}
}
