using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetUserSubscriptionsTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Test]
	[DisplayName("Get user subscriptions")]
	public void GetUserSubscriptions()
	{
		Url = "https://api.vk.ru/method/orders.getUserSubscriptions";
		ReadCategoryJsonPath(nameof(GetUserSubscriptions));

		var result = Api.Orders.GetUserSubscriptions(123);

		result.Should()
			.NotBeEmpty();
	}
}