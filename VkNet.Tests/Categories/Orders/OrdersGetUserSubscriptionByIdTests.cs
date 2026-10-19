using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetUserSubscriptionByIdTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Test]
	[DisplayName("Get user subscription by id")]
	public void GetUserSubscriptionById()
	{
		Url = "https://api.vk.ru/method/orders.getUserSubscriptionById";
		ReadCategoryJsonPath(nameof(GetUserSubscriptionById));

		var result = Api.Orders.GetUserSubscriptionById(123, 234);

		result.Should()
			.NotBeNull();
	}
}