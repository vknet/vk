using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class SaveLookalikeRequestResultTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void SaveLookalikeRequestResult()
		{
			Url = "https://api.vk.com/method/ads.saveLookalikeRequestResult";

			ReadCategoryJsonPath(nameof(Api.Ads.SaveLookalikeRequestResult));


			var result = Api.Ads.SaveLookalikeRequestResult(new SaveLookalikeRequestResultParams
			{
				AccountId = 123,
				Level = 2,
				RequestId = 1488
			});

			Assert.That(result.AudienceCount, Is.EqualTo(38000));
		}
	}
}