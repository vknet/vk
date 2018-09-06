using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersGetUserSubscriptionByIdTests: BaseTest
	{
		[Test]
		public void GetUserSubscriptionById()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptionById";

			Json = @"{
				'response':
					{
						'id': 123
					}
			}";

			var result = Api.Orders.GetUserSubscriptionById(123, 234);

			Assert.IsNotNull(result);
		}
	}
}