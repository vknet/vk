using System.Collections.Generic;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Story;

public class StoriesGetTests : CategoryBaseTest
{
	protected override string Folder => JsonTestFolderConstants.Categories.Stories;

	[Fact]
	public void Get()
	{
		Url = "https://api.vk.com/method/stories.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.Stories.Get();

		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);
	}

	[Fact]
	public void GetBanned()
	{
		Url = "https://api.vk.com/method/stories.getBanned";
		ReadCategoryJsonPath(nameof(GetBanned));

		var result = Api.Stories.GetBanned();

		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);

		result.Items.Should()
			.NotContainNulls();
	}

	[Fact]
	public void GetPhotoUploadServer()
	{
		Url = "https://api.vk.com/method/stories.getPhotoUploadServer";
		ReadCategoryJsonPath(nameof(GetPhotoUploadServer));

		var result = Api.Stories.GetPhotoUploadServer(new()
		{
			AddToNews = true
		});

		result.Should()
			.NotBeNull();

		result.UploadUrl.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetReplies()
	{
		Url = "https://api.vk.com/method/stories.getReplies";
		ReadCategoryJsonPath(nameof(GetReplies));

		var result = Api.Stories.GetReplies(12345679, 123456789, null, true, new List<string>());

		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);
	}

	[Fact]
	public void GetViewers()
	{
		Url = "https://api.vk.com/method/stories.getViewers";
		ReadCategoryJsonPath(nameof(GetViewers));

		var users = Api.Stories.GetViewers(123456789, 123456789);

		users.Should()
			.NotBeNull();

		users.TotalCount.Should()
			.Be(1);

		users.Should()
			.NotContainNulls();

		users[0].UserId.Should().Be(100);
		users[0].IsLiked.Should().Be(false);
	}

	[Fact]
	public void GetViewersExtended()
	{
		Url = "https://api.vk.com/method/stories.getViewers";
		ReadCategoryJsonPath(nameof(GetViewersExtended));

		var users = Api.Stories.GetViewersExtended(123456789, 123456789);

		users.Should()
			.NotBeNull();

		users.TotalCount.Should()
			.Be(1);

		users.Should()
			.NotContainNulls();

		users.Should()
			.Contain(x => x.Id == 123456789);

		users.Should()
			.Contain(x => x.FirstName == "test");

		users.Should()
			.Contain(x => x.LastName == "test1");
	}

	[Fact]
	public void GetStats()
	{
		Url = "https://api.vk.com/method/stories.getStats";
		ReadCategoryJsonPath(nameof(GetStats));

		var stats = Api.Stories.GetStats(123456789, 123456789);

		stats.Views.Should()
			.NotBeNull();

		stats.Answer.Should()
			.NotBeNull();

		stats.Bans.Should()
			.NotBeNull();

		stats.OpenLink.Should()
			.NotBeNull();

		stats.Replies.Should()
			.NotBeNull();

		stats.Subscribers.Should()
			.NotBeNull();

		stats.Shares.Should()
			.NotBeNull();
	}

	[Fact]
	public void GetById()
	{
		Url = "https://api.vk.com/method/stories.getById";
		ReadCategoryJsonPath(nameof(GetById));

		var stories = Api.Stories.GetById(new List<string>
			{
				"123456789_123456789"
			},
			true,
			new List<string>());

		stories.Should()
			.NotBeNull();

		stories.Count.Should()
			.Be(1);

		stories.Items.Should()
			.NotBeNullOrEmpty();
	}

	[Fact]
	public void Search()
	{
		Url = "https://api.vk.com/method/stories.search";
		ReadCategoryJsonPath(nameof(Search));

		var result = Api.Stories.Search(new()
		{
			Query = "Ростов",
			Extended = true,
			Fields = new List<string>
			{
				"bdate"
			}
		});

		result.Should()
			.NotBeNull();

		result.Count.Should()
			.Be(1);

		result.Items.Should()
			.NotBeNullOrEmpty();

		result.Profiles.Should()
			.NotBeNullOrEmpty();

		result.Groups.Should()
			.NotBeNull();
	}

	[Fact]
	public void SendInteraction()
	{
		Url = "https://api.vk.com/method/stories.sendInteraction";
		ReadCommonJsonFile(JsonTestFolderConstants.Common.True);

		var result = Api.Stories.SendInteraction("key", "message");

		result.Should()
			.BeTrue();
	}
}