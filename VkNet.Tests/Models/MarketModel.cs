using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class MarketModel
{
	[Fact]
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