using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories.Orders
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class ChangeStateTests: BaseTest
	{
		[Test]
		public void ChangeState()
		{
			Url = "https://api.vk.com/method/orders.changeState";

			Json = @"{ 'response': 'charged' }";

			var result = Api.Orders.ChangeState(123, OrderStateAction.Charge);

			Assert.AreEqual(OrderState.Charged, result);
		}
	}
}