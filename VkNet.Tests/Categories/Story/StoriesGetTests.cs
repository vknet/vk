using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Model.RequestParams.Stories;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Story
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
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

			var result = Api.Stories.GetPhotoUploadServer(new GetPhotoUploadServerParams { AddToNews = true });

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

			var stories = Api.Stories.GetById(new List<string> { "123456789_123456789" }, true, new List<string>());
			var story = stories.Items.FirstOrDefault();

			Assert.That(stories.Count, Is.EqualTo(1));
			Assert.NotNull(story);
		}
	}
}