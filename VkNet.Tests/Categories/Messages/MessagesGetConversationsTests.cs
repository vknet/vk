using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories.Messages
{
	public class MessagesGetConversationsTests : MessagesBaseTests
	{
		[Test]
		public void GetConversations()
		{
			Url = "https://api.vk.com/method/messages.getConversations";
			ReadCategoryJsonPath(nameof(GetConversations));

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(1, Is.EqualTo(result.Count));
		}

		[Test]
		public void GetConversations_Attachment_wall()
		{
			Url = "https://api.vk.com/method/messages.getConversations";
			ReadCategoryJsonPath(nameof(GetConversations_Attachment_wall));

			var result = Api.Messages.GetConversations(new GetConversationsParams());

			Assert.That(253, Is.EqualTo(result.Count));
		}

		[Test]
		public void GetConversations_Group_PhotoField()
		{
			Url = "https://api.vk.com/method/messages.getConversations";
			ReadCategoryJsonPath(nameof(GetConversations_Group_PhotoField));

			var result = Api.Messages.GetConversations(new GetConversationsParams
			{
				Filter = GetConversationFilter.All,
				Count = 1,
				Offset = 0,
				Extended = true
			});

			result.Count.Should().Be(177);
			result.Groups.Should().NotBeNullOrEmpty();
			result.Groups[0].Should().NotBeNull();
			result.Groups[0].Photo50.Should().NotBeNull();
			result.Groups[0].Id.Should().NotBe(0);
			result.Groups[0].Name.Should().NotBeNullOrEmpty();
			result.Groups[0].ScreenName.Should().NotBeNullOrEmpty();
			result.Groups[0].Type.Should().Be(GroupType.Group);
		}
	}
}