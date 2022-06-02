using FluentAssertions;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models
{


	public class GraffitiModel : BaseTest
	{
		[Fact]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Graffiti>();
		}

		[Fact]
		public void ShouldDeserializeOldApiResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment_for_960");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Graffiti>();
		}
	}
}