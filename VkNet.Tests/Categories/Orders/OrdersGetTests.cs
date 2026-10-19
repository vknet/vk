using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Test]
	[DisplayName("Get")]
	public void Get()
	{
		Url = "https://api.vk.ru/method/orders.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Orders.Get();

		result.Should()
			.NotBeEmpty();
	}
}