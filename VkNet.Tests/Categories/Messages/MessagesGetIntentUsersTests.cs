using FluentAssertions;
using VkNet.Enums.StringEnums;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetIntentUsersTests : MessagesBaseTests
{
	[Fact]
	public void GetIntentUsers()
	{
		// Arrange
		Url = "https://api.vk.com/method/messages.getIntentUsers";
		ReadCategoryJsonPath(nameof(GetIntentUsers));

		// Act
		var result = Api.Messages.GetIntentUsers(new()
		{
			Intent = MessageIntent.ConfirmedNotification,
			SubscribeId = 1,
			Offset = 0,
			Count = 20,
			Extended = true
		});

		// Assert
		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);

		result.Items.Should()
			.NotBeNullOrEmpty();

		result.Items.Should()
			.HaveCount(1);

		result.Profiles.Should()
			.NotBeNullOrEmpty();

		result.Profiles.Should()
			.HaveCount(1);
	}
}