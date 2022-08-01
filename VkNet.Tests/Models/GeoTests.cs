using FluentAssertions;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Models;

public class GeoTests : BaseTest
{
	[Fact]
	public void GeoFromJson()
	{
		ReadJsonFile("Models", nameof(Geo));

		var response = GetResponse();

		var geo = Geo.FromJson(response);

		geo.Should()
			.NotBeNull();
	}

	[Fact]
	public void GeoJsonConvert()
	{
		ReadJsonFile("Models", nameof(Geo));

		ReadJsonFile("Models", nameof(Geo));

		Url = "https://api.vk.com/method/friends.getRequests";
		var result = Api.Call<Geo>("friends.getRequests", VkParameters.Empty);

		result.Should()
			.NotBeNull();
	}
}