using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[ExcludeFromCodeCoverage]
	public class MessagesGetByIdTests : MessagesBaseTests
	{
		[Test]
		public void AdminAuthorId()
		{
			Url = "https://api.vk.me/method/messages.getById";
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
			Assert.NotNull(message);
			Assert.AreEqual(45, message.AdminAuthorId);
		}
	}
}