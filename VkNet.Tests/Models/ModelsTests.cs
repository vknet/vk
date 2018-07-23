using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class ModelsTests
	{
		[Test]
		public void ModelsDateTimeFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly
				.GetTypes()
				.Where(predicate: t =>
					t.Namespace != null
					&& t.Namespace.StartsWith(value: "VkNet.Model")
					&& t.GetProperties()
						.Any(predicate: p =>
							(
								p.PropertyType == typeof(DateTime)
								|| p.PropertyType == typeof(DateTime?)
							)
							&& p.GetCustomAttributes(attributeType: typeof(JsonConverterAttribute), inherit: false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.FullName)));
			}

			Assert.IsEmpty(collection: enumerable);
		}

		[Test]
		public void ModelsAttachmentsFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly
				.GetTypes()
				.Where(predicate: t =>
					t.Namespace != null
					&& t.Namespace.StartsWith(value: "VkNet.Model")
					&& t.GetProperties()
						.Any(predicate: p =>
							(
								p.PropertyType == typeof(ReadOnlyCollection<Attachment>)
							)
							&& p.GetCustomAttributes(attributeType: typeof(JsonConverterAttribute), inherit: false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.FullName)));
			}

			Assert.IsEmpty(collection: enumerable);
		}

		[Test]
		public void ModelsSafetyEnumFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly
				.GetTypes()
				.Where(predicate: t =>
					t.Namespace != null
					&& t.Namespace.StartsWith(value: "VkNet.Model")
					&& t.GetProperties()
						.Any(predicate: p =>
							(
								!p.PropertyType.IsAbstract
								&& !p.PropertyType.IsInterface
								&& p.PropertyType.BaseType != null
								&& p.PropertyType.BaseType.IsGenericType
								&& p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(SafetyEnum<>)
							)
							&& p.GetCustomAttributes(attributeType: typeof(JsonConverterAttribute), inherit: false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.FullName)));
			}

			Assert.IsEmpty(collection: enumerable);
		}

		public static string AssemblyDirectory
		{
			get
			{
				var codeBase = Assembly.GetExecutingAssembly().CodeBase;
				var uri = new UriBuilder(codeBase);
				var path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}
	}
}