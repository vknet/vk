using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests;

public class FromJsonTest
{
	[Fact]
	public void CheckCountOfFromJsomMethodsTest()
	{
		string nspace = "Model";

		var assembly = Assembly.GetAssembly(typeof(VkApi));
		var types = assembly.GetTypes();
		var classes = types.Where(x => x.IsClass && x.Namespace != null && x.Namespace.Contains(nspace));

		var count = classes.Select(@class => @class.GetMethods(BindingFlags.Public|BindingFlags.Static).Where(x => x.Name.StartsWith("FromJson"))).Count(methods => methods.Any());

		count.Should().BeGreaterOrEqualTo(10);
	}
}