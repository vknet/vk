using FluentAssertions;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class CreateClientsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void CreateClients()
		{
			Url = "https://api.vk.com/method/ads.createClients";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateClients));

			var clientSpecification1 = new ClientSpecification
			{
				DayLimit = 100,
				AllLimit = 100,
				Name = "123"
			};

			var clientSpecification2 = new ClientSpecification
			{
				DayLimit = 100,
				AllLimit = 100,
				Name = "123"
			};

			ClientSpecification[] data =
			{
				clientSpecification1,
				clientSpecification2
			};

			var officeUsers = Api.Ads.CreateClients(new AdsDataSpecificationParams<ClientSpecification>
			{
				Data = data,
				AccountId = 1605245430
			});

			officeUsers[0].Id.Should().Be(1);
			officeUsers[0].ErrorCode.Should().Be(100);
			officeUsers[1].Id.Should().Be(2);
		}
	}
}