using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class UpdateClientsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void UpdateClients()
		{
			Url = "https://api.vk.com/method/ads.updateClients";

			ReadCategoryJsonPath(nameof(Api.Ads.UpdateClients));

			ClientModSpecification clientModSpecification1 = new ClientModSpecification
			{
				ClientId = 1012219949,
				Name = "123",
				AllLimit = 100,
				DayLimit = 50
			};

			ClientModSpecification clientModSpecification2 = new ClientModSpecification
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

			var officeUsers = Api.Ads.UpdateClients(new AdsDataSpecificationParams<ClientModSpecification>
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