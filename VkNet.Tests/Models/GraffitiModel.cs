using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GraffitiModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is Graffiti);
		}

		[Test]
		public void ShouldDeserializeOldApiResponseToAttachment()
		{
			ReadJsonFile("Models", "graffiti_attachment_for_960");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is Graffiti);
		}
	}
}