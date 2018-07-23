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

		[Test]
		public void GetCheckins()
		{
			Url = "https://api.vk.com/method/places.getCheckins";

			Json = @"{
				response: {
					count: 68,
					items: [{
					id: '973782_2187',
						user_id: 973782,
						post_id: 2187,
						date: 1530002871,
						latitude: 0,
						longitude: 0,
						text: 'text',
						place_id: 0,
						place_title: '',
						place_country: 0,
						place_city: 0,
						place_address: '',
						place_type: 0,
						place_icon: 'http://vk.com/images/places/place.png',
						distance: 7062029
					}]
				}
			}";


			var result = Api.Places.GetCheckins(new PlacesGetCheckinsParams());

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetTypes()
		{
			Url = "https://api.vk.com/method/places.getTypes";

			Json = @"{
				response: [{
					id: 1,
					title: 'Home',
					icon: 'http://vk.com/images/places/home.png'
				}]
			}";


			var result = Api.Places.GetTypes();

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void Search()
		{
			Url = "https://api.vk.com/method/places.search";

			Json = @"{
				response: {
					count: 1999,
					items: [{
						id: 213784,
						title: 'Дом Зингера',
						latitude: 59.935624,
						longitude: 30.325875,
						created: 1295369575,
						icon: 'http://vk.com/images/places/work.png',
						checkins: 355,
						updated: 1439407347,
						type: 2,
						country: 1,
						city: 2,
						address: 'Невский проспект 28',
						distance: 3
					}]
				}
			}";


			var result = Api.Places.Search(new PlacesSearchParams());

			Assert.IsNotEmpty(result);
		}
	}
}