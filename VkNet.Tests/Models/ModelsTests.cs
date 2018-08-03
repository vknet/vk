using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
				.Where(t =>
					t.Namespace != null
					&& t.Namespace.StartsWith("VkNet.Model")
					&& t.GetProperties()
						.Any(p =>
							(
								p.PropertyType == typeof(DateTime)
								|| p.PropertyType == typeof(DateTime?)
							)
							&& p.GetCustomAttributes(typeof(JsonConverterAttribute), false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(string.Join(Environment.NewLine, enumerable.Select(x => x.FullName)));
			}

			Assert.IsEmpty(enumerable);
		}

		[Test]
		public void ModelsAttachmentsFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly
				.GetTypes()
				.Where(t =>
					t.Namespace != null
					&& t.Namespace.StartsWith("VkNet.Model")
					&& t.GetProperties()
						.Any(p =>
							(
								p.PropertyType == typeof(ReadOnlyCollection<Attachment>)
							)
							&& p.GetCustomAttributes(typeof(JsonConverterAttribute), false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(string.Join(Environment.NewLine, enumerable.Select(x => x.FullName)));
			}

			Assert.IsEmpty(enumerable);
		}

		[Test]
		public void ModelsSafetyEnumFieldsShouldHaveJsonConverterAttribute()
		{
			var models = typeof(VkApi).Assembly
				.GetTypes()
				.Where(t =>
					t.Namespace != null
					&& t.Namespace.StartsWith("VkNet.Model")
					&& t.GetProperties()
						.Any(p =>
							(
								!p.PropertyType.IsAbstract
								&& !p.PropertyType.IsInterface
								&& p.PropertyType.BaseType != null
								&& p.PropertyType.BaseType.IsGenericType
								&& p.PropertyType.BaseType.GetGenericTypeDefinition() == typeof(SafetyEnum<>)
							)
							&& p.GetCustomAttributes(typeof(JsonConverterAttribute), false).Length
							< 1));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(string.Join(Environment.NewLine, enumerable.Select(x => x.FullName)));
			}

			Assert.IsEmpty(enumerable);
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