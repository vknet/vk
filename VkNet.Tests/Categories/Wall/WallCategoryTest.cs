using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;

namespace VkNet.Tests.Categories.Wall
{
	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	[ExcludeFromCodeCoverage]
	public class WallCategoryTest : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_defaultWall = new WallCategory(new VkApi());
		}

		private WallCategory _defaultWall;

		private WallCategory GetMockedWallCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new WallCategory(Api);
		}

		[Test]

		[Ignore("")]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(() => _defaultWall.Delete(1, 1), Throws.InstanceOf<AccessTokenInvalidException>());
		}

		[Test]
		public void Get_Document_NormalCase()
		{
			const string url = "https://api.vk.com/method/wall.get";

			const string json =
					@"{
                    'response': {
                      'count': 100,
                      'items': [
                        {
                          'id': 1261,
                          'from_id': 26033241,
                          'owner_id': 26033241,
                          'date': 1383978467,
                          'post_type': 'post',
                          'text': '',
                          'attachments': [
                            {
                              'type': 'doc',
                              'doc': {
                                'id': 237844408,
                                'owner_id': 26033241,
                                'title': '2e857c8f-aaf8-4399-9856-e4fda3199e3d.gif',
                                'size': 2006654,
                                'ext': 'gif',
                                'url': 'http://vk.com/doc26033241_237844408?hash=126f761781ce2ebfc5&dl=f2c681ec7740f9a3a0&api=1',
                                'photo_100': 'http://cs537313.vk.me/u26033241/-3/s_48ba682f61.jpg',
                                'photo_130': 'http://cs537313.vk.me/u26033241/-3/m_48ba682f61.jpg',
                                'access_key': '5bf7103aa95aacb8ad'
                              }
                            }
                          ],
                          'post_source': {
                            'type': 'vk'
                          },
                          'comments': {
                            'count': 0,
                            'can_post': 0
                          },
                          'likes': {
                            'count': 7,
                            'user_likes': 0,
                            'can_like': 1,
                            'can_publish': 1
                          },
                          'reposts': {
                            'count': 0,
                            'user_reposted': 0
                          }
                        }
                      ]
                    }
                  }";

			var posts = GetMockedWallCategory(url, json)
					.Get(new WallGetParams
					{
							OwnerId = 26033241
							, Count = 1
							, Offset = 2
					});

			Assert.That(posts.TotalCount, Is.EqualTo(100u));
			Assert.That(posts.WallPosts[0].Attachments.Count, Is.EqualTo(1));
			var doc = (Document) posts.WallPosts[0].Attachment.Instance;
			Assert.That(doc, Is.Not.Null);
			Assert.That(doc.Id, Is.EqualTo(237844408));
			Assert.That(doc.OwnerId, Is.EqualTo(26033241));
			Assert.That(doc.Title, Is.EqualTo("2e857c8f-aaf8-4399-9856-e4fda3199e3d.gif"));
			Assert.That(doc.Size, Is.EqualTo(2006654));
			Assert.That(doc.Ext, Is.EqualTo("gif"));

			Assert.That(doc.Uri
					, Is.EqualTo(
							"http://vk.com/doc26033241_237844408?hash=126f761781ce2ebfc5&dl=f2c681ec7740f9a3a0&api=1"));

			Assert.That(doc.Photo100, Is.EqualTo("http://cs537313.vk.me/u26033241/-3/s_48ba682f61.jpg"));
			Assert.That(doc.Photo130, Is.EqualTo("http://cs537313.vk.me/u26033241/-3/m_48ba682f61.jpg"));
			Assert.That(doc.AccessKey, Is.EqualTo("5bf7103aa95aacb8ad"));
		}

		[Test]
		public void Get_ExtendedVersion_GenerateOutParametersCorrectly()
		{
			const string url = "https://api.vk.com/method/wall.get";

			const string json =
					@"{
                    'response': {
							count: 42,
							items: [{
								id: 41,
								from_id: 10,
								owner_id: 10,
								date: 1394002266,
								post_type: 'post',
								text: '',
								copy_history: [{
									id: 93530,
									owner_id: -29246653,
									from_id: -29246653,
									date: 1393956845,
									post_type: 'post',
									text: '',
									attachments: [{
										type: 'photo',
										photo: {
										id: 323086640,
										album_id: -7,
										owner_id: -29246653,
										user_id: 100,
										photo_75: 'http://cs413130.vk.me/v413130344/9563/Dr-sxoSsoBs.jpg',
										photo_130: 'http://cs413130.vk.me/v413130344/9564/k2jeOxwxgr4.jpg',
										photo_604: 'http://cs413130.vk.me/v413130344/9565/jCLiluawfXE.jpg',
										width: 604,
										height: 348,
										text: '',
										date: 1393956845,
										post_id: 93530
										}
									}],
									post_source: {
										type: 'api'
									}
								}],
								can_delete: 1,
								post_source: {
									type: 'api'
								},
								comments: {
									count: 0,
									can_post: 1
								},
								likes: {
									count: 1,
									user_likes: 0,
									can_like: 1,
									can_publish: 0
								},
								reposts: {
									count: 0,
									user_reposted: 0
								}
							}],

							profiles: [{
							id: 10,
							first_name: 'Иван',
							last_name: 'Иванов',
							sex: 2,
							online: 0
							}],

							groups: [{
							id: 29246653,
							name: 'Корпорация Зла',
							screen_name: 'evil_incorparate',
							is_closed: 0,
							type: 'page',
							is_admin: 0,
							is_member: 1,
							photo_50: 'http://cs409529.vk.me/v409529400/98d2/3OMudmIl7gY.jpg',
							photo_100: 'http://cs409529.vk.me/v409529400/98d1/dFkKFf-xWIw.jpg',
							photo_200: 'http://cs409529.vk.me/v409529400/98cd/xHrEeHMSXQQ.jpg'
							}]
							}
                  }";

			// 10, out posts, out profiles, out groups, 1, 1, WallFilter.Owner
			var count = GetMockedWallCategory(url, json)
					.Get(new WallGetParams
					{
							OwnerId = 10
							, Count = 1
							, Offset = 1
							, Filter = WallFilter.Owner
					});

			Assert.That(count.TotalCount, Is.EqualTo(42));

			Assert.That(count.WallPosts.Count, Is.EqualTo(1));
			Assert.That(count.WallPosts[0].Id, Is.EqualTo(41));

			Assert.That(count.Profiles.Count, Is.EqualTo(1));
			Assert.That(count.Profiles[0].Id, Is.EqualTo(10));

			Assert.That(count.Groups.Count, Is.EqualTo(1));
			Assert.That(count.Groups[0].Id, Is.EqualTo(29246653));
		}

		[Test]
		[Ignore("undone")]
		public void Get_Geo_NormalCase()
		{
			const string url = "https://api.vk.com/method/wall.get";

			const string json =
					@"{
                    'response': {
                      'count': 165,
                      'items': [
                        {
                          'id': 1164,
                          'from_id': 1563369,
                          'owner_id': 1563369,
                          'date': 1397915906,
                          'post_type': 'post',
                          'text': '',
                          'copy_history': [
                            {
                              'id': 128,
                              'owner_id': -42895313,
                              'from_id': -42895313,
                              'date': 1397915146,
                              'post_type': 'post',
                              'text': 'Мы оформляем храм...\n#пасха #весна #праздник #цветы #храм',
                              'attachments': [


                                {
                                  'type': 'poll',
                                  'poll': {
                                    'id': 133455339,
                                    'owner_id': -42895313,
                                    'created': 1397915146,
                                    'question': 'А вы как готовитесь к Пасхе?',
                                    'votes': 6,
                                    'answer_id': 0,
                                    'answers': [
                                      {
                                        'id': 430631442,
                                        'text': 'Красим яйца, печем куличи',
                                        'votes': 4,
                                        'rate': 66.67
                                      },
                                      {
                                        'id': 430631443,
                                        'text': 'Пойдем в храм освящать куличи',
                                        'votes': 0,
                                        'rate': 0.0
                                      },
                                      {
                                        'id': 430631444,
                                        'text': 'Готовим праздничный обед',
                                        'votes': 1,
                                        'rate': 16.67
                                      },
                                      {
                                        'id': 430631445,
                                        'text': 'Никак не готовлюсь, это праздник не для меня...',
                                        'votes': 1,
                                        'rate': 16.67
                                      },
                                      {
                                        'id': 430631446,
                                        'text': 'Ваш вариант в комментарии',
                                        'votes': 0,
                                        'rate': 0.0
                                      }
                                    ],
                                    'anonymous': 1
                                  }
                                }
                              ],
                              'geo': {
                                'type': 'point',
                                'coordinates': '47.282735079717 39.697793677442',
                                'place': {
                                  'id': 0,
                                  'title': 'Neklinovskiy pereulok, Rostov-na-Donu',
                                  'latitude': 0.0,
                                  'longitude': 0.0,
                                  'created': 0,
                                  'icon': 'http://vk.com/images/places/place.png',
                                  'country': 'Russian Federation',
                                  'city': 'Rostov-na-Donu'
                                },
                                'showmap': 1
                              },
                              'post_source': {
                                'type': 'vk'
                              }
                            }
                          ],
                          'post_source': {
                            'type': 'vk'
                          },
                          'comments': {
                            'count': 0,
                            'can_post': 1
                          },
                          'likes': {
                            'count': 1,
                            'user_likes': 0,
                            'can_like': 1,
                            'can_publish': 1
                          },
                          'reposts': {
                            'count': 0,
                            'user_reposted': 0
                          }
                        }
                      ]
                    }
                  }";

			var posts = GetMockedWallCategory(url, json)
					.Get(new WallGetParams
					{
							OwnerId = 1563369
							, Count = 3
							, Offset = 2
					});

			Assert.That(posts.TotalCount, Is.EqualTo(165));
			Assert.That(posts, Is.Not.Null);

			Assert.Fail("undone");
		}

		[Test]
		public void Get_With_PhotoListAttachment()
		{
			const string url = "https://api.vk.com/method/wall.get";

			const string json =
					@"{
                    'response': {
                      'count': 1724,
                      'items': [
                        {
                          'id': 3188,
                          'from_id': 46476924,
                          'owner_id': 46476924,
                          'date': 1359992640,
                          'post_type': 'post',
                          'text': '',
                          'copy_history': [
                            {
                              'id': 2569,
                              'owner_id': 91781360,
                              'from_id': 91781360,
                              'date': 1358240377,
                              'post_type': 'post',
                              'text': 'Закрыл стол! 130000 тыс, чуть больше месяца.',
                              'attachments': [
                                {
                                  'type': 'photos_list',
                                  'photos_list': null
                                }
                              ],
                              'post_source': {
                                'type': 'vk'
                              }
                            }
                          ],
                          'post_source': {
                            'type': 'vk'
                          },
                          'comments': {
                            'count': 0,
                            'can_post': 0
                          },
                          'likes': {
                            'count': 5,
                            'user_likes': 0,
                            'can_like': 1,
                            'can_publish': 1
                          },
                          'reposts': {
                            'count': 0,
                            'user_reposted': 0
                          }
                        }
                      ]
                    }
                  }";

			var posts = GetMockedWallCategory(url, json)
					.Get(new WallGetParams
					{
							OwnerId = 46476924
							, Count = 1
							, Offset = 213
							, Filter = WallFilter.Owner
					});

			Assert.That(posts.TotalCount, Is.EqualTo(1724));
			Assert.That(posts.WallPosts, Is.Not.Null);
			Assert.That(posts.WallPosts.Count, Is.EqualTo(1));
			Assert.That(posts.WallPosts[0].CopyHistory, Is.Not.Null);
			Assert.That(posts.WallPosts[0].CopyHistory.Count, Is.EqualTo(1));

			var attach = posts.WallPosts[0].CopyHistory[0].Attachment;
			Assert.That(attach, Is.Not.Null);
			Assert.That(attach.Instance, Is.Null);
		}

		[Test]
		public void Get_WithPoll_NormalCase()
		{
			const string url = "https://api.vk.com/method/wall.get";

			const string json =
					@"{
					response: {
					count: 2,
					items: [{
						id: 3,
						from_id: -103292418,
						owner_id: -103292418,
						date: 1447252575,
						post_type: 'post',
						text: 'Тест',
						can_delete: 1,
						can_pin: 1,
						post_source: {
							type: 'api'
						},
						comments: {
							count: 0,
							can_post: 1
						},
						likes: {
							count: 0,
							user_likes: 0,
							can_like: 1,
							can_publish: 1
						},
						reposts: {
							count: 0,
							user_reposted: 0
						}
					}]
				}
			}";

			var posts = GetMockedWallCategory(url, json)
					.Get(new WallGetParams
					{
							OwnerId = -103292418
							, Count = 1
					});

			Assert.That(posts.TotalCount, Is.EqualTo(2u));
			Assert.That(posts.WallPosts.Count, Is.EqualTo(1));

			var post = posts.WallPosts.FirstOrDefault();
			Assert.That(post, Is.Not.Null);

			Assert.That(post.Id, Is.EqualTo(3));
			Assert.That(post.FromId, Is.EqualTo(-103292418));
			Assert.That(post.OwnerId, Is.EqualTo(-103292418));
			Assert.That(post.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1447252575)));
			Assert.That(post.PostType, Is.EqualTo(PostType.Post));
			Assert.That(post.Text, Is.EqualTo("Тест"));
			Assert.That(post.CanDelete, Is.True);
			Assert.That(post.CanEdit, Is.False);
			Assert.That(post.PostSource.Type, Is.EqualTo(PostSourceType.Api));
			Assert.That(post.Comments, Is.Not.Null);
			Assert.That(post.Comments.Count, Is.EqualTo(0));
			Assert.That(post.Likes.Count, Is.EqualTo(0));
			Assert.That(post.Likes.UserLikes, Is.False);
			Assert.That(post.Likes.CanLike, Is.True);
			Assert.That(post.Likes.CanPublish, Is.EqualTo(true));
			Assert.That(post.Reposts.Count, Is.EqualTo(0));
			Assert.That(post.Reposts.UserReposted, Is.False);
		}

		[Ignore("")]
		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(() => _defaultWall.GetById(new[]
					{
							"93388_21539"
							, "93388_20904"
							, "2943_4276"
					})
					, Throws.TypeOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_IncorrectParameters_ThrowException()
		{
			Assert.That(() => _defaultWall.GetById(null), Throws.TypeOf<ArgumentNullException>());
			Assert.That(() => _defaultWall.GetById(Enumerable.Empty<string>()), Throws.TypeOf<ArgumentException>());
		}

		[Test]
		public void GetById_ReturnWallRecords()
		{
			const string url = "https://api.vk.com/method/wall.getById";

			const string json =
					@"{
                    response: [{
						id: 617,
						from_id: 1,
						owner_id: 1,
						date: 1171758699,
						post_type: 'post',
						text: '',
						post_source: {
							type: 'vk'
						},
						comments: {
							count: 0,
							can_post: 1
						},
						likes: {
							count: 2,
							user_likes: 0,
							can_like: 1,
							can_publish: 0
						},
						reposts: {
							count: 0,
							user_reposted: 0
						}
					}]
                  }";

			var records = GetMockedWallCategory(url, json)
					.GetById(new[]
					{
							"1_619"
							, "1_617"
							, "1_616"
					});

			Assert.That(records.TotalCount == 1);

			Assert.That(records.WallPosts[0].Id, Is.EqualTo(617));
			Assert.That(records.WallPosts[0].FromId, Is.EqualTo(1));
			Assert.That(records.WallPosts[0].OwnerId, Is.EqualTo(1));

			Assert.That(records.WallPosts[0].Date
					, Is.EqualTo(new DateTime(1970
							, 1
							, 1
							, 0
							, 0
							, 0
							, 0
							, DateTimeKind.Utc).AddSeconds(1171758699)));

			Assert.That(records.WallPosts[0].Text, Is.Null.Or.Empty);
			Assert.That(records.WallPosts[0].Comments.Count == 0);
			Assert.That(records.WallPosts[0].Comments.CanPost, Is.True);
			Assert.That(records.WallPosts[0].Likes.Count, Is.EqualTo(2));
			Assert.That(records.WallPosts[0].Likes.UserLikes, Is.False);
			Assert.That(records.WallPosts[0].Likes.CanLike, Is.True);
			Assert.That(records.WallPosts[0].Likes.CanPublish, Is.False);
			Assert.That(records.WallPosts[0].Reposts.Count, Is.EqualTo(0));
			Assert.That(records.WallPosts[0].Reposts.UserReposted, Is.False);
		}

		[Test]
		public void GetComments_ReturnLikesAndAttachments()
		{
			const string url = "https://api.vk.com/method/wall.getComments";

			const string json =
					@"{
                    'response': {
                      'count': 2,
                      'items': [{
                        'id': 3809,
                        'from_id': 6733856,
                        'date': 1385099144,
                        'text': 'Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!',
                        'likes': {
                          'count': 1
                        }
                      },
                      {
                        'id': 3810,
                        'from_id': 3073863,
                        'date': 1385101266,
                        'text': 'C днем рождения малышку и родителей!!!',
                        'likes': {
                          'count': 1
                        },
                        'attachments': [
                          {
                            'type': 'photo',
                            'photo': {
                              'id': 315467755,
                              'album_id': -5,
                              'owner_id': 3073863,
                              'photo_130': 'http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg',
                              'photo_604': 'http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg',
                              'photo_75': 'http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg',
                              'width': 510,
                              'height': 383,
                              'text': '',
                              'date': 1385101231,
                              'access_key': 'ade2532c6a39c12be6'
                            }
                          }
                        ]
                      } ]
                    }
                  }";

			var comments = GetMockedWallCategory(url, json)
					.GetComments(new WallGetCommentsParams
					{
							OwnerId = 12312
							, PostId = 12345
							, Sort = SortOrderBy.Asc
							, NeedLikes = true
					});

			Assert.That(comments.TotalCount, Is.EqualTo(2));
			Assert.That(comments.Count, Is.EqualTo(2));

			var comment0 = comments[0];
			Assert.That(comment0.Id, Is.EqualTo(3809));
			Assert.That(comment0.FromId, Is.EqualTo(6733856));

			Assert.That(comment0.Date
					, Is.EqualTo(new DateTime(2013
							, 11
							, 22
							, 05
							, 45
							, 44
							, DateTimeKind.Utc)));

			Assert.That(comment0.Text
					, Is.EqualTo("Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!"));

			Assert.That(comment0.Likes, Is.Not.Null);
			Assert.That(comment0.Likes.Count, Is.EqualTo(1));

			var comment1 = comments[1];
			Assert.That(comment1.Id, Is.EqualTo(3810));
			Assert.That(comment1.FromId, Is.EqualTo(3073863));

			Assert.That(comment1.Date
					, Is.EqualTo(new DateTime(2013
							, 11
							, 22
							, 6
							, 21
							, 06
							, DateTimeKind.Utc)));

			Assert.That(comment1.Text, Is.EqualTo("C днем рождения малышку и родителей!!!"));
			Assert.That(comment1.Likes, Is.Not.Null);
			Assert.That(comment1.Likes.Count, Is.EqualTo(1));

			var attachment = comment1.Attachment;
			Assert.That(attachment, Is.Not.Null);
			Assert.That(attachment.Type, Is.EqualTo(typeof(Photo)));

			var photo = (Photo) attachment.Instance;
			Assert.That(photo.Id, Is.EqualTo(315467755));
			Assert.That(photo.AlbumId, Is.EqualTo(-5));
			Assert.That(photo.OwnerId, Is.EqualTo(3073863));

			Assert.That(photo.Photo130
					, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg")));

			Assert.That(photo.Photo604
					, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg")));

			Assert.That(photo.Photo75
					, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg")));

			Assert.That(photo.Photo807, Is.Null);
			Assert.That(photo.Photo1280, Is.Null);
			Assert.That(photo.Width, Is.EqualTo(510));
			Assert.That(photo.Height, Is.EqualTo(383));
			Assert.That(photo.Text, Is.EqualTo(string.Empty));

			Assert.That(photo.CreateTime
					, Is.EqualTo(new DateTime(2013
							, 11
							, 22
							, 6
							, 20
							, 31
							, DateTimeKind.Utc)));
		}

		[Test]
		public void Repost_ReturnCorrectResults()
		{
			const string url = "https://api.vk.com/method/wall.repost";

			const string json =
					@"{
                    'response': {
						success: 1,
						post_id: 2587,
						reposts_count: 21,
						likes_count: 105
					} }";

			var result = GetMockedWallCategory(url, json).Repost("id", null, null, false);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Success, Is.True);
			Assert.That(result.PostId, Is.EqualTo(2587));
			Assert.That(result.RepostsCount, Is.EqualTo(21));
			Assert.That(result.LikesCount, Is.EqualTo(105));
		}

		[Test]
		public void Repost_UrlIsGeneratedCorrectly()
		{
			const string url = "https://api.vk.com/method/wall.repost";

			const string json =
					@"{
                    'response': {
						success: 1,
						post_id: 2587,
						reposts_count: 21,
						likes_count: 105
					} }";

			var result = GetMockedWallCategory(url, json)
					.Repost("id", "example", 50, false);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Success, Is.True);
			Assert.That(result.PostId, Is.EqualTo(2587));
			Assert.That(result.RepostsCount, Is.EqualTo(21));
			Assert.That(result.LikesCount, Is.EqualTo(105));
		}
	}
}