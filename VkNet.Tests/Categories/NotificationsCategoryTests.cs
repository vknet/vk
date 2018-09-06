using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class NotificationsCategoryTests : BaseTest
	{
		[Test]
		public void MarkAsViewed()
		{
			Json = @"
            {
				'response': 1
			}";

			Url = "https://api.vk.com/method/notifications.markAsViewed";
			var result = Api.Notifications.MarkAsViewed();
			Assert.True(result);
		}
	}
}