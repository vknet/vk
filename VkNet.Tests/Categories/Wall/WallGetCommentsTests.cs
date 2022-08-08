using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Wall;

public class WallGetCommentsTests : CategoryBaseTest
{
	protected override string Folder => "Wall";

	[Fact]
	public void GetComments802()
	{
		Url = "https://api.vk.com/method/wall.getComments";
		ReadCategoryJsonPath(nameof(GetComments802));

		var result = Api.Wall.GetComments(new()
		{
			NeedLikes = false,
			PostId = 123,
			OwnerId = 321,
			Count = 100,
			Offset = 0
		});

		result.Should()
			.NotBeNull();
	}
}