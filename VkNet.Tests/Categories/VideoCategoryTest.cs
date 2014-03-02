using System;
using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using VkNet.Categories;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Categories
{
    [TestFixture]
    public class VideoCategoryTest
    {
         private VideoCategory GetMockedVideoCategory(string url, string json)
         {
             var browser = new Mock<IBrowser>();
             browser.Setup(m => m.GetJson(url)).Returns(json);

             return new VideoCategory(new VkApi{AccessToken = "token", Browser = browser.Object, Version = "5.9"});
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
             result[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 20, 55));
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
             result[1].Date.ShouldEqual(new DateTime(2013, 11, 18, 0, 51, 23));
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
             result[2].Date.ShouldEqual(new DateTime(2013, 4, 21, 1, 57, 55));
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
             result[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 20, 55));
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
             result[1].Date.ShouldEqual(new DateTime(2013, 11, 18, 0, 51, 23));
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
             result[2].Date.ShouldEqual(new DateTime(2013, 4, 21, 1, 57, 55));
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
             comments[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 22, 41));
             comments[0].Text.ShouldEqual("паша здаров!");
             comments[0].Likes.Count.ShouldEqual(5);
             comments[0].Likes.UserLikes.ShouldEqual(false);
             comments[0].Likes.CanLike.ShouldEqual(true);

             comments[1].Id.ShouldEqual(14716);
             comments[1].FromId.ShouldEqual(94278436);
             comments[1].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 22, 52));
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
             comments[0].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 22, 41));
             comments[0].Text.ShouldEqual("паша здаров!");
             
             comments[1].Id.ShouldEqual(14716);
             comments[1].FromId.ShouldEqual(94278436);
             comments[1].Date.ShouldEqual(new DateTime(2013, 11, 19, 17, 22, 52));
             comments[1].Text.ShouldEqual("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!");
         }

    }
}