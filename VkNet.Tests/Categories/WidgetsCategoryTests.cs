using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class WidgetsCategoryTests : BaseTest
	{
		[Test]
		public void GetComments()
		{
			Url = "https://api.vk.com/method/widgets.getComments";

			Json =
				@"{
					""response"": {
						""count"": 10,
						""posts"": [
							{
								""id"": 292,
								""from_id"": 459911423,
								""to_id"": 459911423,
								""date"": 1520738708,
								""post_type"": ""post"",
								""text"": ""&#10084;&#10084;&#10084;"",
								""post_source"": {
									""link"": {
										""url"": ""http://griffiny.r...smerti-est-ten.html"",
										""title"": ""1 сезон 1 серия: И у Смерти есть тень"",
										""description"": ""Первая серия Гриффинов, в которой Питера уволили с работы, и вся семья жила на огромное пособие по безработице.""
									},
									""type"": ""widget"",
									""data"": ""comments""
								},
								""comments"": {
									""count"": 0,
									""groups_can_post"": true,
									""can_post"": 1
								},
								""likes"": {
									""count"": 0,
									""user_likes"": 0,
									""can_like"": 1,
									""can_publish"": 1
								},
								""reposts"": {
									""count"": 0,
									""user_reposted"": 0
								}
							}
						]
					}
				}
            ";

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

			Json =
				@"{
					""response"": {
						""count"": 50,
						""pages"": [
							{
								""id"": ""40161742"",
								""title"": ""12 сезон 19 серия: Мег воняет!"",
								""description"": ""Брайана опрыскивает скунс, после чего пёс из-за вони переселяется на улицу. Питер же становится лучшим другом Мег."",
								""url"": ""http://griffiny.rya-meg-vonyaet.html"",
								""likes"": {
									""count"": 0
								},
								""comments"": {
									""count"": 1
								},
								""date"": 1526041833,
								""photo"": {
									""id"": 456241785,
									""album_id"": -5,
									""owner_id"": 338349868,
									""sizes"": [
										{
											""type"": ""m"",
											""url"": ""https://pp.userap20b/DUrJf2XxN4Q.jpg"",
											""width"": 130,
											""height"": 73
										},
										{
											""type"": ""o"",
											""url"": ""https://pp.userap20d/caAmdNtd57Y.jpg"",
											""width"": 130,
											""height"": 87
										},
										{
											""type"": ""p"",
											""url"": ""https://pp.userap20e/PgDjUi-WvQ0.jpg"",
											""width"": 200,
											""height"": 133
										},
										{
											""type"": ""q"",
											""url"": ""https://pp.userap20f/BB7Wt7wKCU0.jpg"",
											""width"": 302,
											""height"": 170
										},
										{
											""type"": ""r"",
											""url"": ""https://pp.userap210/MjW7-V9ln4A.jpg"",
											""width"": 302,
											""height"": 170
										},
										{
											""type"": ""s"",
											""url"": ""https://pp.userap20a/JWbVV9YuOFU.jpg"",
											""width"": 75,
											""height"": 42
										},
										{
											""type"": ""x"",
											""url"": ""https://pp.userap20c/a25POAHx2IY.jpg"",
											""width"": 302,
											""height"": 170
										}
									],
									""text"": """",
									""date"": 1526041834
								}
							}
						]
					}
				}
            ";

			var result = Api.Widgets.GetPages(5553257, null, "alltime", 0, 10);
			Assert.IsNotEmpty(result);
			Assert.AreEqual(50, result.TotalCount);
		}
	}
}