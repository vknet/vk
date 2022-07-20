using FluentAssertions;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models
{

	public class MoneyRequestTests: BaseTest
	{
		[Fact]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "money_request");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<MoneyRequest>();;
		}
	}
}