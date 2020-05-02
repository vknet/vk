using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class CreateTest : CategoryBaseTest
	{
		protected override string Folder => "PrettyCards";

		[Test]
		public void Create()
		{
			Url = "https://api.vk.com/method/prettyCards.create";

			ReadCategoryJsonPath(nameof(Api.PrettyCards.Create));

			var result = Api.PrettyCards.Create(new PrettyCardsCreateParams
			{
				OwnerId = -126102803,
				Photo = "-126102803_457239118",
				Price = "123",
				PriceOld = "140",
				Title = "123",
				Link = "tel:+79111234567",
				Button = Button.Call
			});

			Assert.NotNull(result);
			Assert.AreEqual(result.CardId, "545435");
			Assert.AreEqual(result.OwnerId, -126102803);
		}
	}
}