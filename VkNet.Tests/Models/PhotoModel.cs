using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class PhotoModel
{
	[Fact]
	public void ToString_PhotoShouldHaveAccessKey()
	{
		var photo = new Photo
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = photo.ToString();

		result.Should()
			.Be("photo1234_1234_test");
	}
}