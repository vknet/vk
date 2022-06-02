using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Orders
{


	public class OrdersGetByIdTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Fact]
		public void GetById()
		{
			Url = "https://api.vk.com/method/orders.getById";
			ReadCategoryJsonPath(nameof(GetById));

			var result = Api.Orders.GetById();

			result.Should().NotBeEmpty();
		}
	}
}