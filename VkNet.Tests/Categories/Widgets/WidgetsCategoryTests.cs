using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Widgets
{


	public class WidgetsCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Widgets";

		[Fact]
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

			result.Should().NotBeEmpty();
			result.TotalCount.Should().Be(10);
		}

		[Fact]
		public void GetPages()
		{
			Url = "https://api.vk.com/method/widgets.getPages";

			ReadCategoryJsonPath(nameof(GetPages));

			var result = Api.Widgets.GetPages(5553257, null, "alltime", 0, 10);
			result.Should().NotBeEmpty();
			result.TotalCount.Should().Be(50);
		}
	}
}