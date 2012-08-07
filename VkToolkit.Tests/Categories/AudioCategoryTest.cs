using System.Linq;
using Moq;
using NUnit.Framework;
using VkToolkit.Categories;
using VkToolkit.Enums;
using VkToolkit.Exception;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Tests.Categories
{
    [TestFixture]
    public class AudioCategoryTest
    {
        private AudioCategory GetMockedAudioCategory(string url, string json)
        {
            var mock = new Mock<IBrowser>();
            mock.Setup(m => m.GetJson(url)).Returns(json);

            return new AudioCategory(new VkApi {AccessToken = "token", Browser = mock.Object});

        }

        [Test]
        [ExpectedException (typeof(AccessTokenInvalidException))]
        public void GetCount_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.GetCount(1);
        }

        [Test]
        public void GetCount_UserHasNoAudio_ReturnZero()
        {
            const string url = "https://api.vk.com/method/audio.getCount?oid=1&access_token=token";
            const string json = "{\"response\":\"0\"}";

            var audio = GetMockedAudioCategory(url, json);
            int count = audio.GetCount(1);

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void GetCount_UserHasAudio_CountOfRecords()
        {
            const string url = "https://api.vk.com/method/audio.getCount?oid=1&access_token=token";
            const string json = "{\"response\":\"158\"}";
            
            var audio = GetMockedAudioCategory(url, json);
            int count = audio.GetCount(1);

            Assert.That(count, Is.EqualTo(158));
        }

        [Test]
        public void GetCount_GroupHasAudio_CountOfRecords()
        {
            const string url = "https://api.vk.com/method/audio.getCount?oid=-1158263&access_token=token";
            const string json = "{\"response\":\"4\"}";

            var audio = GetMockedAudioCategory(url, json);
            int count = audio.GetCount(-1158263);

            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetLyrics_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.GetLyrics(222);
        }

        [Test]
        public void GetLyrics_2662381_ReturnLyricsObject()
        {
            const string url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=2662381&access_token=token";
            const string json =
                "{\"response\":{\"lyrics_id\":2662381,\"text\":\"Ich will, ich will,\\nIch will, ich will,\\nIch will\"}}";

            var audio = GetMockedAudioCategory(url, json);
            Lyrics lyrics = audio.GetLyrics(2662381);

            Assert.That(lyrics.Id, Is.EqualTo(2662381));
            Assert.That(lyrics.Text, Is.EqualTo("Ich will, ich will,\nIch will, ich will,\nIch will"));
        }

        [Test]
        public void GetLyrics_WrongId_ReturnEmptyTextProperty()
        {
            const string url = "https://api.vk.com/method/audio.getLyrics?lyrics_id=-1&access_token=token";
            const string json = "{\"response\":{\"lyrics_id\":-1,\"text\":\"\"}}";
            var audio = GetMockedAudioCategory(url, json);
            Lyrics lyrics = audio.GetLyrics(-1);

            Assert.That(lyrics.Id, Is.EqualTo(-1));
            Assert.That(lyrics.Text, Is.Null.Or.Empty);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetById_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.GetById(new string[] {"1_1"});
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "audios param is null.")]
        public void GetById_AudiosParamIsNull_ThrowInvalidParamException()
        {
            var audio = GetMockedAudioCategory("", "");
            audio.GetById(null);
        }

        [Test]
        public void GetById_WrongId_EmptyList()
        {
            const string url = "https://api.vk.com/method/audio.getById?audios=2e4w_67859ds194&access_token=token";
            const string json = "{\"response\":[]}";

            var cat = GetMockedAudioCategory(url, json);

            var ids = new[] {"2e4w_67859ds194"};
            var audios = cat.GetById(ids).ToList();
            Assert.That(audios.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetById_NormalCase_ListOfAudioObjects()
        {
            const string url = "https://api.vk.com/method/audio.getById?audios=4793858_158073513,2_63937759&access_token=token";
            const string json = "{\"response\":[{\"aid\":158073513,\"owner_id\":4793858,\"artist\":\"Тараканы!\",\"title\":\"Собачье Сердце\",\"duration\":230,\"url\":\"http:\\/\\/cs4838.vkontakte.ru\\/u4198300\\/audio\\/e00969c453e9.mp3\",\"lyrics_id\":\"7985406\"},{\"aid\":63937759,\"owner_id\":2,\"artist\":\"Madonna\",\"title\":\"Celebration\",\"duration\":215,\"url\":\"http:\\/\\/cs4246.vkontakte.ru\\/u2877745\\/audio\\/befc415b7853.mp3\",\"lyrics_id\":\"2195871\",\"album\":\"26758146\"}]}";

            var cat = GetMockedAudioCategory(url, json);
            var ids = new string[] { "4793858_158073513", "2_63937759" };
            var audios = cat.GetById(ids).ToList();

            Assert.That(audios.Count, Is.EqualTo(2));
            Assert.That(audios[0].Id, Is.EqualTo(158073513));
            Assert.That(audios[0].OwnerId, Is.EqualTo(4793858));
            Assert.That(audios[0].Artist, Is.EqualTo("Тараканы!"));
            Assert.That(audios[0].Title, Is.EqualTo("Собачье Сердце"));
            Assert.That(audios[0].Duration, Is.EqualTo(230));
            Assert.That(audios[0].Url.OriginalString, Is.EqualTo("http://cs4838.vkontakte.ru/u4198300/audio/e00969c453e9.mp3"));
            Assert.That(audios[0].LyricsId, Is.EqualTo(7985406));
            Assert.That(audios[1].Id, Is.EqualTo(63937759));
            Assert.That(audios[1].OwnerId, Is.EqualTo(2));
            Assert.That(audios[1].Artist, Is.EqualTo("Madonna"));
            Assert.That(audios[1].Title, Is.EqualTo("Celebration"));
            Assert.That(audios[1].Duration, Is.EqualTo(215));
            Assert.That(audios[1].Url.OriginalString, Is.EqualTo("http://cs4246.vkontakte.ru/u2877745/audio/befc415b7853.mp3"));
            Assert.That(audios[1].LyricsId, Is.EqualTo(2195871));
            Assert.That(audios[1].AlbumId, Is.EqualTo(26758146));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void GetUploadServer_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.GetUploadServer();
        }

        [Test]
        public void GetUploadServer_NormalCase_ReturnUploadUrl()
        {
            const string url = "https://api.vk.com/method/audio.getUploadServer?access_token=token";
            const string json =
                "{\"response\":{\"upload_url\":\"http:\\/\\/cs6173.vk.com\\/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1\"}}";

            var audio = GetMockedAudioCategory(url, json);
            string uploadUrl = audio.GetUploadServer();

            Assert.That(uploadUrl, Is.EqualTo("http://cs6173.vk.com/upload.php?act=add_audio&mid=4793858&aid=0&gid=0&hash=a1ec03d21addb2d8cf371db90c79f592&rhash=e5eda6ac5b469953c4d15d0c02d364f2&api=1"));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Get_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.Get(1);
        }

        [Test]
        public void Get_NormalCaseDefaultValues_ListOfAudioObjects()
        {
            const string url = "https://api.vk.com/method/audio.get?uid=4793858&access_token=token";
            const string json =
                "{\"response\":[{\"aid\":158947216,\"owner_id\":4793858,\"artist\":\"Дядя Женя\",\"title\":\"Вопреки законам природы\",\"duration\":204,\"url\":\"http:\\/\\/cs4517.vkontakte.ru\\/u50781326\\/audio\\/d20ef68f7848.mp3\",\"lyrics_id\":\"4002932\"},{\"aid\":158945986,\"owner_id\":4793858,\"artist\":\"Дядя Женя\",\"title\":\"Финал: Без правил\",\"duration\":380,\"url\":\"http:\\/\\/cs4259.vkontakte.ru\\/u1622813\\/audio\\/61bf620e698e.mp3\",\"lyrics_id\":\"3004301\"}]}";

            var category = GetMockedAudioCategory(url, json);
            var audios = category.Get(4793858).ToList();

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
            const string url = "https://api.vk.com/method/audio.get?gid=28622822&access_token=token";
            const string json =
                "{\"response\":[{\"aid\":111400889,\"owner_id\":-28622822,\"artist\":\"Дискотека Авария (www.primemusic.ru)\",\"title\":\"Недетское Время\",\"duration\":238,\"url\":\"http:\\/\\/cs5002.vkontakte.ru\\/u40615612\\/audio\\/9f34e8775a94.mp3\"},{\"aid\":111400883,\"owner_id\":-28622822,\"artist\":\"Дискотека Авария\",\"title\":\"Нано Техно (NEW 2011)\",\"duration\":206,\"url\":\"http:\\/\\/cs4676.vkontakte.ru\\/u45593256\\/audio\\/423512410072.mp3\"}]}";

            var category = GetMockedAudioCategory(url, json);
            var audios = category.GetFromGroup(28622822).ToList();

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
            const string url = "https://api.vk.com/method/audio.get?uid=4793858&need_user=1&count=3&offset=5&access_token=token";
            const string json =
                "{\"response\":[{\"id\":\"4793858\",\"photo\":\"http:\\/\\/cs9215.userapi.com\\/u4793858\\/e_1b975695.jpg\",\"name\":\"Антон Жидков\",\"name_gen\":\"Антона\"},{\"aid\":157633898,\"owner_id\":4793858,\"artist\":\"Марш Люфтваффе(немецкая народная песня)\",\"title\":\"Was wollen wir trinken!\",\"duration\":298,\"url\":\"http:\\/\\/cs4696.vkontakte.ru\\/u78355164\\/audio\\/e9a8e73e283b.mp3\",\"lyrics_id\":\"7257154\"},{\"aid\":157469004,\"owner_id\":4793858,\"artist\":\"Титаник-гитара=)\",\"title\":\"титаник\",\"duration\":227,\"url\":\"http:\\/\\/cs4770.vkontakte.ru\\/u12282005\\/audio\\/946096f61144.mp3\",\"lyrics_id\":\"5540676\"},{\"aid\":157187769,\"owner_id\":4793858,\"artist\":\"И.В.Сталин\",\"title\":\"Речь И.В.Сталина 7 ноября 1941\",\"duration\":185,\"url\":\"http:\\/\\/cs1338.vkontakte.ru\\/u3201669\\/audio\\/7d67c7278b65.mp3\"}]}";

            User user;
            var category = GetMockedAudioCategory(url, json);
            var audios = category.Get(4793858, out user,null,null,3,5).ToList();

            Assert.That(audios.Count, Is.EqualTo(3));

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(4793858));
            Assert.That(user.Photo, Is.EqualTo("http://cs9215.userapi.com/u4793858/e_1b975695.jpg"));
            Assert.That(user.FirstName, Is.EqualTo("Антон"));
            Assert.That(user.LastName, Is.EqualTo("Жидков"));
            Assert.That(user.NameGen, Is.EqualTo("Антона"));

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
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Search_AccessTokenInvalid_ThrowAccessTokenInvalidExcpetion()
        {
            var audio = new AudioCategory(new VkApi());
            int totalCount;
            audio.Search("Beatles", out totalCount);
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "Query is null or empty.")]
        public void Search_QueryEmptyOrNull_ThrowInvalidParamException()
        {
            var audio = GetMockedAudioCategory("", "");
            int  totalCount;
            audio.Search("", out totalCount);
        }

        [Test]
        public void Search_NotExistedQuery_EmptyList()
        {
            const string url = "https://api.vk.com/method/audio.search?q=ThisQueryDoesNotExistAtAll&access_token=token";
            const string json = "{\"response\":[0]}";

            var audio = GetMockedAudioCategory(url, json);

            int totalCount;
            var auds = audio.Search("ThisQueryDoesNotExistAtAll", out totalCount).ToList();

            Assert.That(totalCount, Is.EqualTo(0));
            Assert.That(auds.Count, Is.EqualTo(0));
        }

        [Test]
        public void Search_NormalCaseAllFields_ListOfAudios()
        {
            const string url =
                "https://api.vk.com/method/audio.search?q=иуфедуы&auto_complete=1&sort=1&lyrics=1&count=3&offset=5&access_token=token";
            const string json =
                "{\"response\":[84673,{\"aid\":141104180,\"owner_id\":2289065,\"artist\":\"2560 The BEATLES (цикл передач на РАДИО СВОБОДА)\",\"title\":\"Джон, Пол, Ждордж, Ринго - работа для кино\",\"duration\":3180,\"url\":\"http:\\/\\/cs5045.vkontakte.ru\\/u17922696\\/audio\\/7af351f23650.mp3\",\"lyrics_id\":\"23484916\",\"album\":\"24110176\"},{\"aid\":141104155,\"owner_id\":2289065,\"artist\":\"2556 The BEATLES (цикл передач на РАДИО СВОБОДА)\",\"title\":\"БИТЛЗ. Песни, подаренные другим\",\"duration\":3179,\"url\":\"http:\\/\\/cs5045.vkontakte.ru\\/u17922696\\/audio\\/5f36b4e2c652.mp3\",\"lyrics_id\":\"23484936\",\"album\":\"24110176\"},{\"aid\":141104164,\"owner_id\":2289065,\"artist\":\"2558 The BEATLES (цикл передач на РАДИО СВОБОДА)\",\"title\":\"Музыка БИТЛЗ у других исполнителей\",\"duration\":3179,\"url\":\"http:\\/\\/cs5045.vkontakte.ru\\/u17922696\\/audio\\/6768fd4bfece.mp3\",\"lyrics_id\":\"23484929\",\"album\":\"24110176\"}]}";

            var category = GetMockedAudioCategory(url, json);
            int totalCount;
            var auds = category.Search("иуфедуы", out totalCount, true, AudioSort.Duration, true, 3, 5).ToList();

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
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Add_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.Add(0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void Add_InvalidInputParam_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/audio.add?aid=0&oid=0&access_token=token";
            const string json =
                "{\"error\":{\"error_code\":100,\"error_msg\":\"One of the parameters specified was missing or invalid\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.add\"},{\"key\":\"aid\",\"value\":\"0\"},{\"key\":\"oid\",\"value\":\"0\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var category = GetMockedAudioCategory(url, json);
            category.Add(0, 0);
        }

        [Test]
        public void Add_AddToCuurentUser_AudioId()
        {
            const string url = "https://api.vk.com/method/audio.add?aid=141104180&oid=2289065&access_token=token";
            const string json = "{\"response\":159200195}";

            var category = GetMockedAudioCategory(url, json);
            var id = category.Add(141104180, 2289065);
            Assert.That(id, Is.EqualTo(159200195));
        }

        [Test]
        public void Add_AddToGroup_AudioId()
        {
            const string url =
                "https://api.vk.com/method/audio.add?aid=141104180&oid=2289065&gid=1158263&access_token=token";
            const string json = "{\"response\":160532304}";

            var cat = GetMockedAudioCategory(url, json);
            var id = cat.Add(141104180, 2289065, 1158263);
            Assert.That(id, Is.EqualTo(160532304));
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Delete_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.Delete(0, 0);
        }

        [Test]
        public void Delete_NoramCaseUser_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=159203048&oid=4793858&access_token=token";
            const string json = "{\"response\":1}";

            var cat = GetMockedAudioCategory(url, json);
            bool result = cat.Delete(159203048, 4793858);

            Assert.That(result, Is.True);
        }
        
        [Test]
        public void Delete_NoramCaseGroup_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=160532304&oid=-1158263&access_token=token";
            const string json = "{\"response\":1}";

            var cat = GetMockedAudioCategory(url, json);
            bool result = cat.Delete(160532304, -1158263);

            Assert.That(result, Is.True);
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void Delete_WrongInputParams_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/audio.delete?aid=0&oid=0&access_token=token";
            const string json =
                "{\"error\":{\"error_code\":100,\"error_msg\":\"One of the parameters specified was missing or invalid\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.delete\"},{\"key\":\"aid\",\"value\":\"0\"},{\"key\":\"oid\",\"value\":\"0\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var cat = GetMockedAudioCategory(url, json);
            cat.Delete(0, 0);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Edit_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.Edit(0, 0, "", "", "");
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "artist parameter is null.")]
        public void Edit_ArtistParamIsNull_ThrowInvalidParamException()
        {
            var cat = GetMockedAudioCategory("", "");
            cat.Edit(0, 0, null, "", "");
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "title parameter is null.")]
        public void Edit_TitleParamIsNull_ThrowInvalidParamException()
        {
            var cat = GetMockedAudioCategory("", "");
            cat.Edit(0, 0, "", null, "");
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException), ExpectedMessage = "text parameter is null.")]
        public void Edit_TextParamIsNull_ThrowInvalidParamException()
        {
            var cat = GetMockedAudioCategory("", "");
            cat.Edit(0, 0, "", "", null);
        }

        [Test]
        public void Edit_NoramCase_ReturnLyricsId()
        {
            const string url =
                "https://api.vk.com/method/audio.edit?aid=159207130&oid=4793858&artist=Test Artist&title=Test Title&text=Test Text&no_search=0&access_token=token";
            const string json = "{\"response\":26350163}";

            var cat = GetMockedAudioCategory(url, json);
            var id = cat.Edit(159207130, 4793858, "Test Artist", "Test Title", "Test Text");

            Assert.That(id, Is.EqualTo(26350163));
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void Edit_WrongInputParams_ThrowInvalidParamException()
        {
            const string url =
                "https://api.vk.com/method/audio.edit?aid=0&oid=0&artist=Test Artist&title=Test Title&text=Test Text&no_search=0&access_token=token";
            const string json =
                "{\"error\":{\"error_code\":100,\"error_msg\":\"One of the parameters specified was missing or invalid\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.edit\"},{\"key\":\"aid\",\"value\":\"0\"},{\"key\":\"oid\",\"value\":\"0\"},{\"key\":\"artist\",\"value\":\"Test Artist\"},{\"key\":\"title\",\"value\":\"Test Title\"},{\"key\":\"text\",\"value\":\"Test Text\"},{\"key\":\"no_search\",\"value\":\"0\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var cat = GetMockedAudioCategory(url, json);

            cat.Edit(0, 0, "Test Artist", "Test Title", "Test Text");
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Restore_InvalidAccessToken_ThrowAccessTokenInvalidException()
        {
            var audio = new AudioCategory(new VkApi());
            audio.Restore(0, 0);
        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void Restore_InvalidInputParams_ThrowInvalidParamException()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=0&oid=0&access_token=token";
            const string json = "{\"error\":{\"error_code\":100,\"error_msg\":\"One of the parameters specified was missing or invalid\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.restore\"},{\"key\":\"aid\",\"value\":\"0\"},{\"key\":\"oid\",\"value\":\"0\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var cat = GetMockedAudioCategory(url, json);
            cat.Restore(0, 0);
        }

        [Test]
        public void Restore_NoramCase_ReturnAudioObject()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=159209928&access_token=token";
            const string json =
                "{\"response\":{\"aid\":159209928,\"owner_id\":4793858,\"artist\":\"2560 The BEATLES (цикл передач на РАДИО СВОБОДА)\",\"title\":\"Джон, Пол, Ждордж, Ринго - работа для кино\",\"duration\":3180,\"url\":\"http:\\/\\/cs5045.vkontakte.ru\\/u17922696\\/audio\\/4529541451fe.mp3\",\"lyrics_id\":\"23484916\"}}";

            var cat = GetMockedAudioCategory(url, json);
            Audio a = cat.Restore(159209928);

            Assert.That(a.Id, Is.EqualTo(159209928));
            Assert.That(a.OwnerId, Is.EqualTo(4793858));
            Assert.That(a.Artist, Is.EqualTo("2560 The BEATLES (цикл передач на РАДИО СВОБОДА)"));
            Assert.That(a.Title, Is.EqualTo("Джон, Пол, Ждордж, Ринго - работа для кино"));
            Assert.That(a.Duration, Is.EqualTo(3180));
            Assert.That(a.Url.OriginalString, Is.EqualTo("http://cs5045.vkontakte.ru/u17922696/audio/4529541451fe.mp3"));
            Assert.That(a.LyricsId, Is.EqualTo(23484916));

        }

        [Test]
        [ExpectedException(typeof(VkApiException), ExpectedMessage = "Cache expired")]
        public void Restore_AudioNotDeletedYet_Throw()
        {
            const string url = "https://api.vk.com/method/audio.restore?aid=159210112&access_token=token";
            const string json = "{\"error\":{\"error_code\":202,\"error_msg\":\"Cache expired\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.restore\"},{\"key\":\"aid\",\"value\":\"159210112\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";
            
            var cat = GetMockedAudioCategory(url, json);
            cat.Restore(159210112);
        }

        [Test]
        [ExpectedException(typeof(AccessTokenInvalidException))]
        public void Reorder_AccessTokenInvalid_ThrowAccessTokenInvalidException()
        {
            var cat = new AudioCategory(new VkApi());
            cat.Reorder(0, 0, 0, 0);

        }

        [Test]
        [ExpectedException(typeof(InvalidParamException))]
        public void Reorder_InvalidInputParams_ThrowInvalidParamException()
        {
            const string url =
                "https://api.vk.com/method/audio.reorder?aid=0&oid=0&after=159104443&before=158945986&access_token=token";

            const string json = "{\"error\":{\"error_code\":100,\"error_msg\":\"One of the parameters specified was missing or invalid\",\"request_params\":[{\"key\":\"oauth\",\"value\":\"1\"},{\"key\":\"method\",\"value\":\"audio.reorder\"},{\"key\":\"aid\",\"value\":\"0\"},{\"key\":\"oid\",\"value\":\"0\"},{\"key\":\"after\",\"value\":\"159104443\"},{\"key\":\"before\",\"value\":\"158945986\"},{\"key\":\"access_token\",\"value\":\"token\"}]}}";

            var cat = GetMockedAudioCategory(url, json);
            cat.Reorder(0, 0, 159104443, 158945986);
        }

        [Test]
        public void Reorder_NormalCase_ReturnTrue()
        {
            const string url = "https://api.vk.com/method/audio.reorder?aid=159210112&oid=4793858&after=159104443&before=158945986&access_token=token";
            const string json = "{\"response\":1}";

            var cat = GetMockedAudioCategory(url, json);
            bool result = cat.Reorder(159210112, 4793858, 159104443, 158945986);
            Assert.That(result, Is.True);
        }
    }
}