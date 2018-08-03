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
			@params.Add("NullableBoolean", nbool);
			Assert.That(@params, Does.ContainKey("NullableBoolean"));
			var val = @params["NullableBoolean"];
			Assert.That(val, Is.EqualTo("0"));
		}

		[Test]
		public void AddNullableBoolean_NullValue()
		{
			var @params = new VkParameters();
			bool? nbool = null;
			@params.Add("NullableBoolean", nbool);
			Assert.That(@params, Does.Not.ContainKey("NullableBoolean"));
		}

		[Test]
		public void AddNullableBoolean_TrueValue()
		{
			var @params = new VkParameters();
			bool? nbool = true;
			@params.Add("NullableBoolean", nbool);
			Assert.That(@params, Does.ContainKey("NullableBoolean"));
			var val = @params["NullableBoolean"];
			Assert.That(val, Is.EqualTo("1"));
		}
	}
}