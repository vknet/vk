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

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[SuppressMessage(category: "ReSharper", checkId: "PublicMembersMustHaveComments")]
	public class WallCategoryTest : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			_defaultWall = new WallCategory(vk: new VkApi());
		}

		private WallCategory _defaultWall;

		private WallCategory GetMockedWallCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new WallCategory(vk: Api);
		}

		[Test]

		//[Ignore("")]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(del: () => _defaultWall.Delete(ownerId: 1, postId: 1), expr: Throws.InstanceOf<AccessTokenInvalidException>());
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

			var posts = GetMockedWallCategory(url: url, json: json)
					.Get(@params: new WallGetParams
					{
							OwnerId = 26033241
							, Count = 1
							, Offset = 2
					});

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 100u));
			Assert.That(actual: posts.WallPosts[index: 0].Attachments.Count, expression: Is.EqualTo(expected: 1));
			var doc = (Document) posts.WallPosts[index: 0].Attachment.Instance;
			Assert.That(actual: doc, expression: Is.Not.Null);
			Assert.That(actual: doc.Id, expression: Is.EqualTo(expected: 237844408));
			Assert.That(actual: doc.OwnerId, expression: Is.EqualTo(expected: 26033241));
			Assert.That(actual: doc.Title, expression: Is.EqualTo(expected: "2e857c8f-aaf8-4399-9856-e4fda3199e3d.gif"));
			Assert.That(actual: doc.Size, expression: Is.EqualTo(expected: 2006654));
			Assert.That(actual: doc.Ext, expression: Is.EqualTo(expected: "gif"));

			Assert.That(actual: doc.Uri
					, expression: Is.EqualTo(
							expected: "http://vk.com/doc26033241_237844408?hash=126f761781ce2ebfc5&dl=f2c681ec7740f9a3a0&api=1"));

			Assert.That(actual: doc.Photo100, expression: Is.EqualTo(expected: "http://cs537313.vk.me/u26033241/-3/s_48ba682f61.jpg"));
			Assert.That(actual: doc.Photo130, expression: Is.EqualTo(expected: "http://cs537313.vk.me/u26033241/-3/m_48ba682f61.jpg"));
			Assert.That(actual: doc.AccessKey, expression: Is.EqualTo(expected: "5bf7103aa95aacb8ad"));
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
			var count = GetMockedWallCategory(url: url, json: json)
					.Get(@params: new WallGetParams
					{
							OwnerId = 10
							, Count = 1
							, Offset = 1
							, Filter = WallFilter.Owner
					});

			Assert.That(actual: count.TotalCount, expression: Is.EqualTo(expected: 42));

			Assert.That(actual: count.WallPosts.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: count.WallPosts[index: 0].Id, expression: Is.EqualTo(expected: 41));

			Assert.That(actual: count.Profiles.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: count.Profiles[index: 0].Id, expression: Is.EqualTo(expected: 10));

			Assert.That(actual: count.Groups.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: count.Groups[index: 0].Id, expression: Is.EqualTo(expected: 29246653));
		}

		[Test]
		[Ignore(reason: "undone")]
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

			var posts = GetMockedWallCategory(url: url, json: json)
					.Get(@params: new WallGetParams
					{
							OwnerId = 1563369
							, Count = 3
							, Offset = 2
					});

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 165));
			Assert.That(actual: posts, expression: Is.Not.Null);

			Assert.Fail(message: "undone");
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

			var posts = GetMockedWallCategory(url: url, json: json)
					.Get(@params: new WallGetParams
					{
							OwnerId = 46476924
							, Count = 1
							, Offset = 213
							, Filter = WallFilter.Owner
					});

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 1724));
			Assert.That(actual: posts.WallPosts, expression: Is.Not.Null);
			Assert.That(actual: posts.WallPosts.Count, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: posts.WallPosts[index: 0].CopyHistory, expression: Is.Not.Null);
			Assert.That(actual: posts.WallPosts[index: 0].CopyHistory.Count, expression: Is.EqualTo(expected: 1));

			var attach = posts.WallPosts[index: 0].CopyHistory[index: 0].Attachment;
			Assert.That(actual: attach, expression: Is.Not.Null);
			Assert.That(actual: attach.Instance, expression: Is.Null);
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

			var posts = GetMockedWallCategory(url: url, json: json)
					.Get(@params: new WallGetParams
					{
							OwnerId = -103292418
							, Count = 1
					});

			Assert.That(actual: posts.TotalCount, expression: Is.EqualTo(expected: 2u));
			Assert.That(actual: posts.WallPosts.Count, expression: Is.EqualTo(expected: 1));

			var post = posts.WallPosts.FirstOrDefault();
			Assert.That(actual: post, expression: Is.Not.Null);

			Assert.That(actual: post.Id, expression: Is.EqualTo(expected: 3));
			Assert.That(actual: post.FromId, expression: Is.EqualTo(expected: -103292418));
			Assert.That(actual: post.OwnerId, expression: Is.EqualTo(expected: -103292418));
			Assert.That(actual: post.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1447252575)));
			Assert.That(actual: post.PostType, expression: Is.EqualTo(expected: PostType.Post));
			Assert.That(actual: post.Text, expression: Is.EqualTo(expected: "Тест"));
			Assert.That(actual: post.CanDelete, expression: Is.True);
			Assert.That(actual: post.CanEdit, expression: Is.False);
			Assert.That(actual: post.PostSource.Type, expression: Is.EqualTo(expected: PostSourceType.Api));
			Assert.That(actual: post.Comments, expression: Is.Not.Null);
			Assert.That(actual: post.Comments.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: post.Likes.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: post.Likes.UserLikes, expression: Is.False);
			Assert.That(actual: post.Likes.CanLike, expression: Is.True);
			Assert.That(actual: post.Likes.CanPublish, expression: Is.EqualTo(expected: true));
			Assert.That(actual: post.Reposts.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: post.Reposts.UserReposted, expression: Is.False);
		}

		[Test]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			Assert.That(del: () => _defaultWall.GetById(posts: new[]
					{
							"93388_21539"
							, "93388_20904"
							, "2943_4276"
					})
					, expr: Throws.TypeOf<AccessTokenInvalidException>());
		}

		[Test]
		public void GetById_IncorrectParameters_ThrowException()
		{
			Assert.That(del: () => _defaultWall.GetById(posts: null), expr: Throws.TypeOf<ArgumentNullException>());
			Assert.That(del: () => _defaultWall.GetById(posts: Enumerable.Empty<string>()), expr: Throws.TypeOf<ArgumentException>());
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

			var records = GetMockedWallCategory(url: url, json: json)
					.GetById(posts: new[]
					{
							"1_619"
							, "1_617"
							, "1_616"
					});

			Assert.That(condition: records.TotalCount == 1);

			Assert.That(actual: records.WallPosts[index: 0].Id, expression: Is.EqualTo(expected: 617));
			Assert.That(actual: records.WallPosts[index: 0].FromId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: records.WallPosts[index: 0].OwnerId, expression: Is.EqualTo(expected: 1));

			Assert.That(actual: records.WallPosts[index: 0].Date
					, expression: Is.EqualTo(expected: new DateTime(year: 1970
							, month: 1
							, day: 1
							, hour: 0
							, minute: 0
							, second: 0
							, millisecond: 0
							, kind: DateTimeKind.Utc).AddSeconds(value: 1171758699)));

			Assert.That(actual: records.WallPosts[index: 0].Text, expression: Is.Null.Or.Empty);
			Assert.That(condition: records.WallPosts[index: 0].Comments.Count == 0);
			Assert.That(actual: records.WallPosts[index: 0].Comments.CanPost, expression: Is.True);
			Assert.That(actual: records.WallPosts[index: 0].Likes.Count, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: records.WallPosts[index: 0].Likes.UserLikes, expression: Is.False);
			Assert.That(actual: records.WallPosts[index: 0].Likes.CanLike, expression: Is.True);
			Assert.That(actual: records.WallPosts[index: 0].Likes.CanPublish, expression: Is.False);
			Assert.That(actual: records.WallPosts[index: 0].Reposts.Count, expression: Is.EqualTo(expected: 0));
			Assert.That(actual: records.WallPosts[index: 0].Reposts.UserReposted, expression: Is.False);
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

			var comments = GetMockedWallCategory(url: url, json: json)
					.GetComments(@params: new WallGetCommentsParams
					{
							OwnerId = 12312
							, PostId = 12345
							, Sort = SortOrderBy.Asc
							, NeedLikes = true
					});

			Assert.That(actual: comments.TotalCount, expression: Is.EqualTo(expected: 2));
			Assert.That(actual: comments.Count, expression: Is.EqualTo(expected: 2));

			var comment0 = comments[index: 0];
			Assert.That(actual: comment0.Id, expression: Is.EqualTo(expected: 3809));
			Assert.That(actual: comment0.FromId, expression: Is.EqualTo(expected: 6733856));

			Assert.That(actual: comment0.Date
					, expression: Is.EqualTo(expected: new DateTime(year: 2013
							, month: 11
							, day: 22
							, hour: 05
							, minute: 45
							, second: 44
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: comment0.Text
					, expression: Is.EqualTo(expected: "Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!"));

			Assert.That(actual: comment0.Likes, expression: Is.Not.Null);
			Assert.That(actual: comment0.Likes.Count, expression: Is.EqualTo(expected: 1));

			var comment1 = comments[index: 1];
			Assert.That(actual: comment1.Id, expression: Is.EqualTo(expected: 3810));
			Assert.That(actual: comment1.FromId, expression: Is.EqualTo(expected: 3073863));

			Assert.That(actual: comment1.Date
					, expression: Is.EqualTo(expected: new DateTime(year: 2013
							, month: 11
							, day: 22
							, hour: 6
							, minute: 21
							, second: 06
							, kind: DateTimeKind.Utc)));

			Assert.That(actual: comment1.Text, expression: Is.EqualTo(expected: "C днем рождения малышку и родителей!!!"));
			Assert.That(actual: comment1.Likes, expression: Is.Not.Null);
			Assert.That(actual: comment1.Likes.Count, expression: Is.EqualTo(expected: 1));

			var attachment = comment1.Attachment;
			Assert.That(actual: attachment, expression: Is.Not.Null);
			Assert.That(actual: attachment.Type, expression: Is.EqualTo(expected: typeof(Photo)));

			var photo = (Photo) attachment.Instance;
			Assert.That(actual: photo.Id, expression: Is.EqualTo(expected: 315467755));
			Assert.That(actual: photo.AlbumId, expression: Is.EqualTo(expected: -5));
			Assert.That(actual: photo.OwnerId, expression: Is.EqualTo(expected: 3073863));

			Assert.That(actual: photo.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg")));

			Assert.That(actual: photo.Photo604
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg")));

			Assert.That(actual: photo.Photo75
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg")));

			Assert.That(actual: photo.Photo807, expression: Is.Null);
			Assert.That(actual: photo.Photo1280, expression: Is.Null);
			Assert.That(actual: photo.Width, expression: Is.EqualTo(expected: 510));
			Assert.That(actual: photo.Height, expression: Is.EqualTo(expected: 383));
			Assert.That(actual: photo.Text, expression: Is.EqualTo(expected: string.Empty));

			Assert.That(actual: photo.CreateTime
					, expression: Is.EqualTo(expected: new DateTime(year: 2013
							, month: 11
							, day: 22
							, hour: 6
							, minute: 20
							, second: 31
							, kind: DateTimeKind.Utc)));
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

			var result = GetMockedWallCategory(url: url, json: json).Repost(@object: "id", message: null, groupId: null, markAsAds: false);

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Success, expression: Is.True);
			Assert.That(actual: result.PostId, expression: Is.EqualTo(expected: 2587));
			Assert.That(actual: result.RepostsCount, expression: Is.EqualTo(expected: 21));
			Assert.That(actual: result.LikesCount, expression: Is.EqualTo(expected: 105));
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

			var result = GetMockedWallCategory(url: url, json: json)
					.Repost(@object: "id", message: "example", groupId: 50, markAsAds: false);

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Success, expression: Is.True);
			Assert.That(actual: result.PostId, expression: Is.EqualTo(expected: 2587));
			Assert.That(actual: result.RepostsCount, expression: Is.EqualTo(expected: 21));
			Assert.That(actual: result.LikesCount, expression: Is.EqualTo(expected: 105));
		}
	}
}