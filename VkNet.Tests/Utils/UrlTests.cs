using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class UrlTests
{
	[Fact]
	public void Query_From()
	{
		var parameters = new Dictionary<string, string>
		{
			{
				"key1", "value1"
			},
			{
				"key2", "value2"
			}
		};

		var query = Url.QueryFrom(parameters.ToArray());

		query.Should()
			.Be("key1=value1&key2=value2");
	}

	[Fact]
	public void Combine_With_Query()
	{
		const string testUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8";
		const string expectedUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8&key1=value1&key2=value2";
		const string query = "key1=value1&key2=value2";

		var actualUrl = Url.Combine(testUrl, query);

		actualUrl.Should()
			.Be(Uri.EscapeDataString(expectedUrl));
	}

	[Fact]
	public void ParseQueryString()
	{
		const string inputUrl = "https://www.google.com/search?q=dictionary&sourceid=chrome&ie=UTF-8&key1=value1&key2=value2";
		var result = Url.ParseQueryString(inputUrl);

		result.Should()
			.ContainKey("q")
			.WhoseValue.Should()
			.Be("dictionary");

		result.Should()
			.ContainKey("sourceid")
			.WhoseValue.Should()
			.Be("chrome");

		result.Should()
			.ContainKey("ie")
			.WhoseValue.Should()
			.Be("UTF-8");

		result.Should()
			.ContainKey("key1")
			.WhoseValue.Should()
			.Be("value1");

		result.Should()
			.ContainKey("key2")
			.WhoseValue.Should()
			.Be("value2");
	}

	[Fact]
	public void ParseQueryString_UrlShouldContainQueryParameters()
	{
		const string inputUrl = "https://www.google.com/search";
		Action result = () => Url.ParseQueryString(inputUrl);

		result.Should()
			.Throw<UriFormatException>();
	}

	[Fact]
	public void ParseQueryString_UrlShouldReturnExpectedValue()
	{
		const string inputUrl =
			"https://oauth.vk.com/auth_redirect?app_id=4268118&authorize_url=https%253A%252F%252Foauth.vk.com%252Fblank.html%2523access_token%253D52d42d4e710d5b2ac4a2b913e0ef2476cd17b71ade612c0c0d756e1492f83cbea27772d5fcda63065e5b1%2526expires_in%253D86400%2526user_id%253D32190123%2526email%253Dinyutin_maxim%2540mail.ru&redirect_hash=1aae42f9a6908e5978";

		var result = Url.ParseQueryString(inputUrl);

		result.Should()
			.ContainValue(
				"https%3A%2F%2Foauth.vk.com%2Fblank.html%23access_token%3D52d42d4e710d5b2ac4a2b913e0ef2476cd17b71ade612c0c0d756e1492f83cbea27772d5fcda63065e5b1%26expires_in%3D86400%26user_id%3D32190123%26email%3Dinyutin_maxim%40mail.ru");
	}
}