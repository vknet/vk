using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Places
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class PlacesCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Places";

		[Test]
		public void Add()
		{
			Url = "https://api.vk.com/method/places.add";
			ReadCategoryJsonPath(nameof(Add));

			var result = Api.Places.Add(new PlacesAddParams());

			Assert.AreEqual(6162171, result);
		}

		[Test]
		public void Checkin()
		{
			Url = "https://api.vk.com/method/places.checkin";
			ReadCategoryJsonPath(nameof(Checkin));

			var result = Api.Places.Checkin(new PlacesCheckinParams());

			Assert.AreEqual(6162171, result);
		}

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/places.getById";
			ReadCategoryJsonPath(nameof(GetById));

			var result = Api.Places.GetById(new ulong[] { 123 });

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetCheckins()
		{
			Url = "https://api.vk.com/method/places.getCheckins";
			ReadCategoryJsonPath(nameof(GetCheckins));

			var result = Api.Places.GetCheckins(new PlacesGetCheckinsParams());

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetTypes()
		{
			Url = "https://api.vk.com/method/places.getTypes";
			ReadCategoryJsonPath(nameof(GetTypes));

			var result = Api.Places.GetTypes();

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void Search()
		{
			Url = "https://api.vk.com/method/places.search";
			ReadCategoryJsonPath(nameof(Search));

			var result = Api.Places.Search(new PlacesSearchParams());

			Assert.IsNotEmpty(result);
		}
	}
}