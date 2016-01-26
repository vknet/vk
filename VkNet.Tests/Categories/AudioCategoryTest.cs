using System.Diagnostics.CodeAnalysis;

namespace VkNet.Tests.Categories
{
    using System;
    using System.Collections.ObjectModel;

    using Moq;
    using NUnit.Framework;
    using VkNet.Categories;
    using Enums;
    using Exception;
    using Model;
    using Model.Attachments;

    using VkNet.Utils;
    using FluentNUnit;

    [TestFixture]
    [SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
    public class AudioCategoryTest
    {
        private AudioCategory GetMockedAudioCategory(string url, string json)
        {
            var browser = Mock.Of<IBrowser>(m => m.GetJson(url) == json);
            return new AudioCategory(new VkApi { AccessToken = "token", Browser = browser});
        }

        #region GetCount

        [Test]
        public void GetCount_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.GetCount(1)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetCount_UserHasNoAudio_ReturnsZero()
        {
			const string url = "https://api.vk.com/method/audio.getCount?owner_id=1&v=5.44&access_token=token";
			const string json =
                @"{
                    response: 0
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var count = audio.GetCount(1);

			Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void GetCount_UserHasAudio_ReturnsCountOfRecords()
        {
			const string url = "https://api.vk.com/method/audio.getCount?owner_id=1&v=5.44&access_token=token";
			const string json =
                @"{
                    response: 158
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var count = audio.GetCount(1);

			Assert.That(count, Is.EqualTo(158));
        }

        [Test]
        public void GetCount_GroupHasAudio_ReturnsCountOfRecords()
        {
			const string url = "https://api.vk.com/method/audio.getCount?owner_id=-1158263&v=5.44&access_token=token";
			const string json =
                @"{
                    response: 4
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var count = audio.GetCount(-1158263);

			Assert.That(count, Is.EqualTo(4));
        }

        #endregion

        #region GetLyrics

        [Test]
        public void GetLyrics_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.GetLyrics(222)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetLyrics_2662381_ReturnsLyrics()
        {
			const string url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=2662381&v=5.44&access_token=token";
			const string json =
                @"{
                    response: {
                      lyrics_id: 2662381,
                      text: 'Seht ihr mich?\nVersteht ihr mich?\nF&#252;hlt ihr mich?\nH&#246;rt ihr mich?'
                    }
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var lyrics = audio.GetLyrics(2662381);

			Assert.That(lyrics.Id, Is.EqualTo(2662381));
            Assert.That(lyrics.Text, Is.EqualTo("Seht ihr mich?\nVersteht ihr mich?\nFühlt ihr mich?\nHört ihr mich?"));
        }

        [Test]
        public void GetLyrics_WrongLyricsId_ReturnsEmptyLyrics()
        {
			const string url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=-1&v=5.44&access_token=token";
			const string json =
                @"{
                    response: {
                      lyrics_id: -1,
                      text: ''
                    }
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var lyrics = audio.GetLyrics(-1);

			Assert.That(lyrics.Id, Is.EqualTo(-1));
            Assert.That(lyrics.Text, Is.Null.Or.Empty);
        }

        #endregion

        #region GetById

        [Test]
        public void GetById_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.GetById(new[] { "1_1" })).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetById_AudiosParamIsNull_ThrowsArgumentNullException()
        {
            var audio = GetMockedAudioCategory("", "");
            This.Action(() => audio.GetById(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void GetById_WrongId_ReturnsEmptyList()
        {
			const string url = "https://api.vk.com/method/audio.getById?audios=2e4w_67859ds194&v=5.44&access_token=token";
			const string json =
                @"{
                    response: []
                  }";

            var cat = GetMockedAudioCategory(url, json);

            var audios = cat.GetById("2e4w_67859ds194");
            Assert.That(audios.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetById_NormalCase_ListOfAudioObjects()
        {
			const string url = "https://api.vk.com/method/audio.getById?audios=4793858_158073513,2_63937759&v=5.44&access_token=token";
			const string json =
                @"{
                    response: [
                      {
                        id: 158073513,
                        owner_id: 4793858,
                        artist: 'Тараканы!',
                        title: 'Собачье Сердце',
                        duration: 230,
                        url: 'http://cs1-48v4.vk.me/p9/67e26e496a90c9.mp3?extra=ANx_RCt9IR0J__5W_mtAZnymMBpWtoUN2jpxv4nGoRAKughoGmcNqpIlN6zQNW83aHlVqUMNoqi12XEcmSV-8STD68aRVj4',
                        lyrics_id: 7985406,
                        genre_id: 18
                      }, 
                      {
                        id: 63937759,
                        owner_id: 2,
                        artist: 'Madonna',
                        title: 'Celebration',
                        duration: 215,
                        url: 'http://cs1-17v4.vk.me/p10/588a7dc76504b2.mp3?extra=s-AY9VvYoFoyqWr89mbugo9Br7exgc3R1PORbScZsV1BUSZ1RYUXXVmiwE7tfelVyVk2Hv429VYXvJKO5xLJmQ',
                        lyrics_id: 2195871,
                        album_id: 26758146,
                        genre_id: 2
                      }
                    ]
                  }";

            var audio = GetMockedAudioCategory(url, json);
            var audios = audio.GetById("4793858_158073513", "2_63937759");

            Assert.That(audios.Count, Is.EqualTo(2));
            
            Assert.That(audios[0].Id, Is.EqualTo(158073513));
            Assert.That(audios[0].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[0].Artist, Is.EqualTo("Тараканы!"));
            Assert.That(audios[0].Title, Is.EqualTo("Собачье Сердце"));
            Assert.That(audios[0].Duration, Is.EqualTo(230));
            Assert.That(audios[0].Url.OriginalString, Is.EqualTo("http://cs1-48v4.vk.me/p9/67e26e496a90c9.mp3?extra=ANx_RCt9IR0J__5W_mtAZnymMBpWtoUN2jpxv4nGoRAKughoGmcNqpIlN6zQNW83aHlVqUMNoqi12XEcmSV-8STD68aRVj4"));
            Assert.That(audios[0].LyricsId, Is.EqualTo(7985406));
            Assert.That(audios[0].Genre, Is.EqualTo(AudioGenre.Other));

            Assert.That(audios[1].Id, Is.EqualTo(63937759));
            Assert.That(audios[1].OwnerId, Is.EqualTo(2));
            Assert.That(audios[1].Artist, Is.EqualTo("Madonna"));
            Assert.That(audios[1].Title, Is.EqualTo("Celebration"));
            Assert.That(audios[1].Duration, Is.EqualTo(215));
            Assert.That(audios[1].Url.OriginalString, Is.EqualTo("http://cs1-17v4.vk.me/p10/588a7dc76504b2.mp3?extra=s-AY9VvYoFoyqWr89mbugo9Br7exgc3R1PORbScZsV1BUSZ1RYUXXVmiwE7tfelVyVk2Hv429VYXvJKO5xLJmQ"));
            Assert.That(audios[1].LyricsId, Is.EqualTo(2195871));
            Assert.That(audios[1].AlbumId, Is.EqualTo(26758146));
            Assert.That(audios[1].Genre, Is.EqualTo(AudioGenre.Pop));
        }

        #endregion

        [Test]
        public void GetUploadServer_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.GetUploadServer()).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void GetUploadServer_NormalCase_ReturnUploadUrl()
        {
			const string url = "https://api.vk.com/method/audio.getUploadServer?v=5.44&access_token=token";
			const string json =
				@"{
                    'response': {
                      'upload_url': 'http://cs6173.vk.com/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1'
                    }
                  }";
			var audio = GetMockedAudioCategory(url, json);
            var uploadUrl = audio.GetUploadServer();

            Assert.That(uploadUrl, Is.EqualTo(new Uri("http://cs6173.vk.com/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1")));
        }

        [Test]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.Get(1)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Get_NormalCaseDefaultValues_ListOfAudioObjects()
        {
			const string url = "https://api.vk.com/method/audio.get?owner_id=4793858&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': [
                      {
                        'id': 158947216,
                        'owner_id': 4793858,
                        'artist': 'Дядя Женя',
                        'title': 'Вопреки законам природы',
                        'duration': 204,
                        'url': 'http://cs4517.vkontakte.ru/u50781326/audio/d20ef68f7848.mp3',
                        'lyrics_id': '4002932'
                      },
                      {
                        'id': 158945986,
                        'owner_id': 4793858,
                        'artist': 'Дядя Женя',
                        'title': 'Финал: Без правил',
                        'duration': 380,
                        'url': 'http://cs4259.vkontakte.ru/u1622813/audio/61bf620e698e.mp3',
                        'lyrics_id': '3004301'
                      }
                    ]
                  }";

            var category = GetMockedAudioCategory(url, json);
            var audios = category.Get(4793858);

            Assert.That(audios.Count, Is.EqualTo(2));
            Assert.That(audios[0].Id, Is.EqualTo(158947216));
            Assert.That(audios[0].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[0].Artist, Is.EqualTo("Дядя Женя"));
            Assert.That(audios[0].Title, Is.EqualTo("Вопреки законам природы"));
            Assert.That(audios[0].Duration, Is.EqualTo(204));
            Assert.That(audios[0].Url.OriginalString, Is.EqualTo("http://cs4517.vkontakte.ru/u50781326/audio/d20ef68f7848.mp3"));
            Assert.That(audios[0].LyricsId, Is.EqualTo(4002932));
            Assert.That(audios[1].Id, Is.EqualTo(158945986));
            Assert.That(audios[1].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[1].Artist, Is.EqualTo("Дядя Женя"));
            Assert.That(audios[1].Title, Is.EqualTo("Финал: Без правил"));
            Assert.That(audios[1].Duration, Is.EqualTo(380));
            Assert.That(audios[1].Url.OriginalString, Is.EqualTo("http://cs4259.vkontakte.ru/u1622813/audio/61bf620e698e.mp3"));
            Assert.That(audios[1].LyricsId, Is.EqualTo(3004301));
        }

        [Test]
        public void GetFromGroup_NormalCase_ReturnListOfAudio()
        {
			const string url = "https://api.vk.com/method/audio.get?owner_id=28622822&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': [
                      {
                        'id': 111400889,
                        'owner_id': -28622822,
                        'artist': 'Дискотека Авария (www.primemusic.ru)',
                        'title': 'Недетское Время',
                        'duration': 238,
                        'url': 'http://cs5002.vkontakte.ru/u40615612/audio/9f34e8775a94.mp3'
                      },
                      {
                        'id': 111400883,
                        'owner_id': -28622822,
                        'artist': 'Дискотека Авария',
                        'title': 'Нано Техно (NEW 2011)',
                        'duration': 206,
                        'url': 'http://cs4676.vkontakte.ru/u45593256/audio/423512410072.mp3'
                      }
                    ]
                  }";

