using System;
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
			Assert.That(result[0].Name, Is.EqualTo("Alan Walker"));
			Assert.That(result[0].Id, Is.EqualTo(32697));
		}
	}
}