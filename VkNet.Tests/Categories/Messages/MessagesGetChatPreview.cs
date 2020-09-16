using System.Diagnostics.CodeAnalysis;
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

			Assert.NotNull(result);
			Assert.That(result.Emails, Is.Not.Empty);
			Assert.That(result.Groups, Is.Not.Empty);
			Assert.That(result.Profiles, Is.Not.Empty);
			Assert.That(result.Preview, Is.Not.Null);
			Assert.That(result.Preview.LocalId, Is.EqualTo(43));
			Assert.That(result.Preview.Title, Is.EqualTo("qwe"));
			Assert.That(result.Preview.AdminId, Is.EqualTo(123));
			Assert.That(result.Preview.Members, Is.Not.Empty);
		}
	}
}