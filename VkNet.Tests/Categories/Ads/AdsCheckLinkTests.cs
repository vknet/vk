using System;
using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class AdsCheckLinkTests : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
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

			link.Should().NotBeNull();

			link.Description.Should().NotBeEmpty();
			link.Status.Should().Be(LinkStatusType.Disallowed);
		}
	}
}