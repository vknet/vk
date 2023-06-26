using System;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class ModelsTests
{
	private const string VkNetModelBaseNamespace = "VkNet.Model";

	[Fact]
	public void ModelsWithNullableDateTimeFieldsShouldHaveJsonConverterAttribute()
	{
		var types = typeof(VkApi).Assembly.Types()
			.ThatAreUnderNamespace(VkNetModelBaseNamespace)
			.Properties()
			.OfType<DateTime?>()
			.ThatArePublicOrInternal;

		types.Should()
			.BeDecoratedWith<JsonConverterAttribute>();
	}

	[Fact]
	public void ModelsWithDateTimeFieldsShouldHaveJsonConverterAttribute()
	{
		var types = typeof(VkApi).Assembly.Types()
			.ThatAreUnderNamespace(VkNetModelBaseNamespace)
			.Properties()
			.OfType<DateTime>()
			.ThatArePublicOrInternal;

		types.Should()
			.BeDecoratedWith<JsonConverterAttribute>();
	}

	[Fact]
	public void ModelsAttachmentsFieldsShouldHaveJsonConverterAttribute()
	{
		var types = typeof(VkApi).Assembly.Types()
			.ThatAreUnderNamespace(VkNetModelBaseNamespace)
			.Properties()
			.OfType<ReadOnlyCollection<Attachment>>()
			.ThatArePublicOrInternal;

		types.Should()
			.BeDecoratedWith<JsonConverterAttribute>();
	}

	[Fact]
	public void ModelsSafetyEnumFieldsShouldHaveJsonConverterAttribute()
	{
		var models = typeof(VkApi).Assembly.Types()
			.ThatAreUnderNamespace(VkNetModelBaseNamespace)
			.Properties()
			.ThatAreNotDecoratedWith<JsonConverterAttribute>()
			.Where(p =>
				!p.PropertyType.IsAbstract
				&& !p.PropertyType.IsInterface
				&& p.PropertyType.BaseType is
				{
					IsGenericType: true
				}
				&& p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(SafetyEnum<>))
			.Select(x => $"{x.DeclaringType?.FullName} с полем {x.Name}");

		models.Should()
			.BeEmpty();
	}

	[Fact]
	public void ModelsShouldHaveJsonConverterAttributeForCoordinatesType()
	{
		var types = typeof(VkApi).Assembly.Types()
			.ThatAreUnderNamespace(VkNetModelBaseNamespace)
			.Properties()
			.OfType<Coordinates>()
			.ThatArePublicOrInternal;

		types.Should()
			.BeDecoratedWith<JsonConverterAttribute>();
	}
}