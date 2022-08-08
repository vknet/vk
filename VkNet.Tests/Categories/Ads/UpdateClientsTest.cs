using FluentAssertions;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateClientsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateClients()
	{
		Url = "https://api.vk.com/method/ads.updateClients";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateClients));

		var clientModSpecification1 = new ClientModSpecification
		{
			ClientId = 1012219949,
			Name = "123",
			AllLimit = 100,
			DayLimit = 50
		};

		var clientModSpecification2 = new ClientModSpecification
		{
			ClientId = 1012219949,
			Name = "123",
			AllLimit = 100,
			DayLimit = 50
		};

		ClientModSpecification[] data =
		{
			clientModSpecification1,
			clientModSpecification2
		};

		var officeUsers = Api.Ads.UpdateClients(new()
		{
			Data = data,
			AccountId = 1605245430
		});

		officeUsers[0]
			.Id.Should()
			.Be(1);

		officeUsers[0]
			.ErrorCode.Should()
			.Be(100);

		officeUsers[1]
			.Id.Should()
			.Be(2);
	}
}