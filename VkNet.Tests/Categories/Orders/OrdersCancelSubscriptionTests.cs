using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders;

public class OrdersCancelSubscriptionTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Fact]
	public void CancelSubscription()
	{
		Url = "https://api.vk.com/method/orders.cancelSubscription";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Orders.CancelSubscription(123, 23);

		result.Should()
			.BeTrue();
	}
}