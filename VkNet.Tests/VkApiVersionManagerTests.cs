using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Abstractions;
using VkNet.Infrastructure;

namespace VkNet.Tests
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
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
			IVkApiVersionManager manager = new VkApiVersionManager();

			manager.SetVersion(0, 0);
			Assert.AreEqual("0.0", manager.Version);
		}
	}
}