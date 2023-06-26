using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class AudioModel
{
	[Fact]
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