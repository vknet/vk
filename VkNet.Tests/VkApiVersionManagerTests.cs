using NUnit.Framework;
using VkNet.Abstractions;
using VkNet.Infrastructure;

namespace VkNet.Tests
{
	[TestFixture]
	public class VkApiVersionManagerTests
	{
		[Test]
		public void VersionIsNotEmpty()
		{
			IVkApiVersionManager manager = new VkApiVersionManager();

			Assert.IsNotNull(manager);
			Assert.IsFalse(string.IsNullOrWhiteSpace(manager.Version));
		}

		[Test]
		public void VersionIsChanged()
		{
			const string zero = "0";
			IVkApiVersionManager manager = new VkApiVersionManager();

			manager.SetVersion(zero);
			Assert.AreEqual(zero, manager.Version);
		}
	}
}