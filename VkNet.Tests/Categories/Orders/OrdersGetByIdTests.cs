using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class OrdersGetByIdTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/orders.getById";
			ReadCategoryJsonPath(nameof(GetById));

			var result = Api.Orders.GetById();

			Assert.IsNotEmpty(result);
		}
	}
}