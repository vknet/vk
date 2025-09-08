using AwesomeAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class MarketModel
{
	[Fact(DisplayName = "To string market should have id and access key")]
	public void ToString_MarketShouldHaveIdAndAccessKey()
	{
		var market = new Market
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = market.ToString();

		result.Should()
			.Be("market1234_1234_test");
	}
}