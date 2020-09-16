using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]

	public class MessagesPinTests : MessagesBaseTests
	{
		[Test]
		public void Pin()
		{
			Url = "https://api.vk.com/method/messages.pin";
			ReadCategoryJsonPath(nameof(Pin));

			var result = Api.Messages.Pin(123, 345);

			Assert.NotNull(result);
		}
	}
}