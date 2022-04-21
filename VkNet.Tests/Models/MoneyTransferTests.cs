using FluentAssertions;
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

			attachment.Instance.Should().BeOfType<MoneyTransfer>();
		}
	}
}