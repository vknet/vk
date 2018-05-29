using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	public class VkParametersTests
	{
		[Test]
		public void AddNullableBoolean_FalseValue()
		{
			var @params = new VkParameters();
			bool? nbool = false;
			@params.Add(name: "NullableBoolean", nullableValue: nbool);
			Assert.That(actual: @params, expression: Does.ContainKey(expected: "NullableBoolean"));
			var val = @params[key: "NullableBoolean"];
			Assert.That(actual: val, expression: Is.EqualTo(expected: "0"));
		}

		[Test]
		public void AddNullableBoolean_NullValue()
		{
			var @params = new VkParameters();
			bool? nbool = null;
			@params.Add(name: "NullableBoolean", nullableValue: nbool);
			Assert.That(actual: @params, expression: Does.Not.ContainKey(expected: "NullableBoolean"));
		}

		[Test]
		public void AddNullableBoolean_TrueValue()
		{
			var @params = new VkParameters();
			bool? nbool = true;
			@params.Add(name: "NullableBoolean", nullableValue: nbool);
			Assert.That(actual: @params, expression: Does.ContainKey(expected: "NullableBoolean"));
			var val = @params[key: "NullableBoolean"];
			Assert.That(actual: val, expression: Is.EqualTo(expected: "1"));
		}
	}
}