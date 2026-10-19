using AwesomeAssertions;
using VkNet.Model;

namespace VkNet.Tests.Models;

public class PhotoModel
{
	[Test]
	[DisplayName("To string photo should have access key")]
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