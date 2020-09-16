using System;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class AdsCheckLinkTests : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CheckLink()
		{
			Url = "https://api.vk.com/method/ads.checkLink";

			ReadCategoryJsonPath(nameof(Api.Ads.CheckLink));

			var link = Api.Ads.CheckLink(new CheckLinkParams
			{
				AccountId = 123,
				LinkType = AdsLinkType.Application,
				LinkUrl = new Uri(Url)
			});

			Assert.NotNull(link);

			Assert.IsNotEmpty(link.Description);
			Assert.That(link.Status, Is.EqualTo(LinkStatusType.Disallowed));
		}
	}
}