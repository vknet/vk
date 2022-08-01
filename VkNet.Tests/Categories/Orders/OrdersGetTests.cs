using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Fact]
	public void Get()
	{
		Url = "https://api.vk.com/method/orders.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Orders.Get();

		result.Should()
			.NotBeEmpty();
	}
}