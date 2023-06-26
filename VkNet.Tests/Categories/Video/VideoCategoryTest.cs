using System;
using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Exception;
using VkNet.Tests.Helper;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Categories.Video;

public class VideoCategoryTest : CategoryBaseTest
{
	protected override string Folder => "Video";

	[Fact]
	public void Add_NormalCase()
	{
		Url = "https://api.vk.com/method/video.add";

		ReadCategoryJsonPath(nameof(Add_NormalCase));

		var id = Api.Video.Add(164841344, 1);

		id.Should()
			.Be(167593944);
	}

	[Fact]
	public void AddAlbum_ToCurrentUser()
	{
		Url = "https://api.vk.com/method/video.addAlbum";

		ReadCategoryJsonPath(nameof(AddAlbum_ToCurrentUser));

		var id = Api.Video.AddAlbum("Новый альбом видеозаписей");

		id.Should()
			.Be(49273471);
	}

	[Fact]
	public void CreateComment_NormalCase()
	{
		Url = "https://api.vk.com/method/video.createComment";

		ReadCategoryJsonPath(nameof(CreateComment_NormalCase));

		var id = Api.Video.CreateComment(new()
		{
			VideoId = 166613182,
			Message = "забавное видео",
			OwnerId = 1
		});

		id.Should()
			.Be(35634);
	}

