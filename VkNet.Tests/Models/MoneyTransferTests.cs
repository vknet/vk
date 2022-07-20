using FluentAssertions;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models
{
	public class MoneyTransferTests : BaseTest
	{
		[Fact]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "money_transfer");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<MoneyTransfer>();
		}
	}
}