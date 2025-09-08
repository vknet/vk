using AwesomeAssertions;
using VkNet.Enums.Filters;
using Xunit;

namespace VkNet.Tests.Categories.Messages;

public class MessagesGetChatPreview : MessagesBaseTests
{
	[Fact(DisplayName = "Default params")]
	public void DefaultParams()
	{
		Url = "https://api.vk.ru/method/messages.getChatPreview";
		ReadCategoryJsonPath(nameof(DefaultParams));

		var result = Api.Messages.GetChatPreview("http://vk.ru", ProfileFields.About);

		result.Should()
			.NotBeNull();

		result.Emails.Should()
			.NotBeEmpty();

		result.Groups.Should()
			.NotBeEmpty();

		result.Profiles.Should()
			.NotBeEmpty();

		result.Preview.Should()
			.NotBeNull();

		result.Preview.LocalId.Should()
			.Be(43);

		result.Preview.Title.Should()
			.Be("qwe");

		result.Preview.AdminId.Should()
			.Be(123);

		result.Preview.Members.Should()
			.NotBeEmpty();
	}
}