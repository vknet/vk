using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	public class VideoCategoryTest : BaseTest
	{
		private VideoCategory GetMockedVideoCategory(string url, string json)
		{
			Json = json;
			Url = url;

			return new VideoCategory(vk: Api);
		}

		[Test]
		public void Add_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.add";

			const string json =
					@"{
                    'response': 167593944
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var id = cat.Add(videoId: 164841344, ownerId: 1);
			Assert.That(actual: id, expression: Is.EqualTo(expected: 167593944));
		}

		[Test]
		public void AddAlbum_ToCurrentUser()
		{
			const string url = "https://api.vk.com/method/video.addAlbum";

			const string json =
					@"{
                    'response': {
                      'album_id': 49273471
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var id = cat.AddAlbum(title: "Новый альбом видеозаписей");
			Assert.That(actual: id, expression: Is.EqualTo(expected: 49273471));
		}

		[Test]
		public void CreateComment_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.createComment";

			const string json =
					@"{
                    'response': 35634
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var id = cat.CreateComment(@params: new VideoCreateCommentParams
			{
					VideoId = 166613182
					, Message = "забавное видео"
					, OwnerId = 1
			});

			Assert.That(actual: id, expression: Is.EqualTo(expected: 35634));
		}

		[Test]
		public void Delete_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.delete";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.Delete(videoId: 167593944);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void DeleteAlbum_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.deleteAlbum";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.DeleteAlbum(albumId: 52153813);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void DeleteComment_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.deleteComment";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.DeleteComment(commentId: 35634, ownerId: 1);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Edit_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.edit";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.Edit(@params: new VideoEditParams
			{
					VideoId = 167538
					, OwnerId = 23469
					, Name = "Новое название"
					, Desc = "Новое описание"
			});

			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void EditAlbum_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.editAlbum";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.EditAlbum(albumId: 521543, title: "Новое название!!!");
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void EditComment_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.editComment";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.EditComment(commentId: 35634, message: "суперское видео", ownerId: 1);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Get_Extended()
		{
			const string url = "https://api.vk.com/method/video.get";

			const string json =
					@"{
                    'response': {
                      'count': 8,
                      'items': [
                        {
                          'id': 166481021,
                          'owner_id': 1,
                          'title': 'Лидия Аркадьевна',
                          'duration': 131,
                          'description': '',
                          'date': 1384867255,
                          'views': 81677,
                          'comments': 2098,
                          'photo_130': 'http://cs419529.vk.me/u9258277/video/s_af2727af.jpg',
                          'photo_320': 'http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg',
                          'player': 'http://www.youtube.com/embed/VQaHFisdf-s',
                          'can_comment': 1,
                          'can_repost': 1,
                          'likes': {
                            'user_likes': 0,
                            'count': 1789
                          },
                          'repeat': 0
                        },
                        {
                          'id': 166468673,
                          'owner_id': 1,
                          'title': 'Лидия Аркадьевна',
                          'duration': 62,
                          'description': '',
                          'date': 1384721483,
                          'views': 42107,
                          'comments': 1243,
                          'photo_130': 'http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg',
                          'photo_320': 'http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg',
                          'player': 'http://www.youtube.com/embed/YfLytrkbAfM',
                          'can_comment': 1,
                          'can_repost': 1,
                          'likes': {
                            'user_likes': 0,
                            'count': 640
                          },
                          'repeat': 0
                        },
                        {
                          'id': 164841344,
                          'owner_id': 1,
                          'title': 'This is SPARTA',
                          'duration': 16,
                          'description': '',
                          'date': 1366495075,
                          'views': 218659,
                          'comments': 2578,
                          'photo_130': 'http://cs12761.vk.me/u5705167/video/s_df53315c.jpg',
                          'photo_320': 'http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg',
                          'player': 'http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353',
                          'can_comment': 1,
                          'can_repost': 1,
                          'likes': {
                            'user_likes': 1,
                            'count': 4137
                          },
                          'repeat': 1
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.Get(@params: new VideoGetParams
			{
					OwnerId = 1
					, Count = 3
					, Offset = 2
					, Extended = true
			});

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 3));

			var video = result.FirstOrDefault();
			Assert.That(actual: video, expression: Is.Not.Null);
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 166481021));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video.Title, expression: Is.EqualTo(expected: "Лидия Аркадьевна"));
			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 131));
			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867255)));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 81677));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 2098));

			Assert.That(actual: video.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs419529.vk.me/u9258277/video/s_af2727af.jpg")));

			Assert.That(actual: video.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg")));

			Assert.That(actual: video.Player
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://www.youtube.com/embed/VQaHFisdf-s")));

			Assert.That(actual: video.CanComment, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video.CanRepost, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video.Repeat, expression: Is.EqualTo(expected: false));
			Assert.That(actual: video.Likes, expression: Is.Not.Null);
			Assert.That(actual: video.Likes.UserLikes, expression: Is.EqualTo(expected: false));
			Assert.That(actual: video.Likes.Count, expression: Is.EqualTo(expected: 1789));

			var video1 = result.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: video1, expression: Is.Not.Null);
			Assert.That(actual: video1.Id, expression: Is.EqualTo(expected: 166468673));
			Assert.That(actual: video1.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video1.Title, expression: Is.EqualTo(expected: "Лидия Аркадьевна"));
			Assert.That(actual: video1.Duration, expression: Is.EqualTo(expected: 62));
			Assert.That(actual: video1.Description, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: video1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384721483)));
			Assert.That(actual: video1.Views, expression: Is.EqualTo(expected: 42107));
			Assert.That(actual: video1.Comments, expression: Is.EqualTo(expected: 1243));

			Assert.That(actual: video1.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg")));

			Assert.That(actual: video1.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg")));

			Assert.That(actual: video1.Player
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://www.youtube.com/embed/YfLytrkbAfM")));

			Assert.That(actual: video1.CanComment, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video1.CanRepost, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video1.Repeat, expression: Is.EqualTo(expected: false));
			Assert.That(actual: video1.Likes, expression: Is.Not.Null);
			Assert.That(actual: video1.Likes.UserLikes, expression: Is.EqualTo(expected: false));
			Assert.That(actual: video1.Likes.Count, expression: Is.EqualTo(expected: 640));

			var video2 = result.Skip(count: 2).FirstOrDefault();
			Assert.That(actual: video2, expression: Is.Not.Null);
			Assert.That(actual: video2.Id, expression: Is.EqualTo(expected: 164841344));
			Assert.That(actual: video2.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video2.Title, expression: Is.EqualTo(expected: "This is SPARTA"));
			Assert.That(actual: video2.Duration, expression: Is.EqualTo(expected: 16));
			Assert.That(actual: video2.Description, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: video2.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1366495075)));
			Assert.That(actual: video2.Views, expression: Is.EqualTo(expected: 218659));
			Assert.That(actual: video2.Comments, expression: Is.EqualTo(expected: 2578));

			Assert.That(actual: video2.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));

			Assert.That(actual: video2.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));

			Assert.That(actual: video2.Player
					, expression: Is.EqualTo(
							expected: new Uri(uriString: "http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353")));

			Assert.That(actual: video2.CanComment, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video2.CanRepost, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video2.Repeat, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video2.Likes, expression: Is.Not.Null);
			Assert.That(actual: video2.Likes.UserLikes, expression: Is.EqualTo(expected: true));
			Assert.That(actual: video2.Likes.Count, expression: Is.EqualTo(expected: 4137));
		}

		[Test]
		public void Get_NotExtended()
		{
			const string url = "https://api.vk.com/method/video.get";

			const string json =
					@"{
                    'response': {
                      'count': 8,
                      'items': [
                        {
                          'id': 166481021,
                          'owner_id': 1,
                          'title': 'Лидия Аркадьевна',
                          'duration': 131,
                          'description': '',
                          'date': 1384867255,
                          'views': 81676,
                          'comments': 2098,
                          'photo_130': 'http://cs419529.vk.me/u9258277/video/s_af2727af.jpg',
                          'photo_320': 'http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg',
                          'player': 'http://www.youtube.com/embed/VQaHFisdf-s'
                        },
                        {
                          'id': 166468673,
                          'owner_id': 1,
                          'title': 'Лидия Аркадьевна',
                          'duration': 62,
                          'description': '',
                          'date': 1384721483,
                          'views': 42107,
                          'comments': 1243,
                          'photo_130': 'http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg',
                          'photo_320': 'http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg',
                          'player': 'http://www.youtube.com/embed/YfLytrkbAfM'
                        },
                        {
                          'id': 164841344,
                          'owner_id': 1,
                          'title': 'This is SPARTA',
                          'duration': 16,
                          'description': '',
                          'date': 1366495075,
                          'views': 218658,
                          'comments': 2578,
                          'photo_130': 'http://cs12761.vk.me/u5705167/video/s_df53315c.jpg',
                          'photo_320': 'http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg',
                          'player': 'http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353'
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

// 1, width: VideoWidth.Large320, count: 3, offset: 2
			var result = cat.Get(@params: new VideoGetParams
			{
					OwnerId = 1
					, Count = 3
					, Offset = 2
			});

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 3));

			var video = result.FirstOrDefault();
			Assert.That(actual: video, expression: Is.Not.Null);
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 166481021));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video.Title, expression: Is.EqualTo(expected: "Лидия Аркадьевна"));
			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 131));
			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867255)));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 81676));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 2098));

			Assert.That(actual: video.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs419529.vk.me/u9258277/video/s_af2727af.jpg")));

			Assert.That(actual: video.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg")));

			Assert.That(actual: video.Player
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://www.youtube.com/embed/VQaHFisdf-s")));

			var video1 = result.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: video1, expression: Is.Not.Null);
			Assert.That(actual: video1.Id, expression: Is.EqualTo(expected: 166468673));
			Assert.That(actual: video1.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video1.Title, expression: Is.EqualTo(expected: "Лидия Аркадьевна"));
			Assert.That(actual: video1.Duration, expression: Is.EqualTo(expected: 62));
			Assert.That(actual: video1.Description, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: video1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384721483)));
			Assert.That(actual: video1.Views, expression: Is.EqualTo(expected: 42107));
			Assert.That(actual: video1.Comments, expression: Is.EqualTo(expected: 1243));

			Assert.That(actual: video1.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg")));

			Assert.That(actual: video1.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg")));

			Assert.That(actual: video1.Player
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://www.youtube.com/embed/YfLytrkbAfM")));

			var video2 = result.Skip(count: 2).FirstOrDefault();
			Assert.That(actual: video2, expression: Is.Not.Null);
			Assert.That(actual: video2.Id, expression: Is.EqualTo(expected: 164841344));
			Assert.That(actual: video2.OwnerId, expression: Is.EqualTo(expected: 1));
			Assert.That(actual: video2.Title, expression: Is.EqualTo(expected: "This is SPARTA"));
			Assert.That(actual: video2.Duration, expression: Is.EqualTo(expected: 16));
			Assert.That(actual: video2.Description, expression: Is.EqualTo(expected: string.Empty));
			Assert.That(actual: video2.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1366495075)));
			Assert.That(actual: video2.Views, expression: Is.EqualTo(expected: 218658));
			Assert.That(actual: video2.Comments, expression: Is.EqualTo(expected: 2578));

			Assert.That(actual: video2.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));

			Assert.That(actual: video2.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));

			Assert.That(actual: video2.Player
					, expression: Is.EqualTo(
							expected: new Uri(uriString: "http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353")));
		}

		// todo add not extended version
		[Test]
		public void GetAlbums_NormalCase_Extended_TwoItems()
		{
			const string url = "https://api.vk.com/method/video.getAlbums";

			const string json =
					@"{
                    'response': {
                      'count': 2,
                      'items': [
                        {
                          'id': 52154345,
                          'owner_id': 234695119,
                          'title': 'Второй новый альбом видеозаписей',
                          'count': 0
                        },
                        {
                          'id': 52152803,
                          'owner_id': 234695119,
                          'title': 'Новый альбом видеозаписей',
                          'count': 0
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.GetAlbums(ownerId: 234695119, extended: true);
			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 2));

			var videoAlbum = result.FirstOrDefault();
			Assert.That(actual: videoAlbum, expression: Is.Not.Null);
			Assert.That(actual: videoAlbum.Id, expression: Is.EqualTo(expected: 52154345));
			Assert.That(actual: videoAlbum.OwnerId, expression: Is.EqualTo(expected: 234695119));
			Assert.That(actual: videoAlbum.Title, expression: Is.EqualTo(expected: "Второй новый альбом видеозаписей"));
			Assert.That(actual: videoAlbum.Count, expression: Is.EqualTo(expected: 0));

			var videoAlbum1 = result.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: videoAlbum1, expression: Is.Not.Null);
			Assert.That(actual: videoAlbum1.Id, expression: Is.EqualTo(expected: 52152803));
			Assert.That(actual: videoAlbum1.OwnerId, expression: Is.EqualTo(expected: 234695119));
			Assert.That(actual: videoAlbum1.Title, expression: Is.EqualTo(expected: "Новый альбом видеозаписей"));
			Assert.That(actual: videoAlbum1.Count, expression: Is.EqualTo(expected: 0));
		}

		[Test]
		public void GetComments_WithLikes()
		{
			const string url = "https://api.vk.com/method/video.getComments";

			const string json =
					@"{
                    'response': {
                      'count': 2146,
                      'items': [
                        {
                          'id': 14715,
                          'from_id': 24758120,
                          'date': 1384867361,
                          'text': 'паша здаров!',
                          'likes': {
                            'count': 5,
                            'user_likes': 0,
                            'can_like': 1
                          }
                        },
                        {
                          'id': 14716,
                          'from_id': 94278436,
                          'date': 1384867372,
                          'text': 'Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!',
                          'likes': {
                            'count': 77,
                            'user_likes': 0,
                            'can_like': 1
                          }
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var comments = cat.GetComments(@params: new VideoGetCommentsParams
			{
					VideoId = 166481021
					, OwnerId = 1
					, NeedLikes = true
					, Count = 2
					, Offset = 3
					, Sort = CommentsSort.Asc
			});

			Assert.That(actual: comments, expression: Is.Not.Null);
			Assert.That(actual: comments.Count, expression: Is.EqualTo(expected: 2));

			var comment = comments.FirstOrDefault();
			Assert.That(actual: comment, expression: Is.Not.Null);

			Assert.That(actual: comment.Id, expression: Is.EqualTo(expected: 14715));
			Assert.That(actual: comment.FromId, expression: Is.EqualTo(expected: 24758120));
			Assert.That(actual: comment.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867361)));
			Assert.That(actual: comment.Text, expression: Is.EqualTo(expected: "паша здаров!"));
			Assert.That(actual: comment.Likes.Count, expression: Is.EqualTo(expected: 5));
			Assert.That(actual: comment.Likes.UserLikes, expression: Is.EqualTo(expected: false));
			Assert.That(actual: comment.Likes.CanLike, expression: Is.EqualTo(expected: true));

			var comment1 = comments.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: comment1, expression: Is.Not.Null);

			Assert.That(actual: comment1.Id, expression: Is.EqualTo(expected: 14716));
			Assert.That(actual: comment1.FromId, expression: Is.EqualTo(expected: 94278436));
			Assert.That(actual: comment1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867372)));

			Assert.That(actual: comment1.Text
					, expression: Is.EqualTo(expected:
							"Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));

			Assert.That(actual: comment1.Likes.Count, expression: Is.EqualTo(expected: 77));
			Assert.That(actual: comment1.Likes.UserLikes, expression: Is.EqualTo(expected: false));
			Assert.That(actual: comment1.Likes.CanLike, expression: Is.EqualTo(expected: true));
		}

		[Test]
		public void GetComments_WithoutLikes()
		{
			const string url = "https://api.vk.com/method/video.getComments";

			const string json =
					@"{
                    'response': {
                      'count': 2146,
                      'items': [
                        {
                          'id': 14715,
                          'from_id': 24758120,
                          'date': 1384867361,
                          'text': 'паша здаров!'
                        },
                        {
                          'id': 14716,
                          'from_id': 94278436,
                          'date': 1384867372,
                          'text': 'Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!'
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var comments = cat.GetComments(@params: new VideoGetCommentsParams
			{
					VideoId = 166481021
					, OwnerId = 1
					, NeedLikes = false
					, Count = 2
					, Offset = 3
					, Sort = CommentsSort.Asc
			});

			Assert.That(actual: comments, expression: Is.Not.Null);
			Assert.That(actual: comments.Count, expression: Is.EqualTo(expected: 2));

			var comment = comments.FirstOrDefault();
			Assert.That(actual: comment, expression: Is.Not.Null);

			Assert.That(actual: comment.Id, expression: Is.EqualTo(expected: 14715));
			Assert.That(actual: comment.FromId, expression: Is.EqualTo(expected: 24758120));
			Assert.That(actual: comment.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867361)));
			Assert.That(actual: comment.Text, expression: Is.EqualTo(expected: "паша здаров!"));

			var comment1 = comments.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: comment1, expression: Is.Not.Null);
			Assert.That(actual: comment1.Id, expression: Is.EqualTo(expected: 14716));
			Assert.That(actual: comment1.FromId, expression: Is.EqualTo(expected: 94278436));
			Assert.That(actual: comment1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384867372)));

			Assert.That(actual: comment1.Text
					, expression: Is.EqualTo(expected:
							"Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));
		}

		[Test]
		public void Report_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.report";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.Report(videoId: 166613182, reason: ReportReason.DrugPropaganda, ownerId: 1, comment: "коммент");
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void ReportComment_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.reportComment";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.ReportComment(commentId: 35637, ownerId: 1, reason: ReportReason.AdultMaterial);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Restore_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.restore";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.Restore(videoId: 167593944);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void RestoreComment_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.restoreComment";

			const string json =
					@"{
                    'response': 1
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var result = cat.RestoreComment(commentId: 35634, ownerId: 1);
			Assert.That(actual: result, expression: Is.True);
		}

		[Test]
		public void Save_NormalCase()
		{
			const string url = "https://api.vk.com/method/video.save";

			const string json =
					@"{
                    'response': {
                      'upload_url': 'http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043',
                      'video_id': 1673994,
                      'owner_id': 2346958,
                      'title': 'Название из ютуба',
                      'description': 'Описание из ютуба',
                      'access_key': 'f2ec9f3982f05bc'
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			var video = cat.Save(@params: new VideoSaveParams
			{
					Name = "Название из ютуба"
					, Description = "Описание из ютуба"
					, Wallpost = true
					, Link = "https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA"
			});

			Assert.That(actual: video, expression: Is.Not.Null);
			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 1673994));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: 2346958));
			Assert.That(actual: video.Title, expression: Is.EqualTo(expected: "Название из ютуба"));
			Assert.That(actual: video.Description, expression: Is.EqualTo(expected: "Описание из ютуба"));
			Assert.That(actual: video.AccessKey, expression: Is.EqualTo(expected: "f2ec9f3982f05bc"));

			Assert.That(actual: video.UploadUrl
					, expression: Is.EqualTo(expected: new Uri(uriString:
							"http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043")));
		}

		[Test]
		public void Save_ReturnError()
		{
			const string json =
					@"{
   'error' : {
      'error_code' : 204,
      'error_msg' : 'Access denied: user was banned for this action, cant add video',
      'request_params' : [
         {
            'key' : 'oauth',
            'value' : '1'
         },
         {
            'key' : 'method',
            'value' : 'video.save'
         },
         
         {
            'key' : 'description',
            'value' : '123'
         },
         {
            'key' : 'group_id',
            'value' : '33905270'
         },
         {
            'key' : 'v',
            'value' : '5.64'
         }
      ]
   }
}";

			Assert.That(code: () => VkErrors.IfErrorThrowException(json: json), constraint: Throws.TypeOf<VideoAccessDeniedException>());
		}

		[Test]
		public void Search_NormalCase_ListOfVideos()
		{
			const string url = "https://api.vk.com/method/video.search";

			const string json =
					@"{
                    'response': {
                      'count': 1425,
                      'items': [
                        {
                          'id': 166671614,
                          'owner_id': -59205334,
                          'title': 'Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ',
                          'duration': 1934,
                          'description': 'beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<',
                          'date': 1384706962,
                          'views': 11579,
                          'comments': 12,
                          'photo_130': 'http://cs505118.vk.me/u7160710/video/s_08382000.jpg',
                          'photo_320': 'http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg',
                          'album_id': 50100051,
                          'player': 'http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d'
                        },
                        {
                          'id': 165458571,
                          'owner_id': -49956637,
                          'title': 'домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа',
                          'duration': 1139,
                          'description': 'секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex',
                          'date': 1371702618,
                          'views': 12817,
                          'comments': 5,
                          'photo_130': 'http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg',
                          'photo_320': 'http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg',
                          'player': 'http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92'
                        },
                        {
                          'id': 166728490,
                          'owner_id': -54257090,
                          'title': 'Саша Грей | Sasha Grey #13',
                          'duration': 1289,
                          'description': 'Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica',
                          'date': 1386961568,
                          'views': 8730,
                          'comments': 12,
                          'photo_130': 'http://cs535107.vk.me/u146564541/video/s_2d874147.jpg',
                          'photo_320': 'http://cs535107.vk.me/u146564541/video/l_cb794198.jpg',
                          'player': 'http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac'
                        }
                      ]
                    }
                  }";

			var cat = GetMockedVideoCategory(url: url, json: json);

			// , VideoSort.Relevance, false, true, VideoFilters.Long, false, 5, 1
			var result = cat.Search(@params: new VideoSearchParams
			{
					Query = "саша грей"
					, Sort = VideoSort.Relevance
					, Hd = false
					, Adult = true
					, Filters = VideoFilters.Long
					, SearchOwn = false
					, Count = 5
					, Offset = 1
			});

			Assert.That(actual: result, expression: Is.Not.Null);
			Assert.That(actual: result.Count, expression: Is.EqualTo(expected: 3));

			var video = result.FirstOrDefault();
			Assert.That(actual: video, expression: Is.Not.Null);

			Assert.That(actual: video.Id, expression: Is.EqualTo(expected: 166671614));
			Assert.That(actual: video.OwnerId, expression: Is.EqualTo(expected: -59205334));

			Assert.That(actual: video.Title
					, expression: Is.EqualTo(expected:
							"Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ"));

			Assert.That(actual: video.Duration, expression: Is.EqualTo(expected: 1934));

			Assert.That(actual: video.Description
					, expression: Is.EqualTo(expected:
							"beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<"));

			Assert.That(actual: video.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1384706962)));
			Assert.That(actual: video.Views, expression: Is.EqualTo(expected: 11579));
			Assert.That(actual: video.Comments, expression: Is.EqualTo(expected: 12));

			Assert.That(actual: video.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs505118.vk.me/u7160710/video/s_08382000.jpg")));

			Assert.That(actual: video.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg")));

			Assert.That(actual: video.AlbumId, expression: Is.EqualTo(expected: 50100051));

			Assert.That(actual: video.Player
					, expression: Is.EqualTo(
							expected: new Uri(uriString: "http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d")));

			var video1 = result.Skip(count: 1).FirstOrDefault();
			Assert.That(actual: video1, expression: Is.Not.Null);

			Assert.That(actual: video1.Id, expression: Is.EqualTo(expected: 165458571));
			Assert.That(actual: video1.OwnerId, expression: Is.EqualTo(expected: -49956637));

			Assert.That(actual: video1.Title
					, expression: Is.EqualTo(expected:
							"домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа"));

			Assert.That(actual: video1.Duration, expression: Is.EqualTo(expected: 1139));

			Assert.That(actual: video1.Description
					, expression: Is.EqualTo(expected:
							"секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex"));

			Assert.That(actual: video1.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1371702618)));
			Assert.That(actual: video1.Views, expression: Is.EqualTo(expected: 12817));
			Assert.That(actual: video1.Comments, expression: Is.EqualTo(expected: 5));

			Assert.That(actual: video1.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg")));

			Assert.That(actual: video1.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg")));

			Assert.That(actual: video1.Player
					, expression: Is.EqualTo(
							expected: new Uri(uriString: "http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92")));

			var video2 = result.Skip(count: 2).FirstOrDefault();
			Assert.That(actual: video2, expression: Is.Not.Null);

			Assert.That(actual: video2.Id, expression: Is.EqualTo(expected: 166728490));
			Assert.That(actual: video2.OwnerId, expression: Is.EqualTo(expected: -54257090));
			Assert.That(actual: video2.Title, expression: Is.EqualTo(expected: "Саша Грей | Sasha Grey #13"));
			Assert.That(actual: video2.Duration, expression: Is.EqualTo(expected: 1289));

			Assert.That(actual: video2.Description
					, expression: Is.EqualTo(expected:
							"Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica"));

			Assert.That(actual: video2.Date, expression: Is.EqualTo(expected: DateHelper.TimeStampToDateTime(timestamp: 1386961568)));
			Assert.That(actual: video2.Views, expression: Is.EqualTo(expected: 8730));
			Assert.That(actual: video2.Comments, expression: Is.EqualTo(expected: 12));

			Assert.That(actual: video2.Photo130
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs535107.vk.me/u146564541/video/s_2d874147.jpg")));

			Assert.That(actual: video2.Photo320
					, expression: Is.EqualTo(expected: new Uri(uriString: "http://cs535107.vk.me/u146564541/video/l_cb794198.jpg")));

			Assert.That(actual: video2.Player
					, expression: Is.EqualTo(
							expected: new Uri(uriString: "http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac")));
		}
	}
}