﻿using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetLongPollHistory : MessagesBaseTests
{
	[Fact]
	public void GetLongPollHistory_ThrowArgumentException() => FluentActions.Invoking(() => Api.Messages.GetLongPollHistory(new()))
		.Should()
		.ThrowExactly<ArgumentException>();

	[Fact]
	public void GroupsField()
	{
		Url = "https://api.vk.com/method/messages.getLongPollHistory";

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

		result.UnreadMessages.Should()
			.Be(1);

		result.Messages.TotalCount.Should()
			.Be(1);

		result.Groups.First().Id.Should()
			.Be(103292418);
	}
}