using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersUpdateSubscriptionTests : BaseTest
	{
		[Test]
		public void UpdateSubscription()
		{
			Url = "https://api.vk.com/method/orders.updateSubscription";

			Json = @"{
				'response': 1
			}";

			var result = Api.Orders.UpdateSubscription(123, 234, 500);

			Assert.IsTrue(result);
		}
	}
}