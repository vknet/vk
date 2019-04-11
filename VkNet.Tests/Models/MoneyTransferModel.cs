using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	class MoneyTransferModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "money_transfer_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is MoneyTransfer);
		}
	}
}
