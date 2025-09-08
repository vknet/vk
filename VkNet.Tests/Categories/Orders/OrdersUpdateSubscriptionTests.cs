using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders;

public class OrdersUpdateSubscriptionTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Fact(DisplayName = "Update subscription")]
	public void UpdateSubscription()
	{
		Url = "https://api.vk.ru/method/orders.updateSubscription";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Orders.UpdateSubscription(123, 234, 500);

		result.Should()
			.BeTrue();
	}
}