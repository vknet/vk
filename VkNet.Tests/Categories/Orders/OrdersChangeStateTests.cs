using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders;

public class ChangeStateTests : CategoryBaseTest
{
	protected override string Folder => "Orders";

	[Fact]
	public void ChangeState()
	{
		Url = "https://api.vk.com/method/orders.changeState";
		ReadCategoryJsonPath(nameof(ChangeState));

		var result = Api.Orders.ChangeState(123, OrderStateAction.Charge);

		result.Should()
			.Be(OrderState.Charged);
	}
}