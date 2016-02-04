using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
    [TestFixture]
    [SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
    public class LikesCategoryTest
    {
        private LikesCategory GetMockedLikesCategory(string url, string json)
        {
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
            return new LikesCategory(new VkApi { AccessToken = "token", Browser = browser });
        }

        [Test]
        public void IsLiked_NormalCase()
        {
            const string url = "https://api.vk.com/method/likes.isLiked?type=post&item_id=701&v=5.44&access_token=token";
            const string json =
                @"{
					response: {
						liked: 1,
						copied: 0
					}
				}";
            var likesCategory = GetMockedLikesCategory(url, json);
            bool copied;
            var like = likesCategory.IsLiked(out copied, LikeObjectType.Post, 701);
            Assert.That(like, Is.EqualTo(true));
            Assert.That(copied, Is.EqualTo(false));
        }

        [Test]
        public void Delete_NormalCase()
        {
            const string url = "https://api.vk.com/method/likes.delete?type=post&item_id=701&v=5.44&access_token=token";
            const string json =
                @"{
					response: {
						likes: 4
					}
				}";
            var likesCategory = GetMockedLikesCategory(url, json);
            var like = likesCategory.Delete(LikeObjectType.Post, 701);
            Assert.That(like, Is.EqualTo(4));
        }

        [Test]
        public void Add_NormalCase()
        {
            const string url = "https://api.vk.com/method/likes.add?type=post&item_id=701&v=5.44&access_token=token";
            const string json =
                @"{
					response: {
						likes: 5
					}
				}";
            var likesCategory = GetMockedLikesCategory(url, json);
            var like = likesCategory.Add(new LikesAddParams { Type = LikeObjectType.Post, ItemId = 701 });
            Assert.That(like, Is.EqualTo(5));
        }

        [Test]
        public void GetList_NormalCase()
        {
            const string url = "https://api.vk.com/method/likes.getList?item_id=701&extended=1&v=5.44&access_token=token";
            const string json =
                @"{
					response: {
						count: 5,
						items: [32190123, 221634238, 229027572, 210894192, 201173701]
					}
				}";
            var likesCategory = GetMockedLikesCategory(url, json);
            var like = likesCategory.GetList(new LikesGetListParams
            {
                ItemId = 701
            });
            Assert.That(like.Count, Is.EqualTo(5));
        }

        [Test]
        public void GetListEx_NormalCase()
        {
            const string url = "https://api.vk.com/method/likes.getList?item_id=701&extended=1&v=5.44&access_token=token";
            const string json =
                @"{
					response: {
						count: 5,
						items: [{
								type: 'profile',
								id: 32190123,
								first_name: 'Максим',
								last_name: 'Инютин'
							}, {
								type: 'profile',
								id: 221634238,
								first_name: 'Александр',
								last_name: 'Инютин'
							}, {
								type: 'profile',
								id: 229027572,
								first_name: 'Настя',
								last_name: 'Зубова'
							}, {
								type: 'profile',
								id: 210894192,
								first_name: 'Елизавета',
								last_name: 'Емельянова'
							}, {
								type: 'profile',
								id: 201173701,
								first_name: 'Даниил',
								last_name: 'Богданов'
						}]
					}
				}";
            var likesCategory = GetMockedLikesCategory(url, json);
            var like = likesCategory.GetListEx(new LikesGetListParams
            {
                ItemId = 701
            });
            Assert.That(like.Users.Count, Is.EqualTo(5));
            Assert.That(like.Users.First().Id, Is.EqualTo(32190123));
            Assert.That(like.Users.First().FirstName, Is.EqualTo("Максим"));
            Assert.That(like.Users.First().LastName, Is.EqualTo("Инютин"));
            Assert.That(like.Groups.Count, Is.EqualTo(0));
        }
    }
}