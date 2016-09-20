using System;
using System.Collections.Generic;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;

namespace VkNet.Tests.Categories
{
	[TestFixture]
    public class DatabaseCategoryTest : BaseTest
    {
        private DatabaseCategory GetMockedDatabaseCategory(string url, string json)
        {
            Json = json;
            Url = url;
            return new DatabaseCategory(Api);
        }

        [Test]
        public void GetStreetsById_EmptyList()
        {
            const string url = "https://api.vk.com/method/database.getStreetsById?v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

			var ex = Assert.Throws<InvalidParameterException>(() => db.GetStreetsById());
			Assert.That(ex.Message, Is.EqualTo("One of the parameters specified was missing or invalid: street_ids is undefined"));
		}

        [Test]
        public void GetUniversities_FindVstu()
        {
            const string url = "https://api.vk.com/method/database.getUniversities?q=ВолгГТУ&country_id=1&city_id=10&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var universities = db.GetUniversities(1, 10, "ВолгГТУ");

			Assert.That(universities.Count, Is.EqualTo(1));
            Assert.That(universities[0].Id, Is.EqualTo(431));
            Assert.That(universities[0].Name, Is.EqualTo("ВолгГТУ"));
        }

        [Test]
        public void GetUniversities_ListOfUniversities()
        {
            const string url = "https://api.vk.com/method/database.getUniversities?q=ThisUniverDoesNotExist&country_id=1&city_id=1&v=" + VkApi.VkApiVersion ;
            const string json =
				@"{
                    response: {
						count: 0,
						items: []
					}
                  }";

            var db = GetMockedDatabaseCategory(url, json);

            var univers = db.GetUniversities(1, 1, "ThisUniverDoesNotExist");

