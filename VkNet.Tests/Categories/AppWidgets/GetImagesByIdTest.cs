using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.AppWidgets
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetImagesByIdTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void GetAppImages()
		{
			Url = "https://api.vk.com/method/appWidgets.getImagesById";

			ReadCategoryJsonPath(nameof(GetAppImages));

			var result = Api.AppWidgets.GetImagesById("7309583_1192027");

			Assert.IsNotNull(result);
			Assert.AreEqual("7309583_1192027", result.First().Id);
		}
	}
}