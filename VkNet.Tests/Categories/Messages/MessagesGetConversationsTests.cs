using FluentAssertions;
using VkNet.Enums.StringEnums;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetConversationsTests : MessagesBaseTests
{
	[Fact]
	public void GetConversations()
	{
		Url = "https://api.vk.com/method/messages.getConversations";
		ReadCategoryJsonPath(nameof(GetConversations));

		var result = Api.Messages.GetConversations(new());

		result.Count.Should()
			.Be(1);
	}

	[Fact]
	public void GetConversations_Attachment_wall()
	{
		Url = "https://api.vk.com/method/messages.getConversations";
		ReadCategoryJsonPath(nameof(GetConversations_Attachment_wall));

		var result = Api.Messages.GetConversations(new());

		result.Count.Should()
			.Be(253);
	}

	[Fact]
	public void GetConversations_Group_PhotoField()
	{
		Url = "https://api.vk.com/method/messages.getConversations";
		ReadCategoryJsonPath(nameof(GetConversations_Group_PhotoField));

		var result = Api.Messages.GetConversations(new()
		{
			Filter = GetConversationFilter.All,
			Count = 1,
			Offset = 0,
			Extended = true
		});

		result.Count.Should()
			.Be(177);

		result.Groups.Should()
			.NotBeNullOrEmpty();

		result.Groups[0]
			.Should()
			.NotBeNull();

		result.Groups[0]
			.Photo50.Should()
			.NotBeNull();

		result.Groups[0]
			.Id.Should()
			.NotBe(0);

		result.Groups[0]
			.Name.Should()
			.NotBeNullOrEmpty();

		result.Groups[0]
			.ScreenName.Should()
			.NotBeNullOrEmpty();

		result.Groups[0]
			.Type.Should()
			.Be(GroupType.Group);
	}
}