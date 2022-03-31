using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards
{
	[TestFixture]

	public class EditTest : CategoryBaseTest
	{
		protected override string Folder => "PrettyCards";

		[Test]
		public void Edit()
		{
			Url = "https://api.vk.com/method/prettyCards.edit";

			ReadCategoryJsonPath(nameof(Api.PrettyCards.Edit));

			var result = Api.PrettyCards.Edit(new PrettyCardsEditParams
			{
				OwnerId = -126102803,
				CardId = "1488"
			});

			result.Should().NotBeNull();
			result.CardId.Should().Be("1488");
			result.OwnerId.Should().Be(-126102803);
		}
	}
}