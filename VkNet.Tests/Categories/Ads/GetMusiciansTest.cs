using System;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	public class GetMusiciansTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetMusicians()
		{
			Url = "https://api.vk.com/method/ads.getMusicians";

			ReadCategoryJsonPath(nameof(Api.Ads.GetMusicians));

			var result = Api.Ads.GetMusicians("Alan Walker");
			result[0].Name.Should().Be("Alan Walker");
			result[0].Id.Should().Be(32697);
		}
	}
}