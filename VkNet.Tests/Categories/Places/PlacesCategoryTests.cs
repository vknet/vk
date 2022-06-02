using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Places
{


	public class PlacesCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Places";

		[Fact]
		public void Add()
		{
			Url = "https://api.vk.com/method/places.add";
			ReadCategoryJsonPath(nameof(Add));

			var result = Api.Places.Add(new PlacesAddParams());

			result.Should().Be(6162171);
		}

		[Fact]
		public void Checkin()
		{
			Url = "https://api.vk.com/method/places.checkin";
			ReadCategoryJsonPath(nameof(Checkin));

			var result = Api.Places.Checkin(new PlacesCheckinParams());

			result.Should().Be(6162171);
		}

		[Fact]
		public void GetById()
		{
			Url = "https://api.vk.com/method/places.getById";
			ReadCategoryJsonPath(nameof(GetById));

			var result = Api.Places.GetById(new ulong[] { 123 });

			result.Should().NotBeEmpty();
		}

		[Fact]
		public void GetCheckins()
		{
			Url = "https://api.vk.com/method/places.getCheckins";
			ReadCategoryJsonPath(nameof(GetCheckins));

			var result = Api.Places.GetCheckins(new PlacesGetCheckinsParams());

			result.Should().NotBeEmpty();
		}

		[Fact]
		public void GetTypes()
		{
			Url = "https://api.vk.com/method/places.getTypes";
			ReadCategoryJsonPath(nameof(GetTypes));

			var result = Api.Places.GetTypes();

			result.Should().NotBeEmpty();
		}

		[Fact]
		public void Search()
		{
			Url = "https://api.vk.com/method/places.search";
			ReadCategoryJsonPath(nameof(Search));

			var result = Api.Places.Search(new PlacesSearchParams());

			result.Should().NotBeEmpty();
		}
	}
}