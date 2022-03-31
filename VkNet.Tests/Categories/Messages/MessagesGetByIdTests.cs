using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{

	public class MessagesGetByIdTests : MessagesBaseTests
	{
		[Test]
		public void AdminAuthorId()
		{
			Url = "https://api.vk.com/method/messages.getById";
			ReadCategoryJsonPath(nameof(AdminAuthorId));

			var result = Api.Messages.GetById(new ulong[]
				{
					123
				},
				new[]
				{
					"123"
				});

			var message = result.FirstOrDefault();
			message.Should().NotBeNull();
			message.AdminAuthorId.Should().Be(45);
		}
	}
}