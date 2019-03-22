using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Wall
{
	[TestFixture]
	public class WallGetCommentsTests: CategoryBaseTest
	{
		protected override string Folder => "Wall";


		[Test]
		public void GetComments802()
		{
			Url = "https://api.vk.com/method/wall.getComments";
			ReadCategoryJsonPath(nameof(GetComments802));

			var result = Api.Wall.GetComments(new WallGetCommentsParams
			{
				NeedLikes = false,
				PostId = 123,
				OwnerId = 321,
				Count = 100,
				Offset = 0
			});

			Assert.NotNull(result);
		}

	}
}