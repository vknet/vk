using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class PlacesCategoryTests : BaseTest
	{
		[Test]
		public void Add()
		{
			Url = "https://api.vk.com/method/places.add";

			Json = @"{
				response: {
					id: 6162171
				}
			}";

			var result = Api.Places.Add(new PlacesAddParams());

			Assert.AreEqual(6162171, result);
		}

		[Test]
		public void Checkin()
		{
			Url = "https://api.vk.com/method/places.checkin";

			Json = @"{
				response: 6162171
			}";

			var result = Api.Places.Checkin(new PlacesCheckinParams());

			Assert.AreEqual(6162171, result);
		}

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/places.getById";

			Json = @"{
				response: [{
					id: 4980426,
					title: 'test',
					latitude: 25,
					longitude: 25,
					created: 1364117621,
					icon: 'http://vk.com/images/places/home.png',
					checkins: 18,
					updated: 1375926671,
					type: 1
				}]
			}";

			var result = Api.Places.GetById(new ulong[] { 123 });

			Assert.IsNotEmpty(result);
		}
	}
}