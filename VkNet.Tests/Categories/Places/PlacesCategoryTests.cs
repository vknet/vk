using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Places;

public class PlacesCategoryTests : CategoryBaseTest
{
	protected override string Folder => "Places";

	[Test]
	[DisplayName("Add")]
	public void Add()
	{
		Url = "https://api.vk.ru/method/places.add";
		ReadCategoryJsonPath(nameof(Add));

		var result = Api.Places.Add(new());

		result.Should()
			.Be(6162171);
	}

	[Test]
	[DisplayName("Checkin")]
	public void Checkin()
	{
		Url = "https://api.vk.ru/method/places.checkin";
		ReadCategoryJsonPath(nameof(Checkin));

		var result = Api.Places.Checkin(new());

		result.Should()
			.Be(6162171);
	}

	[Test]
	[DisplayName("Get by id")]
	public void GetById()
	{
		Url = "https://api.vk.ru/method/places.getById";
		ReadCategoryJsonPath(nameof(GetById));

		var result = Api.Places.GetById([123]);

		result.Should()
			.NotBeEmpty();
	}

	[Test]
	[DisplayName("Get checkins")]
	public void GetCheckins()
	{
		Url = "https://api.vk.ru/method/places.getCheckins";
		ReadCategoryJsonPath(nameof(GetCheckins));

		var result = Api.Places.GetCheckins(new());

		result.Should()
			.NotBeEmpty();
	}

	[Test]
	[DisplayName("Get types")]
	public void GetTypes()
	{
		Url = "https://api.vk.ru/method/places.getTypes";
		ReadCategoryJsonPath(nameof(GetTypes));

		var result = Api.Places.GetTypes();

		result.Should()
			.NotBeEmpty();
	}

	[Test]
	[DisplayName("Search")]
	public void Search()
	{
		Url = "https://api.vk.ru/method/places.search";
		ReadCategoryJsonPath(nameof(Search));

		var result = Api.Places.Search(new());

		result.Should()
			.NotBeEmpty();
	}
}