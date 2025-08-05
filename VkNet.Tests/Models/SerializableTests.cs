using System.Linq;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace VkNet.Tests.Models;

public class SerializableTests
{
	[Fact]
	public void ModelsShouldHaveSerializableAttribute()
	{
		var models = typeof(VkApi).Assembly
			.GetTypes()
			.Where(x =>
				x.Namespace is not null
				&& x.Namespace.StartsWith("VkNet.Model")
				&& !x.Attributes.HasFlag(TypeAttributes.Serializable)
				&& !x.IsInterface)
			.Where(x => !x.Name.StartsWith("<>c__DisplayClass56_0"));

		var enumerable = models.ToList();

		enumerable.Should()
			.BeEmpty();
	}
}