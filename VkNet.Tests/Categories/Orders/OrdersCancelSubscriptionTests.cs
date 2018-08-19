using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	public class OrdersCancelSubscriptionTests: BaseTest
	{
		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/orders.cancelSubscription";

			Json = @"{
				'response': 1
			}";

			var result = Api.Orders.CancelSubscription(123, 23);

			Assert.IsTrue(result);
		}
	}
}