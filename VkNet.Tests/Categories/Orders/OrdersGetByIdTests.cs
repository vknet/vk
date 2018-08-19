using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	public class OrdersGetByIdTests: BaseTest
	{
		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/orders.getById";

			Json = @"{
				'response': [
					{
						'item': 'item'
					}
				]
			}";

			var result = Api.Orders.GetById();

			Assert.IsNotEmpty(result);
		}
	}
}