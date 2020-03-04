using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetUploadUrlTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetUploadUrl()
		{
			Url = "https://api.vk.com/method/ads.getUploadUrl";

			ReadCategoryJsonPath(nameof(Api.Ads.GetUploadUrl));

			var url = Api.Ads.GetUploadUrl(new GetUploadUrlParams
			{
				AdFormat = AdFormat.Public,
				Icon = AdIcon.AdIconYes
			});

			Assert.That(url.ToString(), Is.EqualTo("https://pu.vk.com/c850608/upload.php?act=ads_add&mid=504736359&size=s&hash_time=1583351712&hash=318c03e7ca5d39a25926b70c37f1dadf&rhash=7914a36ca66600b440aca5991cba69e2&api=1"));
		}
	}
}