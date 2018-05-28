using NUnit.Framework;

namespace VkNet.Tests.Categories
{
	public class StreamingCategoryTests: BaseTest
	{
		[Test]
		public void GetServerUrl()
		{
			Url = "https://api.vk.com/method/streaming.getServerUrl";

			Json =
				@"{
					""response"": {
						""endpoint"": ""streaming.vk.com"",
						""key"": ""be8d29c05546e58cb52420aaf2b9f51f0a440f89""
					}
				}
            ";

			var result = Api.Streaming.GetServerUrl();

			Assert.IsNotNull(result);
			Assert.AreEqual("streaming.vk.com", result.Endpoint);
			Assert.AreEqual("be8d29c05546e58cb52420aaf2b9f51f0a440f89", result.Key);
		}
	}
}