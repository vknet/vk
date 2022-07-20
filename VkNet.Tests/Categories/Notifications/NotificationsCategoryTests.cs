using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Notifications
{


	public class NotificationsCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Notifications";

		[Fact]
		public void MarkAsViewed()
		{
			Url = "https://api.vk.com/method/notifications.markAsViewed";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notifications.MarkAsViewed();

			result.Should().BeTrue();
		}
	}
}