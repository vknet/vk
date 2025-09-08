using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class RemoveTargetContactsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact(DisplayName = "Remove target contacts")]
	public void RemoveTargetContacts()
	{
		Url = "https://api.vk.ru/method/ads.removeTargetContacts";

		ReadCategoryJsonPath(nameof(Api.Ads.RemoveTargetContacts));

		var result = Api.Ads.RemoveTargetContacts(new()
		{
			AccountId = 1605245430,
			Contacts =
			[
				"79534998632",
				"79534998633"
			],
			TargetGroupId = 29859003
		});

		result.Result.Should()
			.BeTrue();
	}
}