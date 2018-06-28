using NUnit.Framework;
using VkNet.Model.RequestParams;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class PlacesCategoryTests: BaseTest
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
	}
}