using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class DatabaseCategoryTest
    {
        // TODO: Добавить больше тестов на методы
        DatabaseCategory _db = new DatabaseCategory(new VkApi());


        private DatabaseCategory GetMockedDatabaseCategory(string url, string json)
        {
            var mock = new Mock<IBrowser>();
            mock.Setup(m => m.GetJson(url.Replace('\'', '"'))).Returns(json);

            return new DatabaseCategory(new VkApi{Browser = mock.Object});
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetRegions_CountryIdIsNegative_ThrowArgumentException()
        {
            DatabaseCategory db = GetMockedDatabaseCategory("", "");

            db.GetRegions(-1);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void GetRegions_CountIsNegative_ThrowArgumentException()
        {
            DatabaseCategory db = GetMockedDatabaseCategory("", "");

            db.GetRegions(1, count: -2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetRegions_OffsetIsNegative_ThrowArgumentException()
        {
            DatabaseCategory db = GetMockedDatabaseCategory("", "");

            db.GetRegions(1, offset: -2);
        }

        [Test]
        public void GetRegions_NormalCase_ListOfRegions()
        {
            const string url = "https://api.vk.com/method/database.getRegions?country_id=1&offset=5&count=3&access_token=";
            const string json =
                @"{
                    'response': [
                      {
                        'region_id': '1000236',
                        'title': 'Архангельская область'
                      },
                      {
                        'region_id': '1004118',
                        'title': 'Астраханская область'
                      },
                      {
                        'region_id': '1004565',
                        'title': 'Башкортостан'
                      }
                    ]
                  }";

            DatabaseCategory db = GetMockedDatabaseCategory(url, json);

            List<Region> regions = db.GetRegions(1, count:3, offset:5);

            Assert.That(regions.Count, Is.EqualTo(3));

            Assert.That(regions[0].Id, Is.EqualTo(1000236));
            Assert.That(regions[0].Title, Is.EqualTo("Архангельская область"));

            Assert.That(regions[1].Id, Is.EqualTo(1004118));
            Assert.That(regions[1].Title, Is.EqualTo("Астраханская область"));

            Assert.That(regions[2].Id, Is.EqualTo(1004565));
            Assert.That(regions[2].Title, Is.EqualTo("Башкортостан"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCountries_CountIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
            db.GetCountries(count: -2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetCountries_OffsetIsNegative_ThrowArgumentException()
        {
            var db = GetMockedDatabaseCategory("", "");
            db.GetCountries(offset: -2);
        }

        [Test]
        public void GetCountries_ListOfCodes_ListOfCountries()
        {
            const string url = "https://api.vk.com/method/database.getCountries?code=ru, de&need_all=1&access_token=";

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
            List<Country> countries = db.GetCountries(codes: "ru, de");

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

             const string url = "https://api.vk.com/method/database.getCountries?offset=5&count=3&need_all=1&access_token=";

             var db = GetMockedDatabaseCategory(url, json);

             List<Country> countries = db.GetCountries(true, "", 3, 5);

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
            var db = new DatabaseCategory(new VkApi());

            List<Country> countries = db.GetCountriesById();

            Assert.That(countries, Is.Not.Null);
            Assert.That(countries.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetCountriesById_1And65_RussiaAndGermany()
        {
            const string url = "https://api.vk.com/method/database.getCountriesById?country_ids=1,65&access_token=";
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

            DatabaseCategory db = GetMockedDatabaseCategory(url, json);

            List<Country> countries = db.GetCountriesById(1, 65);

            Assert.That(countries.Count, Is.EqualTo(2));

            Assert.That(countries[0].Id, Is.EqualTo(1));
            Assert.That(countries[0].Title, Is.EqualTo("Россия"));

            Assert.That(countries[1].Id, Is.EqualTo(65));
            Assert.That(countries[1].Title, Is.EqualTo("Германия"));
        }
    }
}