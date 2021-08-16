using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	public class UpdateOfficeUsersTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void UpdateOfficeUsers()
		{
			Url = "https://api.vk.com/method/ads.updateOfficeUsers";

			ReadCategoryJsonPath(nameof(Api.Ads.UpdateOfficeUsers));

			OfficeUsersSpecification officeUsersSpecification1 = new OfficeUsersSpecification
			{
				UserId = 12423,
				Role = AccessRole.Reports,
				ClientsIds = new int[]
				{
					1245,
					566,
					323
				},
				GrantAccessToAllClients = true,
				ViewBudget = true
			};

			OfficeUsersSpecification officeUsersSpecification2 = new OfficeUsersSpecification
			{
				UserId = 4324432,
				Role = AccessRole.Manager,
				ClientsIds = new int[]
				{
					567357,
					566566,
					3645623
				},
				GrantAccessToAllClients = false,
				ViewBudget = false
			};

			OfficeUsersSpecification[] data =
			{
				officeUsersSpecification1,
				officeUsersSpecification2
			};

			var result = Api.Ads.UpdateOfficeUsers(new AdsDataSpecificationParams<OfficeUsersSpecification>
			{
				AccountId = 1605245430,
				Data = data
			});

			Assert.That(result[0].UserId, Is.EqualTo(1567));
			Assert.That(result[0].IsSuccess, Is.False);
			Assert.That(result[0].Error.ErrorCode, Is.EqualTo(100));
		}
	}
}