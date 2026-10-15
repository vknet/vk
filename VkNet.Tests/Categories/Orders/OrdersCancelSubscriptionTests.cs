using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders;

public class OrdersCancelSubscriptionTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Test]
	[DisplayName("Cancel subscription")]
	public void CancelSubscription()
	{
		Url = "https://api.vk.ru/method/orders.cancelSubscription";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Orders.CancelSubscription(123, 23);

		result.Should()
			.BeTrue();
	}
}