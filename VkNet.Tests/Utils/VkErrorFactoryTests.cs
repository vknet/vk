using FluentAssertions;
using VkNet.Exception;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Utils
{

	public class VkErrorFactoryTests
	{
		[Fact]
		public void VkErrorFactory()
		{
			var exception = VkNet.Utils.VkErrorFactory.Create(new VkError
			{
				ErrorCode = 14
			});

			exception.Should().BeOfType<CaptchaNeededException>();
		}
	}
}