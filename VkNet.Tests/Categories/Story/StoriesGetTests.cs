using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Stories;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Story
{
	[TestFixture]
	public class StoriesGetTests : CategoryBaseTest
	{
		protected override string Folder => "Stories";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/stories.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.Stories.Get();

			Assert.That(1, Is.EqualTo(result.Count));
		}

		[Test]
		public void GetBanned()
		{
			Url = "https://api.vk.com/method/stories.getBanned";
			ReadCategoryJsonPath(nameof(GetBanned));

			var result = Api.Stories.GetBanned();

			var userId = result.Items.FirstOrDefault();

			Assert.That(result.Count, Is.EqualTo(1));
			Assert.NotNull(userId);
		}

		[Test]
		public void GetPhotoUploadServer()
		{
			Url = "https://api.vk.com/method/stories.getPhotoUploadServer";
			ReadCategoryJsonPath(nameof(GetPhotoUploadServer));

			var result = Api.Stories.GetPhotoUploadServer(new GetPhotoUploadServerParams
			{
				AddToNews = true
			});

			Assert.NotNull(result.UploadUrl);
		}

		[Test]
		public void GetReplies()
		{
			Url = "https://api.vk.com/method/stories.getReplies";
			ReadCategoryJsonPath(nameof(GetReplies));

			var result = Api.Stories.GetReplies(12345679, 123456789, null, true, new List<string>());

			Assert.That(result.Count, Is.EqualTo(1));
		}

		[Test]
		public void GetViewers()
		{
			Url = "https://api.vk.com/method/stories.getViewers";
			ReadCategoryJsonPath(nameof(GetViewers));

			var users = Api.Stories.GetViewers(123456789, 123456789);
			var userId = users.FirstOrDefault();

			Assert.That(users.Count, Is.EqualTo(1));
			Assert.NotNull(userId);
			Assert.That(userId, Is.EqualTo(123456789));
		}

		[Test]
		public void GetViewersExtended()
		{
			Url = "https://api.vk.com/method/stories.getViewers";
			ReadCategoryJsonPath(nameof(GetViewersExtended));

			var users = Api.Stories.GetViewersExtended(123456789, 123456789);
			var user = users.FirstOrDefault();

			Assert.That(users.Count, Is.EqualTo(1));
			Assert.NotNull(user);
			Assert.That(user.Id, Is.EqualTo(123456789));
			Assert.That(user.FirstName, Is.EqualTo("test"));
			Assert.That(user.LastName, Is.EqualTo("test1"));
		}

		[Test]
		public void GetStats()
		{
			Url = "https://api.vk.com/method/stories.getStats";
			ReadCategoryJsonPath(nameof(GetStats));

			var stats = Api.Stories.GetStats(123456789, 123456789);

			Assert.NotNull(stats.Views);
			Assert.NotNull(stats.Answer);
			Assert.NotNull(stats.Bans);
			Assert.NotNull(stats.OpenLink);
			Assert.NotNull(stats.Replies);
			Assert.NotNull(stats.Subscribers);
			Assert.NotNull(stats.Shares);
		}

		[Test]
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

			stories.Should().NotBeNull();
			stories.Count.Should().Be(1);
			stories.Items.Should().NotBeNullOrEmpty();
		}

		[Test]
		public void Search()
		{
			Url = "https://api.vk.com/method/stories.search";
			ReadCategoryJsonPath(nameof(Search));

			var result = Api.Stories.Search(new StoriesSearchParams
			{
				Query = "Ростов",
				Extended = true,
				Fields = new List<string>
				{
					"bdate"
				}
			});

			result.Should().NotBeNull();
			result.Count.Should().Be(1);
			result.Items.Should().NotBeNullOrEmpty();
			result.Profiles.Should().NotBeNullOrEmpty();
			result.Groups.Should().NotBeNull();
		}
	}
}