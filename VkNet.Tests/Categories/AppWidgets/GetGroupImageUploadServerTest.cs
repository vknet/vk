using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.AppWidgets
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetGroupImageUploadServerTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void GetGroupImageUploadServer()
		{
			Url = "https://api.vk.com/method/appWidgets.getGroupImageUploadServer";

			ReadCategoryJsonPath(nameof(GetGroupImageUploadServer));

			var result = Api.AppWidgets.GetGroupImageUploadServer(AppWidgetImageType.FiftyOnFifty);

			Assert.IsNotNull(result.UploadUrl);
		}
	}
}