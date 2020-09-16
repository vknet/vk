using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Abstractions.Core;
using VkNet.Exception;
using VkNet.Infrastructure;

namespace VkNet.Tests
{
	[TestFixture]
	public class VkApiVersionManagerTests
	{
		private IVkApiVersionManager Manager { get; }

		public VkApiVersionManagerTests()
		{
			Manager = new VkApiVersionManager();
		}

		[Test]
		public void VersionIsNotEmpty()
		{
			Assert.IsNotNull(Manager);
			Assert.IsFalse(string.IsNullOrWhiteSpace(Manager.Version));
		}

		[Test]
		public void VersionIsChanged()
		{
			Manager.SetVersion(999, 0);
			Assert.AreEqual("999.0", Manager.Version);
		}

		[Test]
		public void IsGreaterThanOrEqual_GreaterValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsFalse(Manager.IsGreaterThanOrEqual(5, 93));
		}

		[Test]
		public void IsGreaterThanOrEqual_EqualValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsTrue(Manager.IsGreaterThanOrEqual(5, 92));
		}

		[Test]
		public void IsGreaterThanOrEqual_MinorLessValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsTrue(Manager.IsGreaterThanOrEqual(5, 91));
		}

		[Test]
		public void IsGreaterThanOrEqual_MajorLessValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsTrue(Manager.IsGreaterThanOrEqual(4, 95));
		}

		[Test]
		public void IsLessThanOrEqual_GreaterValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsTrue(Manager.IsLessThanOrEqual(5, 93));
		}

		[Test]
		public void IsLessThanOrEqual_EqualValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsTrue(Manager.IsLessThanOrEqual(5, 92));
		}

		[Test]
		public void IsLessThanOrEqual_MinorLessValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsFalse(Manager.IsLessThanOrEqual(5, 91));
		}

		[Test]
		public void IsLessThanOrEqual_MajorLessValue()
		{
			Manager.SetVersion(5, 92);
			Assert.IsFalse(Manager.IsLessThanOrEqual(4, 95));
		}

		[Test]
		public void MinimalVersion_5_51_ShouldThrowException()
		{
			// Arrange

			// Act
			var exception = Assert.Throws<VkApiException>(() => Manager.SetVersion(5, 50));

			// Assert
			Assert.That(exception.Message, Is.EqualTo("С 1 сентября 2020 года перестанут поддерживаться версии ниже 5.51."));
			Assert.That(exception.HelpLink, Is.EqualTo("https://vk.com/dev/constant_version_updates"));
		}

		[Test]
		public void MinimalMajorVersion_5_ShouldThrowException()
		{
			// Arrange

			// Act
			var exception = Assert.Throws<VkApiException>(() => Manager.SetVersion(4, 50));

			// Assert
			Assert.That(exception.Message, Is.EqualTo("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются."));
			Assert.That(exception.HelpLink, Is.EqualTo("https://vk.com/dev/version_update_2.0"));
		}
	}
}