			Assert.That(univers.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetStreetsById_1_89_437()
        {
            const string url = "https://api.vk.com/method/database.getStreetsById?street_ids=1,89,437&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var streets = db.GetStreetsById(1, 89, 437);

			Assert.That(streets.Count, Is.EqualTo(3));

            Assert.That(streets[0].Id, Is.EqualTo(1));
            Assert.That(streets[0].Title, Is.EqualTo("8 Марта ул."));

            Assert.That(streets[1].Id, Is.EqualTo(89));
            Assert.That(streets[1].Title, Is.EqualTo("Черкесская ул."));

            Assert.That(streets[2].Id, Is.EqualTo(437));
            Assert.That(streets[2].Title, Is.EqualTo("Синяя ул."));
        }

        [Test]
        public void GetCities_CountryIdIsNegative_ThrowException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetCities(-1), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetCities_RegionIdIsNegative_ThrowException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetCities(1, -2), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetCitiesById_EmptyList()
        {
            const string url = "https://api.vk.com/method/database.getCitiesById?v=" + VkApi.VkApiVersion ;
            const string json =
                @"{
                    'response': []
                  }";

            var db = GetMockedDatabaseCategory(url, json);

            var cities = db.GetCitiesById();

			Assert.That(cities.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetCitiesById_MskSpbVlg()
        {
            const string url = "https://api.vk.com/method/database.getCitiesById?city_ids=1,2,10&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var cities = db.GetCitiesById(1, 2, 10);

			Assert.That(cities.Count, Is.EqualTo(3));

            Assert.That(cities[0].Id, Is.EqualTo(1));
            Assert.That(cities[0].Title, Is.EqualTo("Москва"));

            Assert.That(cities[1].Id, Is.EqualTo(2));
            Assert.That(cities[1].Title, Is.EqualTo("Санкт-Петербург"));

            Assert.That(cities[2].Id, Is.EqualTo(10));
            Assert.That(cities[2].Title, Is.EqualTo("Волгоград"));
        }

        [Test]
        public void GetCities_GetBiggestCitiesOfRussia()
        {
            const string url = "https://api.vk.com/method/database.getCities?country_id=1&count=3&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var cities = db.GetCities(1, count: 3);

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
        [Ignore("undone")]
        public void GetCities_GetGermanyCities()
        {
            Assert.Fail("undone");
        }

        [Test]
        public void GetCities_NormalCase()
        {
            const string url = "https://api.vk.com/method/database.getCities?country_id=1&region_id=1004118&offset=1&count=2&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var cities = db.GetCities(1, 1004118, count:2, offset:1);

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
        public void GetRegions_CountryIdIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetRegions(-1), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetRegions_CountIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetRegions(1, count: -2), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetRegions_OffsetIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetRegions(1, offset: -2), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetRegions_NormalCase_ListOfRegions()
        {
            const string url = "https://api.vk.com/method/database.getRegions?country_id=1&offset=5&count=3&v=" + VkApi.VkApiVersion ;
            const string json =
                @"{'response':{'count':83,'items':[{'id':1004118,'title':'Астраханская область'},{'id':1004565,'title':'Башкортостан'},{'id':1009404,'title':'Белгородская область'}]}}";

            var db = GetMockedDatabaseCategory(url, json);

			var regions = db.GetRegions(1, count: 3, offset: 5);

            Assert.That(regions.Count, Is.EqualTo(3));

            Assert.That(regions[0].Id, Is.EqualTo(1004118));
            Assert.That(regions[0].Title, Is.EqualTo("Астраханская область"));

            Assert.That(regions[1].Id, Is.EqualTo(1004565));
            Assert.That(regions[1].Title, Is.EqualTo("Башкортостан"));

            Assert.That(regions[2].Id, Is.EqualTo(1009404));
            Assert.That(regions[2].Title, Is.EqualTo("Белгородская область"));
        }

        [Test]
        public void GetCountries_CountIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetCountries(count: -2), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetCountries_OffsetIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
			Assert.That(() => db.GetCountries(offset: -2), Throws.InstanceOf<ArgumentException>());
		}

        [Test]
        public void GetCountries_ListOfCodes_ListOfCountries()
        {
			const string url = "https://api.vk.com/method/database.getCountries?code=RU,DE&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);
            var countries = db.GetCountries(codes: new List<Iso3166>
            {
	            Iso3166.RU,
				Iso3166.DE
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

			const string url = "https://api.vk.com/method/database.getCountries?offset=5&count=3&need_all=1&v=" + VkApi.VkApiVersion ;
			var db = GetMockedDatabaseCategory(url, json);

             var countries = db.GetCountries(true, null, 3, 5);

			Assert.That(countries.Count, Is.EqualTo(3));

             Assert.That(countries[0].Id, Is.EqualTo(23));
             Assert.That(countries[0].Title, Is.EqualTo("Американское Самоа"));

             Assert.That(countries[1].Id, Is.EqualTo(24));
             Assert.That(countries[1].Title, Is.EqualTo("Ангилья"));

             Assert.That(countries[2].Id, Is.EqualTo(25));
             Assert.That(countries[2].Title, Is.EqualTo("Ангола"));
         }

        [Test]
        public void GetCountriesById_EmptyList()
        {
            const string url = "https://api.vk.com/method/database.getCountriesById?v=" + VkApi.VkApiVersion ;
            const string json =
                @"{
                    'response': []
                  }";

            var db = GetMockedDatabaseCategory(url, json);

			var countries = db.GetCountriesById();

            Assert.That(countries, Is.Not.Null);
            Assert.That(countries.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetCountriesById_1And65_RussiaAndGermany()
        {
            const string url = "https://api.vk.com/method/database.getCountriesById?country_ids=1,65&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

			var countries = db.GetCountriesById(1, 65);

            Assert.That(countries.Count, Is.EqualTo(2));

            Assert.That(countries[0].Id, Is.EqualTo(1));
            Assert.That(countries[0].Title, Is.EqualTo("Россия"));

            Assert.That(countries[1].Id, Is.EqualTo(65));
            Assert.That(countries[1].Title, Is.EqualTo("Германия"));
        }

        [Test]
        public void GetSchools_BadQuery_EmptyList()
        {
            const string url = "https://api.vk.com/method/database.getSchools?q=SchoolDoesNotExist&city_id=10&v=" + VkApi.VkApiVersion ;
            const string json =
				@"{
                    response: {
						count: 0,
						items: []
					}
                  }";

            var db = GetMockedDatabaseCategory(url, json);

            var schools = db.GetSchools(10, "SchoolDoesNotExist");

			Assert.That(schools.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetSchools_LiceumsInVolgograd_ListOfLiceums()
        {
            const string url = "https://api.vk.com/method/database.getSchools?city_id=10&count=3&v=" + VkApi.VkApiVersion ;
            const string json =
                @"{'response':{'count':343,'items':[{'id':51946,'title':'Астраханское речное училище (ВФ АРУ)'},{'id':207063,'title':'Библейская школа «Весть»'},{'id':224706,'title':'Библейский колледж «Новая жизнь»'}]}}";

            var db = GetMockedDatabaseCategory(url, json);

            var schools = db.GetSchools(10, count: 3);

			Assert.That(schools.Count, Is.EqualTo(3));

            Assert.That(schools[0].Id, Is.EqualTo(51946));
            Assert.That(schools[0].Name, Is.EqualTo("Астраханское речное училище (ВФ АРУ)"));

            Assert.That(schools[1].Id, Is.EqualTo(207063));
            Assert.That(schools[1].Name, Is.EqualTo("Библейская школа «Весть»"));

            Assert.That(schools[2].Id, Is.EqualTo(224706));
            Assert.That(schools[2].Name, Is.EqualTo("Библейский колледж «Новая жизнь»"));
        }

        [Test]
        [Ignore("undone")]
        public void GetFaculties_SuchUniversityDoesNotExist()
        {
            //            const string url = "https://api.vk.com/method/database.getFaculties?university_id=999999&v=" + VkApi.VkApiVersion ;
            //            var db = _db;
            //
            //            List<Faculty> faculties = db.GetFaculties(999999);

            Assert.Fail("undone");
        }

        [Test]
        public void GetFaculties_ListVstuFaculties()
        {
            const string url = "https://api.vk.com/method/database.getFaculties?university_id=431&offset=2&count=3&v=" + VkApi.VkApiVersion ;
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

            var db = GetMockedDatabaseCategory(url, json);

            var faculties = db.GetFaculties(431, 3, 2);

			Assert.That(faculties.Count, Is.EqualTo(3));

            Assert.That(faculties[0].Id, Is.EqualTo(3160));
            Assert.That(faculties[0].Title, Is.EqualTo("Автоматизированных систем и технологической информатики (бывш. Машиностроительный)"));

            Assert.That(faculties[1].Id, Is.EqualTo(3161));
            Assert.That(faculties[1].Title, Is.EqualTo("Технологии конструкционных материалов"));

            Assert.That(faculties[2].Id, Is.EqualTo(3162));
            Assert.That(faculties[2].Title, Is.EqualTo("Электроники и вычислительной техники"));
        }
    }
}