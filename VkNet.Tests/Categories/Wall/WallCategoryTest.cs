using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Attachments;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Wall;

[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
public class WallCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Wall";

	[Fact]
	public void CloseComments_ReturnTrue()
	{
		Url = "https://api.vk.com/method/wall.closeComments";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Wall.CloseComments(3, 3);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException() => FluentActions
		.Invoking(() => new WallCategory(new VkApi()).Delete(1, 1))
		.Should()
		.ThrowExactly<AccessTokenInvalidException>();

	[Fact]
	public void Get_Document_NormalCase()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(Get_Document_NormalCase));

		var posts = Api.Wall.Get(new()
		{
			OwnerId = 26033241,
			Count = 1,
			Offset = 2
		});

		posts.TotalCount.Should()
			.Be(100u);

		posts.WallPosts[0]
			.Attachments.Should()
			.ContainSingle();

		var doc = (Document) posts.WallPosts[0]
			.Attachment.Instance;

		doc.Should()
			.NotBeNull();

		doc.Id.Should()
			.Be(237844408);

		doc.OwnerId.Should()
			.Be(26033241);

		doc.Title.Should()
			.Be("2e857c8f-aaf8-4399-9856-e4fda3199e3d.gif");

		doc.Size.Should()
			.Be(2006654);

		doc.Ext.Should()
			.Be("gif");

		doc.Uri.Should()
			.Be("http://vk.com/doc26033241_237844408?hash=126f761781ce2ebfc5&dl=f2c681ec7740f9a3a0&api=1");

		doc.Photo100.Should()
			.Be("http://cs537313.vk.me/u26033241/-3/s_48ba682f61.jpg");

		doc.Photo130.Should()
			.Be("http://cs537313.vk.me/u26033241/-3/m_48ba682f61.jpg");

		doc.AccessKey.Should()
			.Be("5bf7103aa95aacb8ad");
	}

	[Fact]
	public void Get_ExtendedVersion_GenerateOutParametersCorrectly()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(Get_ExtendedVersion_GenerateOutParametersCorrectly));

		// 10, out posts, out profiles, out groups, 1, 1, WallFilter.Owner
		var count = Api.Wall.Get(new()
		{
			OwnerId = 10,
			Count = 1,
			Offset = 1,
			Filter = WallFilter.Owner
		});

		count.TotalCount.Should()
			.Be(42);

		count.WallPosts.Should()
			.ContainSingle();

		count.WallPosts[0]
			.Id.Should()
			.Be(41);

		count.Profiles.Should()
			.ContainSingle();

		count.Profiles[0]
			.Id.Should()
			.Be(10);

		count.Groups.Should()
			.HaveCount(1);

		count.Groups[0]
			.Id.Should()
			.Be(29246653);
	}

	[Fact]
	public void Get_Geo_NormalCase()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(Get_Geo_NormalCase));

		var posts = Api.Wall.Get(new()
		{
			OwnerId = 1563369,
			Count = 3,
			Offset = 2
		});

		posts.TotalCount.Should()
			.Be(165);

		posts.Should()
			.NotBeNull();
	}

	[Fact]
	public void Get_With_PhotoListAttachment()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(Get_With_PhotoListAttachment));

		var posts = Api.Wall.Get(new()
		{
			OwnerId = 46476924,
			Count = 1,
			Offset = 213,
			Filter = WallFilter.Owner
		});

		posts.TotalCount.Should()
			.Be(1724);

		posts.WallPosts.Should()
			.NotBeNull();

		posts.WallPosts.Should()
			.HaveCount(1);

		posts.WallPosts[0]
			.CopyHistory.Should()
			.NotBeNull();

		posts.WallPosts[0]
			.CopyHistory.Should()
			.HaveCount(1);

		var attach = posts.WallPosts[0]
			.CopyHistory[0]
			.Attachment;

		attach.Should()
			.NotBeNull();

		attach.Instance.Should()
			.BeNull();
	}

	[Fact]
	public void Get_WithPoll_NormalCase()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(Get_WithPoll_NormalCase));

		var posts = Api.Wall.Get(new()
		{
			OwnerId = -103292418,
			Count = 1
		});

		posts.TotalCount.Should()
			.Be(2u);

		posts.WallPosts.Should()
			.HaveCount(1);

		var post = posts.WallPosts.FirstOrDefault();

		post.Should()
			.NotBeNull();

		post.Id.Should()
			.Be(3);

		post.FromId.Should()
			.Be(-103292418);

		post.OwnerId.Should()
			.Be(-103292418);

		post.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1447252575));

		post.PostType.Should()
			.Be(PostType.Post);

		post.Text.Should()
			.Be("Тест");

		post.CanDelete.Should()
			.BeTrue();

		post.CanEdit.Should()
			.BeFalse();

		post.PostSource.Type.Should()
			.Be(PostSourceType.Api);

		post.Comments.Should()
			.NotBeNull();

		post.Comments.Count.Should()
			.Be(0);

		post.Likes.Count.Should()
			.Be(0);

		post.Likes.UserLikes.Should()
			.BeFalse();

		post.Likes.CanLike.Should()
			.BeTrue();

		post.Likes.CanPublish.Should()
			.BeTrue();

		post.Reposts.Count.Should()
			.Be(0);

		post.Reposts.UserReposted.Should()
			.BeFalse();
	}

	[Fact]
	public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException() => FluentActions.Invoking(() =>
			new WallCategory(new VkApi()).GetById(new[]
			{
				"93388_21539",
				"93388_20904",
				"2943_4276"
			}, true))
		.Should()
		.ThrowExactly<AccessTokenInvalidException>();

	[Fact]
	public void GetById_IncorrectParameters_ThrowException()
	{
		FluentActions.Invoking(() => new WallCategory(Api).GetById(null))
			.Should()
			.ThrowExactly<ArgumentNullException>();

		FluentActions.Invoking(() => new WallCategory(Api).GetById(Enumerable.Empty<string>(), true))
			.Should()
			.ThrowExactly<ArgumentException>();
	}

	[Fact]
	public void GetById_ReturnWallRecords()
	{
		Url = "https://api.vk.com/method/wall.getById";
		ReadCategoryJsonPath(nameof(GetById_ReturnWallRecords));

		var records = Api.Wall.GetById(new[]
		{
			"1_619",
			"1_617",
			"1_616"
		});

		records.Count.Should()
			.Be(1);

		records[0]
			.Id.Should()
			.Be(617);

		records[0]
			.FromId.Should()
			.Be(1);

		records[0]
			.OwnerId.Should()
			.Be(1);

		records[0]
			.Date.Should()
			.Be(new DateTime(1970,
				1,
				1,
				0,
				0,
				0,
				0,
				DateTimeKind.Utc).AddSeconds(1171758699));

		records[0]
			.Text.Should()
			.BeNullOrEmpty();

		records[0]
			.Comments.Count.Should()
			.Be(0);

		records[0]
			.Comments.CanPost.Should()
			.BeTrue();

		records[0]
			.Likes.Count.Should()
			.Be(2);

		records[0]
			.Likes.UserLikes.Should()
			.BeFalse();

		records[0]
			.Likes.CanLike.Should()
			.BeTrue();

		records[0]
			.Likes.CanPublish.Should()
			.BeFalse();

		records[0]
			.Reposts.Count.Should()
			.Be(0);

		records[0]
			.Reposts.UserReposted.Should()
			.BeFalse();
	}

	[Fact]
	public void GetById_Donut()
	{
		Url = "https://api.vk.com/method/wall.getById";
		ReadCategoryJsonPath(nameof(GetById_Donut));

		var records = Api.Wall.GetById(new[]
		{
			"-322_123"
		}, true);

		records.Groups.Count.Should()
			.Be(1);

		records.WallPosts[0]
			.Id.Should()
			.Be(123);

		records.WallPosts[0]
			.FromId.Should()
			.Be(-322);

		records.WallPosts[0]
			.OwnerId.Should()
			.Be(-322);

		records.WallPosts[0]
			.Date.Should()
			.Be(new DateTime(1970,
				1,
				1,
				0,
				0,
				0,
				0,
				DateTimeKind.Utc).AddSeconds(1605698519));

		records.WallPosts[0]
			.Text.Should()
			.Be("В этом посте нет доната");
	}

	[Fact]
	public void GetComments_ReturnLikesAndAttachments()
	{
		Url = "https://api.vk.com/method/wall.getComments";
		ReadCategoryJsonPath(nameof(GetComments_ReturnLikesAndAttachments));

		var comments = Api.Wall.GetComments(new()
		{
			OwnerId = 12312,
			PostId = 12345,
			Sort = SortOrderBy.Asc,
			NeedLikes = true
		});

		comments.Count.Should()
			.Be(2);

		var comment0 = comments.Items[0];

		comment0.Id.Should()
			.Be(3809);

		comment0.FromId.Should()
			.Be(6733856);

		comment0.Date.Should()
			.Be(new(2013,
				11,
				22,
				05,
				45,
				44,
				DateTimeKind.Utc));

		comment0.Text.Should()
			.Be("Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!");

		comment0.Likes.Should()
			.NotBeNull();

		comment0.Likes.Count.Should()
			.Be(1);

		var comment1 = comments.Items[1];

		comment1.Id.Should()
			.Be(3810);

		comment1.FromId.Should()
			.Be(3073863);

		comment1.Date.Should()
			.Be(new(2013,
				11,
				22,
				6,
				21,
				06,
				DateTimeKind.Utc));

		comment1.Text.Should()
			.Be("C днем рождения малышку и родителей!!!");

		comment1.Likes.Should()
			.NotBeNull();

		comment1.Likes.Count.Should()
			.Be(1);

		var attachment = comment1.Attachment;

		attachment.Should()
			.NotBeNull();

		attachment.Type.Should()
			.Be(typeof(Photo));

		var photo = (Photo) attachment.Instance;

		photo.Id.Should()
			.Be(315467755);

		photo.AlbumId.Should()
			.Be(-5);

		photo.OwnerId.Should()
			.Be(3073863);

		photo.Photo130.Should()
			.Be(new Uri("http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg"));

		photo.Photo604.Should()
			.Be(new Uri("http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg"));

		photo.Photo75.Should()
			.Be(new Uri("http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg"));

		photo.Photo807.Should()
			.BeNull();

		photo.Photo1280.Should()
			.BeNull();

		photo.Width.Should()
			.Be(510);

		photo.Height.Should()
			.Be(383);

		photo.Text.Should()
			.BeEmpty();

		photo.CreateTime.Should()
			.Be(new(2013,
				11,
				22,
				6,
				20,
				31,
				DateTimeKind.Utc));
	}

	[Fact]
	public void OpenComments_ReturnTrue()
	{
		Url = "https://api.vk.com/method/wall.openComments";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Wall.OpenComments(3, 3);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Repost_ReturnCorrectResults()
	{
		Url = "https://api.vk.com/method/wall.repost";
		ReadCategoryJsonPath(nameof(Repost_ReturnCorrectResults));

		var result = Api.Wall.Repost("id", null, null, false);

		result.Should()
			.NotBeNull();

		result.Success.Should()
			.BeTrue();

		result.PostId.Should()
			.Be(2587);

		result.RepostsCount.Should()
			.Be(21);

		result.LikesCount.Should()
			.Be(105);
	}

	[Fact]
	public void Repost_UrlIsGeneratedCorrectly()
	{
		Url = "https://api.vk.com/method/wall.repost";
		ReadCategoryJsonPath(nameof(Repost_UrlIsGeneratedCorrectly));

		var result = Api.Wall.Repost("id", "example", 50, false);

		result.Should()
			.NotBeNull();

		result.Success.Should()
			.BeTrue();

		result.PostId.Should()
			.Be(2587);

		result.RepostsCount.Should()
			.Be(21);

		result.LikesCount.Should()
			.Be(105);
	}

	[Fact]
	public void CheckCopyrightLink_ReturnTrue()
	{
		Url = "https://api.vk.com/method/wall.checkCopyrightLink";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Wall.CheckCopyrightLink("https://habr.com");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void GetComment_ReturnCorrectResults()
	{
		Url = "https://api.vk.com/method/wall.getComment";

		ReadCategoryJsonPath(nameof(GetComment_ReturnCorrectResults));

		var wallCommentResult = Api.Wall.GetComment(66559, 73674, true);
		var comment = wallCommentResult.Comment.FirstOrDefault();
		var profiles = wallCommentResult.Profiles;
		var groups = wallCommentResult.Groups;

		comment.Date.Should()
			.Be(new DateTime(1970,
				1,
				1,
				0,
				0,
				0,
				0).AddSeconds(1534927387));

		comment.FromId.Should()
			.Be(233754083);

		comment.ReplyToUser.Should()
			.Be(6099);

		groups.Should()
			.BeEmpty();

		profiles.FirstOrDefault()
			.FirstName.Should()
			.Be("Dmitry");

		profiles.FirstOrDefault()
			.LastName.Should()
			.Be("Sergeev");
	}
}