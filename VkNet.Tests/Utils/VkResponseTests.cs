using FluentAssertions;
using Newtonsoft.Json.Linq;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils
{
	public class VkResponseTests : BaseTest
	{
		[Fact]
		public void ShouldBeNull()
		{
			var json = ReadJson("VkResponse", nameof(ShouldBeNull));

			var jObject = JToken.Parse(json);
			var response = new VkResponse(jObject) { RawJson = json };

			((bool?) response["nullable_field"]).Should().BeNull();
			((bool?) response["nonexistent_field"]).Should().BeNull();
		}
	}
}