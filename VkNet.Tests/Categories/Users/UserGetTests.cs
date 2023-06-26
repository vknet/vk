using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Users;

public class UserGetTests : CategoryBaseTest
{
	protected override string Folder => "Users";

	[Fact]
	public void Get_Olesya_SingleUser()
	{
		Url = "https://api.vk.com/method/users.get";
		ReadCategoryJsonPath(nameof(Get_Olesya_SingleUser));

		var users = Api.Users.Get(new List<long>
		{
			118312730
		}, ProfileFields.Sex, NameCase.Nom);

		users.Should()
			.NotBeNull();

		var user = users.FirstOrDefault();

		user.Should()
			.NotBeNull();

		user.Sex.Should()
			.Be(Sex.Deactivated);
	}
}