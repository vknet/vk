using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Widgets
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class WidgetsCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Widgets";

		[Test]
		public void GetComments()
		{
			Url = "https://api.vk.com/method/widgets.getComments";

			ReadCategoryJsonPath(nameof(GetComments));

			var result = Api.Widgets.GetComments(new GetCommentsParams
			{
				WidgetApiId = 5553257,
				Url = "http://griffiny.ru/season-01/4-1-sezon-1-seriya-i-u-smerti-est-ten.html",
				Order = "date",
				Count = 10,
				Offset = 0
			});

			Assert.IsNotEmpty(result);
			Assert.AreEqual(10, result.TotalCount);
		}

		[Test]
		public void GetPages()
		{
			Url = "https://api.vk.com/method/widgets.getPages";

			ReadCategoryJsonPath(nameof(GetPages));

			var result = Api.Widgets.GetPages(5553257, null, "alltime", 0, 10);
			Assert.IsNotEmpty(result);
			Assert.AreEqual(50, result.TotalCount);
		}
	}
}