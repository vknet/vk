using System;
using AwesomeAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetLongPollHistory : MessagesBaseTests
{
	[Fact(DisplayName = "Get long poll history throw argument exception")]
	public void GetLongPollHistory_ThrowArgumentException() => FluentActions.Invoking(() => Api.Messages.GetLongPollHistory(new()))
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact(DisplayName = "Groups field")]
	public void GroupsField()
	{
		Url = "https://api.vk.ru/method/messages.getLongPollHistory";

		ReadCategoryJsonPath(nameof(Api.Messages.GetLongPollHistory));

		var result = Api.Messages.GetLongPollHistory(new()
		{
			Ts = 1874397841,
			PreviewLength = 0,
			EventsLimit = 1000,
			MsgsLimit = 200,
			MaxMsgId = 0,
			Onlines = true
		});

		result.Groups.Should()
			.NotBeEmpty();
	}
}