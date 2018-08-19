using NUnit.Framework;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	public class OrdersGetAmountTests: BaseTest
	{
		[Test]
		public void GetAmount()
		{
			Url = "https://api.vk.com/method/orders.getAmount";

			Json = @"{
				'response': [
					{
						'votes': 'item',
						'amount': 1,
						'description': 'description',
						'currency': 'Rub'
					}
				]
			}";

			var result = Api.Orders.GetAmount(123, new []{"1"});

			 Assert.IsNotEmpty(result);
		}
	}
}