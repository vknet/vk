using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersGetUserSubscriptionByIdTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void GetUserSubscriptionById()
		{
			Url = "https://api.vk.com/method/orders.getUserSubscriptionById";
			ReadCategoryJsonPath(nameof(GetUserSubscriptionById));

			var result = Api.Orders.GetUserSubscriptionById(123, 234);

			Assert.IsNotNull(result);
		}
	}
}