using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class WallCategoryTest
	{
		private WallCategory _defaultWall;

		[SetUp]
		public void SetUp()
		{
			_defaultWall = new WallCategory(new VkApi());
		}

		private WallCategory GetMockedWallCategory(string url, string json)
		{
			var mock = new Mock<IBrowser>(MockBehavior.Strict);
			mock.Setup(m => m.GetJson(url)).Returns(json);

			return new WallCategory(new VkApi { AccessToken = "token", Browser = mock.Object });
		}

		#region Wall.Get

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			int totalCount;
			_defaultWall.Get(1, out totalCount);

			ReadOnlyCollection<Post> posts;
			ReadOnlyCollection<User> profiles;
			ReadOnlyCollection<Group> groups;
			_defaultWall.GetExtended(1, out posts, out profiles, out groups);
		}

		[Test]
		public void Get_IncorrectParameters_ThrowArgumentException()
		{
			int totalCount;
			Assert.That(() => _defaultWall.Get(1, out totalCount, count: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("count"));
			Assert.That(() => _defaultWall.Get(1, out totalCount, offset: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("offset"));
			Assert.That(() => _defaultWall.Get(1, out totalCount, filter: WallFilter.Suggests), Throws.ArgumentException.And.Property("ParamName").EqualTo("ownerId"));

			ReadOnlyCollection<Post> posts;
			ReadOnlyCollection<User> profiles;
			ReadOnlyCollection<Group> groups;
			Assert.That(() => _defaultWall.GetExtended(1, out posts, out profiles, out groups, count: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("count"));
			Assert.That(() => _defaultWall.GetExtended(1, out posts, out profiles, out groups, offset: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("offset"));
			Assert.That(() => _defaultWall.GetExtended(1, out posts, out profiles, out groups, filter: WallFilter.Suggests), Throws.ArgumentException.And.Property("ParamName").EqualTo("ownerId"));
		}

		[Test]
		public void Get_DefaultFields_ReturnBasicInfo()
		{
			const string url =
			    "https://api.vk.com/method/wall.get?owner_id=1&count=3&offset=5&filter=owner&access_token=token";
			const string json = @"{
                    'response': [
                      137,
                      {
                        'id': 619,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1341145268,
                        'text': 'Фильмы ужасов, основанные на реальных событиях.',
                        'copy_owner_id': 50915841,
                        'copy_post_id': 1374,
                        'media': {
                          'type': 'photo',
                          'owner_id': 50915841,
                          'item_id': 283337039,
                          'thumb_src': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg'
                        },
                        'attachment': {
                          'type': 'photo',
                          'photo': {
                            'id': 283337039,
                            'album_id': -7,
                            'owner_id': 50915841,
                            'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                            'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                            'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                            'width': 450,
                            'height': 320,
                            'text': '',
                            'date': 1337542384,
                            'access_key': 'e377d6e0b55e299741'
                          }
                        },
                        'attachments': [
                          {
                            'type': 'photo',
                            'photo': {
                              'id': 283337039,
                              'album_id': -7,
                              'owner_id': 50915841,
                              'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                              'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                              'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                              'width': 450,
                              'height': 320,
                              'text': '',
                              'date': 1337542384,
                              'access_key': 'e377d6e0b55e299741'
                            }
                          },
                          {
                            'type': 'link',
                            'link': {
                              'url': 'http://vk.com/link',
                              'title': 'Любой заголово',
                              'description': 'Любое описание',
                              'image_src': 'http://vk.com/images/any.gif'
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 1,
                          'can_like': 0,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 617,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339684666,
                        'text': '',
                        'media': {
                          'type': 'audio',
                          'owner_id': 4793858,
                          'item_id': 154701206
                        },
                        'attachment': {
                          'type': 'audio',
                          'audio': {
                            'id': 154701206,
                            'owner_id': 4793858,
                            'performer': 'Мук',
                            'title': 'Дорогою добра',
                            'duration': 130
                          }
                        },
                        'attachments': [
                          {
                            'type': 'audio',
                            'audio': {
                              'id': 154701206,
                              'owner_id': 4793858,
                              'performer': 'Мук',
                              'title': 'Дорогою добра',
                              'duration': 130
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 0,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 616,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339227157,
                        'text': 'Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было.',
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      }
                    ]
                  }";

			int totalCount;
			var records = GetMockedWallCategory(url, json).Get(1, out totalCount, 3, 5, WallFilter.Owner);

			Assert.That(totalCount, Is.EqualTo(137));
			Assert.That(records.Count == 3);

			Assert.That(records[1].Attachment.Type == typeof(Audio));
			//var audio = (Audio) records[1].Attachment.GetAttachment();
			var audio = (Audio)records[1].Attachment.Instance;

			Assert.That(audio.Id, Is.EqualTo(154701206));
			Assert.That(audio.OwnerId, Is.EqualTo(4793858));
			Assert.That(audio.Title, Is.EqualTo("Дорогою добра"));
			Assert.That(audio.Duration, Is.EqualTo(130));

			Assert.That(records[1].Id, Is.EqualTo(617));
			Assert.That(records[1].FromId, Is.EqualTo(4793858));
			Assert.That(records[1].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[1].Date, Is.EqualTo(new DateTime(2012, 6, 14, 18, 37, 46)));
			Assert.That(records[1].Text, Is.Null.Or.Empty);
			Assert.That(records[1].Comments.Count == 0);
			Assert.That(records[1].Comments.CanPost, Is.True);
			Assert.That(records[1].Likes.Count, Is.EqualTo(0));
			Assert.That(records[1].Likes.UserLikes, Is.False);
			Assert.That(records[1].Likes.CanLike, Is.True);
			Assert.That(records[1].Likes.CanPublish, Is.False);
			Assert.That(records[1].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[1].Reposts.UserReposted, Is.False);

			Assert.That(records[2].Id, Is.EqualTo(616));
			Assert.That(records[2].FromId, Is.EqualTo(4793858));
			Assert.That(records[2].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[2].Date, Is.EqualTo(new DateTime(2012, 6, 9, 11, 32, 37)));
			Assert.That(records[2].Text,
						Is.EqualTo("Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было."));
			Assert.That(records[2].Comments.Count, Is.EqualTo(0));
			Assert.That(records[2].Comments.CanPost, Is.True);
			Assert.That(records[2].Likes.Count, Is.EqualTo(1));
			Assert.That(records[2].Likes.UserLikes, Is.False);
			Assert.That(records[2].Likes.CanLike, Is.True);
			Assert.That(records[2].Likes.CanPublish, Is.False);
			Assert.That(records[2].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[2].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Id, Is.EqualTo(619));
			Assert.That(records[0].FromId, Is.EqualTo(4793858));
			Assert.That(records[0].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[0].Date, Is.EqualTo(new DateTime(2012, 7, 1, 16, 21, 8)));
			Assert.That(records[0].Text, Is.EqualTo("Фильмы ужасов, основанные на реальных событиях."));
			Assert.That(records[0].CopyOwnerId, Is.EqualTo(50915841));
			Assert.That(records[0].CopyPostId, Is.EqualTo(1374));
			Assert.That(records[0].Comments.Count, Is.EqualTo(0));
			Assert.That(records[0].Comments.CanPost, Is.True);
			Assert.That(records[0].Likes.Count, Is.EqualTo(1));
			Assert.That(records[0].Likes.UserLikes, Is.True);
			Assert.That(records[0].Likes.CanLike, Is.False);
			Assert.That(records[0].Likes.CanPublish, Is.False);
			Assert.That(records[0].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[0].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Attachment.Type == typeof(Photo));
			var photo = (Photo)records[0].Attachment.Instance;
			Assert.That(photo.Id, Is.EqualTo(283337039));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(50915841));
			Assert.That(photo.Photo130.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg"));
			Assert.That(photo.Photo604.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg"));
			Assert.That(photo.Photo75.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg"));
			Assert.That(photo.Width, Is.EqualTo(450));
			Assert.That(photo.Height, Is.EqualTo(320));
			Assert.That(photo.Text, Is.Null.Or.Empty);
			Assert.That(photo.CreateTime, Is.EqualTo(new DateTime(2012, 05, 20, 23, 33, 04)));
			//Assert.That(records[0]., Is.EqualTo());

			Assert.That(records[0].Attachments.Count(), Is.EqualTo(2));
			var attach1 = (Photo)records[0].Attachments.ElementAt(0).Instance;
			Assert.That(attach1.Id, Is.EqualTo(283337039));
			var attach2 = (Link)records[0].Attachments.ElementAt(1).Instance;
			Assert.That(attach2.Url, Is.EqualTo(new Uri("http://vk.com/link")));

			Assert.That(records[1].Attachments.Count(), Is.EqualTo(1));
			var attach3 = (Audio)records[1].Attachments.ElementAt(0).Instance;
			Assert.That(attach3.Id, Is.EqualTo(154701206));
		}

		[Test]
		public void Get_ExtendedVersion_GenerateOutParametersCorrectly()
		{
			const string url =
			    "https://api.vk.com/method/wall.get?owner_id=10&count=1&offset=1&filter=owner&extended=1&access_token=token";
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

			ReadOnlyCollection<Post> posts;
			ReadOnlyCollection<User> profiles;
			ReadOnlyCollection<Group> groups;
			var count = GetMockedWallCategory(url, json).GetExtended(10, out posts, out profiles, out groups, 1, 1, WallFilter.Owner);
			Assert.That(count, Is.EqualTo(42));

			Assert.That(posts.Count, Is.EqualTo(1));
			Assert.That(posts[0].Id, Is.EqualTo(41));

			Assert.That(profiles.Count, Is.EqualTo(1));
			Assert.That(profiles[0].Id, Is.EqualTo(10));

			Assert.That(groups.Count, Is.EqualTo(1));
			Assert.That(groups[0].Id, Is.EqualTo(29246653));
		}

		#endregion

		#region Wall.GetComments

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void GetComments_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			int totalCount;
			_defaultWall.GetComments(12312, 12345, out totalCount, CommentsSort.Asc, true);
		}

		[Test]
		public void GetComments_IncorrectParameters_ThrowArgumentException()
		{
			int id;
			Assert.That(() => _defaultWall.GetComments(1, -1, out id), Throws.ArgumentException.And.Property("ParamName").EqualTo("postId"));
			Assert.That(() => _defaultWall.GetComments(1, 1, out id, count: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("count"));
			Assert.That(() => _defaultWall.GetComments(1, 1, out id, offset: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("offset"));
			Assert.That(() => _defaultWall.GetComments(1, 1, out id, previewLength: -1), Throws.ArgumentException.And.Property("ParamName").EqualTo("previewLength"));

		}

		[Test]
		public void GetComments_ReturnLikesAndAttachments()
		{
			const string url = "https://api.vk.com/method/wall.getComments?owner_id=12312&post_id=12345&need_likes=1&preview_length=0&v=5.9&sort=asc&access_token=token";
			const string json =
                @"{
                    'response': [
                      2,
                      {
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
                      }
                    ]
                  }";

			int totalCount;
			var comments = GetMockedWallCategory(url, json).GetComments(12312, 12345, out totalCount, CommentsSort.Asc, true);

			Assert.That(totalCount, Is.EqualTo(2));
			Assert.That(comments.Count, Is.EqualTo(2));

			var comment0 = comments[0];
			Assert.That(comment0.Id, Is.EqualTo(3809));
			Assert.That(comment0.FromId, Is.EqualTo(6733856));
			Assert.That(comment0.Date, Is.EqualTo(new DateTime(2013, 11, 22, 09, 45, 44)));
			Assert.That(comment0.Text, Is.EqualTo("Поздравляю вас!!!<br>Растите здоровыми, счастливыми и красивыми!"));
			Assert.That(comment0.Likes, Is.Not.Null);
			Assert.That(comment0.Likes.Count, Is.EqualTo(1));

			var comment1 = comments[1];
			Assert.That(comment1.Id, Is.EqualTo(3810));
			Assert.That(comment1.FromId, Is.EqualTo(3073863));
			Assert.That(comment1.Date, Is.EqualTo(new DateTime(2013, 11, 22, 10, 21, 06)));
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
			Assert.That(photo.Photo130, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fd/PvqwvqEOG2A.jpg")));
			Assert.That(photo.Photo604, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fe/XhRY9Pmoo70.jpg")));
			Assert.That(photo.Photo75, Is.EqualTo(new Uri("http://cs425830.vk.me/v425830763/48fc/iJaRiL3vPfA.jpg")));
			Assert.That(photo.Photo807, Is.Null);
			Assert.That(photo.Photo1280, Is.Null);
			Assert.That(photo.Width, Is.EqualTo(510));
			Assert.That(photo.Height, Is.EqualTo(383));
			Assert.That(photo.Text, Is.EqualTo(string.Empty));
			Assert.That(photo.CreateTime, Is.EqualTo(new DateTime(2013, 11, 22, 10, 20, 31)));
		}

		#endregion

		#region Wall.GetById

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.GetById(new[] { "93388_21539", "93388_20904", "2943_4276" });
			_defaultWall.GetById(new[] { new KeyValuePair<long, long>(10, 20), new KeyValuePair<long, long>(10, 20) });
		}

		[Test]
		public void GetById_ReturnWallRecords_ObsoleteOverload()
		{
			const string url = "https://api.vk.com/method/wall.getById?posts=1_619,1_617,1_616&access_token=token";
			const string json = @"{
                    'response': [
                      {
                        'id': 619,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1341145268,
                        'text': 'Фильмы ужасов, основанные на реальных событиях.',
                        'copy_owner_id': 50915841,
                        'copy_post_id': 1374,
                        'media': {
                          'type': 'photo',
                          'owner_id': 50915841,
                          'item_id': 283337039,
                          'thumb_src': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg'
                        },
                        'attachment': {
                          'type': 'photo',
                          'photo': {
                            'id': 283337039,
                            'album_id': -7,
                            'owner_id': 50915841,
                            'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                            'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                            'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                            'width': 450,
                            'height': 320,
                            'text': '',
                            'created': 1337542384,
                            'access_key': 'e377d6e0b55e299741'
                          }
                        },
                        'attachments': [
                          {
                            'type': 'photo',
                            'photo': {
                              'id': 283337039,
                              'album_id': -7,
                              'owner_id': 50915841,
                              'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                              'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                              'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                              'width': 450,
                              'height': 320,
                              'text': '',
                              'date': 1337542384,
                              'access_key': 'e377d6e0b55e299741'
                            }
                          },
                          {
                            'type': 'link',
                            'link': {
                              'url': 'http://vk.com/link',
                              'title': 'Любой заголово',
                              'description': 'Любое описание',
                              'image_src': 'http://vk.com/images/any.gif'
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 1,
                          'can_like': 0,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 617,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339684666,
                        'text': '',
                        'media': {
                          'type': 'audio',
                          'owner_id': 4793858,
                          'item_id': 154701206
                        },
                        'attachment': {
                          'type': 'audio',
                          'audio': {
                            'aid': 154701206,
                            'owner_id': 4793858,
                            'performer': 'Мук',
                            'title': 'Дорогою добра',
                            'duration': 130
                          }
                        },
                        'attachments': [
                          {
                            'type': 'audio',
                            'audio': {
                              'id': 154701206,
                              'owner_id': 4793858,
                              'performer': 'Мук',
                              'title': 'Дорогою добра',
                              'duration': 130
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 0,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 616,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339227157,
                        'text': 'Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было.',
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      }
                    ]
                  }";

			var records = GetMockedWallCategory(url, json).GetById(new[] { "1_619", "1_617", "1_616" });

			Assert.That(records.Count == 3);

			Assert.That(records[1].Attachment.Type == typeof(Audio));
			//var audio = (Audio) records[1].Attachment.GetAttachment();
			var audio = (Audio)records[1].Attachment.Instance;

			Assert.That(audio.Id, Is.EqualTo(154701206));
			Assert.That(audio.OwnerId, Is.EqualTo(4793858));
			Assert.That(audio.Title, Is.EqualTo("Дорогою добра"));
			Assert.That(audio.Duration, Is.EqualTo(130));

			Assert.That(records[1].Id, Is.EqualTo(617));
			Assert.That(records[1].FromId, Is.EqualTo(4793858));
			Assert.That(records[1].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[1].Date, Is.EqualTo(new DateTime(2012, 6, 14, 18, 37, 46)));
			Assert.That(records[1].Text, Is.Null.Or.Empty);
			Assert.That(records[1].Comments.Count == 0);
			Assert.That(records[1].Comments.CanPost, Is.True);
			Assert.That(records[1].Likes.Count, Is.EqualTo(0));
			Assert.That(records[1].Likes.UserLikes, Is.False);
			Assert.That(records[1].Likes.CanLike, Is.True);
			Assert.That(records[1].Likes.CanPublish, Is.False);
			Assert.That(records[1].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[1].Reposts.UserReposted, Is.False);

			Assert.That(records[2].Id, Is.EqualTo(616));
			Assert.That(records[2].FromId, Is.EqualTo(4793858));
			Assert.That(records[2].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[2].Date, Is.EqualTo(new DateTime(2012, 6, 9, 11, 32, 37)));
			Assert.That(records[2].Text,
						Is.EqualTo("Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было."));
			Assert.That(records[2].Comments.Count, Is.EqualTo(0));
			Assert.That(records[2].Comments.CanPost, Is.True);
			Assert.That(records[2].Likes.Count, Is.EqualTo(1));
			Assert.That(records[2].Likes.UserLikes, Is.False);
			Assert.That(records[2].Likes.CanLike, Is.True);
			Assert.That(records[2].Likes.CanPublish, Is.False);
			Assert.That(records[2].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[2].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Id, Is.EqualTo(619));
			Assert.That(records[0].FromId, Is.EqualTo(4793858));
			Assert.That(records[0].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[0].Date, Is.EqualTo(new DateTime(2012, 7, 1, 16, 21, 8)));
			Assert.That(records[0].Text, Is.EqualTo("Фильмы ужасов, основанные на реальных событиях."));
			Assert.That(records[0].CopyOwnerId, Is.EqualTo(50915841));
			Assert.That(records[0].CopyPostId, Is.EqualTo(1374));
			Assert.That(records[0].Comments.Count, Is.EqualTo(0));
			Assert.That(records[0].Comments.CanPost, Is.True);
			Assert.That(records[0].Likes.Count, Is.EqualTo(1));
			Assert.That(records[0].Likes.UserLikes, Is.True);
			Assert.That(records[0].Likes.CanLike, Is.False);
			Assert.That(records[0].Likes.CanPublish, Is.False);
			Assert.That(records[0].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[0].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Attachment.Type == typeof(Photo));
			var photo = (Photo)records[0].Attachment.Instance;
			Assert.That(photo.Id, Is.EqualTo(283337039));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(50915841));
			Assert.That(photo.Photo130.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg"));
			Assert.That(photo.Photo604.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg"));
			Assert.That(photo.Photo75.OriginalString,
						Is.EqualTo("http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg"));
			Assert.That(photo.Width, Is.EqualTo(450));
			Assert.That(photo.Height, Is.EqualTo(320));
			Assert.That(photo.Text, Is.Null.Or.Empty);
			Assert.That(photo.CreateTime, Is.EqualTo(new DateTime(2012, 05, 20, 23, 33, 04)));
			//Assert.That(records[0]., Is.EqualTo());

			Assert.That(records[0].Attachments.Count(), Is.EqualTo(2));
			var attach1 = (Photo)records[0].Attachments.ElementAt(0).Instance;
			Assert.That(attach1.Id, Is.EqualTo(283337039));
			var attach2 = (Link)records[0].Attachments.ElementAt(1).Instance;
			Assert.That(attach2.Url, Is.EqualTo(new Uri("http://vk.com/link")));

			Assert.That(records[1].Attachments.Count(), Is.EqualTo(1));
			var attach3 = (Audio)records[1].Attachments.ElementAt(0).Instance;
			Assert.That(attach3.Id, Is.EqualTo(154701206));
		}

		[Test]
		public void GetById_ReturnWallRecords()
		{
			const string url = "https://api.vk.com/method/wall.getById?posts=1_619,1_617,1_616&access_token=token";
			const string json =
                @"{
                    'response': [
                      {
                        'id': 619,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1341145268,
                        'text': 'Фильмы ужасов, основанные на реальных событиях.',
                        'copy_owner_id': 50915841,
                        'copy_post_id': 1374,
                        'media': {
                          'type': 'photo',
                          'owner_id': 50915841,
                          'item_id': 283337039,
                          'thumb_src': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg'
                        },
                        'attachment': {
                          'type': 'photo',
                          'photo': {
                            'id': 283337039,
                            'album_id': -7,
                            'owner_id': 50915841,
                            'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                            'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                            'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                            'width': 450,
                            'height': 320,
                            'text': '',
                            'created': 1337542384,
                            'access_key': 'e377d6e0b55e299741'
                          }
                        },
                        'attachments': [
                          {
                            'type': 'photo',
                            'photo': {
                              'id': 283337039,
                              'album_id': -7,
                              'owner_id': 50915841,
                              'photo_130': 'http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg',
                              'photo_604': 'http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg',
                              'photo_75': 'http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg',
                              'width': 450,
                              'height': 320,
                              'text': '',
                              'date': 1337542384,
                              'access_key': 'e377d6e0b55e299741'
                            }
                          },
                          {
                            'type': 'link',
                            'link': {
                              'url': 'http://vk.com/link',
                              'title': 'Любой заголово',
                              'description': 'Любое описание',
                              'image_src': 'http://vk.com/images/any.gif'
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 1,
                          'can_like': 0,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 617,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339684666,
                        'text': '',
                        'media': {
                          'type': 'audio',
                          'owner_id': 4793858,
                          'item_id': 154701206
                        },
                        'attachment': {
                          'type': 'audio',
                          'audio': {
                            'aid': 154701206,
                            'owner_id': 4793858,
                            'performer': 'Мук',
                            'title': 'Дорогою добра',
                            'duration': 130
                          }
                        },
                        'attachments': [
                          {
                            'type': 'audio',
                            'audio': {
                              'id': 154701206,
                              'owner_id': 4793858,
                              'performer': 'Мук',
                              'title': 'Дорогою добра',
                              'duration': 130
                            }
                          }
                        ],
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 0,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      },
                      {
                        'id': 616,
                        'from_id': 4793858,
                        'owner_id': 4793858,
                        'date': 1339227157,
                        'text': 'Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было.',
                        'comments': {
                          'count': 0,
                          'can_post': 1
                        },
                        'likes': {
                          'count': 1,
                          'user_likes': 0,
                          'can_like': 1,
                          'can_publish': 0
                        },
                        'reposts': {
                          'count': 0,
                          'user_reposted': 0
                        }
                      }
                    ]
                  }";

			var records = GetMockedWallCategory(url, json).GetById(
				new[] 
				{
					new KeyValuePair<long, long>(1, 619),
					new KeyValuePair<long, long>(1, 617), 
					new KeyValuePair<long, long>(1,616)
					
				});

			Assert.That(records.Count == 3);

			Assert.That(records[1].Attachment.Type == typeof(Audio));
			//var audio = (Audio) records[1].Attachment.GetAttachment();
			var audio = (Audio)records[1].Attachment.Instance;

			Assert.That(audio.Id, Is.EqualTo(154701206));
			Assert.That(audio.OwnerId, Is.EqualTo(4793858));
			Assert.That(audio.Title, Is.EqualTo("Дорогою добра"));
			Assert.That(audio.Duration, Is.EqualTo(130));

			Assert.That(records[1].Id, Is.EqualTo(617));
			Assert.That(records[1].FromId, Is.EqualTo(4793858));
			Assert.That(records[1].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[1].Date, Is.EqualTo(new DateTime(2012, 6, 14, 18, 37, 46)));
			Assert.That(records[1].Text, Is.Null.Or.Empty);
			Assert.That(records[1].Comments.Count == 0);
			Assert.That(records[1].Comments.CanPost, Is.True);
			Assert.That(records[1].Likes.Count, Is.EqualTo(0));
			Assert.That(records[1].Likes.UserLikes, Is.False);
			Assert.That(records[1].Likes.CanLike, Is.True);
			Assert.That(records[1].Likes.CanPublish, Is.False);
			Assert.That(records[1].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[1].Reposts.UserReposted, Is.False);

			Assert.That(records[2].Id, Is.EqualTo(616));
			Assert.That(records[2].FromId, Is.EqualTo(4793858));
			Assert.That(records[2].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[2].Date, Is.EqualTo(new DateTime(2012, 6, 9, 11, 32, 37)));
			Assert.That(records[2].Text, Is.EqualTo("Народная примета: если парень идет по улице с букетом роз, значит секса у них ещё не было."));
			Assert.That(records[2].Comments.Count, Is.EqualTo(0));
			Assert.That(records[2].Comments.CanPost, Is.True);
			Assert.That(records[2].Likes.Count, Is.EqualTo(1));
			Assert.That(records[2].Likes.UserLikes, Is.False);
			Assert.That(records[2].Likes.CanLike, Is.True);
			Assert.That(records[2].Likes.CanPublish, Is.False);
			Assert.That(records[2].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[2].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Id, Is.EqualTo(619));
			Assert.That(records[0].FromId, Is.EqualTo(4793858));
			Assert.That(records[0].OwnerId, Is.EqualTo(4793858));
			Assert.That(records[0].Date, Is.EqualTo(new DateTime(2012, 7, 1, 16, 21, 8)));
			Assert.That(records[0].Text, Is.EqualTo("Фильмы ужасов, основанные на реальных событиях."));
			Assert.That(records[0].CopyOwnerId, Is.EqualTo(50915841));
			Assert.That(records[0].CopyPostId, Is.EqualTo(1374));
			Assert.That(records[0].Comments.Count, Is.EqualTo(0));
			Assert.That(records[0].Comments.CanPost, Is.True);
			Assert.That(records[0].Likes.Count, Is.EqualTo(1));
			Assert.That(records[0].Likes.UserLikes, Is.True);
			Assert.That(records[0].Likes.CanLike, Is.False);
			Assert.That(records[0].Likes.CanPublish, Is.False);
			Assert.That(records[0].Reposts.Count, Is.EqualTo(0));
			Assert.That(records[0].Reposts.UserReposted, Is.False);

			Assert.That(records[0].Attachment.Type == typeof(Photo));
			var photo = (Photo)records[0].Attachment.Instance;
			Assert.That(photo.Id, Is.EqualTo(283337039));
			Assert.That(photo.AlbumId, Is.EqualTo(-7));
			Assert.That(photo.OwnerId, Is.EqualTo(50915841));
			Assert.That(photo.Photo130.OriginalString, Is.EqualTo("http://cs303810.userapi.com/v303810841/126e/H5W0B96fSVM.jpg"));
			Assert.That(photo.Photo604.OriginalString, Is.EqualTo("http://cs303810.userapi.com/v303810841/126f/35YS_xcXCJk.jpg"));
			Assert.That(photo.Photo75.OriginalString, Is.EqualTo("http://cs303810.userapi.com/v303810841/126d/qYeAGOiA5kY.jpg"));
			Assert.That(photo.Width, Is.EqualTo(450));
			Assert.That(photo.Height, Is.EqualTo(320));
			Assert.That(photo.Text, Is.Null.Or.Empty);
			Assert.That(photo.CreateTime, Is.EqualTo(new DateTime(2012, 05, 20, 23, 33, 04)));
			//Assert.That(records[0]., Is.EqualTo());

			Assert.That(records[0].Attachments.Count(), Is.EqualTo(2));
			var attach1 = (Photo)records[0].Attachments.ElementAt(0).Instance;
			Assert.That(attach1.Id, Is.EqualTo(283337039));
			var attach2 = (Link)records[0].Attachments.ElementAt(1).Instance;
			Assert.That(attach2.Url, Is.EqualTo(new Uri("http://vk.com/link")));

			Assert.That(records[1].Attachments.Count(), Is.EqualTo(1));
			var attach3 = (Audio)records[1].Attachments.ElementAt(0).Instance;
			Assert.That(attach3.Id, Is.EqualTo(154701206));
		}

		#endregion

		#region Wall.Post

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		public void Post_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.Post(message: "message");
		}

		[Test]
		public void Post_IncorrectParameters_MessageAttachmentsAndUrlAreNullOrEmpty_ThrowException()
		{
			Assert.That(() => _defaultWall.Post(message: null, mediaAttachments: null, url: null), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: null, mediaAttachments: null, url: string.Empty), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: null, mediaAttachments: Enumerable.Empty<MediaAttachment>(), url: null), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: null, mediaAttachments: Enumerable.Empty<MediaAttachment>(), url: string.Empty), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: string.Empty, mediaAttachments: null, url: null), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: string.Empty, mediaAttachments: null, url: string.Empty), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: string.Empty, mediaAttachments: Enumerable.Empty<MediaAttachment>(), url: null), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: string.Empty, mediaAttachments: Enumerable.Empty<MediaAttachment>(), url: string.Empty), Throws.ArgumentException);	
		}

		[Test]
		public void Post_IncorrectParameters_ThrowException()
		{
			Assert.That(() => _defaultWall.Post(message: "message", placeId: -1), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: "message", postId: -1), Throws.ArgumentException);
			Assert.That(() => _defaultWall.Post(message: "message", lat: 90.1), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(() => _defaultWall.Post(message: "message", lat: -90.1), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(() => _defaultWall.Post(message: "message", @long: 180.1), Throws.TypeOf<ArgumentOutOfRangeException>());
			Assert.That(() => _defaultWall.Post(message: "message", @long: -180.1), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		public void Post_UrlIsGeneratedCorrectly()
		{
			const string url = "https://api.vk.com/method/wall.post?owner_id=10&friends_only=1&from_group=1&message=message&" +
								"attachments=audio10_20,link&services=twitter&signed=1&publish_date=1388620800&" +
								"lat=45&long=135&place_id=100&post_id=500&access_token=token";
			const string json =
                @"{
                    'response': {
						   post_id: 42
					} }";

			Assert.That(GetMockedWallCategory(url, json).Post(
				10, true, true, "message", new[] { new Audio { Id = 20, OwnerId = 10 } }, "link",
				"twitter", true, new DateTime(2014, 1, 2, 0,0,0, DateTimeKind.Utc).ToLocalTime(), 45, 135, 100, 500), Is.EqualTo(42));

		}


		#endregion

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void Edit_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.Edit();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.Delete();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void Restore_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.Restore();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void AddComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.AddComment();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void RestoreComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.RestoreComment();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void DeleteComment_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.DeleteComment();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void AddLike_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.AddLike();
		}

		[Test]
		[ExpectedException(typeof(AccessTokenInvalidException))]
		[Ignore]
		public void DeleteLike_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			_defaultWall.DeleteLike();
		}
	}
}