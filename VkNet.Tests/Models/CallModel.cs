using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class CallModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "call");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is Call);
		}
	}
}