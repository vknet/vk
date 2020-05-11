using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesUnpinTests : MessagesBaseTests
	{
		[Test]
		public void Unpin()
		{
			Url = "https://api.vk.com/method/messages.unpin";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Messages.Unpin(123, 345);

			Assert.True(result);
		}
	}
}