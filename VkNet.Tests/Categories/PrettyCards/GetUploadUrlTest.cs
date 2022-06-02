using System;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards
{
	[TestFixture]
	public class GetUploadUrlTest : CategoryBaseTest
	{
		protected override string Folder => "PrettyCards";

		[Test]
		public void GetUploadUrl()
		{
			Url = "https://api.vk.com/method/prettyCards.getUploadURL";

			ReadCategoryJsonPath(nameof(Api.PrettyCards.GetUploadUrl));

			var url = Api.PrettyCards.GetUploadUrl();

			url.Should()
				.Be(new Uri(
					"https://pu.vk.com/c850608/upload.php?act=ads_add&mid=504736359&size=s&hash_time=1583351712&hash=318c03e7ca5d39a25926b70c37f1dadf&rhash=7914a36ca66600b440aca5991cba69e2&api=1"));
		}
	}
}