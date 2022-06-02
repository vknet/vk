using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model.RequestParams.Database;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Database
{
	[TestFixture]
	public class DatabaseCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Database";

		[Test]
		public void GetCities_CountryIdIsNegative_ThrowException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetCities(new GetCitiesParams
				{
					CountryId = -1
				}))
				.Should()
				.ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetCities_GetBiggestCitiesOfRussia()
		{
			Url = "https://api.vk.com/method/database.getCities";
			ReadCategoryJsonPath(nameof(GetCities_GetBiggestCitiesOfRussia));

			var cities = Api.Database.GetCities(new GetCitiesParams
			{
				CountryId = 1,
				Count = 3
			});

			cities.Should().HaveCount(3);

			cities[0].Id.Should().Be(1);
			cities[0].Title.Should().Be("Москва");
			cities[0].Important.Should().BeTrue();
			cities[0].Area.Should().BeNull();
			cities[0].Region.Should().BeNull();

			cities[1].Id.Should().Be(2);
			cities[1].Title.Should().Be("Санкт-Петербург");
			cities[1].Important.Should().BeTrue();
			cities[1].Area.Should().BeNull();
			cities[1].Region.Should().BeNull();

			cities[2].Id.Should().Be(10);
			cities[2].Title.Should().Be("Волгоград");
			cities[2].Important.Should().BeFalse();
			cities[2].Area.Should().BeNull();
			cities[2].Region.Should().BeNull();
		}

		[Test]
		public void GetCities_NormalCase()
		{
			Url = "https://api.vk.com/method/database.getCities";
			ReadCategoryJsonPath(nameof(GetCities_NormalCase));

			var cities = Api.Database.GetCities(new GetCitiesParams
			{
				CountryId = 1,
				RegionId = 1004118,
				Count = 2,
				Offset = 1
			});

			cities.Should().HaveCount(2);

			cities[0].Id.Should().Be(1004357);
			cities[0].Title.Should().Be("Азау");
			cities[0].Area.Should().Be("Красноярский район");
			cities[0].Region.Should().Be("Астраханская область");

			cities[1].Id.Should().Be(1004307);
			cities[1].Title.Should().Be("Азовский");
			cities[1].Area.Should().Be("Камызякский район");
			cities[1].Region.Should().Be("Астраханская область");
		}

		[Test]
		public void GetCities_RegionIdIsNegative_ThrowException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetCities(new GetCitiesParams
				{
					CountryId = 1,
					RegionId = -2
				}))
				.Should()
				.ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetCitiesById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getCitiesById";
			ReadJsonFile(JsonPaths.EmptyArray);

			var cities = Api.Database.GetCitiesById();

			cities.Should().BeEmpty();
		}

		[Test]
		public void GetCitiesById_MskSpbVlg()
		{
			Url = "https://api.vk.com/method/database.getCitiesById";
			ReadCategoryJsonPath(nameof(GetCitiesById_MskSpbVlg));

			var cities = Api.Database.GetCitiesById(1, 2, 10);

			cities.Should().HaveCount(3);

			cities[0].Id.Should().Be(1);
			cities[0].Title.Should().Be("Москва");

			cities[1].Id.Should().Be(2);
			cities[1].Title.Should().Be("Санкт-Петербург");

			cities[2].Id.Should().Be(10);
			cities[2].Title.Should().Be("Волгоград");
		}

		[Test]
		public void GetCountries_CountIsNegative_ThrowArgumentException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetCountries(count: -2)).Should().ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetCountries_ListOfCodes_ListOfCountries()
		{
			Url = "https://api.vk.com/method/database.getCountries";
			ReadCategoryJsonPath(nameof(GetCountries_ListOfCodes_ListOfCountries));

			var countries = Api.Database.GetCountries(codes: new List<Iso3166>
			{
				Iso3166.RU,
				Iso3166.DE
			});

			countries.Should().HaveCount(2);

			countries[0].Id.Should().Be(1);
			countries[0].Title.Should().Be("Россия");

			countries[1].Id.Should().Be(65);
			countries[1].Title.Should().Be("Германия");
		}

		[Test]
		public void GetCountries_NormalCase_ListOfCountries()
		{
			Url = "https://api.vk.com/method/database.getCountries";
			ReadCategoryJsonPath(nameof(GetCountries_NormalCase_ListOfCountries));

			var countries = Api.Database.GetCountries(true, null, 3, 5);

			countries.Should().HaveCount(3);

			countries[0].Id.Should().Be(23);
			countries[0].Title.Should().Be("Американское Самоа");

			countries[1].Id.Should().Be(24);
			countries[1].Title.Should().Be("Ангилья");

			countries[2].Id.Should().Be(25);
			countries[2].Title.Should().Be("Ангола");
		}

		[Test]
		public void GetCountries_OffsetIsNegative_ThrowArgumentException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetCountries(offset: -2)).Should().ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetCountriesById_1And65_RussiaAndGermany()
		{
			Url = "https://api.vk.com/method/database.getCountriesById";
			ReadCategoryJsonPath(nameof(GetCountriesById_1And65_RussiaAndGermany));

			var countries = Api.Database.GetCountriesById(1, 65);

			countries.Should().HaveCount(2);

			countries[0].Id.Should().Be(1);
			countries[0].Title.Should().Be("Россия");

			countries[1].Id.Should().Be(65);
			countries[1].Title.Should().Be("Германия");
		}

		[Test]
		public void GetCountriesById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getCountriesById";
			ReadJsonFile(JsonPaths.EmptyArray);

			var countries = Api.Database.GetCountriesById();

			countries.Should().NotBeNull();
			countries.Should().BeEmpty();
		}

		[Test]
		public void GetFaculties_ListVstuFaculties()
		{
			Url = "https://api.vk.com/method/database.getFaculties";
			ReadCategoryJsonPath(nameof(GetFaculties_ListVstuFaculties));

			var faculties = Api.Database.GetFaculties(431, 3, 2);

			faculties.Should().HaveCount(3);

			faculties[0].Id.Should().Be(3160);

			faculties[0].Title.Should().Be("Автоматизированных систем и технологической информатики (бывш. Машиностроительный)");

			faculties[1].Id.Should().Be(3161);
			faculties[1].Title.Should().Be("Технологии конструкционных материалов");

			faculties[2].Id.Should().Be(3162);
			faculties[2].Title.Should().Be("Электроники и вычислительной техники");
		}

		[Test]
		public void GetRegions_CountIsNegative_ThrowArgumentException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetRegions(1, count: -2)).Should().ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetRegions_CountryIdIsNegative_ThrowArgumentException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetRegions(-1)).Should().ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetRegions_NormalCase_ListOfRegions()
		{
			Url = "https://api.vk.com/method/database.getRegions";
			ReadCategoryJsonPath(nameof(GetRegions_NormalCase_ListOfRegions));

			var regions = Api.Database.GetRegions(1, count: 3, offset: 5);

			regions.Should().HaveCount(3);

			regions[0].Id.Should().Be(1004118);
			regions[0].Title.Should().Be("Астраханская область");

			regions[1].Id.Should().Be(1004565);
			regions[1].Title.Should().Be("Башкортостан");

			regions[2].Id.Should().Be(1009404);
			regions[2].Title.Should().Be("Белгородская область");
		}

		[Test]
		public void GetRegions_OffsetIsNegative_ThrowArgumentException()
		{
			FluentActions.Invoking(() => new DatabaseCategory(Api).GetRegions(1, offset: -2)).Should().ThrowExactly<ArgumentException>();
		}

		[Test]
		public void GetSchools_BadQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getSchools";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var schools = Api.Database.GetSchools(10, "SchoolDoesNotExist");

			schools.Should().BeEmpty();
		}

		[Test]
		public void GetSchools_LiceumsInVolgograd_ListOfLiceums()
		{
			Url = "https://api.vk.com/method/database.getSchools";
			ReadCategoryJsonPath(nameof(GetSchools_LiceumsInVolgograd_ListOfLiceums));

			var schools = Api.Database.GetSchools(10, count: 3);

			schools.Should().HaveCount(3);

			schools[0].Id.Should().Be(51946);
			schools[0].Name.Should().Be("Астраханское речное училище (ВФ АРУ)");

			schools[1].Id.Should().Be(207063);
			schools[1].Name.Should().Be("Библейская школа «Весть»");

			schools[2].Id.Should().Be(224706);
			schools[2].Name.Should().Be("Библейский колледж «Новая жизнь»");
		}

		[Test]
		public void GetStreetsById_1_89_437()
		{
			Url = "https://api.vk.com/method/database.getStreetsById";
			ReadCategoryJsonPath(nameof(GetStreetsById_1_89_437));

			var streets = Api.Database.GetStreetsById(1, 89, 437);

			streets.Should().HaveCount(3);

			streets[0].Id.Should().Be(1);
			streets[0].Title.Should().Be("8 Марта ул.");

			streets[1].Id.Should().Be(89);
			streets[1].Title.Should().Be("Черкесская ул.");

			streets[2].Id.Should().Be(437);
			streets[2].Title.Should().Be("Синяя ул.");
		}

		[Test]
		public void GetStreetsById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getStreetsById";
			ReadErrorsJsonFile(100);

			FluentActions.Invoking(() =>
				{
					var readOnlyCollection = Api.Database.GetStreetsById();
					readOnlyCollection.Should().NotBeEmpty();
				})
				.Should()
				.ThrowExactly<ParameterMissingOrInvalidException>()
				.And.Message.Should()
				.Be("One of the parameters specified was missing or invalid: value should be positive");
		}

		[Test]
		public void GetUniversities_FindVstu()
		{
			Url = "https://api.vk.com/method/database.getUniversities";
			ReadCategoryJsonPath(nameof(GetUniversities_FindVstu));

			var universities = Api.Database.GetUniversities(1, 10, "ВолгГТУ");

			universities.Should().ContainSingle();
			universities[0].Id.Should().Be(431);
			universities[0].Name.Should().Be("ВолгГТУ");
		}

		[Test]
		public void GetUniversities_ListOfUniversities()
		{
			Url = "https://api.vk.com/method/database.getUniversities";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var universities = Api.Database.GetUniversities(1, 1, "ThisUniverDoesNotExist");

			universities.Should().BeEmpty();
		}

		[Test]
		public void GetMetroStations()
		{
			Url = "https://api.vk.com/method/database.getMetroStations";
			ReadCategoryJsonPath(nameof(GetMetroStations));

			var universities = Api.Database.GetMetroStations(2, 10, 10, true);

			universities.TotalCount.Should().Be(69);
		}

		[Test]
		public void GetMetroStationsById()
		{
			Url = "https://api.vk.com/method/database.getMetroStationsById";
			ReadCategoryJsonPath(nameof(GetMetroStationsById));

			var universities = Api.Database.GetMetroStationsById(new ulong[]
			{
				189,
				181
			});

			universities.Should().HaveCount(2);
		}
	}
}