using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace VkNet.Tests.Models
{
	[TestFixture]
	public class SerializableTests
	{
		[Test]
		public void ModelsShouldHaveSerializableAtribute()
		{
			var models = typeof(VkApi).Assembly
					.GetTypes()
					.Where(predicate: x =>
							x.Namespace != null
							&& x.Namespace.StartsWith(value: "VkNet.Model")
							&& !x.Attributes.HasFlag(flag: TypeAttributes.Serializable)
							&& !x.IsInterface)
					.Where(predicate: x => !x.Name.StartsWith(value: "<>c__DisplayClass56_0"));

			var enumerable = models.ToList();

			if (enumerable.Any())
			{
				Assert.Fail(message: string.Join(separator: Environment.NewLine, values: enumerable.Select(selector: x => x.Name)));
			}

			Assert.IsEmpty(collection: enumerable);
		}
	}
}