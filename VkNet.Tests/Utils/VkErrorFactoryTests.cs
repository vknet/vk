using FluentAssertions;
using VkNet.Exception;
using Xunit;

namespace VkNet.Tests.Utils;

public class VkErrorFactoryTests
{
	[Fact]
	public void VkErrorFactory()
	{
		var exception = VkNet.Utils.VkErrorFactory.Create(new()
		{
			ErrorCode = 14
		});

		exception.Should()
			.BeOfType<CaptchaNeededException>();
	}
}