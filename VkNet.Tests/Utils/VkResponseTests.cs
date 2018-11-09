using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	public class VkResponseTests
	{
		[Test]
		public void ShouldBeNull()
		{
			const string json = @"{
									'nullable_field': null,
								}";

			var jObject = JToken.Parse(json);
			var response = new VkResponse(jObject) { RawJson = json };

			Assert.IsNull((bool?) response["nullable_field"]);
			Assert.IsNull((bool?) response["nonexistent_field"]);
		}
	}
}