            var category = GetMockedAudioCategory(url, json);
            var audios = category.GetFromGroup(28622822);

            Assert.That(audios.Count, Is.EqualTo(2));
            Assert.That(audios[0].Id, Is.EqualTo(111400889));
            Assert.That(audios[0].OwnerId, Is.EqualTo(-28622822));
            Assert.That(audios[0].Artist, Is.EqualTo("Дискотека Авария (www.primemusic.ru)"));
            Assert.That(audios[0].Title, Is.EqualTo("Недетское Время"));
            Assert.That(audios[0].Duration, Is.EqualTo(238));
            Assert.That(audios[0].Url.OriginalString, Is.EqualTo("http://cs5002.vkontakte.ru/u40615612/audio/9f34e8775a94.mp3"));
            Assert.That(audios[1].Id, Is.EqualTo(111400883));
            Assert.That(audios[1].OwnerId, Is.EqualTo(-28622822));
            Assert.That(audios[1].Artist, Is.EqualTo("Дискотека Авария"));
            Assert.That(audios[1].Title, Is.EqualTo("Нано Техно (NEW 2011)"));
            Assert.That(audios[1].Duration, Is.EqualTo(206));
            Assert.That(audios[1].Url.OriginalString, Is.EqualTo("http://cs4676.vkontakte.ru/u45593256/audio/423512410072.mp3"));
        }

        [Test]
        public void Get_WithOutUserAndAllFields_ReturnListOfAudio()
        {
			const string url = "https://api.vk.com/method/audio.get?owner_id=4793858&need_user=1&offset=5&count=3&v=5.44&access_token=token";

			const string json =
                @"{
                    'response': [
                      {
                        'id': '4793858',
                        'photo_50': 'http://cs9215.userapi.com/u4793858/e_1b975695.jpg',
                        'name': 'Антон Жидков'
                      },
                      {
                        'id': 157633898,
                        'owner_id': 4793858,
                        'artist': 'Марш Люфтваффе(немецкая народная песня)',
                        'title': 'Was wollen wir trinken!',
                        'duration': 298,
                        'url': 'http://cs4696.vkontakte.ru/u78355164/audio/e9a8e73e283b.mp3',
                        'lyrics_id': '7257154'
                      },
                      {
                        'id': 157469004,
                        'owner_id': 4793858,
                        'artist': 'Титаник-гитара=)',
                        'title': 'титаник',
                        'duration': 227,
                        'url': 'http://cs4770.vkontakte.ru/u12282005/audio/946096f61144.mp3',
                        'lyrics_id': '5540676'
                      },
                      {
                        'id': 157187769,
                        'owner_id': 4793858,
                        'artist': 'И.В.Сталин',
                        'title': 'Речь И.В.Сталина 7 ноября 1941',
                        'duration': 185,
                        'url': 'http://cs1338.vkontakte.ru/u3201669/audio/7d67c7278b65.mp3'
                      }
                    ]
                  }";

            User user;
            var category = GetMockedAudioCategory(url, json);
            var audios = category.Get(4793858, out user, null, null, 3, 5);

			Assert.That(audios.Count, Is.EqualTo(3));

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(4793858));
            Assert.That(user.PhotoPreviews.Photo50, Is.EqualTo(new Uri("http://cs9215.userapi.com/u4793858/e_1b975695.jpg")));
            Assert.That(user.FirstName, Is.EqualTo("Антон"));
            Assert.That(user.LastName, Is.EqualTo("Жидков"));

            Assert.That(audios[0].Id, Is.EqualTo(157633898));
            Assert.That(audios[0].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[0].Artist, Is.EqualTo("Марш Люфтваффе(немецкая народная песня)"));
            Assert.That(audios[0].Title, Is.EqualTo("Was wollen wir trinken!"));
            Assert.That(audios[0].Duration, Is.EqualTo(298));
            Assert.That(audios[0].Url.OriginalString, Is.EqualTo("http://cs4696.vkontakte.ru/u78355164/audio/e9a8e73e283b.mp3"));
            Assert.That(audios[0].LyricsId, Is.EqualTo(7257154));
            Assert.That(audios[1].Id, Is.EqualTo(157469004));
            Assert.That(audios[1].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[1].Artist, Is.EqualTo("Титаник-гитара=)"));
            Assert.That(audios[1].Title, Is.EqualTo("титаник"));
            Assert.That(audios[1].Duration, Is.EqualTo(227));
            Assert.That(audios[1].Url.OriginalString, Is.EqualTo("http://cs4770.vkontakte.ru/u12282005/audio/946096f61144.mp3"));
            Assert.That(audios[1].LyricsId, Is.EqualTo(5540676));
            Assert.That(audios[2].Id, Is.EqualTo(157187769));
            Assert.That(audios[2].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[2].Artist, Is.EqualTo("И.В.Сталин"));
            Assert.That(audios[2].Title, Is.EqualTo("Речь И.В.Сталина 7 ноября 1941"));
            Assert.That(audios[2].Duration, Is.EqualTo(185));
            Assert.That(audios[2].Url.OriginalString, Is.EqualTo("http://cs1338.vkontakte.ru/u3201669/audio/7d67c7278b65.mp3"));
        }

        [Test]
        public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidExcpetion()
        {
            var audio = new AudioCategory(new VkApi());
            long totalCount;
            This.Action(() => audio.Search("Beatles", out totalCount)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Search_QueryEmptyOrNull_ThrowsArgumentException()
        {
            var audio = GetMockedAudioCategory("", "");
			long totalCount;
            This.Action(() => audio.Search("", out totalCount)).Throws<ArgumentException>();
        }

        [Test]
        public void Search_NotExistedQuery_EmptyList()
        {
			const string url = "https://api.vk.com/method/audio.search?q=ThisQueryDoesNotExistAtAll&count=0&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': [
                      0
                    ]
                  }";

            var audio = GetMockedAudioCategory(url, json);

			long totalCount;
            var auds = audio.Search("ThisQueryDoesNotExistAtAll", out totalCount);

            Assert.That(totalCount, Is.EqualTo(0));
            Assert.That(auds.Count, Is.EqualTo(0));
        }

        [Test]
        public void Search_NormalCaseAllFields_ListOfAudios()
        {
            const string url =
                "https://api.vk.com/method/audio.search?q=иуфедуы&auto_complete=1&sort=1&lyrics=1&count=3&offset=5&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': [
                      84673,
                      {
                        'id': 141104180,
                        'owner_id': 2289065,
                        'artist': '2560 The BEATLES (цикл передач на РАДИО СВОБОДА)',
                        'title': 'Джон, Пол, Ждордж, Ринго - работа для кино',
                        'duration': 3180,
                        'url': 'http://cs5045.vkontakte.ru/u17922696/audio/7af351f23650.mp3',
                        'lyrics_id': '23484916',
                        'album_id': '24110176'
                      },
                      {
                        'id': 141104155,
                        'owner_id': 2289065,
                        'artist': '2556 The BEATLES (цикл передач на РАДИО СВОБОДА)',
                        'title': 'БИТЛЗ. Песни, подаренные другим',
                        'duration': 3179,
                        'url': 'http://cs5045.vkontakte.ru/u17922696/audio/5f36b4e2c652.mp3',
                        'lyrics_id': '23484936',
                        'album_id': '24110176'
                      },
                      {
                        'id': 141104164,
                        'owner_id': 2289065,
                        'artist': '2558 The BEATLES (цикл передач на РАДИО СВОБОДА)',
                        'title': 'Музыка БИТЛЗ у других исполнителей',
                        'duration': 3179,
                        'url': 'http://cs5045.vkontakte.ru/u17922696/audio/6768fd4bfece.mp3',
                        'lyrics_id': '23484929',
                        'album_id': '24110176'
                      }
                    ]
                  }";

            var category = GetMockedAudioCategory(url, json);
			long totalCount;
            var auds = category.Search("иуфедуы", out totalCount, true, AudioSort.Duration, true, 3, 5);

            Assert.That(auds.Count, Is.EqualTo(3));
            Assert.That(totalCount, Is.EqualTo(84673));

            Assert.That(auds[2].Id, Is.EqualTo(141104164));
            Assert.That(auds[2].OwnerId, Is.EqualTo(2289065));
            Assert.That(auds[2].Artist, Is.EqualTo("2558 The BEATLES (цикл передач на РАДИО СВОБОДА)"));
            Assert.That(auds[2].Title, Is.EqualTo("Музыка БИТЛЗ у других исполнителей"));
            Assert.That(auds[2].Duration, Is.EqualTo(3179));
            Assert.That(auds[2].Url.OriginalString, Is.EqualTo("http://cs5045.vkontakte.ru/u17922696/audio/6768fd4bfece.mp3"));
            Assert.That(auds[2].LyricsId, Is.EqualTo(23484929));
            Assert.That(auds[2].AlbumId, Is.EqualTo(24110176));

            Assert.That(auds[1].Id, Is.EqualTo(141104155));
            Assert.That(auds[1].OwnerId, Is.EqualTo(2289065));
            Assert.That(auds[1].Artist, Is.EqualTo("2556 The BEATLES (цикл передач на РАДИО СВОБОДА)"));
            Assert.That(auds[1].Title, Is.EqualTo("БИТЛЗ. Песни, подаренные другим"));
            Assert.That(auds[1].Duration, Is.EqualTo(3179));
            Assert.That(auds[1].Url.OriginalString, Is.EqualTo("http://cs5045.vkontakte.ru/u17922696/audio/5f36b4e2c652.mp3"));
            Assert.That(auds[1].LyricsId, Is.EqualTo(23484936));
            Assert.That(auds[1].AlbumId, Is.EqualTo(24110176));

            Assert.That(auds[0].Id, Is.EqualTo(141104180));
            Assert.That(auds[0].OwnerId, Is.EqualTo(2289065));
            Assert.That(auds[0].Artist, Is.EqualTo("2560 The BEATLES (цикл передач на РАДИО СВОБОДА)"));
            Assert.That(auds[0].Title, Is.EqualTo("Джон, Пол, Ждордж, Ринго - работа для кино"));
            Assert.That(auds[0].Duration, Is.EqualTo(3180));
            Assert.That(auds[0].Url.OriginalString, Is.EqualTo("http://cs5045.vkontakte.ru/u17922696/audio/7af351f23650.mp3"));
            Assert.That(auds[0].LyricsId, Is.EqualTo(23484916));
            Assert.That(auds[0].AlbumId, Is.EqualTo(24110176));
        }

        [Test]
        public void Add_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.Add(0, 0, null, null)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Add_InvalidInputParam_ThrowsInvalidParameterException()
        {
			const string url = "https://api.vk.com/method/audio.add?audio_id=0&owner_id=0&v=5.44&access_token=token";
			const string json =
                @"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.add'
                        },
                        {
                          'key': 'aid',
                          'value': '0'
                        },
                        {
                          'key': 'oid',
                          'value': '0'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var category = GetMockedAudioCategory(url, json);
            This.Action(() => category.Add(0, 0)).Throws<InvalidParameterException>();
        }

        [Test]
        public void Add_AddToCuurentUser_AudioId()
        {
			const string url = "https://api.vk.com/method/audio.add?audio_id=141104180&owner_id=2289065&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': 159200195
                  }";

            var category = GetMockedAudioCategory(url, json);
            var id = category.Add(141104180, 2289065);
            Assert.That(id, Is.EqualTo(159200195));
        }

        [Test]
        public void Add_AddToGroup_AudioId()
        {
			const string url = "https://api.vk.com/method/audio.add?audio_id=141104180&owner_id=2289065&group_id=1158263&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': 160532304
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var id = cat.Add(141104180, 2289065, 1158263);
            Assert.That(id, Is.EqualTo(160532304));
        }

        [Test]
        public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.Delete(0, 0)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Delete_NoramCaseUser_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=159203048&oid=4793858&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var result = cat.Delete(159203048, 4793858);

			Assert.That(result, Is.True);
        }

        [Test]
        public void Delete_NoramCaseGroup_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=160532304&oid=-1158263&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var result = cat.Delete(160532304, -1158263);

			Assert.That(result, Is.True);
        }

        [Test]
        public void Delete_WrongInputParams_ThrowsInvalidParameterException()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=0&oid=0&v=5.44&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.delete'
                        },
                        {
                          'key': 'aid',
                          'value': '0'
                        },
                        {
                          'key': 'oid',
                          'value': '0'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);
            This.Action(() => cat.Delete(0, 0)).Throws<InvalidParameterException>();
        }

        [Test]
        public void Edit_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.Edit(0, 0, "", "", "", null, null)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Edit_ArtistParamIsNull_ThrowsArgumentNullException()
        {
            var cat = GetMockedAudioCategory("", "");
            This.Action(() => cat.Edit(0, 0, null, "", "", null, null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edit_TitleParamIsNull_ThrowsArgumentNullException()
        {
            var cat = GetMockedAudioCategory("", "");
            This.Action(() => cat.Edit(0, 0, "", null, "", null, null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edit_TextParamIsNull_ThrowsArgumentNullException()
        {
            var cat = GetMockedAudioCategory("", "");
            This.Action(() => cat.Edit(0, 0, "", "", null, null, null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void Edit_NoramCase_ReturnLyricsId()
        {
			const string url = "https://api.vk.com/method/audio.edit?owner_id=4793858&audio_id=159207130&artist=Test Artist&title=Test Title&text=Test Text&genre_id=1&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': 26350163
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var id = cat.Edit(159207130, 4793858, "Test Artist", "Test Title", "Test Text", null, AudioGenre.Rock);

            Assert.That(id, Is.EqualTo(26350163));
        }

        [Test]
        public void Edit_WrongInputParams_ThrowsInvalidParameterException()
        {
			const string url = "https://api.vk.com/method/audio.edit?owner_id=0&audio_id=0&artist=Test Artist&title=Test Title&text=Test Text&genre_id=18&v=5.44&access_token=token";
			const string json =
                @"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.edit'
                        },
                        {
                          'key': 'aid',
                          'value': '0'
                        },
                        {
                          'key': 'oid',
                          'value': '0'
                        },
                        {
                          'key': 'artist',
                          'value': 'Test Artist'
                        },
                        {
                          'key': 'title',
                          'value': 'Test Title'
                        },
                        {
                          'key': 'text',
                          'value': 'Test Text'
                        },
                        {
                          'key': 'no_search',
                          'value': '0'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);

            This.Action(() => cat.Edit(0, 0, "Test Artist", "Test Title", "Test Text", false, AudioGenre.Other)).Throws<InvalidParameterException>();
        }

        [Test]
        public void Restore_InvalidAccessToken_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            This.Action(() => audio.Restore(0, 0)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Restore_InvalidInputParams_ThrowsInvalidParameterException()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=0&oid=0&v=5.44&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.restore'
                        },
                        {
                          'key': 'aid',
                          'value': '0'
                        },
                        {
                          'key': 'oid',
                          'value': '0'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);
            This.Action(() => cat.Restore(0, 0)).Throws<InvalidParameterException>();
        }

        [Test]
        public void Restore_NoramCase_ReturnAudioObject()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=159209928&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': {
                      'id': 159209928,
                      'owner_id': 4793858,
                      'artist': '2560 The BEATLES (цикл передач на РАДИО СВОБОДА)',
                      'title': 'Джон, Пол, Ждордж, Ринго - работа для кино',
                      'duration': 3180,
                      'url': 'http://cs5045.vkontakte.ru/u17922696/audio/4529541451fe.mp3',
                      'lyrics_id': '23484916'
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var audio = cat.Restore(159209928);

			Assert.That(audio.Id, Is.EqualTo(159209928));
            Assert.That(audio.OwnerId, Is.EqualTo(4793858));
            Assert.That(audio.Artist, Is.EqualTo("2560 The BEATLES (цикл передач на РАДИО СВОБОДА)"));
            Assert.That(audio.Title, Is.EqualTo("Джон, Пол, Ждордж, Ринго - работа для кино"));
            Assert.That(audio.Duration, Is.EqualTo(3180));
            Assert.That(audio.Url.OriginalString, Is.EqualTo("http://cs5045.vkontakte.ru/u17922696/audio/4529541451fe.mp3"));
            Assert.That(audio.LyricsId, Is.EqualTo(23484916));

        }

        [Test]
        public void Restore_AudioNotDeletedYet_Throw()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=159210112&v=5.44&access_token=token";
            const string json =
                @"{
                    'error': {
                      'error_code': 202,
                      'error_msg': 'Cache expired',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.restore'
                        },
                        {
                          'key': 'aid',
                          'value': '159210112'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var ex = This.Action(() => cat.Restore(159210112)).Throws<VkApiException>();
            ex.Message.ShouldEqual("Cache expired");
        }

        [Test]
        public void Reorder_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new AudioCategory(new VkApi());
            This.Action(() => cat.Reorder(0, 0, 0, 0)).Throws<AccessTokenInvalidException>();
        }

        [Test]
        public void Reorder_InvalidInputParams_ThrowsInvalidParameterException()
        {
			const string url = "https://api.vk.com/method/audio.reorder?audio_id=0&owner_id=0&before=159104443&after=158945986&v=5.44&access_token=token";

			const string json =
                @"{
                    'error': {
                      'error_code': 100,
                      'error_msg': 'One of the parameters specified was missing or invalid',
                      'request_params': [
                        {
                          'key': 'oauth',
                          'value': '1'
                        },
                        {
                          'key': 'method',
                          'value': 'audio.reorder'
                        },
                        {
                          'key': 'aid',
                          'value': '0'
                        },
                        {
                          'key': 'oid',
                          'value': '0'
                        },
                        {
                          'key': 'after',
                          'value': '159104443'
                        },
                        {
                          'key': 'before',
                          'value': '158945986'
                        },
                        {
                          'key': 'access_token',
                          'value': 'token'
                        }
                      ]
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);
            This.Action(() => cat.Reorder(0, 0, 159104443, 158945986)).Throws<InvalidParameterException>();
        }

        [Test]
        public void Reorder_NormalCase_ReturnTrue()
        {
			const string url = "https://api.vk.com/method/audio.reorder?audio_id=159210112&owner_id=4793858&before=159104443&after=158945986&v=5.44&access_token=token";
			const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);
            var result = cat.Reorder(159210112, 4793858, 159104443, 158945986);
			Assert.That(result, Is.True);
        }

        [Test]
        public void AddAlbum_ToUser_NormalCase()
        {
//            const string url = "https://api.vk.com/method/audio.addAlbum?title=тестовый альбом&v=5.44&access_token=token";
//            const string json =
//                @"{
//                    'album_id': 45282793
//                  }";

            const string url = "https://api.vk.com/method/audio.addAlbum?title=тестовый альбом&v=5.44&access_token=token";
            const string json =
                  @"{
                    'response': {
                      'album_id': 45284861
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var albumId = cat.AddAlbum("тестовый альбом");

            Assert.That(albumId, Is.EqualTo(45284861));
        }

        [Test]
        public void AddAlbum_ToGroup_NormalCase()
        {
			const string url = "https://api.vk.com/method/audio.addAlbum?group_id=65968887&title=Test audio category&v=5.44&access_token=token";
			const string json =
            @"{
                    'response': {
                      'album_id': 45302272
                    }
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var albumId = cat.AddAlbum("Test audio category", 65968887);

            Assert.That(albumId, Is.EqualTo(45302272));
        }

        [Test]
        public void AddAlbum_TitleIsEmpty_ThrowException()
        {
            var cat = GetMockedAudioCategory("", "");
			This.Action(() => cat.AddAlbum("")).Throws<ArgumentNullException>();
        }

        [Test]
        public void AddAlbum_GroupIdIsNegative_ThrowException()
        {
            var cat = GetMockedAudioCategory("", "");
			This.Action(() => cat.AddAlbum("test title", 0)).Throws<ArgumentException>();
        }

        [Test]
        public void EditAlbum_EditUserAlbum_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.editAlbum?title=еще один альбом&album_id=45284866&v=5.44&access_token=token";
            const string json =
            @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var result = cat.EditAlbum("еще один альбом", 45284866);

            Assert.That(result, Is.True);
        }

        [Test]
        public void EditAlbum_EditGroupAlbum_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.editAlbum?title=audio category 222&group_id=65968885&album_id=45302272&v=5.44&access_token=token";
            const string json =
            @"{
                    'response': 1
                  }";
            var cat = GetMockedAudioCategory(url, json);

			var result = cat.EditAlbum("audio category 222", albumId: 45302272, groupId: 65968885);

            Assert.That(result, Is.True);
        }

        [Test]
        public void EditAlbum_TitleIsEmpty_ThrowException()
        {
            var cat = GetMockedAudioCategory("", "");
			This.Action(() => cat.EditAlbum("", 1234567)).Throws<ArgumentNullException>();
        }

        [Test]
        public void EditAlbum_GroupIdIsNegative_ThrowException()
        {
            var cat = GetMockedAudioCategory("", "");
			This.Action(() => cat.EditAlbum("title", 1234567, 0)).Throws<ArgumentException>();
        }

        [Test]
        public void DeleteAlbum_FromUser_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.deleteAlbum?album_id=45282792&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var result = cat.DeleteAlbum(45282792);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteAlbum_FromGroup_NormalCase()
        {
			const string url = "https://api.vk.com/method/audio.deleteAlbum?group_id=65968885&album_id=45302272&v=5.44&access_token=token";
			const string json =
            @"{
                    'response': 1
                  }";

            var cat = GetMockedAudioCategory(url, json);

            var result = cat.DeleteAlbum(45302272, 65968885);

			Assert.That(result, Is.True);
        }

        [Test]
        public void GetPopular_GetOnly3RapRecords()
        {
            const string url = "https://api.vk.com/method/audio.getPopular?only_eng=0&genre_id=3&offset=2&count=3&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': [
                      {
                        'aid': 253824296,
                        'owner_id': 81739784,
                        'artist': 'ЯрмаК feat. Лев, Фир, Тоф ',
                        'title': 'Улетай (2014)',
                        'duration': 252,
                        'url': 'http://cs9-11v4.vk.me/p21/ab488503b6d761.mp3',
                        'genre': 3
                      },
                      {
                        'aid': 104973590,
                        'owner_id': 57524028,
                        'artist': 'Die Antwoord',
                        'title': 'Rich Bitch',
                        'duration': 212,
                        'url': 'http://cs9-6v4.vk.me/p24/4f070b4cbc0648.mp3',
                        'lyrics_id': '10501388',
                        'genre': 3
                      },
                      {
                        'aid': 239379431,
                        'owner_id': 4172099,
                        'artist': 'Тимати (feat. LOne и Сергей Мазаев)',
                        'title': 'GQ',
                        'duration': 209,
                        'url': 'http://cs9-12v4.vk.me/p16/11fc1ad07ef625.mp3',
                        'lyrics_id': '126521441',
                        'genre': 3
                      }
                    ]
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var result = cat.GetPopular(genre: AudioGenre.RapAndHipHop, count: 3, offset: 2);

            Assert.That(result.Count, Is.EqualTo(3));

            Assert.That(result[0].Id, Is.EqualTo(253824296));
            Assert.That(result[0].OwnerId, Is.EqualTo(81739784));
            Assert.That(result[0].Artist, Is.EqualTo("ЯрмаК feat. Лев, Фир, Тоф "));
            Assert.That(result[0].Title, Is.EqualTo("Улетай (2014)"));
            Assert.That(result[0].Duration, Is.EqualTo(252));
            Assert.That(result[0].Url, Is.EqualTo(new Uri("http://cs9-11v4.vk.me/p21/ab488503b6d761.mp3")));
            Assert.That(result[0].Genre, Is.EqualTo(AudioGenre.RapAndHipHop));

            Assert.That(result[1].Id, Is.EqualTo(104973590));
            Assert.That(result[1].OwnerId, Is.EqualTo(57524028));
            Assert.That(result[1].Artist, Is.EqualTo("Die Antwoord"));
            Assert.That(result[1].Title, Is.EqualTo("Rich Bitch"));
            Assert.That(result[1].Duration, Is.EqualTo(212));
            Assert.That(result[1].Url, Is.EqualTo(new Uri("http://cs9-6v4.vk.me/p24/4f070b4cbc0648.mp3")));
            Assert.That(result[1].LyricsId, Is.EqualTo(10501388));
            Assert.That(result[1].Genre, Is.EqualTo(AudioGenre.RapAndHipHop));

            Assert.That(result[2].Id, Is.EqualTo(239379431));
            Assert.That(result[2].OwnerId, Is.EqualTo(4172099));
            Assert.That(result[2].Artist, Is.EqualTo("Тимати (feat. LOne и Сергей Мазаев)"));
            Assert.That(result[2].Title, Is.EqualTo("GQ"));
            Assert.That(result[2].Duration, Is.EqualTo(209));
            Assert.That(result[2].Url, Is.EqualTo(new Uri("http://cs9-12v4.vk.me/p16/11fc1ad07ef625.mp3")));
            Assert.That(result[2].LyricsId, Is.EqualTo(126521441));
            Assert.That(result[2].Genre, Is.EqualTo(AudioGenre.RapAndHipHop));
        }

        [Test]
        public void GetAlbums_FromUser_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.getAlbums?owner_id=23465118&v=5.44&access_token=token";
            const string json =
                @"{
                    'response': [
                      2,
                      {
                        'owner_id': 23465118,
                        'album_id': 45303161,
                        'title': 'первый альбом'
                      },
                      {
                        'owner_id': 23465118,
                        'album_id': 45284861,
                        'title': 'еще один альбом'
                      }
                    ]
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var result = cat.GetAlbums(23465118);

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].OwnerId, Is.EqualTo(23465118));
            Assert.That(result[0].AlbumId, Is.EqualTo(45303161));
            Assert.That(result[0].Title, Is.EqualTo("первый альбом"));

            Assert.That(result[1].OwnerId, Is.EqualTo(23465118));
            Assert.That(result[1].AlbumId, Is.EqualTo(45284861));
            Assert.That(result[1].Title, Is.EqualTo("еще один альбом"));
        }

        [Test]
        public void MoveToAlbum_ToUserAlbum()
        {
            const string url = "https://api.vk.com/method/audio.moveToAlbum?album_id=45303161&audio_ids=258542771,258542571&v=5.44&access_token=token";
             const string json =
                @"{
                    'response': 1
                  }";


            var cat = GetMockedAudioCategory(url, json);

			var result = cat.MoveToAlbum(45303161, new ulong[] {258542771, 258542571});

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetRecommendations_TargetAudio_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.getRecommendations?target_audio=2314852_190922480&count=2&shuffle=1&v=5.44&access_token=token";
            const string json =
            @"{
                    'response': [
                      {
                        'aid': 66529476,
                        'owner_id': 210002,
                        'artist': 'Helloween',
                        'title': 'If I Could Fly',
                        'duration': 249,
                        'url': 'http://cs4528.vk.me/u36851245/audios/1243be024abd.mp3',
                        'genre': 18
                      },
                      {
                        'aid': 151029625,
                        'owner_id': 34446002,
                        'artist': 'Helloween',
                        'title': 'In The Middle Of A Heartbeat',
                        'duration': 270,
                        'url': 'http://cs4431.vk.me/u1988945/audios/7f2657a01cbe.mp3?extra=cCSpaW9F1X5StA3UYs2Tpw_hyjRQAAL0r9LfAzcQjcV6orUA1FFHej4llC_hk0Tqfp9DQrYYw9IZXddhcCEGm_AmZVsQAxov',
                        'genre': 18
                      }
                    ]
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var result = cat.GetRecommendations(targetAudio: "2314852_190922480", count: 2);

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].Id, Is.EqualTo(66529476));
            Assert.That(result[0].OwnerId, Is.EqualTo(210002));
            Assert.That(result[0].Artist, Is.EqualTo("Helloween"));
            Assert.That(result[0].Title, Is.EqualTo("If I Could Fly"));
            Assert.That(result[0].Duration, Is.EqualTo(249));
            Assert.That(result[0].Url, Is.EqualTo(new Uri("http://cs4528.vk.me/u36851245/audios/1243be024abd.mp3")));
            Assert.That(result[0].Genre, Is.EqualTo(AudioGenre.Other));

            Assert.That(result[1].Id, Is.EqualTo(151029625));
            Assert.That(result[1].OwnerId, Is.EqualTo(34446002));
            Assert.That(result[1].Artist, Is.EqualTo("Helloween"));
            Assert.That(result[1].Title, Is.EqualTo("In The Middle Of A Heartbeat"));
            Assert.That(result[1].Duration, Is.EqualTo(270));
            Assert.That(result[1].Url, Is.EqualTo(new Uri("http://cs4431.vk.me/u1988945/audios/7f2657a01cbe.mp3?extra=cCSpaW9F1X5StA3UYs2Tpw_hyjRQAAL0r9LfAzcQjcV6orUA1FFHej4llC_hk0Tqfp9DQrYYw9IZXddhcCEGm_AmZVsQAxov")));
            Assert.That(result[1].Genre, Is.EqualTo(AudioGenre.Other));
        }

        [Test]
        public void SetBroadcast_NormalCase()
        {
            const string url = "https://api.vk.com/method/audio.setBroadcast?audio=210002_66529476&target_ids=234695118,-65968880&v=5.44&access_token=token";
            const string json =
            @"{
                    'response': [
                      234695118,
                      -65968880
                    ]
                  }";

            var cat = GetMockedAudioCategory(url, json);

			var ids = cat.SetBroadcast("210002_66529476", new long[] {234695118, -65968880});

            Assert.That(ids.Count, Is.EqualTo(2));
            Assert.That(ids[0], Is.EqualTo(234695118));
            Assert.That(ids[1], Is.EqualTo(-65968880));
        }
    }
}