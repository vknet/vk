using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersGetAmountTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void GetAmount()
		{
			Url = "https://api.vk.com/method/orders.getAmount";
			ReadCategoryJsonPath(nameof(GetAmount));

			var result = Api.Orders.GetAmount(123, new[] { "1" });

			Assert.IsNotEmpty(result);
		}
	}
}