	[Fact]
	public void Delete_NormalCase()
	{
		Url = "https://api.vk.com/method/video.delete";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.Delete(167593944);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void DeleteAlbum_NormalCase()
	{
		Url = "https://api.vk.com/method/video.deleteAlbum";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.DeleteAlbum(52153813);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void DeleteComment_NormalCase()
	{
		Url = "https://api.vk.com/method/video.deleteComment";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.DeleteComment(35634, 1);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Edit_NormalCase()
	{
		Url = "https://api.vk.com/method/video.edit";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.Edit(new()
		{
			VideoId = 167538,
			OwnerId = 23469,
			Name = "Новое название",
			Desc = "Новое описание"
		});

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditAlbum_NormalCase()
	{
		Url = "https://api.vk.com/method/video.editAlbum";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.EditAlbum(521543, "Новое название!!!");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void EditComment_NormalCase()
	{
		Url = "https://api.vk.com/method/video.editComment";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.EditComment(35634, "суперское видео", 1);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Get_Extended()
	{
		Url = "https://api.vk.com/method/video.get";

		ReadCategoryJsonPath(nameof(Get_Extended));

		var result = Api.Video.Get(new()
		{
			OwnerId = -129440544,
			Count = 1,
			Extended = true
		});

		var video = result.FirstOrDefault();

		result.Should()
			.NotBeNull();

		result.Should()
			.ContainSingle();

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(456245310);

		video.OwnerId.Should()
			.Be(-129440544);

		video.Title.Should()
			.Be("ec");

		video.Duration.Should()
			.Be(20);

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1569151132));

		video.Comments.Should()
			.Be(6);

		video.Views.Should()
			.Be(40308);

		video.Width.Should()
			.Be(640);

		video.Height.Should()
			.Be(640);

		video.Image.Should()
			.NotBeEmpty();

		video.FirstFrame.Should()
			.NotBeEmpty();

		video.IsFavorite.Should()
			.BeFalse();

		video.AddingDate.Should()
			.Be(DateHelper.TimeStampToDateTime(1569151132));

		video.Repeat.Should()
			.BeTrue();

		video.Files.Should()
			.NotBeNull();

		video.Player.Should()
			.Be(new Uri("https://vk.com/vi/dec_GQ3DKNZUGI4TAMQ"));

		video.CanAdd.Should()
			.BeTrue();

		video.CanComment.Should()
			.BeTrue();

		video.CanRepost.Should()
			.BeTrue();

		video.Likes.Should()
			.NotBeNull();

		video.Likes.UserLikes.Should()
			.BeFalse();

		video.Likes.Count.Should()
			.Be(369);

		video.Reposts.Should()
			.NotBeNull();

		video.Reposts.UserReposted.Should()
			.BeFalse();

		video.Reposts.Count.Should()
			.Be(1);
	}

	[Fact]
	public void Get_NotExtended()
	{
		Url = "https://api.vk.com/method/video.get";

		ReadCategoryJsonPath(nameof(Get_NotExtended));

		// 1, width: VideoWidth.Large320, count: 3, offset: 2
		var result = Api.Video.Get(new()
		{
			OwnerId = 1,
			Count = 3,
			Offset = 2
		});

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(3);

		var video = result.FirstOrDefault();

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(166481021);

		video.OwnerId.Should()
			.Be(1);

		video.Title.Should()
			.Be("Лидия Аркадьевна");

		video.Duration.Should()
			.Be(131);

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384867255));

		video.Views.Should()
			.Be(81676);

		video.Comments.Should()
			.Be(2098);

		video.Photo130.Should()
			.Be(new Uri("http://cs419529.vk.me/u9258277/video/s_af2727af.jpg"));

		video.Photo320.Should()
			.Be(new Uri("http://cs419529.vk.me/u9258277/video/l_aba9c1ab.jpg"));

		video.Player.Should()
			.Be(new Uri("http://www.youtube.com/embed/VQaHFisdf-s"));

		var video1 = result.Skip(1)
			.FirstOrDefault();

		video1.Should()
			.NotBeNull();

		video1.Id.Should()
			.Be(166468673);

		video1.OwnerId.Should()
			.Be(1);

		video1.Title.Should()
			.Be("Лидия Аркадьевна");

		video1.Duration.Should()
			.Be(62);

		video1.Description.Should()
			.BeEmpty();

		video1.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384721483));

		video1.Views.Should()
			.Be(42107);

		video1.Comments.Should()
			.Be(1243);

		video1.Photo130.Should()
			.Be(new Uri("http://cs409217.vk.me/u9258277/video/s_4e281f24.jpg"));

		video1.Photo320.Should()
			.Be(new Uri("http://cs409217.vk.me/u9258277/video/l_aa616ea2.jpg"));

		video1.Player.Should()
			.Be(new Uri("http://www.youtube.com/embed/YfLytrkbAfM"));

		var video2 = result.Skip(2)
			.FirstOrDefault();

		video2.Should()
			.NotBeNull();

		video2.Id.Should()
			.Be(164841344);

		video2.OwnerId.Should()
			.Be(1);

		video2.Title.Should()
			.Be("This is SPARTA");

		video2.Duration.Should()
			.Be(16);

		video2.Description.Should()
			.BeEmpty();

		video2.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1366495075));

		video2.Views.Should()
			.Be(218658);

		video2.Comments.Should()
			.Be(2578);

		video2.Photo130.Should()
			.Be(new Uri("http://cs12761.vk.me/u5705167/video/s_df53315c.jpg"));

		video2.Photo320.Should()
			.Be(new Uri("http://cs12761.vk.me/u5705167/video/l_00c6be47.jpg"));

		video2.Player.Should()
			.Be(new Uri("http://vk.com/video_ext.php?oid=1&id=164841344&hash=c8de45fc73389353"));
	}

	// todo add not extended version
	[Fact]
	public void GetAlbums_NormalCase_Extended()
	{
		Url = "https://api.vk.com/method/video.getAlbums";

		ReadCategoryJsonPath(nameof(GetAlbums_NormalCase_Extended));

		var result = Api.Video.GetAlbums(-129440544, extended: true, needSystem: true);
		var videoAlbum = result.FirstOrDefault();

		result.Should()
			.NotBeNull();

		result.TotalCount.Should()
			.Be(2);

		videoAlbum.Should()
			.NotBeNull();

		videoAlbum.Count.Should()
			.Be(3790);

		videoAlbum.Id.Should()
			.Be(-2);

		videoAlbum.OwnerId.Should()
			.Be(-129440544);

		videoAlbum.Title.Should()
			.Be("Добавленные");

		videoAlbum.Image.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void GetComments_WithLikes()
	{
		Url = "https://api.vk.com/method/video.getComments";

		ReadCategoryJsonPath(nameof(GetComments_WithLikes));

		var comments = Api.Video.GetComments(new()
		{
			VideoId = 166481021,
			OwnerId = 1,
			NeedLikes = true,
			Count = 2,
			Offset = 3,
			Sort = CommentsSort.Asc
		});

		comments.Should()
			.NotBeNull();

		comments.Should()
			.HaveCount(2);

		var comment = comments.FirstOrDefault();

		comment.Should()
			.NotBeNull();

		comment.Id.Should()
			.Be(14715);

		comment.FromId.Should()
			.Be(24758120);

		comment.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384867361));

		comment.Text.Should()
			.Be("паша здаров!");

		comment.Likes.Count.Should()
			.Be(5);

		comment.Likes.UserLikes.Should()
			.BeFalse();

		comment.Likes.CanLike.Should()
			.BeTrue();

		var comment1 = comments.Skip(1)
			.FirstOrDefault();

		comment1.Should()
			.NotBeNull();

		comment1.Id.Should()
			.Be(14716);

		comment1.FromId.Should()
			.Be(94278436);

		comment1.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384867372));

		comment1.Text.Should()
			.Be("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!");

		comment1.Likes.Count.Should()
			.Be(77);

		comment1.Likes.UserLikes.Should()
			.BeFalse();

		comment1.Likes.CanLike.Should()
			.BeTrue();
	}

	[Fact]
	public void GetComments_WithoutLikes()
	{
		Url = "https://api.vk.com/method/video.getComments";

		ReadCategoryJsonPath(nameof(GetComments_WithoutLikes));

		var comments = Api.Video.GetComments(new()
		{
			VideoId = 166481021,
			OwnerId = 1,
			NeedLikes = false,
			Count = 2,
			Offset = 3,
			Sort = CommentsSort.Asc
		});

		comments.Should()
			.NotBeNull();

		comments.Should()
			.HaveCount(2);

		var comment = comments.FirstOrDefault();

		comment.Should()
			.NotBeNull();

		comment.Id.Should()
			.Be(14715);

		comment.FromId.Should()
			.Be(24758120);

		comment.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384867361));

		comment.Text.Should()
			.Be("паша здаров!");

		var comment1 = comments.Skip(1)
			.FirstOrDefault();

		comment1.Should()
			.NotBeNull();

		comment1.Id.Should()
			.Be(14716);

		comment1.FromId.Should()
			.Be(94278436);

		comment1.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384867372));

		comment1.Text.Should()
			.Be("Я опять на странице Дурова, опять передаю привет Маме, Бабушке и своим друзьям! Дела у меня очень отлично!");
	}

	[Fact]
	public void Report_NormalCase()
	{
		Url = "https://api.vk.com/method/video.report";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.Report(166613182, ReportReason.DrugPropaganda, 1, "коммент");

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void ReportComment_NormalCase()
	{
		Url = "https://api.vk.com/method/video.reportComment";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.ReportComment(35637, 1, ReportReason.AdultMaterial);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Restore_NormalCase()
	{
		Url = "https://api.vk.com/method/video.restore";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.Restore(167593944);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void RestoreComment_NormalCase()
	{
		Url = "https://api.vk.com/method/video.restoreComment";

		ReadJsonFile(JsonPaths.True);

		var result = Api.Video.RestoreComment(35634, 1);

		result.Should()
			.BeTrue();
	}

	[Fact]
	public void Save_NormalCase()
	{
		Url = "https://api.vk.com/method/video.save";

		ReadCategoryJsonPath(nameof(Save_NormalCase));

		var video = Api.Video.Save(new()
		{
			Name = "Название из ютуба",
			Description = "Описание из ютуба",
			Wallpost = true,
			Link = "https://www.youtube.com/watch?v=lhQtzv5a408&list=PLBC36AAAE4E4E0CAA"
		});

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(1673994);

		video.OwnerId.Should()
			.Be(2346958);

		video.Title.Should()
			.Be("Название из ютуба");

		video.Description.Should()
			.Be("Описание из ютуба");

		video.AccessKey.Should()
			.Be("f2ec9f3982f05bc");

		video.UploadUrl.Should()
			.Be(new Uri(
				"http://cs6058.vk.com/upload.php?act=parse_share&hash=d5371f57b935d1b3b0c6cde1100ecb&rhash=5c623ee8b80db0d3af5078a5dfb2&mid=234695118&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3DlhQtzv5a408&api_callback=06ec8115dfc9a66eec&remotely=1&photo_server=607423&photo_server_hash=7874a144e80b8bb3c1a1eee5c9043"));
	}

	[Fact]
	public void Save_ReturnError()
	{
		ReadErrorsJsonFile(204);

		FluentActions.Invoking(() => VkErrors.IfErrorThrowException(Json))
			.Should()
			.ThrowExactly<VideoAccessDeniedException>();
	}

	[Fact]
	public void Search_NormalCase_ListOfVideos()
	{
		Url = "https://api.vk.com/method/video.search";

		ReadCategoryJsonPath(nameof(Search_NormalCase_ListOfVideos));

		// , VideoSort.Relevance, false, true, VideoFilters.Long, false, 5, 1
		var result = Api.Video.Search(new()
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

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveCount(3);

		var video = result.FirstOrDefault();

		video.Should()
			.NotBeNull();

		video.Id.Should()
			.Be(166671614);

		video.OwnerId.Should()
			.Be(-59205334);

		video.Title.Should()
			.Be("Fucking Machines Sasha Grey | Саша Грей | Саша Грэй  | Порно | Секс | Эротика | Секс машина |  Садо-мазо  | БДСМ");

		video.Duration.Should()
			.Be(1934);

		video.Description.Should()
			.Be("beauty 18+\n\n\'Качественное и эксклюзивное порно  у нас\'\n\n>>>>>>> http://vk.com/mastofmastur<<<<<<");

		video.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1384706962));

		video.Views.Should()
			.Be(11579);

		video.Comments.Should()
			.Be(12);

		video.Photo130.Should()
			.Be(new Uri("http://cs505118.vk.me/u7160710/video/s_08382000.jpg"));

		video.Photo320.Should()
			.Be(new Uri("http://cs505118.vk.me/u7160710/video/l_a02ed037.jpg"));

		video.AlbumId.Should()
			.Be(50100051);

		video.Player.Should()
			.Be(new Uri("http://vk.com/video_ext.php?oid=-59205334&id=166671614&hash=d609a7775bbb2e7d"));

		var video1 = result.Skip(1)
			.FirstOrDefault();

		video1.Should()
			.NotBeNull();

		video1.Id.Should()
			.Be(165458571);

		video1.OwnerId.Should()
			.Be(-49956637);

		video1.Title.Should()
			.Be("домашнее частное порно порно модель саша грей on-line любовь порно с сюжетом лесби порка стендап stand up клип группа");

		video1.Duration.Should()
			.Be(1139);

		video1.Description.Should()
			.Be("секс знакомства подписывайся,знакомься,общайся,тут русские шлюхи,проститутки подпишись у нас http://vk.com/tyt_sex");

		video1.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1371702618));

		video1.Views.Should()
			.Be(12817);

		video1.Comments.Should()
			.Be(5);

		video1.Photo130.Should()
			.Be(new Uri("http://cs527502.vk.me/u65226705/video/s_1d867e81.jpg"));

		video1.Photo320.Should()
			.Be(new Uri("http://cs527502.vk.me/u65226705/video/l_ba2e1aff.jpg"));

		video1.Player.Should()
			.Be(new Uri("http://vk.com/video_ext.php?oid=-49956637&id=165458571&hash=dc6995a7cc9aed92"));

		var video2 = result.Skip(2)
			.FirstOrDefault();

		video2.Should()
			.NotBeNull();

		video2.Id.Should()
			.Be(166728490);

		video2.OwnerId.Should()
			.Be(-54257090);

		video2.Title.Should()
			.Be("Саша Грей | Sasha Grey #13");

		video2.Duration.Should()
			.Be(1289);

		video2.Description.Should()
			.Be("Взято со страницы Саша Грей | Sasha Grey | 18+: http://vk.com/sashagreyphotos\nЭротика: http://vk.com/gentleerotica");

		video2.Date.Should()
			.Be(DateHelper.TimeStampToDateTime(1386961568));

		video2.Views.Should()
			.Be(8730);

		video2.Comments.Should()
			.Be(12);

		video2.Photo130.Should()
			.Be(new Uri("http://cs535107.vk.me/u146564541/video/s_2d874147.jpg"));

		video2.Photo320.Should()
			.Be(new Uri("http://cs535107.vk.me/u146564541/video/l_cb794198.jpg"));

		video2.Player.Should()
			.Be(new Uri("http://vk.com/video_ext.php?oid=-54257090&id=166728490&hash=15a0552ca76bedac"));
	}

	[Fact]
	public void AddToAlbum()
	{
		Url = "https://api.vk.com/method/video.addToAlbum";

		ReadCategoryJsonPath(nameof(AddToAlbum));

		var result = Api.Video.AddToAlbum(123, 123, null, null, 123);

		result.TotalCount.Should()
			.Be(0);

		result.Should()
			.Contain(2);
	}
}