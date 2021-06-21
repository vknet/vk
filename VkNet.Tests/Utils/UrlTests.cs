using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

		[Test]
		public void ParseQueryString()
		{
			const string inputUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8&key1=value1&key2=value2";
			var result = Url.ParseQueryString(inputUrl);

			result.Should().ContainKey("q").WhichValue.Should().Be("dictionary");
			result.Should().ContainKey("sourceid").WhichValue.Should().Be("chrome");
			result.Should().ContainKey("ie").WhichValue.Should().Be("UTF-8");
			result.Should().ContainKey("key1").WhichValue.Should().Be("value1");
			result.Should().ContainKey("key2").WhichValue.Should().Be("value2");
		}

		[Test]
		public void ParseQueryString_UrlShouldContainQueryParameters()
		{
			const string inputUrl = "https://www.google.com/search";
			Action result = () => Url.ParseQueryString(inputUrl);

			result.Should().Throw<UriFormatException>();
		}
	}
}