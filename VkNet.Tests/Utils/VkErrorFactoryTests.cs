using FluentAssertions;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	public class VkErrorFactoryTests
	{
		[Test]
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