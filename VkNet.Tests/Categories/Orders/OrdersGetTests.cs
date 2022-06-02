using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]

	public class OrdersGetTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/orders.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.Orders.Get();

			result.Should().NotBeEmpty();
		}
	}
}