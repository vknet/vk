using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model.RequestParams.Database;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class DatabaseCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Database";

		[Test]
		public void GetCities_CountryIdIsNegative_ThrowException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetCities(new GetCitiesParams
				{
					CountryId = -1
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCities_GetBiggestCitiesOfRussia()
		{
			Url = "https://api.vk.com/method/database.getCities";
			ReadCategoryJsonPath(nameof(GetCities_GetBiggestCitiesOfRussia));

			var cities = Api.Database.GetCities(new GetCitiesParams
			{
				CountryId = 1, Count = 3
			});

			Assert.That(cities.Count, Is.EqualTo(3));

			Assert.That(cities[0].Id, Is.EqualTo(1));
			Assert.That(cities[0].Title, Is.EqualTo("Москва"));
			Assert.That(cities[0].Important, Is.True);
			Assert.That(cities[0].Area, Is.Null);
			Assert.That(cities[0].Region, Is.Null);

			Assert.That(cities[1].Id, Is.EqualTo(2));
			Assert.That(cities[1].Title, Is.EqualTo("Санкт-Петербург"));
			Assert.That(cities[1].Important, Is.True);
			Assert.That(cities[1].Area, Is.Null);
			Assert.That(cities[1].Region, Is.Null);

			Assert.That(cities[2].Id, Is.EqualTo(10));
			Assert.That(cities[2].Title, Is.EqualTo("Волгоград"));
			Assert.That(cities[2].Important, Is.False);
			Assert.That(cities[2].Area, Is.Null);
			Assert.That(cities[2].Region, Is.Null);
		}

		[Test]
		public void GetCities_NormalCase()
		{
			Url = "https://api.vk.com/method/database.getCities";
			ReadCategoryJsonPath(nameof(GetCities_NormalCase));

			var cities = Api.Database.GetCities(new GetCitiesParams
			{
				CountryId = 1, RegionId = 1004118, Count = 2, Offset = 1
			});

			Assert.That(cities.Count, Is.EqualTo(2));

			Assert.That(cities[0].Id, Is.EqualTo(1004357));
			Assert.That(cities[0].Title, Is.EqualTo("Азау"));
			Assert.That(cities[0].Area, Is.EqualTo("Красноярский район"));
			Assert.That(cities[0].Region, Is.EqualTo("Астраханская область"));

			Assert.That(cities[1].Id, Is.EqualTo(1004307));
			Assert.That(cities[1].Title, Is.EqualTo("Азовский"));
			Assert.That(cities[1].Area, Is.EqualTo("Камызякский район"));
			Assert.That(cities[1].Region, Is.EqualTo("Астраханская область"));
		}

		[Test]
		public void GetCities_RegionIdIsNegative_ThrowException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetCities(new GetCitiesParams
				{
					CountryId = 1, RegionId = -2
				}),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCitiesById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getCitiesById";
			ReadJsonFile(JsonPaths.EmptyArray);

			var cities = Api.Database.GetCitiesById();

			Assert.That(cities.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetCitiesById_MskSpbVlg()
		{
			Url = "https://api.vk.com/method/database.getCitiesById";
			ReadCategoryJsonPath(nameof(GetCitiesById_MskSpbVlg));

			var cities = Api.Database.GetCitiesById(1, 2, 10);

			Assert.That(cities.Count, Is.EqualTo(3));

			Assert.That(cities[0].Id, Is.EqualTo(1));
			Assert.That(cities[0].Title, Is.EqualTo("Москва"));

			Assert.That(cities[1].Id, Is.EqualTo(2));
			Assert.That(cities[1].Title, Is.EqualTo("Санкт-Петербург"));

			Assert.That(cities[2].Id, Is.EqualTo(10));
			Assert.That(cities[2].Title, Is.EqualTo("Волгоград"));
		}

		[Test]
		public void GetCountries_CountIsNegative_ThrowArgumentException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetCountries(count: -2), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCountries_ListOfCodes_ListOfCountries()
		{
			Url = "https://api.vk.com/method/database.getCountries";
			ReadCategoryJsonPath(nameof(GetCountries_ListOfCodes_ListOfCountries));

			var countries = Api.Database.GetCountries(codes: new List<Iso3166>
			{
				Iso3166.RU, Iso3166.DE
			});

			Assert.That(countries.Count, Is.EqualTo(2));

			Assert.That(countries[0].Id, Is.EqualTo(1));
			Assert.That(countries[0].Title, Is.EqualTo("Россия"));

			Assert.That(countries[1].Id, Is.EqualTo(65));
			Assert.That(countries[1].Title, Is.EqualTo("Германия"));
		}

		[Test]
		public void GetCountries_NormalCase_ListOfCountries()
		{
			Url = "https://api.vk.com/method/database.getCountries";
			ReadCategoryJsonPath(nameof(GetCountries_NormalCase_ListOfCountries));

			var countries = Api.Database.GetCountries(true, null, 3, 5);

			Assert.That(countries.Count, Is.EqualTo(3));

			Assert.That(countries[0].Id, Is.EqualTo(23));
			Assert.That(countries[0].Title, Is.EqualTo("Американское Самоа"));

			Assert.That(countries[1].Id, Is.EqualTo(24));
			Assert.That(countries[1].Title, Is.EqualTo("Ангилья"));

			Assert.That(countries[2].Id, Is.EqualTo(25));
			Assert.That(countries[2].Title, Is.EqualTo("Ангола"));
		}

		[Test]
		public void GetCountries_OffsetIsNegative_ThrowArgumentException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetCountries(offset: -2), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCountriesById_1And65_RussiaAndGermany()
		{
			Url = "https://api.vk.com/method/database.getCountriesById";
			ReadCategoryJsonPath(nameof(GetCountriesById_1And65_RussiaAndGermany));

			var countries = Api.Database.GetCountriesById(1, 65);

			Assert.That(countries.Count, Is.EqualTo(2));

			Assert.That(countries[0].Id, Is.EqualTo(1));
			Assert.That(countries[0].Title, Is.EqualTo("Россия"));

			Assert.That(countries[1].Id, Is.EqualTo(65));
			Assert.That(countries[1].Title, Is.EqualTo("Германия"));
		}

		[Test]
		public void GetCountriesById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getCountriesById";
			ReadJsonFile(JsonPaths.EmptyArray);

			var countries = Api.Database.GetCountriesById();

			Assert.That(countries, Is.Not.Null);
			Assert.That(countries.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetFaculties_ListVstuFaculties()
		{
			Url = "https://api.vk.com/method/database.getFaculties";
			ReadCategoryJsonPath(nameof(GetFaculties_ListVstuFaculties));

			var faculties = Api.Database.GetFaculties(431, 3, 2);

			Assert.That(faculties.Count, Is.EqualTo(3));

			Assert.That(faculties[0].Id, Is.EqualTo(3160));

			Assert.That(faculties[0].Title,
				Is.EqualTo("Автоматизированных систем и технологической информатики (бывш. Машиностроительный)"));

			Assert.That(faculties[1].Id, Is.EqualTo(3161));
			Assert.That(faculties[1].Title, Is.EqualTo("Технологии конструкционных материалов"));

			Assert.That(faculties[2].Id, Is.EqualTo(3162));
			Assert.That(faculties[2].Title, Is.EqualTo("Электроники и вычислительной техники"));
		}

		[Test]
		public void GetRegions_CountIsNegative_ThrowArgumentException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetRegions(1, count: -2), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetRegions_CountryIdIsNegative_ThrowArgumentException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetRegions(-1), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetRegions_NormalCase_ListOfRegions()
		{
			Url = "https://api.vk.com/method/database.getRegions";
			ReadCategoryJsonPath(nameof(GetRegions_NormalCase_ListOfRegions));

			var regions = Api.Database.GetRegions(1, count: 3, offset: 5);

			Assert.That(regions.Count, Is.EqualTo(3));

			Assert.That(regions[0].Id, Is.EqualTo(1004118));
			Assert.That(regions[0].Title, Is.EqualTo("Астраханская область"));

			Assert.That(regions[1].Id, Is.EqualTo(1004565));
			Assert.That(regions[1].Title, Is.EqualTo("Башкортостан"));

			Assert.That(regions[2].Id, Is.EqualTo(1009404));
			Assert.That(regions[2].Title, Is.EqualTo("Белгородская область"));
		}

		[Test]
		public void GetRegions_OffsetIsNegative_ThrowArgumentException()
		{
			Assert.That(() => new DatabaseCategory(Api).GetRegions(1, offset: -2), Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetSchools_BadQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getSchools";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var schools = Api.Database.GetSchools(10, "SchoolDoesNotExist");

			Assert.That(schools.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetSchools_LiceumsInVolgograd_ListOfLiceums()
		{
			Url = "https://api.vk.com/method/database.getSchools";
			ReadCategoryJsonPath(nameof(GetSchools_LiceumsInVolgograd_ListOfLiceums));

			var schools = Api.Database.GetSchools(10, count: 3);

			Assert.That(schools.Count, Is.EqualTo(3));

			Assert.That(schools[0].Id, Is.EqualTo(51946));
			Assert.That(schools[0].Name, Is.EqualTo("Астраханское речное училище (ВФ АРУ)"));

			Assert.That(schools[1].Id, Is.EqualTo(207063));
			Assert.That(schools[1].Name, Is.EqualTo("Библейская школа «Весть»"));

			Assert.That(schools[2].Id, Is.EqualTo(224706));
			Assert.That(schools[2].Name, Is.EqualTo("Библейский колледж «Новая жизнь»"));
		}

		[Test]
		public void GetStreetsById_1_89_437()
		{
			Url = "https://api.vk.com/method/database.getStreetsById";
			ReadCategoryJsonPath(nameof(GetStreetsById_1_89_437));

			var streets = Api.Database.GetStreetsById(1, 89, 437);

			Assert.That(streets.Count, Is.EqualTo(3));

			Assert.That(streets[0].Id, Is.EqualTo(1));
			Assert.That(streets[0].Title, Is.EqualTo("8 Марта ул."));

			Assert.That(streets[1].Id, Is.EqualTo(89));
			Assert.That(streets[1].Title, Is.EqualTo("Черкесская ул."));

			Assert.That(streets[2].Id, Is.EqualTo(437));
			Assert.That(streets[2].Title, Is.EqualTo("Синяя ул."));
		}

		[Test]
		public void GetStreetsById_EmptyList()
		{
			Url = "https://api.vk.com/method/database.getStreetsById";
			ReadErrorsJsonFile(100);

			var ex = Assert.Throws<ParameterMissingOrInvalidException>(() =>
			{
				var readOnlyCollection = Api.Database.GetStreetsById();
				Assert.IsNotEmpty(readOnlyCollection);
			});

			Assert.That(ex.Message, Is.EqualTo("One of the parameters specified was missing or invalid: value should be positive"));
		}

		[Test]
		public void GetUniversities_FindVstu()
		{
			Url = "https://api.vk.com/method/database.getUniversities";
			ReadCategoryJsonPath(nameof(GetUniversities_FindVstu));

			var universities = Api.Database.GetUniversities(1, 10, "ВолгГТУ");

			Assert.That(universities.Count, Is.EqualTo(1));
			Assert.That(universities[0].Id, Is.EqualTo(431));
			Assert.That(universities[0].Name, Is.EqualTo("ВолгГТУ"));
		}

		[Test]
		public void GetUniversities_ListOfUniversities()
		{
			Url = "https://api.vk.com/method/database.getUniversities";
			ReadJsonFile(JsonPaths.EmptyVkCollection);

			var universities = Api.Database.GetUniversities(1, 1, "ThisUniverDoesNotExist");

			Assert.That(universities.Count, Is.EqualTo(0));
		}
	}
}