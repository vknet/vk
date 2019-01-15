using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class ChangeStateTests : CategoryBaseTest
	{
		protected override string Folder => "Orders";

		[Test]
		public void ChangeState()
		{
			Url = "https://api.vk.com/method/orders.changeState";
			ReadCategoryJsonPath(nameof(ChangeState));

			var result = Api.Orders.ChangeState(123, OrderStateAction.Charge);

			Assert.AreEqual(OrderState.Charged, result);
		}
	}
}