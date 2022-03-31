using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards
{
	[TestFixture]

	public class GetTest : CategoryBaseTest
	{
		protected override string Folder => "PrettyCards";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/prettyCards.get";

			ReadCategoryJsonPath(nameof(Api.PrettyCards.Get));

			var result = Api.PrettyCards.Get(new PrettyCardsGetParams
			{
				OwnerId = -126102803,
				Offset = 20,
				Count = 100
			});

			result.Should().NotBeNull();
			result[0].CardId.Should().Be("7037403");
			result[1].PriceOld.Should().Be("123.00");
		}
	}
}