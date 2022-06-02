using System;
using FluentAssertions;
using VkNet.Model.RequestParams;
using Xunit;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetLongPollHistory : MessagesBaseTests
	{
		[Fact]
		public void GetLongPollHistory_ThrowArgumentException()
		{
			FluentActions.Invoking(() => Api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams()))
				.Should()
				.ThrowExactly<ArgumentException>();
		}

		[Fact]
		public void GroupsField()
		{
			Url = "https://api.vk.com/method/messages.getLongPollHistory";

			ReadCategoryJsonPath(nameof(Api.Messages.GetLongPollHistory));

			var result = Api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams
			{
				Ts = 1874397841,
				PreviewLength = 0,
				EventsLimit = 1000,
				MsgsLimit = 200,
				MaxMsgId = 0,
				Onlines = true
			});

			result.Groups.Should().NotBeEmpty();
		}
	}
}