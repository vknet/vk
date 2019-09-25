using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	public class FaveGetPagesTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Fave";

		[Test]
		public void GetPages()
		{
			Url = "https://api.vk.com/method/fave.getPages";
			ReadCategoryJsonPath(nameof(GetPages));

			var pages = Api.Fave.GetPages(FavePageType.Users);
			var page = pages.FirstOrDefault();

			Assert.IsTrue(pages.Any());
			Assert.NotNull(page);
		}
	}
}