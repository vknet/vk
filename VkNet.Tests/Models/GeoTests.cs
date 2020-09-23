using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class GeoTests : BaseTest
	{
		[Test]
		public void GeoFromJson()
		{
			ReadJsonFile("Models", nameof(Geo));

			var response = GetResponse();

			var geo = Geo.FromJson(response);

			Assert.NotNull(geo);
		}

		[Test]
		public void GeoJsonConvert()
		{
			ReadJsonFile("Models", nameof(Geo));

			ReadJsonFile("Models", nameof(Geo));

			Url = "https://api.vk.com/method/friends.getRequests";
			var result = Api.Call<Geo>("friends.getRequests", VkParameters.Empty);

			Assert.NotNull(result);
		}
	}
}