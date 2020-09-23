using System;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.RequestParams;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;

namespace VkNet.Tests.Categories.Video
{
	[TestFixture]

	public class VideoCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Video";

		[Test]
		public void Add_NormalCase()
		{
			Url = "https://api.vk.com/method/video.add";

			ReadCategoryJsonPath(nameof(Add_NormalCase));

			var id = Api.Video.Add(164841344, 1);
			Assert.That(id, Is.EqualTo(167593944));
		}

		[Test]
		public void AddAlbum_ToCurrentUser()
		{
			Url = "https://api.vk.com/method/video.addAlbum";

			ReadCategoryJsonPath(nameof(AddAlbum_ToCurrentUser));

			var id = Api.Video.AddAlbum("Новый альбом видеозаписей");
			Assert.That(id, Is.EqualTo(49273471));
		}

		[Test]
		public void CreateComment_NormalCase()
		{
			Url = "https://api.vk.com/method/video.createComment";

			ReadCategoryJsonPath(nameof(CreateComment_NormalCase));

			var id = Api.Video.CreateComment(new VideoCreateCommentParams
			{
				VideoId = 166613182,
				Message = "забавное видео",
				OwnerId = 1
			});

			Assert.That(id, Is.EqualTo(35634));
		}

		[Test]
		public void Delete_NormalCase()
		{
			Url = "https://api.vk.com/method/video.delete";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.Delete(167593944);
			Assert.That(result, Is.True);
		}

