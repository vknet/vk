using FluentAssertions;
using Xunit;
using VkNet.Model;

namespace VkNet.Tests.Models;

public class DocumentModel
{
	[Fact]
	public void ToString_DocumentShouldHaveAccessKey()
	{
		var document = new Document
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = document.ToString();

		result.Should()
			.Be("doc1234_1234_test");
	}
}