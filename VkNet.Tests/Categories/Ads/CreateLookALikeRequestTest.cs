using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class CreateLookALikeRequestTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CreateLookalikeRequest()
		{
			Url = "https://api.vk.com/method/ads.createLookalikeRequest";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateLookalikeRequest));


			var officeUsers = Api.Ads.CreateLookalikeRequest(new CreateLookALikeRequestParams
			{
				AccountId = 1605245430,
				SourceType = SourceType.RetargetingGroup,
				RetargetingGroupId = 1
			});

			Assert.That(officeUsers.RequestId, Is.EqualTo(3667));
		}
	}
}