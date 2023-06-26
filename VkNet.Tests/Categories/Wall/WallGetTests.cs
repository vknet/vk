using System.Linq;
using FluentAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Wall;

public class WallGetTests : CategoryBaseTest
{
	protected override string Folder => "Wall";

	[Fact]
	public void ArticleAttachement()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(ArticleAttachement));

		var result = Api.Wall.Get(new());

		result.Should()
			.NotBeNull();

		result.TotalCount.Should()
			.Be(520);

		var post = result.WallPosts.FirstOrDefault();

		post.Should()
			.NotBeNull();

		var attachment = post.Attachment.Instance as Article;

		attachment.Should()
			.NotBeNull();

		attachment.Id.Should()
			.Be(10419);
	}

	[Fact]
	public void PodcastAttachment()
	{
		Url = "https://api.vk.com/method/wall.get";
		ReadCategoryJsonPath(nameof(PodcastAttachment));

		var result = Api.Wall.Get(new());

		result.Should()
			.NotBeNull();

		result.TotalCount.Should()
			.Be(6352);

		var post = result.WallPosts.FirstOrDefault();

		post.Should()
			.NotBeNull();

		var podcast = post.Attachments[1]
			.Instance as Podcast;

		podcast.Should()
			.NotBeNull();

		podcast.Id.Should()
			.Be(456240245);
	}
}