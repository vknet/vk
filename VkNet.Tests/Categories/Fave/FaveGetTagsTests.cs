using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	public class FaveGetTagsTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Fave";

		[Test]
		public void GetTags()
		{
			Url = "https://api.vk.com/method/fave.getTags";
			ReadCategoryJsonPath(nameof(GetTags));

			var tags = Api.Fave.GetTags();

			var tag = tags.FirstOrDefault();

			Assert.IsNotEmpty(tags);
			Assert.NotNull(tag);
		}
	}
}