using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class AddOfficeUsersTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void AddOfficeUsers()
	{
		Url = "https://api.vk.com/method/ads.addOfficeUsers";

		ReadCategoryJsonPath(nameof(Api.Ads.AddOfficeUsers));

		var userSpecification1 = new UserSpecification
		{
			UserId = 1488,
			ClientId = 5,
			Role = AccessRole.Reports
		};

		var userSpecification2 = new UserSpecification
		{
			UserId = 1488,
			ClientId = 5,
			Role = AccessRole.Reports
		};

		UserSpecification[] data =
		{
			userSpecification1,
			userSpecification2
		};

		var officeUsers = Api.Ads.AddOfficeUsers(new()
		{
			Data = data,
			AccountId = 1605245430
		});

		officeUsers.Should()
			.HaveElementAt(0, true);

		officeUsers.Should()
			.HaveElementAt(1, true);
	}
}