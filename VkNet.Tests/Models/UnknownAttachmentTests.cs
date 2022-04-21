using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class UnknownAttachmentTests: BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "UnknownAttachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<UnknownAttachment>();
		}
	}
}