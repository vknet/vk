using NUnit.Framework;
using VkNet.Enums;

namespace VkNet.Tests.Enum
{
	[TestFixture]
	public class BirthdayVisibilityTest
	{
		[Test]
		public void ParsingFromNumbers_Works()
		{
			Assert.That((BirthdayVisibility)0 == BirthdayVisibility.Invisible);
			Assert.That((BirthdayVisibility)1 == BirthdayVisibility.Full);
			Assert.That((BirthdayVisibility)2 == BirthdayVisibility.OnlyDayAndMonth);
		}
	}
}