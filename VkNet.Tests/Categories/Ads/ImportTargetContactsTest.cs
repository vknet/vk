using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class ImportTargetContactsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void ImportTargetContacts()
	{
		Url = "https://api.vk.com/method/ads.importTargetContacts";

		ReadCategoryJsonPath(nameof(Api.Ads.ImportTargetContacts));

		var result = Api.Ads.ImportTargetContacts(new()
		{
			AccountId = 1605245430,
			Contacts = new()
			{
				"79534998632",
				"79534998633"
			},
			TargetGroupId = 29859003
		});

		result.Should()
			.Be(2);
	}
}