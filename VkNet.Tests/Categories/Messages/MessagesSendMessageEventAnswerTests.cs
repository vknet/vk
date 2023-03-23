using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesSendMessageEventAnswerTests : MessagesBaseTests
{
	[Fact]
	public void SendMessageEventAnswer()
	{
		Url = "https://api.vk.com/method/messages.sendMessageEventAnswer";
		ReadJsonFile(JsonPaths.True);

		var data = new EventData
		{
			Type = MessageEventType.ShowSnackbar,
			Text = "text"
		};

		var result = Api.Messages.SendMessageEventAnswer("testEventId", 1, 1, data);

		result.Should()
			.BeTrue();
	}
}