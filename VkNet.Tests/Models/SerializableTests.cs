using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace VkNet.Tests.Models
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class SerializableTests
	{
		[Test]
		public void ModelsShouldHaveSerializableAtribute()
		{
			var models = typeof(VkApi).Assembly
					.GetTypes()
					.Where(x =>
							x.Namespace != null
							&& x.Namespace.StartsWith("VkNet.Model")
							&& !x.Attributes.HasFlag(TypeAttributes.Serializable)
							&& !x.IsInterface)
					.Where(x => !x.Name.StartsWith("<>c__DisplayClass56_0"));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(string.Join(Environment.NewLine, enumerable.Select(x => x.Name)));
			}

			Assert.IsEmpty(enumerable);
		}
	}
}