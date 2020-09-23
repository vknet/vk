using NUnit.Framework;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class CreateClientsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CreateClients()
		{
			Url = "https://api.vk.com/method/ads.createClients";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateClients));

			ClientSpecification clientSpecification1 = new ClientSpecification
			{
				DayLimit = 100,
				AllLimit = 100,
				Name = "123"
			};

			ClientSpecification clientSpecification2 = new ClientSpecification
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

			Assert.That(officeUsers[0].Id, Is.EqualTo(1));
			Assert.That(officeUsers[0].ErrorCode, Is.EqualTo(100));
			Assert.That(officeUsers[1].Id, Is.EqualTo(2));
		}
	}
}