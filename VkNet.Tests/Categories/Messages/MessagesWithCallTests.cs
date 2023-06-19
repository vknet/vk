using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesWithCallTests : MessagesBaseTests
{
	[Fact]
	public void Message_WithCallAttachment_AllFieldsArePresent()
	{
		ReadJsonFile("Models", "message_with_call");

		Url = "https://api.vk.com/method/friends.getRequests";
		var message = Api.Call<Message>("friends.getRequests", VkParameters.Empty);


		var call = message.Attachments[0]
			.Instance as Call;

		call.Should()
			.NotBeNull();

		call.Video.Should()
			.BeTrue();

		call.State.Should()
			.Be("reached");

		call.InitiatorId.Should()
			.Be(12345678);

		call.ReceiverId.Should()
			.Be(2012345678);

		call.Duration.HasValue.Should()
			.BeTrue();

		call.Duration.Value.Should()
			.Be(30);

		call.Time.AsUtc()
			.Should()
			.Be(new(2021,
				9,
				27,
				19,
				21,
				21,
				DateTimeKind.Utc));
	}
}