		[Test]
		public void DeleteAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/video.deleteAlbum";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.DeleteAlbum(52153813);
			Assert.That(result, Is.True);
		}

		[Test]
		public void DeleteComment_NormalCase()
		{
			Url = "https://api.vk.com/method/video.deleteComment";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.DeleteComment(35634, 1);
			Assert.That(result, Is.True);
		}

		[Test]
		public void Edit_NormalCase()
		{
			Url = "https://api.vk.com/method/video.edit";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.Edit(new VideoEditParams
			{
				VideoId = 167538,
				OwnerId = 23469,
				Name = "Новое название",
				Desc = "Новое описание"
			});

			Assert.That(result, Is.True);
		}

		[Test]
		public void EditAlbum_NormalCase()
		{
			Url = "https://api.vk.com/method/video.editAlbum";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.EditAlbum(521543, "Новое название!!!");
			Assert.That(result, Is.True);
		}

		[Test]
		public void EditComment_NormalCase()
		{
			Url = "https://api.vk.com/method/video.editComment";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.EditComment(35634, "суперское видео", 1);
			Assert.That(result, Is.True);
		}

		[Test]
		public void Get_Extended()
		{
			Url = "https://api.vk.com/method/video.get";

			ReadCategoryJsonPath(nameof(Get_Extended));

			var result = Api.Video.Get(new VideoGetParams
			{
				OwnerId = -129440544,
				Count = 1,
				Extended = true
			});

			var video = result.FirstOrDefault();

			Assert.NotNull(result);
			Assert.AreEqual(1, result.Count);
			Assert.NotNull(video);
			Assert.AreEqual(456245310, video.Id);
			Assert.AreEqual(-129440544, video.OwnerId);
			Assert.AreEqual("ec", video.Title);
			Assert.AreEqual(20, video.Duration);
			Assert.AreEqual(DateHelper.TimeStampToDateTime(1569151132), video.Date);
			Assert.AreEqual(6, video.Comments);
			Assert.AreEqual(40308, video.Views);
			Assert.AreEqual(640, video.Width);
			Assert.AreEqual(640, video.Height);
			Assert.IsNotEmpty(video.Image);
			Assert.IsNotEmpty(video.FirstFrame);
			Assert.IsFalse(video.IsFavorite);
			Assert.AreEqual(DateHelper.TimeStampToDateTime(1569151132), video.AddingDate);
			Assert.IsTrue(video.Repeat);
			Assert.NotNull(video.Files);
			Assert.AreEqual(new Uri("https://vk.com/vi/dec_GQ3DKNZUGI4TAMQ"), video.Player);
			Assert.True(video.CanAdd);
			Assert.True(video.CanComment);
			Assert.True(video.CanRepost);
			Assert.NotNull(video.Likes);
			Assert.False(video.Likes.UserLikes);
			Assert.AreEqual(369, video.Likes.Count);
			Assert.NotNull(video.Reposts);
			Assert.False(video.Reposts.UserReposted);
			Assert.AreEqual(1, video.Reposts.Count);
		}

		[Test]
		public void Get_NotExtended()
		{
			Url = "https://api.vk.com/method/video.get";

			ReadCategoryJsonPath(nameof(Get_NotExtended));

// 1, width: VideoWidth.Large320, count: 3, offset: 2
			var result = Api.Video.Get(new VideoGetParams
			{
				OwnerId = 1,
				Count = 3,
				Offset = 2
			});

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));

			var video = result.FirstOrDefault();
			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(166481021));
			Assert.That(video.OwnerId, Is.EqualTo(1));
			Assert.That(video.Title, Is.EqualTo("Лидия Аркадьевна"));
			Assert.That(video.Duration, Is.EqualTo(131));
			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384867255)));
			Assert.That(video.Views, Is.EqualTo(81676));
			Assert.That(video.Comments, Is.EqualTo(2098));

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
			Assert.That(video1.Views, Is.EqualTo(42107));
			Assert.That(video1.Comments, Is.EqualTo(1243));

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
			Assert.That(video2.Views, Is.EqualTo(218658));
			Assert.That(video2.Comments, Is.EqualTo(2578));

			Assert.That(video2.Photo130, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg")));

			Assert.That(video2.Photo320, Is.EqualTo(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg")));

			Assert.That(video2.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353")));
		}

		// todo add not extended version
		[Test]
		public void GetAlbums_NormalCase_Extended()
		{
			Url = "https://api.vk.com/method/video.getAlbums";

			ReadCategoryJsonPath(nameof(GetAlbums_NormalCase_Extended));

			var result = Api.Video.GetAlbums(-129440544, extended: true, needSystem: true);
			var videoAlbum = result.FirstOrDefault();

			Assert.NotNull(result);
			Assert.AreEqual(2, result.TotalCount);
			Assert.NotNull(videoAlbum);
			Assert.AreEqual(3790, videoAlbum.Count);
			Assert.AreEqual(-2, videoAlbum.Id);
			Assert.AreEqual(-129440544, videoAlbum.OwnerId);
			Assert.AreEqual("Добавленные", videoAlbum.Title);
			Assert.IsNotEmpty(videoAlbum.Image);
		}

		[Test]
		public void GetComments_WithLikes()
		{
			Url = "https://api.vk.com/method/video.getComments";

			ReadCategoryJsonPath(nameof(GetComments_WithLikes));

			var comments = Api.Video.GetComments(new VideoGetCommentsParams
			{
				VideoId = 166481021,
				OwnerId = 1,
				NeedLikes = true,
				Count = 2,
				Offset = 3,
				Sort = CommentsSort.Asc
			});

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

			Assert.That(comment1.Text,
				Is.EqualTo("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));

			Assert.That(comment1.Likes.Count, Is.EqualTo(77));
			Assert.That(comment1.Likes.UserLikes, Is.EqualTo(false));
			Assert.That(comment1.Likes.CanLike, Is.EqualTo(true));
		}

		[Test]
		public void GetComments_WithoutLikes()
		{
			Url = "https://api.vk.com/method/video.getComments";

			ReadCategoryJsonPath(nameof(GetComments_WithoutLikes));

			var comments = Api.Video.GetComments(new VideoGetCommentsParams
			{
				VideoId = 166481021,
				OwnerId = 1,
				NeedLikes = false,
				Count = 2,
				Offset = 3,
				Sort = CommentsSort.Asc
			});

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

			Assert.That(comment1.Text,
				Is.EqualTo("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!"));
		}

		[Test]
		public void Report_NormalCase()
		{
			Url = "https://api.vk.com/method/video.report";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.Report(166613182, ReportReason.DrugPropaganda, 1, "коммент");
			Assert.That(result, Is.True);
		}

		[Test]
		public void ReportComment_NormalCase()
		{
			Url = "https://api.vk.com/method/video.reportComment";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.ReportComment(35637, 1, ReportReason.AdultMaterial);
			Assert.That(result, Is.True);
		}

		[Test]
		public void Restore_NormalCase()
		{
			Url = "https://api.vk.com/method/video.restore";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.Restore(167593944);
			Assert.That(result, Is.True);
		}

		[Test]
		public void RestoreComment_NormalCase()
		{
			Url = "https://api.vk.com/method/video.restoreComment";

			ReadJsonFile(JsonPaths.True);

			var result = Api.Video.RestoreComment(35634, 1);
			Assert.That(result, Is.True);
		}

		[Test]
		public void Save_NormalCase()
		{
			Url = "https://api.vk.com/method/video.save";

			ReadCategoryJsonPath(nameof(Save_NormalCase));

			var video = Api.Video.Save(new VideoSaveParams
			{
				Name = "Название из ютуба",
				Description = "Описание из ютуба",
				Wallpost = true,
				Link = "https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA"
			});

			Assert.That(video, Is.Not.Null);
			Assert.That(video.Id, Is.EqualTo(1673994));
			Assert.That(video.OwnerId, Is.EqualTo(2346958));
			Assert.That(video.Title, Is.EqualTo("Название из ютуба"));
			Assert.That(video.Description, Is.EqualTo("Описание из ютуба"));
			Assert.That(video.AccessKey, Is.EqualTo("f2ec9f3982f05bc"));

			Assert.That(video.UploadUrl,
				Is.EqualTo(new Uri(
					"http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043")));
		}

		[Test]
		public void Save_ReturnError()
		{
			ReadErrorsJsonFile(204);

			Assert.That(() => VkErrors.IfErrorThrowException(Json), Throws.TypeOf<VideoAccessDeniedException>());
		}

		[Test]
		public void Search_NormalCase_ListOfVideos()
		{
			Url = "https://api.vk.com/method/video.search";

			ReadCategoryJsonPath(nameof(Search_NormalCase_ListOfVideos));

			// , VideoSort.Relevance, false, true, VideoFilters.Long, false, 5, 1
			var result = Api.Video.Search(new VideoSearchParams
			{
				Query = "саша грей",
				Sort = VideoSort.Relevance,
				Hd = false,
				Adult = true,
				Filters = VideoFilters.Long,
				SearchOwn = false,
				Count = 5,
				Offset = 1
			});

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(3));

			var video = result.FirstOrDefault();
			Assert.That(video, Is.Not.Null);

			Assert.That(video.Id, Is.EqualTo(166671614));
			Assert.That(video.OwnerId, Is.EqualTo(-59205334));

			Assert.That(video.Title,
				Is.EqualTo(
					"Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ"));

			Assert.That(video.Duration, Is.EqualTo(1934));

			Assert.That(video.Description,
				Is.EqualTo("beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<"));

			Assert.That(video.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1384706962)));
			Assert.That(video.Views, Is.EqualTo(11579));
			Assert.That(video.Comments, Is.EqualTo(12));

			Assert.That(video.Photo130, Is.EqualTo(new Uri("http://cs505118.vk.me/u7160710/video/s_08382000.jpg")));

			Assert.That(video.Photo320, Is.EqualTo(new Uri("http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg")));

			Assert.That(video.AlbumId, Is.EqualTo(50100051));

			Assert.That(video.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d")));

			var video1 = result.Skip(1).FirstOrDefault();
			Assert.That(video1, Is.Not.Null);

			Assert.That(video1.Id, Is.EqualTo(165458571));
			Assert.That(video1.OwnerId, Is.EqualTo(-49956637));

			Assert.That(video1.Title,
				Is.EqualTo(
					"домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа"));

			Assert.That(video1.Duration, Is.EqualTo(1139));

			Assert.That(video1.Description,
				Is.EqualTo(
					"секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex"));

			Assert.That(video1.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1371702618)));
			Assert.That(video1.Views, Is.EqualTo(12817));
			Assert.That(video1.Comments, Is.EqualTo(5));

			Assert.That(video1.Photo130, Is.EqualTo(new Uri("http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg")));

			Assert.That(video1.Photo320, Is.EqualTo(new Uri("http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg")));

			Assert.That(video1.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92")));

			var video2 = result.Skip(2).FirstOrDefault();
			Assert.That(video2, Is.Not.Null);

			Assert.That(video2.Id, Is.EqualTo(166728490));
			Assert.That(video2.OwnerId, Is.EqualTo(-54257090));
			Assert.That(video2.Title, Is.EqualTo("Саша Грей | Sasha Grey #13"));
			Assert.That(video2.Duration, Is.EqualTo(1289));

			Assert.That(video2.Description,
				Is.EqualTo(
					"Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica"));

			Assert.That(video2.Date, Is.EqualTo(DateHelper.TimeStampToDateTime(1386961568)));
			Assert.That(video2.Views, Is.EqualTo(8730));
			Assert.That(video2.Comments, Is.EqualTo(12));

			Assert.That(video2.Photo130, Is.EqualTo(new Uri("http://cs535107.vk.me/u146564541/video/s_2d874147.jpg")));

			Assert.That(video2.Photo320, Is.EqualTo(new Uri("http://cs535107.vk.me/u146564541/video/l_cb794198.jpg")));

			Assert.That(video2.Player, Is.EqualTo(new Uri("http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac")));
		}

		[Test]
		public void AddToAlbum()
		{
			Url = "https://api.vk.com/method/video.addToAlbum";

			ReadCategoryJsonPath(nameof(AddToAlbum));

			var result = Api.Video.AddToAlbum(123, 123, null, null, 123);

			Assert.That(result.TotalCount, Is.EqualTo(0));
			Assert.Contains(2, result);
		}
	}
}