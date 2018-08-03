using NUnit.Framework;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	public class AdsCheckLinkTests : BaseTest
	{
		[Test]
		public void CheckLink()
		{
			Url = "https://api.vk.com/method/ads.checkLink";

			Json =
				@"{
				'response': {
					'status': 'disallowed',
					'description': 'Невозможно использовать запись для продвижения. Запись должна быть опубликована от имени сообщества.'
				}
			}";

			var link = Api.Ads.CheckLink(123, AdsLinkType.Application, Url);

			Assert.NotNull(link);

			Assert.IsNotEmpty(link.Description);
			Assert.That(link.Status, Is.EqualTo(LinkStatusType.Disallowed));
		}
	}
}