namespace VkNet.Tests.Categories
{
	using System;
	using NUnit.Framework;
	using VkNet.Categories;
	using Enums;
	using Exception;
	using Model;
	using System.Diagnostics.CodeAnalysis;

	[TestFixture]
	[SuppressMessage("ReSharper", "PublicMembersMustHaveComments")]
	public class AudioCategoryTest : BaseTest
	{

		#region GetCount

		[Test]
		public void GetCount_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.GetCount(1));
		}

		[Test]
		public void GetCount_UserHasNoAudio_ReturnsZero()
		{
			Url = "https://api.vk.com/method/audio.getCount?owner_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: 0
                  }";

			var count = Api.Audio.GetCount(1);

			Assert.That(count, Is.EqualTo(0));
		}

		[Test]
		public void GetCount_UserHasAudio_ReturnsCountOfRecords()
		{
			Url = "https://api.vk.com/method/audio.getCount?owner_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: 158
                  }";

			var count = Api.Audio.GetCount(1);

			Assert.That(count, Is.EqualTo(158));
		}

		[Test]
		public void GetCount_GroupHasAudio_ReturnsCountOfRecords()
		{
			Url = "https://api.vk.com/method/audio.getCount?owner_id=-1158263&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: 4
                  }";

			var count = Api.Audio.GetCount(-1158263);

			Assert.That(count, Is.EqualTo(4));
		}

		#endregion

		#region GetLyrics

		[Test]
		public void GetLyrics_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.GetLyrics(222));
		}

		[Test]
		public void GetLyrics_2662381_ReturnsLyrics()
		{
			Url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=2662381&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: {
                      lyrics_id: 2662381,
                      text: 'Seht ihr mich?\nVersteht ihr mich?\nF&#252;hlt ihr mich?\nH&#246;rt ihr mich?'
                    }
                  }";

			var lyrics = Api.Audio.GetLyrics(2662381);

			Assert.That(lyrics.Id, Is.EqualTo(2662381));
			Assert.That(lyrics.Text, Is.EqualTo("Seht ihr mich?\nVersteht ihr mich?\nFühlt ihr mich?\nHört ihr mich?"));
		}

		[Test]
		public void GetLyrics_WrongLyricsId_ReturnsEmptyLyrics()
		{
			Url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=-1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: {
                      lyrics_id: -1,
                      text: ''
                    }
                  }";

			var lyrics = Api.Audio.GetLyrics(-1);

			Assert.That(lyrics.Id, Is.EqualTo(-1));
			Assert.That(lyrics.Text, Is.Null.Or.Empty);
		}

		#endregion

		#region GetById

		[Test]
		public void GetById_AccessTokenInvalid_ThrowsAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.GetById("1_1"));
		}

		[Test]
		public void GetById_AudiosParamIsNull_ThrowsArgumentNullException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.GetById(null), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void GetById_WrongId_ReturnsEmptyList()
		{
			Url = "https://api.vk.com/method/audio.getById?audios=2e4w_67859ds194&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: []
                  }";

			var audios = Api.Audio.GetById("2e4w_67859ds194");
			Assert.That(audios.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetById_NormalCase_ListOfAudioObjects()
		{
			Url = "https://api.vk.com/method/audio.getById?audios=4793858_158073513,2_63937759&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var audios = Api.Audio.GetById("4793858_158073513", "2_63937759");

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
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.GetUploadServer());
		}

		[Test]
		public void GetUploadServer_NormalCase_ReturnUploadUrl()
		{
			Url = "https://api.vk.com/method/audio.getUploadServer?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': {
                      'upload_url': 'http://cs6173.vk.com/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1'
                    }
                  }";

			var uploadUrl = Api.Audio.GetUploadServer();

			Assert.That(uploadUrl, Is.EqualTo(new Uri("http://cs6173.vk.com/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1")));
		}

        [Test]
        public void uriConvertJsonResponseTrue()
        {
            Url = "https://api.vk.com/method/audio.getUploadServer?v=" + VkApi.VkApiVersion + "&access_token=token";
            Json = @"{
                    'response': {
                      'upload_url': 'false'
                    }
                  }";

            var uploadUrl = Api.Audio.GetUploadServer();

            Assert.IsNull(uploadUrl);
        }

        [Test]
		public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Get(1));
		}

		[Test]
		public void Get_NormalCaseDefaultValues_ListOfAudioObjects()
		{
			Url = "https://api.vk.com/method/audio.get?owner_id=4793858&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var audios = Api.Audio.Get(4793858);

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
			Url = "https://api.vk.com/method/audio.get?owner_id=28622822&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var audios = Api.Audio.GetFromGroup(28622822);

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
			Url = "https://api.vk.com/method/audio.get?owner_id=4793858&need_user=1&offset=5&count=3&v=" + VkApi.VkApiVersion + "&access_token=token";

			Json =
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

			var audios = Api.Audio.Get(4793858, out user, null, null, 3, 5);

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
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			long totalCount;
			Assert.Throws<AccessTokenInvalidException>(() => audio.Search("Beatles", out totalCount));
		}

		[Test]
		public void Search_QueryEmptyOrNull_ThrowsArgumentException()
		{
			long totalCount;
			Url = "";
			Json = "";
			Assert.That(() => Api.Audio.Search("", out totalCount), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void Search_NotExistedQuery_EmptyList()
		{
			Url = "https://api.vk.com/method/audio.search?q=ThisQueryDoesNotExistAtAll&count=0&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    response: {
						count: 0,
						items: []
					}
                  }";

			long totalCount;
			var auds = Api.Audio.Search("ThisQueryDoesNotExistAtAll", out totalCount);

			Assert.That(totalCount, Is.EqualTo(0));
			Assert.That(auds.Count, Is.EqualTo(0));
		}

		[Test]
		public void Search_NormalCaseAllFields_ListOfAudios()
		{
			Url =
				"https://api.vk.com/method/audio.search?q=иуфедуы&auto_complete=1&sort=1&lyrics=1&count=3&offset=5&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': {
                      count:84673,
                      items: [{
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
                      }]
					}
                  }";

			long totalCount;
			var auds = Api.Audio.Search("иуфедуы", out totalCount, true, AudioSort.Duration, true, 3, 5);

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
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Add(0, 0, null, null));
		}

		[Test]
		public void Add_InvalidInputParam_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/audio.add?audio_id=0&owner_id=0&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			Assert.Throws<InvalidParameterException>(() => Api.Audio.Add(0, 0));
		}

		[Test]
		public void Add_AddToCuurentUser_AudioId()
		{
			Url = "https://api.vk.com/method/audio.add?audio_id=141104180&owner_id=2289065&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 159200195
                  }";

			var id = Api.Audio.Add(141104180, 2289065);
			Assert.That(id, Is.EqualTo(159200195));
		}

		[Test]
		public void Add_AddToGroup_AudioId()
		{
			Url = "https://api.vk.com/method/audio.add?audio_id=141104180&owner_id=2289065&group_id=1158263&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 160532304
                  }";

			var id = Api.Audio.Add(141104180, 2289065, 1158263);
			Assert.That(id, Is.EqualTo(160532304));
		}

		[Test]
		public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Delete(0, 0));
		}

		[Test]
		public void Delete_NoramCaseUser_ReturnTrue()
		{
			Url = "https://api.vk.com/method/audio.delete?audio_id=159203048&owner_id=4793858&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 1
                  }";

			var result = Api.Audio.Delete(159203048, 4793858);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Delete_NoramCaseGroup_ReturnTrue()
		{
			Url = "https://api.vk.com/method/audio.delete?audio_id=160532304&owner_id=-1158263&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 1
                  }";

			var result = Api.Audio.Delete(160532304, -1158263);

			Assert.That(result, Is.True);
		}

		[Test]
		public void Delete_WrongInputParams_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/audio.delete?audio_id=0&owner_id=0&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			Assert.Throws<InvalidParameterException>(() => Api.Audio.Delete(0, 0));
		}

		[Test]
		public void Edit_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Edit(0, 0, "", "", "", null, null));
		}

		[Test]
		public void Edit_ArtistParamIsNull_ThrowsArgumentNullException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.Edit(0, 0, null, "", "", null, null), Throws.InstanceOf<ArgumentNullException>().And.Property("ParamName").EqualTo("artist"));
		}

		[Test]
		public void Edit_TitleParamIsNull_ThrowsArgumentNullException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.Edit(0, 0, "", null, "", null, null), Throws.InstanceOf<ArgumentNullException>().And.Property("ParamName").EqualTo("title"));
		}

		[Test]
		public void Edit_TextParamIsNull_ThrowsArgumentNullException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.Edit(0, 0, "", "", null, null, null), Throws.InstanceOf<ArgumentNullException>().And.Property("ParamName").EqualTo("text"));
		}

		[Test]
		public void Edit_NoramCase_ReturnLyricsId()
		{
			Url = "https://api.vk.com/method/audio.edit?owner_id=4793858&audio_id=159207130&artist=Test Artist&title=Test Title&text=Test Text&genre_id=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 26350163
                  }";

			var id = Api.Audio.Edit(159207130, 4793858, "Test Artist", "Test Title", "Test Text", null, AudioGenre.Rock);

			Assert.That(id, Is.EqualTo(26350163));
		}

		[Test]
		public void Edit_WrongInputParams_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/audio.edit?owner_id=0&audio_id=0&artist=Test Artist&title=Test Title&text=Test Text&genre_id=18&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			Assert.Throws<InvalidParameterException>(() => Api.Audio.Edit(0, 0, "Test Artist", "Test Title", "Test Text", false, AudioGenre.Other));
		}

		[Test]
		public void Restore_InvalidAccessToken_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Restore(0, 0));
		}

		[Test]
		public void Restore_InvalidInputParams_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/audio.restore?audio_id=0&owner_id=0&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			Assert.Throws<InvalidParameterException>(() => Api.Audio.Restore(0, 0));
		}

		[Test]
		public void Restore_NoramCase_ReturnAudioObject()
		{
			Url = "https://api.vk.com/method/audio.restore?audio_id=159209928&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var audio = Api.Audio.Restore(159209928);

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
			Url = "https://api.vk.com/method/audio.restore?audio_id=159210112&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var ex = Assert.Throws<VkApiException>(() => Api.Audio.Restore(159210112));
			Assert.That(ex.Message, Is.EqualTo("Cache expired"));
		}

		[Test]
		public void Reorder_AccessTokenInvalid_ThrowAccessTokenInvalidException()
		{
			// TODO как то я сомневаюсь в необходимости таких проверок, нужно закрыть инициализацию объектов только внутри библиотеки
			var audio = new AudioCategory(new VkApi());
			Assert.Throws<AccessTokenInvalidException>(() => audio.Reorder(0, 0, 0, 0));
		}

		[Test]
		public void Reorder_InvalidInputParams_ThrowsInvalidParameterException()
		{
			Url = "https://api.vk.com/method/audio.reorder?audio_id=0&owner_id=0&before=159104443&after=158945986&v=" + VkApi.VkApiVersion + "&access_token=token";

			Json =
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

			Assert.Throws<InvalidParameterException>(() => Api.Audio.Reorder(0, 0, 159104443, 158945986));
		}

		[Test]
		public void Reorder_NormalCase_ReturnTrue()
		{
			Url = "https://api.vk.com/method/audio.reorder?audio_id=159210112&owner_id=4793858&before=159104443&after=158945986&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 1
                  }";

			var result = Api.Audio.Reorder(159210112, 4793858, 159104443, 158945986);
			Assert.That(result, Is.True);
		}

		[Test]
		public void AddAlbum_ToUser_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.addAlbum?title=тестовый альбом&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				  @"{
                    'response': {
                      'album_id': 45284861
                    }
                  }";

			var albumId = Api.Audio.AddAlbum("тестовый альбом");

			Assert.That(albumId, Is.EqualTo(45284861));
		}

		[Test]
		public void AddAlbum_ToGroup_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.addAlbum?group_id=65968887&title=Test audio category&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			@"{
                    'response': {
                      'album_id': 45302272
                    }
                  }";

			var albumId = Api.Audio.AddAlbum("Test audio category", 65968887);

			Assert.That(albumId, Is.EqualTo(45302272));
		}

		[Test]
		public void AddAlbum_TitleIsEmpty_ThrowException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.AddAlbum(""), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void AddAlbum_GroupIdIsNegative_ThrowException()
		{
			Url = "";
			Json = @"";
			Assert.That(() => Api.Audio.AddAlbum("test title", -1), Throws.InstanceOf<ArgumentException>().And.Property("ParamName").EqualTo("groupId"));
		}

		[Test]
		public void EditAlbum_EditUserAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.editAlbum?title=еще один альбом&album_id=45284866&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			@"{
                    'response': 1
                  }";

			var result = Api.Audio.EditAlbum("еще один альбом", 45284866);

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditAlbum_EditGroupAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.editAlbum?title=audio category 222&group_id=65968885&album_id=45302272&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			@"{
                    'response': 1
                  }";

			var result = Api.Audio.EditAlbum("audio category 222", albumId: 45302272, groupId: 65968885);

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditAlbum_TitleIsEmpty_ThrowException()
		{
			Url = "";
			Json = "";

			Assert.That(() => Api.Audio.EditAlbum("", 1234567), Throws.InstanceOf<ArgumentNullException>().And.Property("ParamName").EqualTo("title"));
		}

		[Test]
		public void EditAlbum_GroupIdIsNegative_ThrowException()
		{
			Url = "";
			Json = @"";

			Assert.That(() => Api.Audio.EditAlbum("title", 1234567, -1), Throws.InstanceOf<ArgumentNullException>());
		}

		[Test]
		public void DeleteAlbum_FromUser_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.deleteAlbum?album_id=45282792&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': 1
                  }";

			var result = Api.Audio.DeleteAlbum(45282792);

			Assert.That(result, Is.True);
		}

		[Test]
		public void DeleteAlbum_FromGroup_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.deleteAlbum?group_id=65968885&album_id=45302272&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			@"{
                    'response': 1
                  }";

			var result = Api.Audio.DeleteAlbum(45302272, 65968885);

			Assert.That(result, Is.True);
		}

		[Test]
		public void GetPopular_GetOnly3RapRecords()
		{
			Url = "https://api.vk.com/method/audio.getPopular?only_eng=0&genre_id=3&offset=2&count=3&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var result = Api.Audio.GetPopular(genre: AudioGenre.RapAndHipHop, count: 3, offset: 2);

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
			Url = "https://api.vk.com/method/audio.getAlbums?owner_id=23465118&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
				@"{
                    'response': {
                      count: 2,
                      items : [{
                        'owner_id': 23465118,
                        'album_id': 45303161,
                        'title': 'первый альбом'
                      },
                      {
                        'owner_id': 23465118,
                        'album_id': 45284861,
                        'title': 'еще один альбом'
                      }]
					}
                  }";

			var result = Api.Audio.GetAlbums(23465118);

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
			Url = "https://api.vk.com/method/audio.moveToAlbum?album_id=45303161&audio_ids=258542771,258542571&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			   @"{
                    'response': 1
                  }";

			var result = Api.Audio.MoveToAlbum(45303161, new long[] { 258542771, 258542571 });

			Assert.That(result, Is.True);
		}

		[Test]
		public void GetRecommendations_TargetAudio_NormalCase()
		{
			Url = "https://api.vk.com/method/audio.getRecommendations?target_audio=2314852_190922480&count=2&shuffle=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
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

			var result = Api.Audio.GetRecommendations(targetAudio: "2314852_190922480", count: 2);

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
			Url = "https://api.vk.com/method/audio.setBroadcast?audio=210002_66529476&target_ids=234695118,-65968880&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json =
			@"{
                    'response': [
                      234695118,
                      -65968880
                    ]
                  }";

			var ids = Api.Audio.SetBroadcast("210002_66529476", new long[] { 234695118, -65968880 });

			Assert.That(ids.Count, Is.EqualTo(2));
			Assert.That(ids[0], Is.EqualTo(234695118));
			Assert.That(ids[1], Is.EqualTo(-65968880));
		}

		#region GetBroadcastList

		[Test]
		public void GetBroadcastList()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: [{
					type: 'profile',
					id: 221634238,
					first_name: 'Александр',
					last_name: 'Инютин'
				},
				{
					id: 103292418,
					name: 'Work',
					screen_name: 'club103292418',
					is_closed: 0,
					type: 'group',
					is_admin: 1,
					admin_level: 3,
					is_member: 1,
					photo_50: 'https://vk.com/images/community_50.png',
					photo_100: 'https://vk.com/images/community_100.png',
					photo_200: 'https://vk.com/images/community_200.png',
					status_audio: {
						id: 456239026,
						owner_id: 32190123,
						artist: 'Sabaton',
						title: 'TheFinalSolution',
						duration: 296,
						date: 1458726613,
						url: 'https://cs1-19v4.vk-cdn.net/p34/d091232184d4e8.mp3?extra=pCRnYEhg5iNEEXxx4CnhWTLczsj3CqOcLLGbZ8gP2ec43A34V5Yhgt88CvnpJOvq_KZZejwMNc7dT-2u05uCNTRcZqNf67skerA44ZDWLx_3VZQ7dn4GBIA2UqskfNq8_TDqdLw-E1mP',
						lyrics_id: 8771021,
						genre_id: 18
					}
				}]
			}";

			var broadcastList = Api.Audio.GetBroadcastList();
			Assert.NotNull(broadcastList);
			CollectionAssert.IsNotEmpty(broadcastList.Groups);
			CollectionAssert.IsNotEmpty(broadcastList.Users);
		}

		[Test]
		public void GetBroadcastList_FilterGroups()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?filter=groups&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: [{
					id: 103292418,
					name: 'Work',
					screen_name: 'club103292418',
					is_closed: 0,
					type: 'group',
					is_admin: 1,
					admin_level: 3,
					is_member: 1,
					photo_50: 'https://vk.com/images/community_50.png',
					photo_100: 'https://vk.com/images/community_100.png',
					photo_200: 'https://vk.com/images/community_200.png',
					status_audio: {
						id: 456239025,
						owner_id: 32190123,
						artist: 'ЛюбителиТишины',
						title: 'Замокпламеникостров',
						duration: 208,
						date: 1458661957,
						url: 'https://psv4.vk.me/c613221/u131374929/audios/cbf90bdb4a97.mp3?extra=vQ54NRALdBHNochOTjYPGkx4UrHmS5yEtqe8-ohU5lNKOndzfUO6VaDaU_mX9p3aaEwHcWiND6WPsMnmGsOG11CH_ss4bAeShUIvg96a-A5tJjDorKTpsUhqpgGd6UEpOmSAWXDJOYEy',
						genre_id: 18
					}
				}]
			}";

			var broadcastList = Api.Audio.GetBroadcastList("groups");
			Assert.NotNull(broadcastList);
			CollectionAssert.IsNotEmpty(broadcastList.Groups);
			CollectionAssert.IsEmpty(broadcastList.Users);
		}

		[Test]
		public void GetBroadcastList_FilterFriends()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?filter=friends&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: [{
					type: 'profile',
					id: 178383030,
					first_name: 'Дмитрий',
					last_name: 'Иванов',
					status_audio: {
						id: 456239176,
						owner_id: 281149252,
						artist: 'GatoBeatZ Prod',
						title: 'Рома Минус',
						duration: 250,
						date: 1458739117,
						url: 'https://psv4.vk.m...rZ0nYs4fhbLEwHSf60A',
						genre_id: 18
					}
				}]
			}";

			var broadcastList = Api.Audio.GetBroadcastList("friends");
			Assert.NotNull(broadcastList);
			CollectionAssert.IsEmpty(broadcastList.Groups);
			CollectionAssert.IsNotEmpty(broadcastList.Users);
		}

		[Test]
		public void GetBroadcastList_FilterFriends_AllParams()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?filter=friends&active=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: [{
					type: 'profile',
					id: 178383030,
					first_name: 'Дмитрий',
					last_name: 'Иванов',
					status_audio: {
						id: 456239176,
						owner_id: 281149252,
						artist: 'GatoBeatZ Prod',
						title: 'Рома Минус',
						duration: 250,
						date: 1458739117,
						url: 'https://psv4.vk.m...rZ0nYs4fhbLEwHSf60A',
						genre_id: 18
					}
				}]
			}";

			var broadcastList = Api.Audio.GetBroadcastList("friends", true);
			Assert.NotNull(broadcastList);
			CollectionAssert.IsEmpty(broadcastList.Groups);
			CollectionAssert.IsNotEmpty(broadcastList.Users);
		}

		[Test]
		public void GetBroadcastList_FilterGroups_AllParams()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?filter=groups&active=1&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: [{
					id: 103292418,
					name: 'Work',
					screen_name: 'club103292418',
					is_closed: 0,
					type: 'group',
					is_admin: 1,
					admin_level: 3,
					is_member: 1,
					photo_50: 'https://vk.com/images/community_50.png',
					photo_100: 'https://vk.com/images/community_100.png',
					photo_200: 'https://vk.com/images/community_200.png',
					status_audio: {
						id: 456239025,
						owner_id: 32190123,
						artist: 'ЛюбителиТишины',
						title: 'Замокпламеникостров',
						duration: 208,
						date: 1458661957,
						url: 'https://psv4.vk.me/c613221/u131374929/audios/cbf90bdb4a97.mp3?extra=vQ54NRALdBHNochOTjYPGkx4UrHmS5yEtqe8-ohU5lNKOndzfUO6VaDaU_mX9p3aaEwHcWiND6WPsMnmGsOG11CH_ss4bAeShUIvg96a-A5tJjDorKTpsUhqpgGd6UEpOmSAWXDJOYEy',
						genre_id: 18
					}
				}]
			}";

			var broadcastList = Api.Audio.GetBroadcastList("groups", true);
			Assert.NotNull(broadcastList);
			CollectionAssert.IsNotEmpty(broadcastList.Groups);
			CollectionAssert.IsEmpty(broadcastList.Users);
		}

		[Test]
		public void GetBroadcastList_FilterGroups_Empty()
		{
			Url = "https://api.vk.com/method/audio.getBroadcastList?filter=groups&v=" + VkApi.VkApiVersion + "&access_token=token";
			Json = @"{
				response: []
			}";

			var broadcastList = Api.Audio.GetBroadcastList("groups");
			Assert.Null(broadcastList);
		}

		#endregion

	}
}