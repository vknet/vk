using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]

	public class OrdersGetUserSubscriptionsTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void GetUserSubscriptions()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptions";
			ReadCategoryJsonPath(nameof(GetUserSubscriptions));

			var result = Api.Orders.GetUserSubscriptions(123);

			Assert.IsNotEmpty(result);
		}
	}
}