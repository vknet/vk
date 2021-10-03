using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Wall
{
	[TestFixture]
	public class WallGetTests : CategoryBaseTest
	{
		protected override string Folder => "Wall";

		[Test]
		public void ArticleAttachement()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(ArticleAttachement));

			var result = Api.Wall.Get(new WallGetParams());

			result.Should().NotBeNull();
			Assert.That(result.TotalCount, Is.EqualTo(520));
			var post = result.WallPosts.FirstOrDefault();
			post.Should().NotBeNull();
			var attachment = post.Attachment.Instance as Article;
			attachment.Should().NotBeNull();
			Assert.That(attachment.Id, Is.EqualTo(10419));
		}

		[Test]
		public void PodcastAttachment()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(PodcastAttachment));

			var result = Api.Wall.Get(new WallGetParams());

			result.Should().NotBeNull();
			Assert.That(result.TotalCount, Is.EqualTo(6352));
			var post = result.WallPosts.FirstOrDefault();
			post.Should().NotBeNull();
			var podcast = post.Attachments[1].Instance as Podcast;
			podcast.Should().NotBeNull();
			Assert.That(podcast.Id, Is.EqualTo(456240245));
		}
	}
}