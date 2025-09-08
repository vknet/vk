using System;
using System.Linq;
using AwesomeAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Streaming;

public class StreamingCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Streaming";

	[Fact(DisplayName = "Get server url")]
	public void GetServerUrl()
	{
		Url = "https://api.vk.ru/method/streaming.getServerUrl";
		ReadCategoryJsonPath(nameof(GetServerUrl));

		var result = Api.Streaming.GetServerUrl();

		result.Should()
			.NotBeNull();

		result.Endpoint.Should()
			.Be("streaming.vk.ru");

		result.Key.Should()
			.Be("be8d29c05546e58cb52420aaf2b9f51f0a440f89");
	}

	[Fact(DisplayName = "Get settings")]
	public void GetSettings()
	{
		Url = "https://api.vk.ru/method/streaming.getSettings";
		ReadCategoryJsonPath(nameof(GetSettings));

		var result = Api.Streaming.GetSettings();

		result.Should()
			.NotBeNull();

		result.MonthlyLimit.Should()
			.Be(MonthlyLimit.Tier6);
	}

	[Fact(DisplayName = "Get stats")]
	public void GetStats()
	{
		Url = "https://api.vk.ru/method/streaming.getStats";
		ReadCategoryJsonPath(nameof(GetStats));

		var result = Api.Streaming.GetStats("prepared", "24h", new DateTime(2018, 5, 1), new DateTime(2018, 5, 20));

		result.Should()
			.NotBeEmpty();

		var stats = result.FirstOrDefault();

		stats.Should()
			.NotBeNull();

		stats.EventType.Should()
			.Be(StreamingEventType.Post);

		stats.Stats.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Set settings")]
	public void SetSettings()
	{
		Url = "https://api.vk.ru/method/streaming.setSettings";
		ReadJsonFile(JsonPaths.True);

		var result = Api.Streaming.SetSettings(MonthlyLimit.Tier6);

		result.Should()
			.BeTrue();
	}

	[Fact(DisplayName = "Get stem")]
	public void GetStem()
	{
		Url = "https://api.vk.ru/method/streaming.getStem";
		ReadCategoryJsonPath(nameof(GetStem));

		var result = Api.Streaming.GetStem("коты");

		result.Should()
			.Be("кот");
	}
}