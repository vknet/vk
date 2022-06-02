using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders
{


	public class OrdersGetUserSubscriptionByIdTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Fact]
		public void GetUserSubscriptionById()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptionById";
			ReadCategoryJsonPath(nameof(GetUserSubscriptionById));

			var result = Api.Orders.GetUserSubscriptionById(123, 234);

			result.Should().NotBeNull();
		}
	}
}