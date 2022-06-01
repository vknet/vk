using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class DocumentModel
	{
		[Test]
		public void ToString_DocumentShouldHaveAccessKey()
		{
			var document = new Document
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = document.ToString();

			result.Should().Be("doc1234_1234_test");
		}
	}
}