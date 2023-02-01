using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class DeleteClientsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void DeleteClients()
	{
		Url = "https://api.vk.com/method/ads.deleteClients";

		ReadCategoryJsonPath(nameof(Api.Ads.DeleteClients));

		var a = new[]
		{
			"1",
			"2"
		};

		var result = Api.Ads.DeleteClients(new()
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