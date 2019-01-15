using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesGetHistoryTest : MessagesBaseTests
	{
		[Test]
		public void GetHistoryTest()
		{
			Url = "https://api.vk.com/method/messages.getHistory";

			ReadCategoryJsonPath(nameof(Api.Messages.GetHistory));

			var result = Api.Messages.GetHistory(new MessagesGetHistoryParams
			{
				Count = 1,
				PeerId = -123456789,
				Extended = true
			});

			Assert.That(result.TotalCount, Is.EqualTo(226));
			Assert.IsNotEmpty(result.Messages);
			Assert.IsNotEmpty(result.Conversations);
			Assert.IsNotEmpty(result.Groups);
			Assert.IsNotEmpty(result.Users);
		}
	}
}