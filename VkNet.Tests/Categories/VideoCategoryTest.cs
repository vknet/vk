namespace VkNet.Tests.Categories
{
    using System;
    using System.Collections.ObjectModel;
    using Moq;
    using NUnit.Framework;
    using VkNet.Categories;
    using VkNet.Utils;
    using FluentNUnit;

    using Enums;
    using Model;
    using Enums.Filters;
    using Enums.SafetyEnums;
    using Model.Attachments;
    

    [TestFixture]
    public class VideoCategoryTest
    {
         private VideoCategory GetMockedVideoCategory(string url, string json)
         {
             var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
             return new VideoCategory(new VkApi{AccessToken = "token", Browser = browser});
         }

         [Test]
         public void Get_NotExtended()
         {
             const string url = "https://api.vk.com/method/video.get?owner_id=1&width=320&count=3&offset=2&extended=0&v=5.9&access_token=token";
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

             VideoCategory cat = GetMockedVideoCategory(url, json);

             ReadOnlyCollection<Video> result = cat.Get(1, width:VideoWidth.Large320, count: 3, offset: 2);

             result.Count.ShouldEqual(3);
             result[0].Id.ShouldEqual(166481021);
             result[0].OwnerId.ShouldEqual(1);
             result[0].Title.ShouldEqual("Лидия Аркадьевна");
             result[0].Duration.ShouldEqual(131);
             result[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 20, 55, DateTimeKind.Utc).ToLocalTime());
             result[0].ViewsCount.ShouldEqual(81676);
             result[0].CommentsCount.ShouldEqual(2098);
             result[0].Photo130.ShouldEqual(new Uri("http://cs419529.vk.me/u9258277/video/s_af2727af.jpg"));
             result[0].Photo320.ShouldEqual(new Uri("http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg"));
             result[0].Player.ShouldEqual(new Uri("http://www.youtube.com/embed/VQaHFisdf-s"));

             result[1].Id.ShouldEqual(166468673);
             result[1].OwnerId.ShouldEqual(1);
             result[1].Title.ShouldEqual("Лидия Аркадьевна");
             result[1].Duration.ShouldEqual(62);
             result[1].Description.ShouldEqual(string.Empty);
             result[1].Date.ShouldEqual(new DateTime(2013, 11, 17, 20, 51, 23, DateTimeKind.Utc).ToLocalTime());
             result[1].ViewsCount.ShouldEqual(42107);
             result[1].CommentsCount.ShouldEqual(1243);
             result[1].Photo130.ShouldEqual(new Uri("http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg"));
             result[1].Photo320.ShouldEqual(new Uri("http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg"));
             result[1].Player.ShouldEqual(new Uri("http://www.youtube.com/embed/YfLytrkbAfM"));

             result[2].Id.ShouldEqual(164841344);
             result[2].OwnerId.ShouldEqual(1);
             result[2].Title.ShouldEqual("This is SPARTA");
             result[2].Duration.ShouldEqual(16);
             result[2].Description.ShouldEqual(string.Empty);
             result[2].Date.ShouldEqual(new DateTime(2013, 4, 20, 21, 57, 55, DateTimeKind.Utc).ToLocalTime());
             result[2].ViewsCount.ShouldEqual(218658);
             result[2].CommentsCount.ShouldEqual(2578);
             result[2].Photo130.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));
             result[2].Photo320.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));
             result[2].Player.ShouldEqual(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353"));
         }

         [Test]
         public void Get_Extended()
         {
             const string url = "https://api.vk.com/method/video.get?owner_id=1&width=320&count=3&offset=2&extended=1&v=5.9&access_token=token";
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

             VideoCategory cat = GetMockedVideoCategory(url, json);

             ReadOnlyCollection<Video> result = cat.Get(1, width: VideoWidth.Large320, count: 3, offset: 2, extended:true);

             result.Count.ShouldEqual(3);
             result[0].Id.ShouldEqual(166481021);
             result[0].OwnerId.ShouldEqual(1);
             result[0].Title.ShouldEqual("Лидия Аркадьевна");
             result[0].Duration.ShouldEqual(131);
             result[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 20, 55, DateTimeKind.Utc).ToLocalTime());
             result[0].ViewsCount.ShouldEqual(81677);
             result[0].CommentsCount.ShouldEqual(2098);
             result[0].Photo130.ShouldEqual(new Uri("http://cs419529.vk.me/u9258277/video/s_af2727af.jpg"));
             result[0].Photo320.ShouldEqual(new Uri("http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg"));
             result[0].Player.ShouldEqual(new Uri("http://www.youtube.com/embed/VQaHFisdf-s"));
             result[0].CanComment.ShouldEqual(true);
             result[0].CanRepost.ShouldEqual(true);
             result[0].Repeat.ShouldEqual(false);
             result[0].Likes.ShouldNotBeNull();
             result[0].Likes.UserLikes.ShouldEqual(false);
             result[0].Likes.Count.ShouldEqual(1789);

             result[1].Id.ShouldEqual(166468673);
             result[1].OwnerId.ShouldEqual(1);
             result[1].Title.ShouldEqual("Лидия Аркадьевна");
             result[1].Duration.ShouldEqual(62);
             result[1].Description.ShouldEqual(string.Empty);
             result[1].Date.ShouldEqual(new DateTime(2013, 11, 17, 20, 51, 23, DateTimeKind.Utc).ToLocalTime());
             result[1].ViewsCount.ShouldEqual(42107);
             result[1].CommentsCount.ShouldEqual(1243);
             result[1].Photo130.ShouldEqual(new Uri("http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg"));
             result[1].Photo320.ShouldEqual(new Uri("http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg"));
             result[1].Player.ShouldEqual(new Uri("http://www.youtube.com/embed/YfLytrkbAfM"));

             result[1].CanComment.ShouldEqual(true);
             result[1].CanRepost.ShouldEqual(true);
             result[1].Repeat.ShouldEqual(false);
             result[1].Likes.ShouldNotBeNull();
             result[1].Likes.UserLikes.ShouldEqual(false);
             result[1].Likes.Count.ShouldEqual(640);

             result[2].Id.ShouldEqual(164841344);
             result[2].OwnerId.ShouldEqual(1);
             result[2].Title.ShouldEqual("This is SPARTA");
             result[2].Duration.ShouldEqual(16);
             result[2].Description.ShouldEqual(string.Empty);
             result[2].Date.ShouldEqual(new DateTime(2013, 4, 20, 21, 57, 55, DateTimeKind.Utc).ToLocalTime());
             result[2].ViewsCount.ShouldEqual(218659);
             result[2].CommentsCount.ShouldEqual(2578);
             result[2].Photo130.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));
             result[2].Photo320.ShouldEqual(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));
             result[2].Player.ShouldEqual(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353"));

             result[2].CanComment.ShouldEqual(true);
             result[2].CanRepost.ShouldEqual(true);
             result[2].Repeat.ShouldEqual(true);
             result[2].Likes.ShouldNotBeNull();
             result[2].Likes.UserLikes.ShouldEqual(true);
             result[2].Likes.Count.ShouldEqual(4137);
         }

         [Test]
         public void Add_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.add?video_id=164841344&owner_id=1&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 167593944
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             long id = cat.Add(164841344, 1);

             id.ShouldEqual(167593944);
         }

         [Test]
         public void Delete_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.delete?video_id=167593944&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             bool result = cat.Delete(167593944);

             result.ShouldBeTrue();
         }

         [Test]
         public void Restore_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.restore?video_id=167593944&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             bool result = cat.Restore(167593944);

             result.ShouldBeTrue();
         }

         [Test]
         public void AddAlbum_ToCurrentUser()
         {
             const string url = "https://api.vk.com/method/video.addAlbum?title=Новый альбом видеозаписей&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': {
                      'album_id': 52153803
                    }
                  }";
             // todo real album id

             VideoCategory cat = GetMockedVideoCategory(url, json);

             long id = cat.AddAlbum("Новый альбом видеозаписей");

             id.ShouldEqual(52153803);
         }

         // todo add not extended version
         [Test]
         public void GetAlbums_NormalCase_Extended_TwoItems()
         {
             const string url = "https://api.vk.com/method/video.getAlbums?owner_id=234695119&extended=1&v=5.9&access_token=token";
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

             VideoCategory cat = GetMockedVideoCategory(url, json);

             ReadOnlyCollection<VideoAlbum> result = cat.GetAlbums(234695119, extended:true);

             result.Count.ShouldEqual(2);
             result[0].Id.ShouldEqual(52154345);
             result[0].OwnerId.ShouldEqual(234695119);
             result[0].Title.ShouldEqual("Второй новый альбом видеозаписей");
             result[0].Count.ShouldEqual(0);

             result[1].Id.ShouldEqual(52152803);
             result[1].OwnerId.ShouldEqual(234695119);
             result[1].Title.ShouldEqual("Новый альбом видеозаписей");
             result[1].Count.ShouldEqual(0);
         }

         [Test]
         public void DeleteAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.deleteAlbum?album_id=52153813&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             bool result = cat.DeleteAlbum(52153813);

             result.ShouldBeTrue();
         }

         [Test]
         public void EditAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.editAlbum?album_id=521543&title=Новое название!!!&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             bool result = cat.EditAlbum(521543, "Новое название!!!");

             result.ShouldBeTrue();
         }

         [Test]
         public void MoveToAlbum_NormalCase()
         {
             const string url = "https://api.vk.com/method/video.moveToAlbum?album_id=52154378&video_ids=167593938&v=5.9&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";

             VideoCategory cat = GetMockedVideoCategory(url, json);

             bool result = cat.MoveToAlbum(new long[] {167593938}, 52154378);

             result.ShouldBeTrue();
         }

         [Test]
         public void GetComments_WithLikes()
         {
             const string url = "https://api.vk.com/method/video.getComments?video_id=166481021&owner_id=1&need_likes=1&count=2&offset=3&sort=asc&v=5.9&access_token=token";
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

             VideoCategory cat = GetMockedVideoCategory(url, json);

             ReadOnlyCollection<Comment> comments = cat.GetComments(166481021, 1, true, 2, 3, CommentsSort.Asc);

             comments.Count.ShouldEqual(2);

             comments[0].Id.ShouldEqual(14715);
             comments[0].FromId.ShouldEqual(24758120);
             comments[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 22, 41, DateTimeKind.Utc).ToLocalTime());
             comments[0].Text.ShouldEqual("паша здаров!");
             comments[0].Likes.Count.ShouldEqual(5);
             comments[0].Likes.UserLikes.ShouldEqual(false);
             comments[0].Likes.CanLike.ShouldEqual(true);

             comments[1].Id.ShouldEqual(14716);
             comments[1].FromId.ShouldEqual(94278436);
             comments[1].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 22, 52, DateTimeKind.Utc).ToLocalTime());
             comments[1].Text.ShouldEqual("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!");
             comments[1].Likes.Count.ShouldEqual(77);
             comments[1].Likes.UserLikes.ShouldEqual(false);
             comments[1].Likes.CanLike.ShouldEqual(true);
         }

         [Test]
         public void GetComments_WithoutLikes()
         {
             const string url = "https://api.vk.com/method/video.getComments?video_id=166481021&owner_id=1&need_likes=0&count=2&offset=3&sort=asc&v=5.9&access_token=token";
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

             VideoCategory cat = GetMockedVideoCategory(url, json);

             ReadOnlyCollection<Comment> comments = cat.GetComments(166481021, 1, false, 2, 3, CommentsSort.Asc);

             comments.Count.ShouldEqual(2);

             comments[0].Id.ShouldEqual(14715);
             comments[0].FromId.ShouldEqual(24758120);
			comments[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 22, 41, DateTimeKind.Utc).ToLocalTime());
             comments[0].Text.ShouldEqual("паша здаров!");
             
             comments[1].Id.ShouldEqual(14716);
             comments[1].FromId.ShouldEqual(94278436);
			comments[1].Date.ShouldEqual(new DateTime(2013, 11, 19, 13, 22, 52, DateTimeKind.Utc).ToLocalTime());
             comments[1].Text.ShouldEqual("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!");
         }

        [Test]
        public void Search_NormalCase_ListOfVideos()
        {
            const string url = "https://api.vk.com/method/video.search?q=саша грей&sort=2&hd=0&adult=1&filters=long&search_own=0&offset=1&count=5&v=5.9&access_token=token";
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

            ReadOnlyCollection<Video> result = cat.Search("саша грей", VideoSort.Relevance, false, true, VideoFilters.Long, false, 5, 1);

            result.Count.ShouldEqual(3);

            result[0].Id.ShouldEqual(166671614);
            result[0].OwnerId.ShouldEqual(-59205334);
            result[0].Title.ShouldEqual("Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ");
            result[0].Duration.ShouldEqual(1934);
            result[0].Description.ShouldEqual("beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<");
            result[0].Date.ShouldEqual(new DateTime(2013, 11, 17, 16, 49, 22, DateTimeKind.Utc).ToLocalTime());
            result[0].ViewsCount.ShouldEqual(11579);
            result[0].CommentsCount.ShouldEqual(12);
            result[0].Photo130.ShouldEqual(new Uri("http://cs505118.vk.me/u7160710/video/s_08382000.jpg"));
            result[0].Photo320.ShouldEqual(new Uri("http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg"));
            result[0].AlbumId.ShouldEqual(50100051);
            result[0].Player.ShouldEqual(new Uri("http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d"));
            
            result[1].Id.ShouldEqual(165458571);
            result[1].OwnerId.ShouldEqual(-49956637);
            result[1].Title.ShouldEqual("домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа");
            result[1].Duration.ShouldEqual(1139);
            result[1].Description.ShouldEqual("секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex");
			result[1].Date.ShouldEqual(new DateTime(2013, 6, 20, 4, 30, 18, DateTimeKind.Utc).ToLocalTime());
            result[1].ViewsCount.ShouldEqual(12817);
            result[1].CommentsCount.ShouldEqual(5);
            result[1].Photo130.ShouldEqual(new Uri("http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg"));
            result[1].Photo320.ShouldEqual(new Uri("http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg"));
            result[1].Player.ShouldEqual(new Uri("http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92"));
            
            result[2].Id.ShouldEqual(166728490);
            result[2].OwnerId.ShouldEqual(-54257090);
            result[2].Title.ShouldEqual("Саша Грей | Sasha Grey #13");
            result[2].Duration.ShouldEqual(1289);
            result[2].Description.ShouldEqual("Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica");
			result[2].Date.ShouldEqual(new DateTime(2013, 12, 13, 19, 6, 8, DateTimeKind.Utc).ToLocalTime());
            result[2].ViewsCount.ShouldEqual(8730);
            result[2].CommentsCount.ShouldEqual(12);
            result[2].Photo130.ShouldEqual(new Uri("http://cs535107.vk.me/u146564541/video/s_2d874147.jpg"));
            result[2].Photo320.ShouldEqual(new Uri("http://cs535107.vk.me/u146564541/video/l_cb794198.jpg"));
            result[2].Player.ShouldEqual(new Uri("http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac"));
        }

        [Test]
        public void CreateComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.createComment?video_id=166613182&owner_id=1&message=забавное видео&from_group=0&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 35634
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            long id = cat.CreateComment(166613182, "забавное видео", 1);

            id.ShouldEqual(35634);
        }

        [Test]
        public void DeleteComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.deleteComment?comment_id=35634&owner_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.DeleteComment(35634, 1);

            result.ShouldBeTrue();
        }

        [Test]
        public void RestoreComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.restoreComment?comment_id=35634&owner_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.RestoreComment(35634, 1);

            result.ShouldBeTrue();
        }

        [Test]
        public void EditComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.editComment?comment_id=35634&message=суперское видео&owner_id=1&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.EditComment(35634, "суперское видео", 1);

            result.ShouldBeTrue();
        }

        [Test]
        public void Report_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.report?video_id=166613182&owner_id=1&reason=4&comment=коммент&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.Report(166613182, VideoReportType.DrugPropaganda, 1, "коммент");

            result.ShouldBeTrue();
        }

        [Test]
        public void ReportComment_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.reportComment?comment_id=35637&owner_id=1&reason=5&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.ReportComment(35637, 1, VideoReportType.AdultMaterial);

            result.ShouldBeTrue();
        }

        [Test]
        public void Edit_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.edit?video_id=167538&owner_id=23469&name=Новое название&desc=Новое описание&repeat=0&v=5.9&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            VideoCategory cat = GetMockedVideoCategory(url, json);

            bool result = cat.Edit(167538, 23469, "Новое название", "Новое описание");

            result.ShouldBeTrue();
        }

        [Test]
        public void Save_NormalCase()
        {
            const string url = "https://api.vk.com/method/video.save?name=Название из ютуба&description=Описание из ютуба&is_private=0&wallpost=1&link=https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA&repeat=0&v=5.9&access_token=token";
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

            VideoCategory cat = GetMockedVideoCategory(url, json);

            Video v = cat.Save("Название из ютуба", "Описание из ютуба", isPostToWall: true, link: "https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA");

            v.Id.ShouldEqual(1673994);
            v.OwnerId.ShouldEqual(2346958);
            v.Title.ShouldEqual("Название из ютуба");
            v.Description.ShouldEqual("Описание из ютуба");
            v.AccessKey.ShouldEqual("f2ec9f3982f05bc");
            v.UploadUrl.ShouldEqual(new Uri("http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043"));
        }

    }
}