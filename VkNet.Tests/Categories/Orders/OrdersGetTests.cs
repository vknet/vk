using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	public class OrdersGetTests: BaseTest
	{
		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/orders.get";

			Json = @"{
				'response': [
					{
						'item': 'item'
					}
				]
			}";

			var result = Api.Orders.Get();

			Assert.IsNotEmpty(result);
		}
	}
}