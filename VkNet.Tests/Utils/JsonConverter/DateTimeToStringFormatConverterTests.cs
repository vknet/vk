using System;
using System.Globalization;
using FluentAssertions;
using FluentAssertions.Extensions;
using Newtonsoft.Json;
using VkNet.Model;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;
using Xunit;

namespace VkNet.Tests.Utils.JsonConverter;

public class DateTimeToStringFormatConverterTests : BaseTest
{
	[Fact]
	public void Deserialize()
	{
		ReadJsonFile(nameof(JsonConverter), nameof(DateTimeToStringFormatConverter), nameof(Deserialize));
		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<MessagesSearchParams>("friends.getRequests", VkParameters.Empty);

		result.Should()
			.NotBeNull();

		result.Date.Should()
			.Be(5.November(2018));
	}

	[Fact]
	public void Serialization()
	{
		ReadJsonFile(nameof(JsonConverter), nameof(DateTimeToStringFormatConverter), nameof(Serialization));

		var message = new MessagesSearchParams
		{
			Date = new DateTime(2018, 11, 5),
			Count = 20
		};

		var json = JsonConvert.SerializeObject(message,
			new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				DefaultValueHandling = DefaultValueHandling.Ignore,
				Formatting = Formatting.Indented
			});

		var result = JsonConvert.DeserializeObject<MessagesSearchParams>(json,
			new JsonSerializerSettings
			{
				MaxDepth = null,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			});

		result.Should()
			.NotBeNull();

		var compare = string.Compare(json, Json, CultureInfo.InvariantCulture, CompareOptions.IgnoreSymbols);

		compare.Should()
			.Be(0);
	}
}