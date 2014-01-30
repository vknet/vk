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

        private DatabaseCategory GetMockedDatabaseCategory(string url, string json)
        {
            var mock = new Mock<IBrowser>();
            mock.Setup(m => m.GetJson(url.Replace('\'', '"'))).Returns(json);

            return new DatabaseCategory(new VkApi{Browser = mock.Object});

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
    }
}