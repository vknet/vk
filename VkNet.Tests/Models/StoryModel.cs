using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class StoryModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "story_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is Story);
		}
	}
}