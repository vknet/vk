using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders
{


	public class OrdersGetUserSubscriptionsTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Fact]
		public void GetUserSubscriptions()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptions";
			ReadCategoryJsonPath(nameof(GetUserSubscriptions));

			var result = Api.Orders.GetUserSubscriptions(123);

			result.Should().NotBeEmpty();
		}
	}
}