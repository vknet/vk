using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages;

public class MessagesSetActivityTests : MessagesBaseTests
{
	[Test]
	[DisplayName("Messages set activity without peer id and group id throws")]
	public void Messages_SetActivity_Without_PeerId_And_GroupId_Throws() => FluentActions
		.Invoking(() => Api.Messages.SetActivity("some_user_id", MessageActivityType.Typing))
		.Should()
		.ThrowExactly<VkApiException>();

	[Test]
	[DisplayName("Messages set activity with both peer id and group id throws")]
	public void Messages_SetActivity_With_Both_PeerId_And_GroupId_Throws() => FluentActions.Invoking(() =>
			Api.Messages.SetActivity("some_user_id", MessageActivityType.Typing, 125, 125))
		.Should()
		.ThrowExactly<VkApiException>();

	[Test]
	[DisplayName("Messages set activity with peer id doesnt fail")]
	public void Messages_SetActivity_With_PeerId_DoesntFail()
	{
		Url = "https://api.vk.ru/method/messages.setActivity";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.SetActivity("7550525", MessageActivityType.Typing, 1);

		result.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("Messages set activity with group id doesnt fail")]
	public void Messages_SetActivity_With_GroupId_DoesntFail()
	{
		Url = "https://api.vk.ru/method/messages.setActivity";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Messages.SetActivity("7550525", MessageActivityType.Typing, null, 2);

		result.Should()
			.BeTrue();
	}
}