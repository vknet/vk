using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class MoneyRequestTests: BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "money_request");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is MoneyRequest);
		}
	}
}