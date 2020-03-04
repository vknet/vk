using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AddOfficeUsersTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void AddOfficeUsers()
		{
			Url = "https://api.vk.com/method/ads.addOfficeUsers";

			ReadCategoryJsonPath(nameof(Api.Ads.AddOfficeUsers));

			UserSpecification userSpecification1 = new UserSpecification
			{
				UserId = 1488,
				ClientId = 5,
				Role = AccessRole.Reports
			};

			UserSpecification userSpecification2 = new UserSpecification
			{
				UserId = 1488,
				ClientId = 5,
				Role = AccessRole.Reports
			};

			UserSpecification[] data = new[]
			{
				userSpecification1,
				userSpecification2
			};

			var officeUsers = Api.Ads.AddOfficeUsers(new AddOfficeUsersParams
			{
				Data = data,
				AccountId = 1605245430
			});

			Assert.That(officeUsers[0], Is.EqualTo(true));
			Assert.That(officeUsers[1], Is.EqualTo(true));
		}
	}
}