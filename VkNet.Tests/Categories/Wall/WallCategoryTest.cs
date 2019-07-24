using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Wall
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class WallCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Wall";

		[Test]
		[Ignore(TestIgnoreConstants.Excess)]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(() => new WallCategory(new VkApi()).Delete(1, 1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_Document_NormalCase()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(Get_Document_NormalCase));

			var posts = Api.Wall.Get(new WallGetParams
			{
				OwnerId = 26033241, Count = 1, Offset = 2
			});

			Assert.That(posts.TotalCount, Is.EqualTo(100u));
			Assert.That(posts.WallPosts[0].Attachments.Count, Is.EqualTo(1));
			var doc = (Document) posts.WallPosts[0].Attachment.Instance;
			Assert.That(doc, Is.Not.Null);
			Assert.That(doc.Id, Is.EqualTo(237844408));
			Assert.That(doc.OwnerId, Is.EqualTo(26033241));
			Assert.That(doc.Title, Is.EqualTo("2e857c8f-aaf8-4399-9856-e4fda3199e3d.gif"));
			Assert.That(doc.Size, Is.EqualTo(2006654));
			Assert.That(doc.Ext, Is.EqualTo("gif"));

			Assert.That(doc.Uri, Is.EqualTo("http://vk.com/doc26033241_237844408?hash=126f761781ce2ebfc5&dl=f2c681ec7740f9a3a0&api=1"));

			Assert.That(doc.Photo100, Is.EqualTo("http://cs537313.vk.me/u26033241/-3/s_48ba682f61.jpg"));
			Assert.That(doc.Photo130, Is.EqualTo("http://cs537313.vk.me/u26033241/-3/m_48ba682f61.jpg"));
			Assert.That(doc.AccessKey, Is.EqualTo("5bf7103aa95aacb8ad"));
		}

		[Test]
		public void Get_ExtendedVersion_GenerateOutParametersCorrectly()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(Get_ExtendedVersion_GenerateOutParametersCorrectly));

			// 10, out posts, out profiles, out groups, 1, 1, WallFilter.Owner
			var count = Api.Wall.Get(new WallGetParams
			{
				OwnerId = 10, Count = 1, Offset = 1, Filter = WallFilter.Owner
			});

			Assert.That(count.TotalCount, Is.EqualTo(42));

			Assert.That(count.WallPosts.Count, Is.EqualTo(1));
			Assert.That(count.WallPosts[0].Id, Is.EqualTo(41));

			Assert.That(count.Profiles.Count, Is.EqualTo(1));
			Assert.That(count.Profiles[0].Id, Is.EqualTo(10));

			Assert.That(count.Groups.Count, Is.EqualTo(1));
			Assert.That(count.Groups[0].Id, Is.EqualTo(29246653));
		}

		[Test]
		[Ignore("undone")]
		public void Get_Geo_NormalCase()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(Get_Geo_NormalCase));

			var posts = Api.Wall.Get(new WallGetParams
			{
				OwnerId = 1563369, Count = 3, Offset = 2
			});

			Assert.That(posts.TotalCount, Is.EqualTo(165));
			Assert.That(posts, Is.Not.Null);

			Assert.Fail("undone");
		}

		[Test]
		public void Get_With_PhotoListAttachment()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(Get_With_PhotoListAttachment));

			var posts = Api.Wall.Get(new WallGetParams
			{
				OwnerId = 46476924, Count = 1, Offset = 213, Filter = WallFilter.Owner
			});

			Assert.That(posts.TotalCount, Is.EqualTo(1724));
			Assert.That(posts.WallPosts, Is.Not.Null);
			Assert.That(posts.WallPosts.Count, Is.EqualTo(1));
			Assert.That(posts.WallPosts[0].CopyHistory, Is.Not.Null);
			Assert.That(posts.WallPosts[0].CopyHistory.Count, Is.EqualTo(1));

			var attach = posts.WallPosts[0].CopyHistory[0].Attachment;
			Assert.That(attach, Is.Not.Null);
			Assert.That(attach.Instance, Is.Null);
		}

		[Test]
		public void Get_WithPoll_NormalCase()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(Get_WithPoll_NormalCase));

			var posts = Api.Wall.Get(new WallGetParams
			{
				OwnerId = -103292418, Count = 1
			});

			Assert.That(posts.TotalCount, Is.EqualTo(2u));
			Assert.That(posts.WallPosts.Count, Is.EqualTo(1));

			var post = posts.WallPosts.FirstOrDefault();
			Assert.That(post, Is.Not.Null);

			Assert.That(post.Id, Is.EqualTo(3));
			Assert.That(post.FromId, Is.EqualTo(-103292418));
			Assert.That(post.OwnerId, Is.EqualTo(-103292418));
			Assert.That(post.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447252575)));
			Assert.That(post.PostType, Is.EqualTo(PostType.Post));
			Assert.That(post.Text, Is.EqualTo("Тест"));
			Assert.That(post.CanDelete, Is.True);
			Assert.That(post.CanEdit, Is.False);
			Assert.That(post.PostSource.Type, Is.EqualTo(PostSourceType.Api));
			Assert.That(post.Comments, Is.Not.Null);
			Assert.That(post.Comments.Count, Is.EqualTo(0));
			Assert.That(post.Likes.Count, Is.EqualTo(0));
			Assert.That(post.Likes.UserLikes, Is.False);
			Assert.That(post.Likes.CanLike, Is.True);
			Assert.That(post.Likes.CanPublish, Is.EqualTo(true));
			Assert.That(post.Reposts.Count, Is.EqualTo(0));
			Assert.That(post.Reposts.UserReposted, Is.False);
		}

		[Test]
		[Ignore(TestIgnoreConstants.Excess)]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(() => new WallCategory(new VkApi()).GetById(new[]
				{
					"93388_21539", "93388_20904", "2943_4276"
				}),
				Throws.TypeOf<AccessTokenInvalidException>());
		}

		[Test]
		[Ignore("Убрана валидация параметров из кода")]
		public void GetById_IncorrectParameters_ThrowException()
		{
			Assert.That(() => new WallCategory(Api).GetById(null), Throws.TypeOf<ArgumentNullException>());
			Assert.That(() => new WallCategory(Api).GetById(Enumerable.Empty<string>()), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void GetById_ReturnWallRecords()
		{
			Url = "https://api.vk.com/method/wall.getById";
			ReadCategoryJsonPath(nameof(GetById_ReturnWallRecords));

			var records = Api.Wall.GetById(new[]
			{
				"1_619", "1_617", "1_616"
			});

			Assert.That(records.TotalCount == 1);

			Assert.That(records.WallPosts[0].Id, Is.EqualTo(617));
			Assert.That(records.WallPosts[0].FromId, Is.EqualTo(1));
			Assert.That(records.WallPosts[0].OwnerId, Is.EqualTo(1));

			Assert.That(records.WallPosts[0].Date,
				Is.EqualTo(new DateTime(1970,
					1,
					1,
					0,
					0,
					0,
					0,
					DateTimeKind.Utc).AddSeconds(1171758699)));

			Assert.That(records.WallPosts[0].Text, Is.Null.Or.Empty);
			Assert.That(records.WallPosts[0].Comments.Count == 0);
			Assert.That(records.WallPosts[0].Comments.CanPost, Is.True);
			Assert.That(records.WallPosts[0].Likes.Count, Is.EqualTo(2));
			Assert.That(records.WallPosts[0].Likes.UserLikes, Is.False);
			Assert.That(records.WallPosts[0].Likes.CanLike, Is.True);
			Assert.That(records.WallPosts[0].Likes.CanPublish, Is.False);
			Assert.That(records.WallPosts[0].Reposts.Count, Is.EqualTo(0));
			Assert.That(records.WallPosts[0].Reposts.UserReposted, Is.False);
		}

		[Test]
		public void GetComments_ReturnLikesAndAttachments()
		{
			Url = "https://api.vk.com/method/wall.getComments";
			ReadCategoryJsonPath(nameof(GetComments_ReturnLikesAndAttachments));

			var comments = Api.Wall.GetComments(new WallGetCommentsParams
			{
				OwnerId = 12312, PostId = 12345, Sort = SortOrderBy.Asc, NeedLikes = true
			});

			Assert.That(comments.Count, Is.EqualTo(2));

			var comment0 = comments.Items[0];
			Assert.That(comment0.Id, Is.EqualTo(3809));
			Assert.That(comment0.FromId, Is.EqualTo(6733856));

			Assert.That(comment0.Date,
				Is.EqualTo(new DateTime(2013,
					11,
					22,
					05,
					45,
					44,
					DateTimeKind.Utc)));

			Assert.That(comment0.Text, Is.EqualTo("Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!"));

			Assert.That(comment0.Likes, Is.Not.Null);
			Assert.That(comment0.Likes.Count, Is.EqualTo(1));

			var comment1 = comments.Items[1];
			Assert.That(comment1.Id, Is.EqualTo(3810));
			Assert.That(comment1.FromId, Is.EqualTo(3073863));

			Assert.That(comment1.Date,
				Is.EqualTo(new DateTime(2013,
					11,
					22,
					6,
					21,
					06,
					DateTimeKind.Utc)));

			Assert.That(comment1.Text, Is.EqualTo("C днем рождения малышку и родителей!!!"));
			Assert.That(comment1.Likes, Is.Not.Null);
			Assert.That(comment1.Likes.Count, Is.EqualTo(1));

			var attachment = comment1.Attachment;
			Assert.That(attachment, Is.Not.Null);
			Assert.That(attachment.Type, Is.EqualTo(typeof(Photo)));

			var photo = (Photo) attachment.Instance;
			Assert.That(photo.Id, Is.EqualTo(315467755));
			Assert.That(photo.AlbumId, Is.EqualTo(-5));
			Assert.That(photo.OwnerId, Is.EqualTo(3073863));

			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg")));

			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg")));

			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg")));

			Assert.That(photo.Photo807, Is.Null);
			Assert.That(photo.Photo1280, Is.Null);
			Assert.That(photo.Width, Is.EqualTo(510));
			Assert.That(photo.Height, Is.EqualTo(383));
			Assert.That(photo.Text, Is.EqualTo(string.Empty));

			Assert.That(photo.CreateTime,
				Is.EqualTo(new DateTime(2013,
					11,
					22,
					6,
					20,
					31,
					DateTimeKind.Utc)));
		}

		[Test]
		public void Repost_ReturnCorrectResults()
		{
			Url = "https://api.vk.com/method/wall.repost";
			ReadCategoryJsonPath(nameof(Repost_ReturnCorrectResults));

			var result = Api.Wall.Repost("id", null, null, false);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Success, Is.True);
			Assert.That(result.PostId, Is.EqualTo(2587));
			Assert.That(result.RepostsCount, Is.EqualTo(21));
			Assert.That(result.LikesCount, Is.EqualTo(105));
		}

		[Test]
		public void Repost_UrlIsGeneratedCorrectly()
		{
			Url = "https://api.vk.com/method/wall.repost";
			ReadCategoryJsonPath(nameof(Repost_UrlIsGeneratedCorrectly));

			var result = Api.Wall.Repost("id", "example", 50, false);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Success, Is.True);
			Assert.That(result.PostId, Is.EqualTo(2587));
			Assert.That(result.RepostsCount, Is.EqualTo(21));
			Assert.That(result.LikesCount, Is.EqualTo(105));
		}

		[Test]
		public void OpenComments_ReturnTrue()
		{
			Url = "https://api.vk.com/method/wall.openComments";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Wall.OpenComments(3, 3);

			Assert.IsTrue(result);
		}

		[Test]
		public void CloseComments_ReturnTrue()
		{
			Url = "https://api.vk.com/method/wall.closeComments";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Wall.CloseComments(3, 3);

			Assert.IsTrue(result);
		}
	}
}