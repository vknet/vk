using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class GraffitiModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Graffiti>();
		}

		[Test]
		public void ShouldDeserializeOldApiResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment_for_960");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Graffiti>();
		}
	}
}