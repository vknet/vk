using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
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
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.Name)));
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
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.Name)));
			}

			Assert.IsEmpty(collection: enumerable);
		}
	}
}