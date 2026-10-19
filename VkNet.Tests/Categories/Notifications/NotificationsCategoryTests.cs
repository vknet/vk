using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Notifications;

public class NotificationsCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Notifications";

	[Test]
	[DisplayName("Mark as viewed")]
	public void MarkAsViewed()
	{
		Url = "https://api.vk.ru/method/notifications.markAsViewed";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Notifications.MarkAsViewed();

		result.Should()
			.BeTrue();
	}
}