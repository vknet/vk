using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersUpdateSubscriptionTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void UpdateSubscription()
		{
			Url = "https://api.vk.com/method/orders.updateSubscription";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Orders.UpdateSubscription(123, 234, 500);

			Assert.IsTrue(result);
		}
	}
}