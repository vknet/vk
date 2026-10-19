using AwesomeAssertions;
using VkNet.Model;

namespace VkNet.Tests.Models;

public class AudioModel
{
	[Test]
	[DisplayName("To string audio should have access key")]
	public void ToString_AudioShouldHaveAccessKey()
	{
		var audio = new Audio
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = audio.ToString();

		result.Should()
			.Be("audio1234_1234_test");
	}
}