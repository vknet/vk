using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	public class MoneyTransferTests : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "money_transfer");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is MoneyTransfer);
		}
	}
}