using System;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class ModelsTests
	{
		private const string VkNetModelBaseNamespace = "VkNet.Model";

		[Test]
		public void ModelsWithNullableDateTimeFieldsShouldHaveJsonConverterAttribute()
		{
			var types = typeof(VkApi).Assembly.Types()
				.ThatAreUnderNamespace(VkNetModelBaseNamespace)
				.Properties()
				.OfType<DateTime?>()
				.ThatArePublicOrInternal;

			types.Should().BeDecoratedWith<JsonConverterAttribute>();
		}

		[Test]
		public void ModelsWithDateTimeFieldsShouldHaveJsonConverterAttribute()
		{
			var types = typeof(VkApi).Assembly.Types()
				.ThatAreUnderNamespace(VkNetModelBaseNamespace)
				.Properties()
				.OfType<DateTime>()
				.ThatArePublicOrInternal;

			types.Should().BeDecoratedWith<JsonConverterAttribute>();
		}

		[Test]
		public void ModelsAttachmentsFieldsShouldHaveJsonConverterAttribute()
		{
			var types = typeof(VkApi).Assembly.Types()
				.ThatAreUnderNamespace(VkNetModelBaseNamespace)
				.Properties()
				.OfType<ReadOnlyCollection<Attachment>>()
				.ThatArePublicOrInternal;

			types.Should().BeDecoratedWith<JsonConverterAttribute>();
		}

		[Test]
		public void ModelsSafetyEnumFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly.Types()
				.ThatAreUnderNamespace(VkNetModelBaseNamespace)
				.Properties()
				.ThatAreNotDecoratedWith<JsonConverterAttribute>()
				.Where(p =>
				(
					!p.PropertyType.IsAbstract
					&& !p.PropertyType.IsInterface
					&& p.PropertyType.BaseType is { IsGenericType: true }
					&& p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(SafetyEnum<>)
				))
				.Select(x => $"{x.DeclaringType?.FullName} с полем {x.Name}");

			models.Should().BeEmpty();
		}

		[Test]
		public void ModelsShouldHaveJsonConverterAttributeForCoordinatesType()
		{
			var types = typeof(VkApi).Assembly.Types()
				.ThatAreUnderNamespace(VkNetModelBaseNamespace)
				.Properties()
				.OfType<Coordinates>()
				.ThatArePublicOrInternal;

			types.Should().BeDecoratedWith<JsonConverterAttribute>();
		}
	}
}