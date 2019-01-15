using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersCancelSubscriptionTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void CancelSubscription()
		{
			Url = "https://api.vk.com/method/orders.cancelSubscription";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Orders.CancelSubscription(123, 23);

			Assert.IsTrue(result);
		}
	}
}