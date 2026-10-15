using AwesomeAssertions;
using JetBrains.Annotations;
using VkNet.Exception;
using VkNet.Infrastructure;

namespace VkNet.Tests;

[TestSubject(typeof(VkApiVersionManager))]
public class VkApiVersionManagerTests
{
	private VkApiVersionManager Manager { get; } = new();

	[Test]
	[DisplayName("Версия не должна быть пустой")]
	public void VersionIsNotEmpty()
	{
		Manager.Should()
			.NotBeNull();

		Manager.Version.Should()
			.NotBeNullOrWhiteSpace();
	}

	[Test]
	[DisplayName("Версия должна быть изменена")]
	public void VersionIsChanged()
	{
		Manager.SetVersion(999, 0);

		Manager.Version.Should()
			.Be("999.0");
	}

	[Test]
	[DisplayName("Значение должно быть больше или равно 5.93")]
	public void IsGreaterThanOrEqual_GreaterValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 93)
			.Should()
			.BeFalse();
	}

	[Test]
	[DisplayName("IsGreaterThanOrEqual. Сравнение текущей версии с самой версией")]
	public void IsGreaterThanOrEqual_EqualValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 92)
			.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("IsGreaterThanOrEqual. Сравнение минорных версий")]
	public void IsGreaterThanOrEqual_MinorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(5, 91)
			.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("IsGreaterThanOrEqual. Сравнение мажорных версий")]
	public void IsGreaterThanOrEqual_MajorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsGreaterThanOrEqual(4, 95)
			.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("IsLessThanOrEqual. Сравнение с большей версией")]
	public void IsLessThanOrEqual_GreaterValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 93)
			.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("IsLessThanOrEqual. Сравнение одинаковых версий")]
	public void IsLessThanOrEqual_EqualValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 92)
			.Should()
			.BeTrue();
	}

	[Test]
	[DisplayName("IsLessThanOrEqual. Сравнение минорных версий")]
	public void IsLessThanOrEqual_MinorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(5, 91)
			.Should()
			.BeFalse();
	}

	[Test]
	[DisplayName("IsLessThanOrEqual. Сравнение мажорных версий")]
	public void IsLessThanOrEqual_MajorLessValue()
	{
		Manager.SetVersion(5, 92);

		Manager.IsLessThanOrEqual(4, 95)
			.Should()
			.BeFalse();
	}

	[Test]
	[DisplayName("С 2 сентября 2021 года прекратилась поддержка версий ниже 5.81.")]
	public void MinimalVersion_5_81_ShouldThrowException() =>

		// Arrange
		// Act
		FluentActions.Invoking(() => Manager.SetVersion(5, 50))
			.Should()
			.ThrowExactly<VersionDeprecatedException>()
			.WithMessage("С 2 сентября 2021 года прекратилась поддержка версий ниже 5.81.")
			.And.HelpLink.Should()
			.Be("https://vk.ru/dev/constant_version_updates");

	[Test]
	[DisplayName("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются.")]
	public void MinimalMajorVersion_5_ShouldThrowException() =>

		// Arrange
		// Act
		FluentActions.Invoking(() => Manager.SetVersion(4, 50))
			.Should()
			.ThrowExactly<VersionDeprecatedException>()
			.WithMessage("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются.")
			.And.HelpLink.Should()
			.Be("https://vk.ru/dev/version_update_2.0");
}