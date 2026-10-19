using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetAmountTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Test]
	[DisplayName("Get amount")]
	public void GetAmount()
	{
		Url = "https://api.vk.ru/method/orders.getAmount";
		ReadCategoryJsonPath(nameof(GetAmount));

		var result = Api.Orders.GetAmount(123, ["1"]);

		result.Should()
			.NotBeEmpty();
	}
}