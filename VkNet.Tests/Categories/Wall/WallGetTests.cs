using System.Linq;
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

			Assert.NotNull(result);
			Assert.That(result.TotalCount, Is.EqualTo(520));
			var post = result.WallPosts.FirstOrDefault();
			Assert.NotNull(post);
			var attachment = post.Attachment.Instance as Article;
			Assert.NotNull(attachment);
			Assert.That(attachment.Id, Is.EqualTo(10419));
		}

		[Test]
		public void PodcastAttachment()
		{
			Url = "https://api.vk.com/method/wall.get";
			ReadCategoryJsonPath(nameof(PodcastAttachment));

			var result = Api.Wall.Get(new WallGetParams());

			Assert.NotNull(result);
			Assert.That(result.TotalCount, Is.EqualTo(6352));
			var post = result.WallPosts.FirstOrDefault();
			Assert.NotNull(post);
			var podcast = post.Attachments[1].Instance as Podcast;
			Assert.NotNull(podcast);
			Assert.That(podcast.Id, Is.EqualTo(456240245));
		}
	}
}