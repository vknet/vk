using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	public class OrdersGetUserSubscriptionsTests: BaseTest
	{
		[Test]
		public void GetUserSubscriptions()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptions";

			Json = @"{
				'response': [
					{
						'id': 123
					}
				]
			}";

			var result = Api.Orders.GetUserSubscriptions(123);

			Assert.IsNotEmpty(result);
		}
	}
}