using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture, Parallelizable]
	public class UrlTests
	{
		[Test]
		public void Query_From()
		{
			var parameters = new Dictionary<string, string>
			{
				{ "key1", "value1" },
				{ "key2", "value2" }
			};

			var query = Url.QueryFrom(parameters.ToArray());

			Assert.AreEqual("key1=value1&key2=value2", query);
		}

		[Test]
		public void Combine_With_Query()
		{
			const string testUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8";
			const string expectedUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8&key1=value1&key2=value2";
			const string query = "key1=value1&key2=value2";

			var actualUrl = Url.Combine(testUrl, query);

			Assert.AreEqual(expectedUrl, actualUrl);
		}
	}
}