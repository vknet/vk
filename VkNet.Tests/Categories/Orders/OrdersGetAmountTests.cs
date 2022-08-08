using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders;

public class OrdersGetAmountTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Fact]
	public void GetAmount()
	{
		Url = "https://api.vk.com/method/orders.getAmount";
		ReadCategoryJsonPath(nameof(GetAmount));

		var result = Api.Orders.GetAmount(123, new[]
		{
			"1"
		});

		result.Should()
			.NotBeEmpty();
	}
}