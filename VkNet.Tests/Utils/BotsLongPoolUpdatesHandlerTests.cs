using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Utils;

public class BotsLongPoolUpdatesHandlerTests
{
	[Fact(DisplayName = "")]
	public void GetBotsLongPollHistory_DonutSubscriptionCreate()
	{
		ulong _currentTimeStamp = 10;

		ulong previousTimeStamp = 11;

		var differenceTimeStamp = (long) (_currentTimeStamp - previousTimeStamp);

		differenceTimeStamp.Should()
			.BeNegative();
	}
}