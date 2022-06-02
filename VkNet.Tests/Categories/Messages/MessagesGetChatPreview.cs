using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.Filters;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]

	public class MessagesGetChatPreview : MessagesBaseTests
	{
		[Test]
		public void DefaultParams()
		{
			Url = "https://api.vk.com/method/messages.getChatPreview";
			ReadCategoryJsonPath(nameof(DefaultParams));

			var result = Api.Messages.GetChatPreview("http://vk.com", ProfileFields.About);

			result.Should().NotBeNull();
			result.Emails.Should().NotBeEmpty();
			result.Groups.Should().NotBeEmpty();
			result.Profiles.Should().NotBeEmpty();
			result.Preview.Should().NotBeNull();
			result.Preview.LocalId.Should().Be(43);
			result.Preview.Title.Should().Be("qwe");
			result.Preview.AdminId.Should().Be(123);
			result.Preview.Members.Should().NotBeEmpty();
		}
	}
}