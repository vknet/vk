using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateOfficeUsersTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateOfficeUsers()
	{
		Url = "https://api.vk.com/method/ads.updateOfficeUsers";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateOfficeUsers));

		var officeUsersSpecification1 = new OfficeUsersSpecification
		{
			UserId = 12423,
			Role = AccessRole.Reports,
			ClientsIds = new[]
			{
				1245,
				566,
				323
			},
			GrantAccessToAllClients = true,
			ViewBudget = true
		};

		var officeUsersSpecification2 = new OfficeUsersSpecification
		{
			UserId = 4324432,
			Role = AccessRole.Manager,
			ClientsIds = new[]
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

		var result = Api.Ads.UpdateOfficeUsers(new()
		{
			AccountId = 1605245430,
			Data = data
		});

		result[0]
			.UserId.Should()
			.Be(1567);

		result[0]
			.IsSuccess.Should()
			.BeFalse();

		result[0]
			.Error.ErrorCode.Should()
			.Be(100);
	}
}