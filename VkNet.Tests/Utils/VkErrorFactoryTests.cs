using AwesomeAssertions;
using JetBrains.Annotations;
using VkNet.Exception;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

[TestSubject(typeof(VkErrorFactory))]
public class VkErrorFactoryTests
{
	[Fact(DisplayName = "Фабрика ошибок должна создавать исключение на основании кода ошибки")]
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