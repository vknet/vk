using System;
using System.Collections.Generic;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model.RequestParams.Database;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class DatabaseCategoryTest : BaseTest
	{
		private DatabaseCategory GetMockedDatabaseCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new DatabaseCategory(vk: Api);
		}

		[Test]
		public void GetCities_CountryIdIsNegative_ThrowException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");

			Assert.That(del: () => db.GetCities(@params: new GetCitiesParams
			{
					CountryId = -1
			}), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCities_GetBiggestCitiesOfRussia()
		{
			const string url = "https://api.vk.com/method/database.getCities";

			const string json =
					@"{
                    'response': [
                      {
                        'cid': 1,
                        'title': 'Москва',
                        'important': 1
                      },
                      {
                        'cid': 2,
                        'title': 'Санкт-Петербург',
                        'important': 1
                      },
                      {
                        'cid': 10,
                        'title': 'Волгоград'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var cities = db.GetCities(@params: new GetCitiesParams
			{
					CountryId = 1
					, Count = 3
			});

			Assert.That(actual: cities.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: cities[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: cities[index: 0].Title, expression: Is.EqualTo(expected: "Москва"));
			Assert.That(actual: cities[index: 0].Important, expression: Is.True);
			Assert.That(actual: cities[index: 0].Area, expression: Is.Null);
			Assert.That(actual: cities[index: 0].Region, expression: Is.Null);

			Assert.That(actual: cities[index: 1].Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: cities[index: 1].Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));
			Assert.That(actual: cities[index: 1].Important, expression: Is.True);
			Assert.That(actual: cities[index: 1].Area, expression: Is.Null);
			Assert.That(actual: cities[index: 1].Region, expression: Is.Null);

			Assert.That(actual: cities[index: 2].Id, expression: Is.EqualTo(expected: 10));
			Assert.That(actual: cities[index: 2].Title, expression: Is.EqualTo(expected: "Волгоград"));
			Assert.That(actual: cities[index: 2].Important, expression: Is.False);
			Assert.That(actual: cities[index: 2].Area, expression: Is.Null);
			Assert.That(actual: cities[index: 2].Region, expression: Is.Null);
		}

		[Test]
		[Ignore(reason: "undone")]
		public void GetCities_GetGermanyCities()
		{
			Assert.Fail(message: "undone");
		}

		[Test]
		public void GetCities_NormalCase()
		{
			const string url = "https://api.vk.com/method/database.getCities";

			const string json =
					@"{
                    'response': [
                      {
                        'cid': 1004357,
                        'title': 'Азау',
                        'area': 'Красноярский район',
                        'region': 'Астраханская область'
                      },
                      {
                        'cid': 1004307,
                        'title': 'Азовский',
                        'area': 'Камызякский район',
                        'region': 'Астраханская область'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var cities = db.GetCities(@params: new GetCitiesParams
			{
					CountryId = 1
					, RegionId = 1004118
					, Count = 2
					, Offset = 1
			});

			Assert.That(actual: cities.Count, expression: Is.EqualTo(expected: 2));

			Assert.That(actual: cities[index: 0].Id, expression: Is.EqualTo(expected: 1004357));
			Assert.That(actual: cities[index: 0].Title, expression: Is.EqualTo(expected: "Азау"));
			Assert.That(actual: cities[index: 0].Area, expression: Is.EqualTo(expected: "Красноярский район"));
			Assert.That(actual: cities[index: 0].Region, expression: Is.EqualTo(expected: "Астраханская область"));

			Assert.That(actual: cities[index: 1].Id, expression: Is.EqualTo(expected: 1004307));
			Assert.That(actual: cities[index: 1].Title, expression: Is.EqualTo(expected: "Азовский"));
			Assert.That(actual: cities[index: 1].Area, expression: Is.EqualTo(expected: "Камызякский район"));
			Assert.That(actual: cities[index: 1].Region, expression: Is.EqualTo(expected: "Астраханская область"));
		}

		[Test]
		public void GetCities_RegionIdIsNegative_ThrowException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");

			Assert.That(del: () => db.GetCities(@params: new GetCitiesParams
			{
					CountryId = 1
					, RegionId = -2
			}), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCitiesById_EmptyList()
		{
			const string url = "https://api.vk.com/method/database.getCitiesById";

			const string json =
					@"{
                    'response': []
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var cities = db.GetCitiesById();

			Assert.That(actual: cities.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetCitiesById_MskSpbVlg()
		{
			const string url = "https://api.vk.com/method/database.getCitiesById";

			const string json =
					@"{
                    'response': [
                      {
                        'cid': '1',
                        'name': 'Москва'
                      },
                      {
                        'cid': '2',
                        'name': 'Санкт-Петербург'
                      },
                      {
                        'cid': '10',
                        'name': 'Волгоград'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var cities = db.GetCitiesById(1, 2, 10);

			Assert.That(actual: cities.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: cities[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: cities[index: 0].Title, expression: Is.EqualTo(expected: "Москва"));

			Assert.That(actual: cities[index: 1].Id, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: cities[index: 1].Title, expression: Is.EqualTo(expected: "Санкт-Петербург"));

			Assert.That(actual: cities[index: 2].Id, expression: Is.EqualTo(expected: 10));
			Assert.That(actual: cities[index: 2].Title, expression: Is.EqualTo(expected: "Волгоград"));
		}

		[Test]
		public void GetCountries_CountIsNegative_ThrowArgumentException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");
			Assert.That(del: () => db.GetCountries(count: -2), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCountries_ListOfCodes_ListOfCountries()
		{
			const string url = "https://api.vk.com/method/database.getCountries";

			const string json =
					@"{
                    'response': [
                      {
                        'cid': 1,
                        'title': 'Россия'
                      },
                      {
                        'cid': 65,
                        'title': 'Германия'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var countries = db.GetCountries(codes: new List<Iso3166>
			{
					Iso3166.RU
					, Iso3166.DE
			});

			Assert.That(actual: countries.Count, expression: Is.EqualTo(expected: 2));

			Assert.That(actual: countries[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: countries[index: 0].Title, expression: Is.EqualTo(expected: "Россия"));

			Assert.That(actual: countries[index: 1].Id, expression: Is.EqualTo(expected: 65));
			Assert.That(actual: countries[index: 1].Title, expression: Is.EqualTo(expected: "Германия"));
		}

		[Test]
		public void GetCountries_NormalCase_ListOfCountries()
		{
			const string json =
					@"{
                    'response': [
                      {
                        'cid': 23,
                        'title': 'Американское Самоа'
                      },
                      {
                        'cid': 24,
                        'title': 'Ангилья'
                      },
                      {
                        'cid': 25,
                        'title': 'Ангола'
                      }
                    ]
                  }";

			const string url = "https://api.vk.com/method/database.getCountries";
			var db = GetMockedDatabaseCategory(url: url, json: json);

			var countries = db.GetCountries(needAll: true, codes: null, count: 3, offset: 5);

			Assert.That(actual: countries.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: countries[index: 0].Id, expression: Is.EqualTo(expected: 23));
			Assert.That(actual: countries[index: 0].Title, expression: Is.EqualTo(expected: "Американское Самоа"));

			Assert.That(actual: countries[index: 1].Id, expression: Is.EqualTo(expected: 24));
			Assert.That(actual: countries[index: 1].Title, expression: Is.EqualTo(expected: "Ангилья"));

			Assert.That(actual: countries[index: 2].Id, expression: Is.EqualTo(expected: 25));
			Assert.That(actual: countries[index: 2].Title, expression: Is.EqualTo(expected: "Ангола"));
		}

		[Test]
		public void GetCountries_OffsetIsNegative_ThrowArgumentException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");
			Assert.That(del: () => db.GetCountries(offset: -2), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetCountriesById_1And65_RussiaAndGermany()
		{
			const string url = "https://api.vk.com/method/database.getCountriesById";

			const string json =
					@"{
                    'response': [
                      {
                        'cid': 1,
                        'name': 'Россия'
                      },
                      {
                        'cid': 65,
                        'name': 'Германия'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var countries = db.GetCountriesById(1, 65);

			Assert.That(actual: countries.Count, expression: Is.EqualTo(expected: 2));

			Assert.That(actual: countries[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: countries[index: 0].Title, expression: Is.EqualTo(expected: "Россия"));

			Assert.That(actual: countries[index: 1].Id, expression: Is.EqualTo(expected: 65));
			Assert.That(actual: countries[index: 1].Title, expression: Is.EqualTo(expected: "Германия"));
		}

		[Test]
		public void GetCountriesById_EmptyList()
		{
			const string url = "https://api.vk.com/method/database.getCountriesById";

			const string json =
					@"{
                    'response': []
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var countries = db.GetCountriesById();

			Assert.That(actual: countries, expression: Is.Not.Null);
			Assert.That(actual: countries.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetFaculties_ListVstuFaculties()
		{
			const string url = "https://api.vk.com/method/database.getFaculties";

			const string json =
					@"{
                    'response': {
                      count: 10,
                      items: [{
                        'id': 3160,
                        'title': 'Автоматизированных систем и технологической информатики (бывш. Машиностроительный)'
                      },
                      {
                        'id': 3161,
                        'title': 'Технологии конструкционных материалов'
                      },
                      {
                        'id': 3162,
                        'title': 'Электроники и вычислительной техники'
                      }]
					}
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var faculties = db.GetFaculties(universityId: 431, count: 3, offset: 2);

			Assert.That(actual: faculties.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: faculties[index: 0].Id, expression: Is.EqualTo(expected: 3160));

			Assert.That(actual: faculties[index: 0].Title
					, expression: Is.EqualTo(
							expected: "Автоматизированных систем и технологической информатики (бывш. Машиностроительный)"));

			Assert.That(actual: faculties[index: 1].Id, expression: Is.EqualTo(expected: 3161));
			Assert.That(actual: faculties[index: 1].Title, expression: Is.EqualTo(expected: "Технологии конструкционных материалов"));

			Assert.That(actual: faculties[index: 2].Id, expression: Is.EqualTo(expected: 3162));
			Assert.That(actual: faculties[index: 2].Title, expression: Is.EqualTo(expected: "Электроники и вычислительной техники"));
		}

		[Test]
		public void GetRegions_CountIsNegative_ThrowArgumentException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");
			Assert.That(del: () => db.GetRegions(countryId: 1, count: -2), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetRegions_CountryIdIsNegative_ThrowArgumentException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");
			Assert.That(del: () => db.GetRegions(countryId: -1), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetRegions_NormalCase_ListOfRegions()
		{
			const string url = "https://api.vk.com/method/database.getRegions";

			const string json =
					@"{'response':{'count':83,'items':[{'id':1004118,'title':'Астраханская область'},{'id':1004565,'title':'Башкортостан'},{'id':1009404,'title':'Белгородская область'}]}}";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var regions = db.GetRegions(countryId: 1, count: 3, offset: 5);

			Assert.That(actual: regions.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: regions[index: 0].Id, expression: Is.EqualTo(expected: 1004118));
			Assert.That(actual: regions[index: 0].Title, expression: Is.EqualTo(expected: "Астраханская область"));

			Assert.That(actual: regions[index: 1].Id, expression: Is.EqualTo(expected: 1004565));
			Assert.That(actual: regions[index: 1].Title, expression: Is.EqualTo(expected: "Башкортостан"));

			Assert.That(actual: regions[index: 2].Id, expression: Is.EqualTo(expected: 1009404));
			Assert.That(actual: regions[index: 2].Title, expression: Is.EqualTo(expected: "Белгородская область"));
		}

		[Test]
		public void GetRegions_OffsetIsNegative_ThrowArgumentException()
		{
			var db = GetMockedDatabaseCategory(url: "", json: "");
			Assert.That(del: () => db.GetRegions(countryId: 1, offset: -2), expr: Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GetSchools_BadQuery_EmptyList()
		{
			const string url = "https://api.vk.com/method/database.getSchools";

			const string json =
					@"{
                    response: {
						count: 0,
						items: []
					}
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var schools = db.GetSchools(cityId: 10, query: "SchoolDoesNotExist");

			Assert.That(actual: schools.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetSchools_LiceumsInVolgograd_ListOfLiceums()
		{
			const string url = "https://api.vk.com/method/database.getSchools";

			const string json =
					@"{'response':{'count':343,'items':[{'id':51946,'title':'Астраханское речное училище (ВФ АРУ)'},{'id':207063,'title':'Библейская школа «Весть»'},{'id':224706,'title':'Библейский колледж «Новая жизнь»'}]}}";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var schools = db.GetSchools(cityId: 10, count: 3);

			Assert.That(actual: schools.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: schools[index: 0].Id, expression: Is.EqualTo(expected: 51946));
			Assert.That(actual: schools[index: 0].Name, expression: Is.EqualTo(expected: "Астраханское речное училище (ВФ АРУ)"));

			Assert.That(actual: schools[index: 1].Id, expression: Is.EqualTo(expected: 207063));
			Assert.That(actual: schools[index: 1].Name, expression: Is.EqualTo(expected: "Библейская школа «Весть»"));

			Assert.That(actual: schools[index: 2].Id, expression: Is.EqualTo(expected: 224706));
			Assert.That(actual: schools[index: 2].Name, expression: Is.EqualTo(expected: "Библейский колледж «Новая жизнь»"));
		}

		[Test]
		public void GetStreetsById_1_89_437()
		{
			const string url = "https://api.vk.com/method/database.getStreetsById";

			const string json =
					@"{
                    'response': [
                      {
                        'sid': 1,
                        'name': '8 Марта ул.'
                      },
                      {
                        'sid': 89,
                        'name': 'Черкесская ул.'
                      },
                      {
                        'sid': 437,
                        'name': 'Синяя ул.'
                      }
                    ]
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var streets = db.GetStreetsById(1, 89, 437);

			Assert.That(actual: streets.Count, expression: Is.EqualTo(expected: 3));

			Assert.That(actual: streets[index: 0].Id, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: streets[index: 0].Title, expression: Is.EqualTo(expected: "8 Марта ул."));

			Assert.That(actual: streets[index: 1].Id, expression: Is.EqualTo(expected: 89));
			Assert.That(actual: streets[index: 1].Title, expression: Is.EqualTo(expected: "Черкесская ул."));

			Assert.That(actual: streets[index: 2].Id, expression: Is.EqualTo(expected: 437));
			Assert.That(actual: streets[index: 2].Title, expression: Is.EqualTo(expected: "Синяя ул."));
		}

		[Test]
		public void GetStreetsById_EmptyList()
		{
			const string url = "https://api.vk.com/method/database.getStreetsById";

			const string json =
					@"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid: street_ids is undefined',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'database.getStreetsById'
                        },
                        {
                          'key': 'access_token',
                          'value': ''
                        }
                      ]
                    }
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var ex = Assert.Throws<ParameterMissingOrInvalidException>(code: () =>
			{
				var readOnlyCollection = db.GetStreetsById();
				Assert.IsNotEmpty(collection: readOnlyCollection);
			});

			Assert.That(actual: ex.Message
					, expression: Is.EqualTo(expected: "One of the parameters specified was missing or invalid: street_ids is undefined"));
		}

		[Test]
		public void GetUniversities_FindVstu()
		{
			const string url = "https://api.vk.com/method/database.getUniversities";

			const string json =
					@"{
                    'response': {
                      count: 1,
                      items: [{
                        'id': 431,
                        'title': 'ВолгГТУ'
                      }]
					}
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var universities = db.GetUniversities(countryId: 1, cityId: 10, query: "ВолгГТУ");

			Assert.That(actual: universities.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: universities[index: 0].Id, expression: Is.EqualTo(expected: 431));
			Assert.That(actual: universities[index: 0].Name, expression: Is.EqualTo(expected: "ВолгГТУ"));
		}

		[Test]
		public void GetUniversities_ListOfUniversities()
		{
			const string url = "https://api.vk.com/method/database.getUniversities";

			const string json =
					@"{
                    response: {
						count: 0,
						items: []
					}
                  }";

			var db = GetMockedDatabaseCategory(url: url, json: json);

			var univers = db.GetUniversities(countryId: 1, cityId: 1, query: "ThisUniverDoesNotExist");

			Assert.That(actual: univers.Count, expression: Is.EqualTo(expected: 0));
		}
	}
}