using System;
using System.Linq;

namespace VkNet.Tests.Categories
{
	using NUnit.Framework;
    using VkNet.Categories;
	using Enums;
	using Enums.Filters;
    using Enums.SafetyEnums;


	[TestFixture]
    public class VideoCategoryTest : BaseTest
	{
         private VideoCategory GetMockedVideoCategory(string url, string json)
         {
            Json = json;
            Url = url;
            return new VideoCategory(Api);
         }

         [Test]
         public void Get_NotExtended()
         {
			const string url = "https://api.vk.com/method/video.get?owner_id=1&count=3&offset=2&v=" + VkApi.VkApiVersion + "&access_token=token";
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

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.Get(1, width:VideoWidth.Large320, count: 3, offset: 2);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));

	        var video = result.FirstOrDefault();
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(166481021));
			Assert.That(video.OwnerId, Is.EqualTo(1));
			Assert.That(video.Title, Is.EqualTo("Лидия Аркадьевна"));
			Assert.That(video.Duration, Is.EqualTo(131));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867255)));
			Assert.That(video.ViewsCount, Is.EqualTo(81676));
			Assert.That(video.CommentsCount, Is.EqualTo(2098));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("http://cs419529.vk.me/u9258277/video/s_af2727af.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg")));
			Assert.That(video.Player, Is.EqualTo(new Uri("http://www.youtube.com/embed/VQaHFisdf-s")));

			var video1 = result.Skip(1).FirstOrDefault();
			Assert.That(video1, Is.Not.Null);
			Assert.That(video1.Id, Is.EqualTo(166468673));
			Assert.That(video1.OwnerId, Is.EqualTo(1));
			Assert.That(video1.Title, Is.EqualTo("Лидия Аркадьевна"));
			Assert.That(video1.Duration, Is.EqualTo(62));
			Assert.That(video1.Description, Is.EqualTo(string.Empty));
			Assert.That(video1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384721483)));
			Assert.That(video1.ViewsCount, Is.EqualTo(42107));
			Assert.That(video1.CommentsCount, Is.EqualTo(1243));
			Assert.That(video1.Photo130, Is.EqualTo(new Uri("http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg")));
			Assert.That(video1.Photo320, Is.EqualTo(new Uri("http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg")));
			Assert.That(video1.Player, Is.EqualTo(new Uri("http://www.youtube.com/embed/YfLytrkbAfM")));

			var video2 = result.Skip(2).FirstOrDefault();
			Assert.That(video2, Is.Not.Null);
			Assert.That(video2.Id, Is.EqualTo(164841344));
			Assert.That(video2.OwnerId, Is.EqualTo(1));
			Assert.That(video2.Title, Is.EqualTo("This is SPARTA"));
			Assert.That(video2.Duration, Is.EqualTo(16));
			Assert.That(video2.Description, Is.EqualTo(string.Empty));
			Assert.That(video2.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1366495075)));
			Assert.That(video2.ViewsCount, Is.EqualTo(218658));
			Assert.That(video2.CommentsCount, Is.EqualTo(2578));
			Assert.That(video2.Photo130, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));
			Assert.That(video2.Photo320, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));
			Assert.That(video2.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353")));
		}

         [Test]
         public void Get_Extended()
         {
			const string url = "https://api.vk.com/method/video.get?owner_id=1&count=3&offset=2&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
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

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.Get(1, width: VideoWidth.Large320, count: 3, offset: 2, extended:true);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));

			var video = result.FirstOrDefault();
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(166481021));
			Assert.That(video.OwnerId, Is.EqualTo(1));
			Assert.That(video.Title, Is.EqualTo("Лидия Аркадьевна"));
			Assert.That(video.Duration, Is.EqualTo(131));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867255)));
			Assert.That(video.ViewsCount, Is.EqualTo(81677));
			Assert.That(video.CommentsCount, Is.EqualTo(2098));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("http://cs419529.vk.me/u9258277/video/s_af2727af.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg")));
			Assert.That(video.Player, Is.EqualTo(new Uri("http://www.youtube.com/embed/VQaHFisdf-s")));
			Assert.That(video.CanComment, Is.EqualTo(true));
			Assert.That(video.CanRepost, Is.EqualTo(true));
			Assert.That(video.Repeat, Is.EqualTo(false));
			Assert.That(video.Likes, Is.Not.Null);
			Assert.That(video.Likes.UserLikes, Is.EqualTo(false));
			Assert.That(video.Likes.Count, Is.EqualTo(1789));

			var video1 = result.Skip(1).FirstOrDefault();
			Assert.That(video1, Is.Not.Null);
			Assert.That(video1.Id, Is.EqualTo(166468673));
			Assert.That(video1.OwnerId, Is.EqualTo(1));
			Assert.That(video1.Title, Is.EqualTo("Лидия Аркадьевна"));
			Assert.That(video1.Duration, Is.EqualTo(62));
			Assert.That(video1.Description, Is.EqualTo(string.Empty));
			Assert.That(video1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384721483)));
			Assert.That(video1.ViewsCount, Is.EqualTo(42107));
			Assert.That(video1.CommentsCount, Is.EqualTo(1243));
			Assert.That(video1.Photo130, Is.EqualTo(new Uri("http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg")));
			Assert.That(video1.Photo320, Is.EqualTo(new Uri("http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg")));
			Assert.That(video1.Player, Is.EqualTo(new Uri("http://www.youtube.com/embed/YfLytrkbAfM")));

			Assert.That(video1.CanComment, Is.EqualTo(true));
			Assert.That(video1.CanRepost, Is.EqualTo(true));
			Assert.That(video1.Repeat, Is.EqualTo(false));
			Assert.That(video1.Likes, Is.Not.Null);
			Assert.That(video1.Likes.UserLikes, Is.EqualTo(false));
			Assert.That(video1.Likes.Count, Is.EqualTo(640));

			var video2 = result.Skip(2).FirstOrDefault();
			Assert.That(video2, Is.Not.Null);
			Assert.That(video2.Id, Is.EqualTo(164841344));
			Assert.That(video2.OwnerId, Is.EqualTo(1));
			Assert.That(video2.Title, Is.EqualTo("This is SPARTA"));
			Assert.That(video2.Duration, Is.EqualTo(16));
			Assert.That(video2.Description, Is.EqualTo(string.Empty));
			Assert.That(video2.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1366495075)));
			Assert.That(video2.ViewsCount, Is.EqualTo(218659));
			Assert.That(video2.CommentsCount, Is.EqualTo(2578));
			Assert.That(video2.Photo130, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));
			Assert.That(video2.Photo320, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));
			Assert.That(video2.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353")));

			Assert.That(video2.CanComment, Is.EqualTo(true));
			Assert.That(video2.CanRepost, Is.EqualTo(true));
			Assert.That(video2.Repeat, Is.EqualTo(true));
			Assert.That(video2.Likes, Is.Not.Null);
			Assert.That(video2.Likes.UserLikes, Is.EqualTo(true));
			Assert.That(video2.Likes.Count, Is.EqualTo(4137));
		}

         [Test]
         public void Add_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.add?video_id=164841344&owner_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
                @"{
                    'response': 167593944
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var id = cat.Add(164841344, 1);
			Assert.That(id, Is.EqualTo(167593944));
		}

         [Test]
         public void Delete_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.delete?video_id=167593944&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.Delete(167593944);
			Assert.That(result, Is.True);
         }

         [Test]
         public void Restore_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.restore?video_id=167593944&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.Restore(167593944);
			Assert.That(result, Is.True);
		}

         [Test]
         public void AddAlbum_ToCurrentUser()
         {
             const string url = "https://api.vk.com/method/video.addAlbum?title=Новый альбом видеозаписей&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
				@"{
                    'response': {
                      'album_id': 49273471
                    }
                  }";
             var cat = GetMockedVideoCategory(url, json);

			var id = cat.AddAlbum("Новый альбом видеозаписей");
			Assert.That(id, Is.EqualTo(49273471));
		}

		// todo add not extended version
		[Test]
         public void GetAlbums_NormalCase_Extended_TwoItems()
         {
             const string url = "https://api.vk.com/method/video.getAlbums?owner_id=234695119&extended=1&v=" + VkApi.VkApiVersion + "&access_token=token";
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

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.GetAlbums(234695119, extended:true);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(2));

			var videoAlbum = result.FirstOrDefault();
			Assert.That(videoAlbum, Is.Not.Null);
			Assert.That(videoAlbum.Id, Is.EqualTo(52154345));
			Assert.That(videoAlbum.OwnerId, Is.EqualTo(234695119));
			Assert.That(videoAlbum.Title, Is.EqualTo("Второй новый альбом видеозаписей"));
			Assert.That(videoAlbum.Count, Is.EqualTo(0));

			var videoAlbum1 = result.Skip(1).FirstOrDefault();
			Assert.That(videoAlbum1, Is.Not.Null);
			Assert.That(videoAlbum1.Id, Is.EqualTo(52152803));
			Assert.That(videoAlbum1.OwnerId, Is.EqualTo(234695119));
			Assert.That(videoAlbum1.Title, Is.EqualTo("Новый альбом видеозаписей"));
			Assert.That(videoAlbum1.Count, Is.EqualTo(0));
		}

         [Test]
         public void DeleteAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.deleteAlbum?album_id=52153813&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.DeleteAlbum(52153813);
			Assert.That(result, Is.True);
         }

         [Test]
         public void EditAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.editAlbum?album_id=521543&title=Новое название!!!&v=" + VkApi.VkApiVersion + "&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.EditAlbum(521543, "Новое название!!!");
			Assert.That(result, Is.True);
		}

         [Test, Ignore("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
         public void MoveToAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.moveToAlbum?album_id=52154378&video_ids=167593938&v=" + VkApi.VkApiVersion + "&access_token=token";

             const string json =
                @"{
                    'response': 1
                  }";

             var cat = GetMockedVideoCategory(url, json);

			var result = cat.MoveToAlbum(new long[] {167593938}, 52154378);
			Assert.That(result, Is.True);
		}

         [Test]
         public void GetComments_WithLikes()
         {
			const string url = "https://api.vk.com/method/video.getComments?owner_id=1&video_id=166481021&need_likes=1&offset=3&count=2&sort=asc&v=" + VkApi.VkApiVersion + "&access_token=token";
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

             var cat = GetMockedVideoCategory(url, json);

			var comments = cat.GetComments(166481021, 1, true, 2, 3, CommentsSort.Asc);
			Assert.That(comments, Is.Not.Null);
			Assert.That(comments.Count, Is.EqualTo(2));

			var comment = comments.FirstOrDefault();
			Assert.That(comment, Is.Not.Null);

			Assert.That(comment.Id, Is.EqualTo(14715));
			Assert.That(comment.FromId, Is.EqualTo(24758120));
			Assert.That(comment.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867361)));
			Assert.That(comment.Text, Is.EqualTo("паша здаров!"));
			Assert.That(comment.Likes.Count, Is.EqualTo(5));
			Assert.That(comment.Likes.UserLikes, Is.EqualTo(false));
			Assert.That(comment.Likes.CanLike, Is.EqualTo(true));

			var comment1 = comments.Skip(1).FirstOrDefault();
			Assert.That(comment1, Is.Not.Null);

			Assert.That(comment1.Id, Is.EqualTo(14716));
			Assert.That(comment1.FromId, Is.EqualTo(94278436));
			Assert.That(comment1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867372)));
			Assert.That(comment1.Text, Is.EqualTo("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));
			Assert.That(comment1.Likes.Count, Is.EqualTo(77));
			Assert.That(comment1.Likes.UserLikes, Is.EqualTo(false));
			Assert.That(comment1.Likes.CanLike, Is.EqualTo(true));
		}

		[Test]
         public void GetComments_WithoutLikes()
         {
			const string url = "https://api.vk.com/method/video.getComments?owner_id=1&video_id=166481021&offset=3&count=2&sort=asc&v=" + VkApi.VkApiVersion + "&access_token=token";
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

             var cat = GetMockedVideoCategory(url, json);

			var comments = cat.GetComments(166481021, 1, false, 2, 3, CommentsSort.Asc);
			Assert.That(comments, Is.Not.Null);
			Assert.That(comments.Count, Is.EqualTo(2));

			var comment = comments.FirstOrDefault();
			Assert.That(comment, Is.Not.Null);

			Assert.That(comment.Id, Is.EqualTo(14715));
			Assert.That(comment.FromId, Is.EqualTo(24758120));
			Assert.That(comment.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867361)));
			Assert.That(comment.Text, Is.EqualTo("паша здаров!"));

			var comment1 = comments.Skip(1).FirstOrDefault();
			Assert.That(comment1, Is.Not.Null);
			Assert.That(comment1.Id, Is.EqualTo(14716));
			Assert.That(comment1.FromId, Is.EqualTo(94278436));
			Assert.That(comment1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867372)));
			Assert.That(comment1.Text, Is.EqualTo("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));
		}

		[Test]
        public void Search_NormalCase_ListOfVideos()
        {
			const string url = "https://api.vk.com/method/video.search?q=саша грей&sort=2&adult=1&filters=long&offset=1&count=5&v=" + VkApi.VkApiVersion + "&access_token=token";
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

            var cat = GetMockedVideoCategory(url, json);

            var result = cat.Search("саша грей", VideoSort.Relevance, false, true, VideoFilters.Long, false, 5, 1);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));

			var video = result.FirstOrDefault();
			Assert.That(video, Is.Not.Null);

			Assert.That(video.Id, Is.EqualTo(166671614));
			Assert.That(video.OwnerId, Is.EqualTo(-59205334));
			Assert.That(video.Title, Is.EqualTo("Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ"));
			Assert.That(video.Duration, Is.EqualTo(1934));
			Assert.That(video.Description, Is.EqualTo("beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<"));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384706962)));
			Assert.That(video.ViewsCount, Is.EqualTo(11579));
			Assert.That(video.CommentsCount, Is.EqualTo(12));
			Assert.That(video.Photo130, Is.EqualTo(new Uri("http://cs505118.vk.me/u7160710/video/s_08382000.jpg")));
			Assert.That(video.Photo320, Is.EqualTo(new Uri("http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg")));
			Assert.That(video.AlbumId, Is.EqualTo(50100051));
			Assert.That(video.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d")));

			var video1 = result.Skip(1).FirstOrDefault();
			Assert.That(video1, Is.Not.Null);

			Assert.That(video1.Id, Is.EqualTo(165458571));
			Assert.That(video1.OwnerId, Is.EqualTo(-49956637));
			Assert.That(video1.Title, Is.EqualTo("домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа"));
			Assert.That(video1.Duration, Is.EqualTo(1139));
			Assert.That(video1.Description, Is.EqualTo("секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex"));
			Assert.That(video1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1371702618)));
			Assert.That(video1.ViewsCount, Is.EqualTo(12817));
			Assert.That(video1.CommentsCount, Is.EqualTo(5));
			Assert.That(video1.Photo130, Is.EqualTo(new Uri("http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg")));
			Assert.That(video1.Photo320, Is.EqualTo(new Uri("http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg")));
			Assert.That(video1.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92")));

			var video2 = result.Skip(2).FirstOrDefault();
			Assert.That(video2, Is.Not.Null);

			Assert.That(video2.Id, Is.EqualTo(166728490));
			Assert.That(video2.OwnerId, Is.EqualTo(-54257090));
			Assert.That(video2.Title, Is.EqualTo("Саша Грей | Sasha Grey #13"));
			Assert.That(video2.Duration, Is.EqualTo(1289));
			Assert.That(video2.Description, Is.EqualTo("Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica"));
			Assert.That(video2.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1386961568)));
			Assert.That(video2.ViewsCount, Is.EqualTo(8730));
			Assert.That(video2.CommentsCount, Is.EqualTo(12));
			Assert.That(video2.Photo130, Is.EqualTo(new Uri("http://cs535107.vk.me/u146564541/video/s_2d874147.jpg")));
			Assert.That(video2.Photo320, Is.EqualTo(new Uri("http://cs535107.vk.me/u146564541/video/l_cb794198.jpg")));
			Assert.That(video2.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac")));
		}

		[Test]
        public void CreateComment_NormalCase()
        {
			const string url = "https://api.vk.com/method/video.createComment?owner_id=1&video_id=166613182&message=забавное видео&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
                @"{
                    'response': 35634
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var id = cat.CreateComment(166613182, "забавное видео", 1);
			Assert.That(id, Is.EqualTo(35634));
		}

        [Test]
        public void DeleteComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.deleteComment?comment_id=35634&owner_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var result = cat.DeleteComment(35634, 1);
			Assert.That(result, Is.True);
        }

        [Test]
        public void RestoreComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.restoreComment?comment_id=35634&owner_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var result = cat.RestoreComment(35634, 1);
			Assert.That(result, Is.True);
		}

        [Test]
        public void EditComment_NormalCase()
        {
			const string url = "https://api.vk.com/method/video.editComment?owner_id=1&comment_id=35634&message=суперское видео&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var result = cat.EditComment(35634, "суперское видео", 1);
			Assert.That(result, Is.True);
		}

        [Test]
        public void Report_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.report?video_id=166613182&owner_id=1&reason=4&comment=коммент&v=" + VkApi.VkApiVersion + "&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var result = cat.Report(166613182, Enums.ReportReason.DrugPropaganda, 1, "коммент");
			Assert.That(result, Is.True);
		}

        [Test]
        public void ReportComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.reportComment?comment_id=35637&owner_id=1&reason=5&v=" + VkApi.VkApiVersion + "&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

            var result = cat.ReportComment(35637, 1, Enums.ReportReason.AdultMaterial);
			Assert.That(result, Is.True);
		}

        [Test]
        public void Edit_NormalCase()
        {
			const string url = "https://api.vk.com/method/video.edit?owner_id=23469&video_id=167538&name=Новое название&desc=Новое описание&v=" + VkApi.VkApiVersion + "&access_token=token";
			const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedVideoCategory(url, json);

			var result = cat.Edit(167538, 23469, "Новое название", "Новое описание");
			Assert.That(result, Is.True);
		}

        [Test]
        public void Save_NormalCase()
        {
			const string url = "https://api.vk.com/method/video.save?name=Название из ютуба&description=Описание из ютуба&wallpost=1&link=https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA&v=" + VkApi.VkApiVersion + "&access_token=token";
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

            var cat = GetMockedVideoCategory(url, json);

            var video = cat.Save("Название из ютуба", "Описание из ютуба", isPostToWall: true, link: "https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA");
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(1673994));
			Assert.That(video.OwnerId, Is.EqualTo(2346958));
			Assert.That(video.Title, Is.EqualTo("Название из ютуба"));
			Assert.That(video.Description, Is.EqualTo("Описание из ютуба"));
			Assert.That(video.AccessKey, Is.EqualTo("f2ec9f3982f05bc"));
			Assert.That(video.UploadUrl, Is.EqualTo(new Uri("http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043")));
		}

    }
}