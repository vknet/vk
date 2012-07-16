using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enum;
using VkToolkit.Exception;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class GroupsCategoryTest
    {   
        // join
        // уже есть в группе

        [SetUp]
        public void SetUp()
        {
             
        }

        private GroupsCategory GetMockedGroupCategory(string url, string json)
        {
            var browser = new Mock<IBrowser>();
            browser.Setup(m => m.GetJson(url)).Returns(json);

            return new GroupsCategory(new VkApi(browser.Object) { AccessToken = "token" });
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException), ExpectedMessage = "Access denied: you can't join this private community")]
        public void Join_WrongGid_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=0&not_sure=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":15,\"error_msg\":\"Access denied: you can't join this private community\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"0\"},{\"key\":\"not_sure\",\"value\":\"1\"},{\"key\":\"access_token\",\"value\":\"\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Join(0, true);
        }

        [Test]
        public void Leave_WrongGid_ReturnTrue()
        {
            const string url =
                "https://api.vk.com/method/groups.leave?gid=-1&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Leave(-1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Join_NormalCase_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=0&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            var result = groups.Join(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Join_NormalCaseNotSure_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=1&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Join(2, true);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Leave_NormalCase_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=2&access_token=token";
            const string json = "{\"response\":1}";

            var groups = GetMockedGroupCategory(url, json);
            bool result = groups.Leave(2);

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Join_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=2&not_sure=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":7,\"error_msg\":\"Permission to perform this action is denied\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.leave\"},{\"key\":\"text\",\"value\":\"test\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);

            groups.Join(2, true);
        }

        [Test]
        [ExpectedException(typeof(AccessDeniedException))]
        public void Leave_AccessDenied_ThrowAccessDeniedException()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=2&access_token=token";
            const string json = "{\"error\":{\"error_code\":7,\"error_msg\":\"Permission to perform this action is denied\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.leave\"},{\"key\":\"text\",\"value\":\"test\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Leave(2);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Join_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Join(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Leave_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.Leave(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException))]
        public void Join_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
        {
            const string url = "https://api.vk.com/method/groups.join?gid=1&not_sure=0&access_token=token";
            const string json = "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: access_token was given to another ip address.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"40724899\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Join(1);
        }

        [Test]
        [ExpectedException(typeof(UserAuthorizationFailException))]
        public void Leave_UserAuthorizationFailed_ThrowUserAuthorizationFailException()
        {
            const string url = "https://api.vk.com/method/groups.leave?gid=1&access_token=token";
            const string json = "{\"error\":{\"error_code\":5,\"error_msg\":\"User authorization failed: access_token was given to another ip address.\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.join\"},{\"key\":\"gid\",\"value\":\"40724899\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);
            groups.Leave(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.GetById(1);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void IsMember_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetMembers_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            int totalCount;
            groups.GetMembers(1, out totalCount);
        }

        [Test]
        public void GetMembers_NormalCase_ListOfUsesIds()
        {
            const string url = "https://api.vk.com/method/groups.getMembers?gid=17683660&access_token=token";
            const string json =
                "{\"response\":{\"count\":861,\"users\":[116446865,485839,23483719,3428459,153698746,16080868,5054657,38690458]}}";

            var groups = GetMockedGroupCategory(url, json);

            int totalCount;
            var ids = groups.GetMembers(17683660, out totalCount).ToList();

            Assert.That(totalCount, Is.EqualTo(861));
            Assert.That(ids.Count, Is.EqualTo(8));

            Assert.That(ids[0], Is.EqualTo(116446865));
            Assert.That(ids[1], Is.EqualTo(485839));
            Assert.That(ids[2], Is.EqualTo(23483719));
            Assert.That(ids[3], Is.EqualTo(3428459));
            Assert.That(ids[4], Is.EqualTo(153698746));
            Assert.That(ids[5], Is.EqualTo(16080868));
            Assert.That(ids[6], Is.EqualTo(5054657));
            Assert.That(ids[7], Is.EqualTo(38690458));
        }

        [Test]
        public void GetMembers_NormalCaseAllInputParameters_ListOfUsesIds()
        {
            const string url = "https://api.vk.com/method/groups.getMembers?gid=17683660&count=7&offset=15&sort=id_asc&access_token=token";
            const string json =
                "{\"response\":{\"count\":861,\"users\":[1129147,1137997,1201582,1205554,1220166,1238937,1239796]}}";

            var groups = GetMockedGroupCategory(url, json);
            int totalCount;
            var ids = groups.GetMembers(17683660, out totalCount, 7, 15, GroupsSort.IdAsc).ToList();

            Assert.That(totalCount, Is.EqualTo(861));
            Assert.That(ids.Count, Is.EqualTo(7));

            Assert.That(ids[0], Is.EqualTo(1129147));
            Assert.That(ids[1], Is.EqualTo(1137997));
            Assert.That(ids[2], Is.EqualTo(1201582));
            Assert.That(ids[3], Is.EqualTo(1205554));
            Assert.That(ids[4], Is.EqualTo(1220166));
            Assert.That(ids[5], Is.EqualTo(1238937));
            Assert.That(ids[6], Is.EqualTo(1239796));
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void GetMembers_InvalidGid_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/groups.getMembers?gid=-1&access_token=token";
            const string json =
                "{\"error\":{\"error_code\":125,\"error_msg\":\"Invalid group id\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.getMembers\"},{\"key\":\"gid\",\"value\":\"-1\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var groups = GetMockedGroupCategory(url, json);

            int totalCount;
            groups.GetMembers(-1, out totalCount);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_Multiple_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var groups = new GroupsCategory(new VkApi());
            groups.GetById(2);
        }
       
        [Test]
        public void GetById_NormalCaseDefaultFields_ReturnTwoItems()
        {
            const string url = "https://api.vk.com/method/groups.getById?gid=17683660&access_token=token";
            const string json =
                "{\"response\":[{\"gid\":17683660,\"name\":\"Творческие каникулы ART CAMP с 21 по 29 июля\",\"screen_name\":\"club17683660\",\"is_closed\":0,\"type\":\"event\",\"is_admin\":0,\"is_member\":0,\"photo\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/e_f700c806.jpg\",\"photo_medium\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/d_26f909c0.jpg\",\"photo_big\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/a_54e3c8fb.jpg\"}]}";

            var cat = GetMockedGroupCategory(url, json);
            var g = cat.GetById(17683660);

            Assert.That(g.Id, Is.EqualTo(17683660));
            Assert.That(g.Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
            Assert.That(g.ScreenName, Is.EqualTo("club17683660"));
            Assert.That(g.IsClosed, Is.False);
            Assert.That(g.IsAdmin, Is.False);
            Assert.That(g.Type, Is.EqualTo(GroupType.Event));
            Assert.That(g.IsMember, Is.False);
            Assert.That(g.Photo, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));
            Assert.That(g.PhotoMedium, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));
            Assert.That(g.PhotoBig, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void GetById_InvalidGid_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/groups.getById?gid=-1&access_token=token";
            const string json =
                "{\"error\":{\"error_code\":125,\"error_msg\":\"Invalid group id\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.getById\"},{\"key\":\"gid\",\"value\":\"17683660,637247\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";
            var cat = GetMockedGroupCategory(url, json);

            cat.GetById(-1);
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void GetById_Multiple_InvalidGids_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/groups.getById?gids=-1&access_token=token";
            const string json = "{\"error\":{\"error_code\":125,\"error_msg\":\"Invalid group id\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"groups.getById\"},{\"key\":\"gids\",\"value\":\"-1\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var cat = GetMockedGroupCategory(url, json);

            cat.GetById(new long[]{-1});
        }

        [Test]
        public void GetById_Multiple_NormalCaseDefaultFields_ReturnTowItems()
        {
            const string url = "https://api.vk.com/method/groups.getById?gids=17683660,637247&access_token=token";
            const string json =
                "{\"response\":[{\"gid\":17683660,\"name\":\"Творческие каникулы ART CAMP с 21 по 29 июля\",\"screen_name\":\"club17683660\",\"is_closed\":0,\"type\":\"event\",\"is_admin\":0,\"is_member\":0,\"photo\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/e_f700c806.jpg\",\"photo_medium\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/d_26f909c0.jpg\",\"photo_big\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/a_54e3c8fb.jpg\"},{\"gid\":637247,\"name\":\"Чак Паланик - Сумасшедший гений литературы\",\"screen_name\":\"club637247\",\"is_closed\":1,\"type\":\"group\",\"is_admin\":0,\"is_member\":1,\"photo\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/c_f597d0f8.jpg\",\"photo_medium\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/b_898ae7f1.jpg\",\"photo_big\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/a_6be98c68.jpg\"}]}";

            var cat = GetMockedGroupCategory(url, json);
            var groups = cat.GetById(new long[] {17683660, 637247}).ToList();

            Assert.That(groups.Count == 2);
            Assert.That(groups[0].Id, Is.EqualTo(17683660));
            Assert.That(groups[0].Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
            Assert.That(groups[0].ScreenName, Is.EqualTo("club17683660"));
            Assert.That(groups[0].IsClosed, Is.False);
            Assert.That(groups[0].IsAdmin, Is.False);
            Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
            Assert.That(groups[0].IsMember, Is.False);
            Assert.That(groups[0].Photo, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));
            Assert.That(groups[0].PhotoMedium, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));
            Assert.That(groups[0].PhotoBig, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));

            Assert.That(groups[1].Id, Is.EqualTo(637247));
            Assert.That(groups[1].Name, Is.EqualTo("Чак Паланик - Сумасшедший гений литературы"));
            Assert.That(groups[1].ScreenName, Is.EqualTo("club637247"));
            Assert.That(groups[1].IsClosed, Is.True);
            Assert.That(groups[1].Type, Is.EqualTo(GroupType.Group));
            Assert.That(groups[1].IsAdmin, Is.False);
            Assert.That(groups[1].IsMember, Is.True);
            Assert.That(groups[1].Photo, Is.EqualTo("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));
            Assert.That(groups[1].PhotoMedium, Is.EqualTo("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));
            Assert.That(groups[1].PhotoBig, Is.EqualTo("http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));

        }

        [Test]
        public void GetById_Multiple_NormalCaseAllFields_ReturnTwoItems()
        {
            const string url =
                "https://api.vk.com/method/groups.getById?gids=17683660,637247&fields=city,country,place,description,wiki_page,start_date,end_date&access_token=token";
            const string json =
                "{\"response\":[{\"gid\":17683660,\"name\":\"Творческие каникулы ART CAMP с 21 по 29 июля\",\"screen_name\":\"club17683660\",\"is_closed\":0,\"city\":95,\"country\":1,\"description\":\"Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21...\",\"start_date\":\"1342850400\",\"type\":\"event\",\"is_admin\":0,\"is_member\":0,\"photo\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/e_f700c806.jpg\",\"photo_medium\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/d_26f909c0.jpg\",\"photo_big\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/a_54e3c8fb.jpg\"},{\"gid\":637247,\"name\":\"Чак Паланик - Сумасшедший гений литературы\",\"screen_name\":\"club637247\",\"is_closed\":1,\"city\":95,\"country\":1,\"description\":\"Кто он, этот неординарный и талантливый человек? Его творчество спо...\",\"wiki_page\":\"Chuk Palahniuk\",\"start_date\":\"0\",\"type\":\"group\",\"is_admin\":0,\"is_member\":1,\"photo\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/c_f597d0f8.jpg\",\"photo_medium\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/b_898ae7f1.jpg\",\"photo_big\":\"http:\\/\\/cs11418.userapi.com\\/g637247\\/a_6be98c68.jpg\"}]}";

            var category = GetMockedGroupCategory(url, json);

            var groups = category.GetById(new long[] { 17683660, 637247 }, GroupsFields.All).ToList();

            Assert.That(groups.Count, Is.EqualTo(2));
            Assert.That(groups[0].Id, Is.EqualTo(17683660));
            Assert.That(groups[0].Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
            Assert.That(groups[0].ScreenName, Is.EqualTo("club17683660"));
            Assert.That(groups[0].IsClosed, Is.False);
            Assert.That(groups[0].IsAdmin, Is.False);
            Assert.That(groups[0].Type, Is.EqualTo(GroupType.Event));
            Assert.That(groups[0].IsMember, Is.False);
            Assert.That(groups[0].Photo, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));
            Assert.That(groups[0].PhotoMedium, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));
            Assert.That(groups[0].PhotoBig, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));
            Assert.That(groups[0].CityId, Is.EqualTo(95));
            Assert.That(groups[0].CountryId, Is.EqualTo(1));
            Assert.That(groups[0].Description, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля<br>С 21..."));
            Assert.That(groups[0].StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0)));

            Assert.That(groups[1].Id, Is.EqualTo(637247));
            Assert.That(groups[1].Name, Is.EqualTo("Чак Паланик - Сумасшедший гений литературы"));
            Assert.That(groups[1].ScreenName, Is.EqualTo("club637247"));
            Assert.That(groups[1].IsClosed, Is.True);
            Assert.That(groups[1].IsAdmin, Is.False);
            Assert.That(groups[1].WikiPage, Is.EqualTo("Chuk Palahniuk"));
            Assert.That(groups[1].Type, Is.EqualTo(GroupType.Group));
            Assert.That(groups[1].IsMember, Is.True);
            Assert.That(groups[1].Photo, Is.EqualTo("http://cs11418.userapi.com/g637247/c_f597d0f8.jpg"));
            Assert.That(groups[1].PhotoMedium, Is.EqualTo("http://cs11418.userapi.com/g637247/b_898ae7f1.jpg"));
            Assert.That(groups[1].PhotoBig, Is.EqualTo("http://cs11418.userapi.com/g637247/a_6be98c68.jpg"));
            Assert.That(groups[1].CityId, Is.EqualTo(95));
            Assert.That(groups[1].CountryId, Is.EqualTo(1));
            Assert.That(groups[1].Description, Is.EqualTo("Кто он, этот неординарный и талантливый человек? Его творчество спо..."));
            Assert.That(groups[1].StartDate, Is.Null);
        }

        [Test]
        public void GetById_NormalCaseAllFields_ReturnTwoItems()
        {
            const string url =
                "https://api.vk.com/method/groups.getById?gid=17683660&fields=city,country,place,description,wiki_page,start_date,end_date&access_token=token";
            const string json =
                "{\"response\":[{\"gid\":17683660,\"name\":\"Творческие каникулы ART CAMP с 21 по 29 июля\",\"screen_name\":\"club17683660\",\"is_closed\":0,\"city\":95,\"country\":1,\"description\":\"Творческие каникулы ART CAMP с 21 по 29 июля<br>....\",\"start_date\":\"1342850400\",\"type\":\"event\",\"is_admin\":0,\"is_member\":0,\"photo\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/e_f700c806.jpg\",\"photo_medium\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/d_26f909c0.jpg\",\"photo_big\":\"http:\\/\\/cs407631.userapi.com\\/g17683660\\/a_54e3c8fb.jpg\"}]}";

            var category = GetMockedGroupCategory(url, json);
            var g = category.GetById(17683660,GroupsFields.All);

            Assert.That(g.Id, Is.EqualTo(17683660));
            Assert.That(g.Name, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля"));
            Assert.That(g.ScreenName, Is.EqualTo("club17683660"));
            Assert.That(g.IsClosed, Is.False);
            Assert.That(g.IsAdmin, Is.False);
            Assert.That(g.Type, Is.EqualTo(GroupType.Event));
            Assert.That(g.IsMember, Is.False);
            Assert.That(g.Photo, Is.EqualTo("http://cs407631.userapi.com/g17683660/e_f700c806.jpg"));
            Assert.That(g.PhotoMedium, Is.EqualTo("http://cs407631.userapi.com/g17683660/d_26f909c0.jpg"));
            Assert.That(g.PhotoBig, Is.EqualTo("http://cs407631.userapi.com/g17683660/a_54e3c8fb.jpg"));
            Assert.That(g.CityId, Is.EqualTo(95));
            Assert.That(g.CountryId, Is.EqualTo(1));
            Assert.That(g.Description, Is.EqualTo("Творческие каникулы ART CAMP с 21 по 29 июля<br>...."));
            Assert.That(g.StartDate, Is.EqualTo(new DateTime(2012, 7, 21, 10, 0, 0)));
        }

    }
}