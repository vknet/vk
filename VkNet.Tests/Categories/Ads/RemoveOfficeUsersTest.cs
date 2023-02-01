using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class RemoveOfficeUsersTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void RemoveOfficeUsers()
	{
		Url = "https://api.vk.com/method/ads.removeOfficeUsers";

		ReadCategoryJsonPath(nameof(Api.Ads.RemoveOfficeUsers));

		var a = new[]
		{
			"1",
			"2"
		};

		var result = Api.Ads.RemoveOfficeUsers(new()
		{
			AccountId = 1605245430,
			Ids = a
		});

		result.Should()
			.HaveElementAt(0, true);

		result.Should()
			.HaveElementAt(1, true);
	}
}