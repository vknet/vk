using FluentAssertions;
using VkNet.Abstractions.Core;
using VkNet.Exception;
using VkNet.Infrastructure;
using Xunit;

namespace VkNet.Tests;

public class VkApiVersionManagerTests
{
	public VkApiVersionManagerTests() => Manager = new VkApiVersionManager();

	private IVkApiVersionManager Manager { get; }

	[Fact]
	public void VersionIsNotEmpty()
	{
		Manager.Should()
			.NotBeNull();

		Manager.Version.Should()
			.NotBeNullOrWhiteSpace();
	}

	[Fact]
	public void VersionIsChanged()
	{
		Manager.SetVersion(999, 0);

		Manager.Version.Should()
			.Be("999.0");
	}

	[Fact]
	public void IsGreaterThanOrEqual_GreaterValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 93)
			.Should()
			.BeFalse();
	}

	[Fact]
	public void IsGreaterThanOrEqual_EqualValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 92)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void IsGreaterThanOrEqual_MinorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 91)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void IsGreaterThanOrEqual_MajorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(4, 95)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void IsLessThanOrEqual_GreaterValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 93)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void IsLessThanOrEqual_EqualValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 92)
			.Should()
			.BeTrue();
	}

	[Fact]
	public void IsLessThanOrEqual_MinorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 91)
			.Should()
			.BeFalse();
	}

	[Fact]
	public void IsLessThanOrEqual_MajorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(4, 95)
			.Should()
			.BeFalse();
	}

	[Fact]
	public void MinimalVersion_5_81_ShouldThrowException() =>

		// Arrange
		// Act
		FluentActions.Invoking(() => Manager.SetVersion(5, 50))
			.Should()
			.ThrowExactly<VkApiException>()
			.WithMessage("С 2 сентября 2021 года прекратилась поддержка версий ниже 5.81.")
			.And.HelpLink.Should()
			.Be("https://vk.com/dev/constant_version_updates");

	[Fact]
	public void MinimalMajorVersion_5_ShouldThrowException() =>

		// Arrange
		// Act
		FluentActions.Invoking(() => Manager.SetVersion(4, 50))
			.Should()
			.ThrowExactly<VkApiException>()
			.WithMessage("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются.")
			.And.HelpLink.Should()
			.Be("https://vk.com/dev/version_update_2.0");
}