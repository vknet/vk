using FluentAssertions;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Enum;

public class EnumsTest
{
	[Fact]
	public void PhotoSearchRadiusTest()
	{
		Utilities.EnumFrom<PhotoSearchRadius>(10)
			.Should()
			.Be(PhotoSearchRadius.Ten);

		Utilities.EnumFrom<PhotoSearchRadius>(100)
			.Should()
			.Be(PhotoSearchRadius.OneHundred);

		Utilities.EnumFrom<PhotoSearchRadius>(800)
			.Should()
			.Be(PhotoSearchRadius.EightHundred);

		Utilities.EnumFrom<PhotoSearchRadius>(6000)
			.Should()
			.Be(PhotoSearchRadius.SixThousand);

		Utilities.EnumFrom<PhotoSearchRadius>(50000)
			.Should()
			.Be(PhotoSearchRadius.FiftyThousand);
	}

	[Fact]
	public void AccessPagesTest()
	{
		Utilities.EnumFrom<AccessPages>(0)
			.Should()
			.Be(AccessPages.Leaders);

		Utilities.EnumFrom<AccessPages>(1)
			.Should()
			.Be(AccessPages.Participants);

		Utilities.EnumFrom<AccessPages>(2)
			.Should()
			.Be(AccessPages.All);
	}

	[Fact]
	public void AddFriendStatusTest()
	{
		Utilities.EnumFrom<AddFriendStatus>(0)
			.Should()
			.Be(AddFriendStatus.Unknown);

		Utilities.EnumFrom<AddFriendStatus>(1)
			.Should()
			.Be(AddFriendStatus.Sended);

		Utilities.EnumFrom<AddFriendStatus>(2)
			.Should()
			.Be(AddFriendStatus.Accepted);

		Utilities.EnumFrom<AddFriendStatus>(4)
			.Should()
			.Be(AddFriendStatus.Resubmit);
	}

	[Fact]
	public void AdminLevelTest()
	{
		Utilities.EnumFrom<AdminLevel>(1)
			.Should()
			.Be(AdminLevel.Moderator);

		Utilities.EnumFrom<AdminLevel>(2)
			.Should()
			.Be(AdminLevel.Editor);

		Utilities.EnumFrom<AdminLevel>(3)
			.Should()
			.Be(AdminLevel.Administrator);
	}

	[Fact]
	public void AttitudeTest()
	{
		Utilities.EnumFrom<Attitude>(0)
			.Should()
			.Be(Attitude.Unknown);

		Utilities.EnumFrom<Attitude>(1)
			.Should()
			.Be(Attitude.VeryNegative);

		Utilities.EnumFrom<Attitude>(2)
			.Should()
			.Be(Attitude.Negative);

		Utilities.EnumFrom<Attitude>(3)
			.Should()
			.Be(Attitude.Compromise);

		Utilities.EnumFrom<Attitude>(4)
			.Should()
			.Be(Attitude.Neutral);

		Utilities.EnumFrom<Attitude>(5)
			.Should()
			.Be(Attitude.Positive);
	}

	[Fact]
	public void AudioGenreTest()
	{
		Utilities.EnumFrom<AudioGenre>(1)
			.Should()
			.Be(AudioGenre.Rock);

		Utilities.EnumFrom<AudioGenre>(2)
			.Should()
			.Be(AudioGenre.Pop);

		Utilities.EnumFrom<AudioGenre>(3)
			.Should()
			.Be(AudioGenre.RapAndHipHop);

		Utilities.EnumFrom<AudioGenre>(4)
			.Should()
			.Be(AudioGenre.EasyListening);

		Utilities.EnumFrom<AudioGenre>(5)
			.Should()
			.Be(AudioGenre.DanceAndHouse);

		Utilities.EnumFrom<AudioGenre>(6)
			.Should()
			.Be(AudioGenre.Instrumental);

		Utilities.EnumFrom<AudioGenre>(7)
			.Should()
			.Be(AudioGenre.Metal);

		Utilities.EnumFrom<AudioGenre>(21)
			.Should()
			.Be(AudioGenre.Alternative);

		Utilities.EnumFrom<AudioGenre>(8)
			.Should()
			.Be(AudioGenre.Dubstep);

		Utilities.EnumFrom<AudioGenre>(1001)
			.Should()
			.Be(AudioGenre.JazzAndBlues);

		Utilities.EnumFrom<AudioGenre>(10)
			.Should()
			.Be(AudioGenre.DrumAndBass);

		Utilities.EnumFrom<AudioGenre>(11)
			.Should()
			.Be(AudioGenre.Trance);

		Utilities.EnumFrom<AudioGenre>(12)
			.Should()
			.Be(AudioGenre.Chanson);

		Utilities.EnumFrom<AudioGenre>(13)
			.Should()
			.Be(AudioGenre.Ethnic);

		Utilities.EnumFrom<AudioGenre>(14)
			.Should()
			.Be(AudioGenre.AcousticAndVocal);

		Utilities.EnumFrom<AudioGenre>(15)
			.Should()
			.Be(AudioGenre.Reggae);

		Utilities.EnumFrom<AudioGenre>(16)
			.Should()
			.Be(AudioGenre.Classical);

		Utilities.EnumFrom<AudioGenre>(17)
			.Should()
			.Be(AudioGenre.IndiePop);

		Utilities.EnumFrom<AudioGenre>(19)
			.Should()
			.Be(AudioGenre.Speech);

		Utilities.EnumFrom<AudioGenre>(22)
			.Should()
			.Be(AudioGenre.ElectropopAndDisco);

		Utilities.EnumFrom<AudioGenre>(18)
			.Should()
			.Be(AudioGenre.Other);
	}

	[Fact]
	public void AudioSortTest()
	{
		Utilities.EnumFrom<AudioSort>(0)
			.Should()
			.Be(AudioSort.AddedDate);

		Utilities.EnumFrom<AudioSort>(1)
			.Should()
			.Be(AudioSort.Duration);

		Utilities.EnumFrom<AudioSort>(2)
			.Should()
			.Be(AudioSort.Popularity);
	}

	[Fact]
	public void BanReasonTest()
	{
		Utilities.EnumFrom<BanReason>(0)
			.Should()
			.Be(BanReason.Other);

		Utilities.EnumFrom<BanReason>(1)
			.Should()
			.Be(BanReason.Spam);

		Utilities.EnumFrom<BanReason>(2)
			.Should()
			.Be(BanReason.VerbalAbuse);

		Utilities.EnumFrom<BanReason>(3)
			.Should()
			.Be(BanReason.StrongLanguage);

		Utilities.EnumFrom<BanReason>(4)
			.Should()
			.Be(BanReason.IrrelevantMessages);
	}

	[Fact]
	public void BirthdayVisibilityTest()
	{
		Utilities.EnumFrom<BirthdayVisibility>(0)
			.Should()
			.Be(BirthdayVisibility.Invisible);

		Utilities.EnumFrom<BirthdayVisibility>(1)
			.Should()
			.Be(BirthdayVisibility.Full);

		Utilities.EnumFrom<BirthdayVisibility>(2)
			.Should()
			.Be(BirthdayVisibility.OnlyDayAndMonth);
	}

	[Fact]
	public void ContentAccessTest()
	{
		Utilities.EnumFrom<ContentAccess>(0)
			.Should()
			.Be(ContentAccess.Off);

		Utilities.EnumFrom<ContentAccess>(1)
			.Should()
			.Be(ContentAccess.Opened);

		Utilities.EnumFrom<ContentAccess>(2)
			.Should()
			.Be(ContentAccess.Restricted);
	}

	[Fact]
	public void DeleteFriendStatusTest()
	{
		Utilities.EnumFrom<DeleteFriendStatus>(0)
			.Should()
			.Be(DeleteFriendStatus.Unknown);

		Utilities.EnumFrom<DeleteFriendStatus>(1)
			.Should()
			.Be(DeleteFriendStatus.UserIsDeleted);

		Utilities.EnumFrom<DeleteFriendStatus>(2)
			.Should()
			.Be(DeleteFriendStatus.RequestRejected);

		Utilities.EnumFrom<DeleteFriendStatus>(3)
			.Should()
			.Be(DeleteFriendStatus.RecommendationDeleted);
	}

	[Fact]
	public void DocFilterTest()
	{
		Utilities.EnumFrom<DocFilter>(1)
			.Should()
			.Be(DocFilter.Text);

		Utilities.EnumFrom<DocFilter>(2)
			.Should()
			.Be(DocFilter.Archive);

		Utilities.EnumFrom<DocFilter>(3)
			.Should()
			.Be(DocFilter.Gif);

		Utilities.EnumFrom<DocFilter>(4)
			.Should()
			.Be(DocFilter.Image);

		Utilities.EnumFrom<DocFilter>(5)
			.Should()
			.Be(DocFilter.Audio);

		Utilities.EnumFrom<DocFilter>(6)
			.Should()
			.Be(DocFilter.Video);

		Utilities.EnumFrom<DocFilter>(7)
			.Should()
			.Be(DocFilter.EBook);

		Utilities.EnumFrom<DocFilter>(8)
			.Should()
			.Be(DocFilter.Unknown);
	}

	[Fact]
	public void FriendStatusTest()
	{
		Utilities.EnumFrom<FriendStatus>(0)
			.Should()
			.Be(FriendStatus.NotFriend);

		Utilities.EnumFrom<FriendStatus>(1)
			.Should()
			.Be(FriendStatus.OutputRequest);

		Utilities.EnumFrom<FriendStatus>(2)
			.Should()
			.Be(FriendStatus.InputRequest);

		Utilities.EnumFrom<FriendStatus>(3)
			.Should()
			.Be(FriendStatus.Friend);
	}

	[Fact]
	public void GiftPrivacyTest()
	{
		Utilities.EnumFrom<GiftPrivacy>(0)
			.Should()
			.Be(GiftPrivacy.All);

		Utilities.EnumFrom<GiftPrivacy>(1)
			.Should()
			.Be(GiftPrivacy.NameAllMessageUser);

		Utilities.EnumFrom<GiftPrivacy>(2)
			.Should()
			.Be(GiftPrivacy.NameHideMessageUser);
	}

	[Fact]
	public void GroupAccessTest()
	{
		Utilities.EnumFrom<GroupAccess>(0)
			.Should()
			.Be(GroupAccess.Open);

		Utilities.EnumFrom<GroupAccess>(1)
			.Should()
			.Be(GroupAccess.Closed);

		Utilities.EnumFrom<GroupAccess>(2)
			.Should()
			.Be(GroupAccess.Private);
	}

	[Fact]
	public void GroupPublicityTest()
	{
		Utilities.EnumFrom<GroupPublicity>(0)
			.Should()
			.Be(GroupPublicity.Public);

		Utilities.EnumFrom<GroupPublicity>(1)
			.Should()
			.Be(GroupPublicity.Closed);

		Utilities.EnumFrom<GroupPublicity>(2)
			.Should()
			.Be(GroupPublicity.Private);
	}

	[Fact]
	public void GroupSortTest()
	{
		Utilities.EnumFrom<GroupSort>(0)
			.Should()
			.Be(GroupSort.Normal);

		Utilities.EnumFrom<GroupSort>(1)
			.Should()
			.Be(GroupSort.Growth);

		Utilities.EnumFrom<GroupSort>(2)
			.Should()
			.Be(GroupSort.Relation);

		Utilities.EnumFrom<GroupSort>(3)
			.Should()
			.Be(GroupSort.Likes);

		Utilities.EnumFrom<GroupSort>(4)
			.Should()
			.Be(GroupSort.Comments);

		Utilities.EnumFrom<GroupSort>(5)
			.Should()
			.Be(GroupSort.Records);
	}

	[Fact]
	public void GroupSubjectsTest()
	{
		Utilities.EnumFrom<GroupSubjects>(1)
			.Should()
			.Be(GroupSubjects.AutoMoto);

		Utilities.EnumFrom<GroupSubjects>(2)
			.Should()
			.Be(GroupSubjects.Leisure);

		Utilities.EnumFrom<GroupSubjects>(3)
			.Should()
			.Be(GroupSubjects.Business);

		Utilities.EnumFrom<GroupSubjects>(4)
			.Should()
			.Be(GroupSubjects.DomesticAnimals);

		Utilities.EnumFrom<GroupSubjects>(5)
			.Should()
			.Be(GroupSubjects.Health);

		Utilities.EnumFrom<GroupSubjects>(6)
			.Should()
			.Be(GroupSubjects.MeetAndChat);

		Utilities.EnumFrom<GroupSubjects>(7)
			.Should()
			.Be(GroupSubjects.Games);

		Utilities.EnumFrom<GroupSubjects>(8)
			.Should()
			.Be(GroupSubjects.It);

		Utilities.EnumFrom<GroupSubjects>(9)
			.Should()
			.Be(GroupSubjects.Cinema);

		Utilities.EnumFrom<GroupSubjects>(10)
			.Should()
			.Be(GroupSubjects.BeautyAndFashion);

		Utilities.EnumFrom<GroupSubjects>(11)
			.Should()
			.Be(GroupSubjects.Cookery);

		Utilities.EnumFrom<GroupSubjects>(12)
			.Should()
			.Be(GroupSubjects.CultureAndArt);

		Utilities.EnumFrom<GroupSubjects>(13)
			.Should()
			.Be(GroupSubjects.References);

		Utilities.EnumFrom<GroupSubjects>(14)
			.Should()
			.Be(GroupSubjects.MobileTelephonyAndInternet);

		Utilities.EnumFrom<GroupSubjects>(15)
			.Should()
			.Be(GroupSubjects.Music);

		Utilities.EnumFrom<GroupSubjects>(16)
			.Should()
			.Be(GroupSubjects.ScienceAndTechnology);

		Utilities.EnumFrom<GroupSubjects>(17)
			.Should()
			.Be(GroupSubjects.RealEstate);

		Utilities.EnumFrom<GroupSubjects>(18)
			.Should()
			.Be(GroupSubjects.NewsAndMedia);

		Utilities.EnumFrom<GroupSubjects>(19)
			.Should()
			.Be(GroupSubjects.Security);

		Utilities.EnumFrom<GroupSubjects>(20)
			.Should()
			.Be(GroupSubjects.Forming);

		Utilities.EnumFrom<GroupSubjects>(21)
			.Should()
			.Be(GroupSubjects.ConstructionAndRepair);

		Utilities.EnumFrom<GroupSubjects>(22)
			.Should()
			.Be(GroupSubjects.Policy);

		Utilities.EnumFrom<GroupSubjects>(23)
			.Should()
			.Be(GroupSubjects.FoodItems);

		Utilities.EnumFrom<GroupSubjects>(24)
			.Should()
			.Be(GroupSubjects.Industry);

		Utilities.EnumFrom<GroupSubjects>(25)
			.Should()
			.Be(GroupSubjects.Travels);

		Utilities.EnumFrom<GroupSubjects>(26)
			.Should()
			.Be(GroupSubjects.Job);

		Utilities.EnumFrom<GroupSubjects>(27)
			.Should()
			.Be(GroupSubjects.Entertainment);

		Utilities.EnumFrom<GroupSubjects>(28)
			.Should()
			.Be(GroupSubjects.Religion);

		Utilities.EnumFrom<GroupSubjects>(29)
			.Should()
			.Be(GroupSubjects.HomeAndFamily);

		Utilities.EnumFrom<GroupSubjects>(30)
			.Should()
			.Be(GroupSubjects.Sports);

		Utilities.EnumFrom<GroupSubjects>(31)
			.Should()
			.Be(GroupSubjects.Coverage);

		Utilities.EnumFrom<GroupSubjects>(32)
			.Should()
			.Be(GroupSubjects.Tv);

		Utilities.EnumFrom<GroupSubjects>(33)
			.Should()
			.Be(GroupSubjects.GoodsAndServices);

		Utilities.EnumFrom<GroupSubjects>(34)
			.Should()
			.Be(GroupSubjects.InterestsAndHobbies);

		Utilities.EnumFrom<GroupSubjects>(35)
			.Should()
			.Be(GroupSubjects.Finances);

		Utilities.EnumFrom<GroupSubjects>(36)
			.Should()
			.Be(GroupSubjects.Photography);

		Utilities.EnumFrom<GroupSubjects>(37)
			.Should()
			.Be(GroupSubjects.Esoterics);

		Utilities.EnumFrom<GroupSubjects>(38)
			.Should()
			.Be(GroupSubjects.ElectronicsAndAppliances);

		Utilities.EnumFrom<GroupSubjects>(39)
			.Should()
			.Be(GroupSubjects.Erotica);

		Utilities.EnumFrom<GroupSubjects>(40)
			.Should()
			.Be(GroupSubjects.Humor);

		Utilities.EnumFrom<GroupSubjects>(41)
			.Should()
			.Be(GroupSubjects.SocietyHumanities);

		Utilities.EnumFrom<GroupSubjects>(42)
			.Should()
			.Be(GroupSubjects.DesignAndGraphics);
	}

	[Fact]
	public void GroupSubTypeTest()
	{
		Utilities.EnumFrom<GroupSubType>(1)
			.Should()
			.Be(GroupSubType.PlaceOrSmallCompany);

		Utilities.EnumFrom<GroupSubType>(2)
			.Should()
			.Be(GroupSubType.OrganizationOrWebsite);

		Utilities.EnumFrom<GroupSubType>(3)
			.Should()
			.Be(GroupSubType.PersonOrTeam);

		Utilities.EnumFrom<GroupSubType>(4)
			.Should()
			.Be(GroupSubType.ProductOrProducts);
	}

	[Fact]
	public void Iso3166Test()
	{
		Utilities.EnumFrom<Iso3166>(0)
			.Should()
			.Be(Iso3166.AU);

		Utilities.EnumFrom<Iso3166>(1)
			.Should()
			.Be(Iso3166.AT);

		Utilities.EnumFrom<Iso3166>(2)
			.Should()
			.Be(Iso3166.AZ);

		Utilities.EnumFrom<Iso3166>(3)
			.Should()
			.Be(Iso3166.AX);

		Utilities.EnumFrom<Iso3166>(4)
			.Should()
			.Be(Iso3166.AL);

		Utilities.EnumFrom<Iso3166>(5)
			.Should()
			.Be(Iso3166.DZ);

		Utilities.EnumFrom<Iso3166>(6)
			.Should()
			.Be(Iso3166.UM);

		Utilities.EnumFrom<Iso3166>(7)
			.Should()
			.Be(Iso3166.VI);

		Utilities.EnumFrom<Iso3166>(8)
			.Should()
			.Be(Iso3166.AS);

		Utilities.EnumFrom<Iso3166>(9)
			.Should()
			.Be(Iso3166.AI);

		Utilities.EnumFrom<Iso3166>(10)
			.Should()
			.Be(Iso3166.AO);

		Utilities.EnumFrom<Iso3166>(11)
			.Should()
			.Be(Iso3166.AD);

		Utilities.EnumFrom<Iso3166>(12)
			.Should()
			.Be(Iso3166.AQ);

		Utilities.EnumFrom<Iso3166>(13)
			.Should()
			.Be(Iso3166.AG);

		Utilities.EnumFrom<Iso3166>(14)
			.Should()
			.Be(Iso3166.AR);

		Utilities.EnumFrom<Iso3166>(15)
			.Should()
			.Be(Iso3166.AM);

		Utilities.EnumFrom<Iso3166>(16)
			.Should()
			.Be(Iso3166.AW);

		Utilities.EnumFrom<Iso3166>(17)
			.Should()
			.Be(Iso3166.AF);

		Utilities.EnumFrom<Iso3166>(18)
			.Should()
			.Be(Iso3166.BS);

		Utilities.EnumFrom<Iso3166>(19)
			.Should()
			.Be(Iso3166.BD);

		Utilities.EnumFrom<Iso3166>(20)
			.Should()
			.Be(Iso3166.BB);

		Utilities.EnumFrom<Iso3166>(21)
			.Should()
			.Be(Iso3166.BH);

		Utilities.EnumFrom<Iso3166>(22)
			.Should()
			.Be(Iso3166.BZ);

		Utilities.EnumFrom<Iso3166>(23)
			.Should()
			.Be(Iso3166.BY);

		Utilities.EnumFrom<Iso3166>(24)
			.Should()
			.Be(Iso3166.BE);

		Utilities.EnumFrom<Iso3166>(25)
			.Should()
			.Be(Iso3166.BJ);

		Utilities.EnumFrom<Iso3166>(26)
			.Should()
			.Be(Iso3166.BM);

		Utilities.EnumFrom<Iso3166>(27)
			.Should()
			.Be(Iso3166.BG);

		Utilities.EnumFrom<Iso3166>(28)
			.Should()
			.Be(Iso3166.BO);

		Utilities.EnumFrom<Iso3166>(29)
			.Should()
			.Be(Iso3166.BA);

		Utilities.EnumFrom<Iso3166>(30)
			.Should()
			.Be(Iso3166.BW);

		Utilities.EnumFrom<Iso3166>(31)
			.Should()
			.Be(Iso3166.BR);

		Utilities.EnumFrom<Iso3166>(32)
			.Should()
			.Be(Iso3166.IO);

		Utilities.EnumFrom<Iso3166>(33)
			.Should()
			.Be(Iso3166.VG);

		Utilities.EnumFrom<Iso3166>(34)
			.Should()
			.Be(Iso3166.BN);

		Utilities.EnumFrom<Iso3166>(35)
			.Should()
			.Be(Iso3166.BF);

		Utilities.EnumFrom<Iso3166>(36)
			.Should()
			.Be(Iso3166.BI);

		Utilities.EnumFrom<Iso3166>(37)
			.Should()
			.Be(Iso3166.BT);

		Utilities.EnumFrom<Iso3166>(38)
			.Should()
			.Be(Iso3166.VU);

		Utilities.EnumFrom<Iso3166>(39)
			.Should()
			.Be(Iso3166.VA);

		Utilities.EnumFrom<Iso3166>(40)
			.Should()
			.Be(Iso3166.GB);

		Utilities.EnumFrom<Iso3166>(41)
			.Should()
			.Be(Iso3166.HU);

		Utilities.EnumFrom<Iso3166>(42)
			.Should()
			.Be(Iso3166.VE);

		Utilities.EnumFrom<Iso3166>(43)
			.Should()
			.Be(Iso3166.TL);

		Utilities.EnumFrom<Iso3166>(44)
			.Should()
			.Be(Iso3166.VN);

		Utilities.EnumFrom<Iso3166>(45)
			.Should()
			.Be(Iso3166.GA);

		Utilities.EnumFrom<Iso3166>(46)
			.Should()
			.Be(Iso3166.HT);

		Utilities.EnumFrom<Iso3166>(47)
			.Should()
			.Be(Iso3166.GY);

		Utilities.EnumFrom<Iso3166>(48)
			.Should()
			.Be(Iso3166.GM);

		Utilities.EnumFrom<Iso3166>(49)
			.Should()
			.Be(Iso3166.GH);

		Utilities.EnumFrom<Iso3166>(50)
			.Should()
			.Be(Iso3166.GP);

		Utilities.EnumFrom<Iso3166>(51)
			.Should()
			.Be(Iso3166.GT);

		Utilities.EnumFrom<Iso3166>(52)
			.Should()
			.Be(Iso3166.GN);

		Utilities.EnumFrom<Iso3166>(53)
			.Should()
			.Be(Iso3166.GW);

		Utilities.EnumFrom<Iso3166>(54)
			.Should()
			.Be(Iso3166.DE);

		Utilities.EnumFrom<Iso3166>(55)
			.Should()
			.Be(Iso3166.GI);

		Utilities.EnumFrom<Iso3166>(56)
			.Should()
			.Be(Iso3166.HN);

		Utilities.EnumFrom<Iso3166>(57)
			.Should()
			.Be(Iso3166.HK);

		Utilities.EnumFrom<Iso3166>(58)
			.Should()
			.Be(Iso3166.GD);

		Utilities.EnumFrom<Iso3166>(59)
			.Should()
			.Be(Iso3166.GL);

		Utilities.EnumFrom<Iso3166>(60)
			.Should()
			.Be(Iso3166.GR);

		Utilities.EnumFrom<Iso3166>(61)
			.Should()
			.Be(Iso3166.GE);

		Utilities.EnumFrom<Iso3166>(62)
			.Should()
			.Be(Iso3166.GU);

		Utilities.EnumFrom<Iso3166>(63)
			.Should()
			.Be(Iso3166.DK);

		Utilities.EnumFrom<Iso3166>(64)
			.Should()
			.Be(Iso3166.CD);

		Utilities.EnumFrom<Iso3166>(65)
			.Should()
			.Be(Iso3166.DJ);

		Utilities.EnumFrom<Iso3166>(66)
			.Should()
			.Be(Iso3166.DM);

		Utilities.EnumFrom<Iso3166>(67)
			.Should()
			.Be(Iso3166.DO);

		Utilities.EnumFrom<Iso3166>(68)
			.Should()
			.Be(Iso3166.EU);

		Utilities.EnumFrom<Iso3166>(69)
			.Should()
			.Be(Iso3166.EG);

		Utilities.EnumFrom<Iso3166>(70)
			.Should()
			.Be(Iso3166.ZM);

		Utilities.EnumFrom<Iso3166>(71)
			.Should()
			.Be(Iso3166.EH);

		Utilities.EnumFrom<Iso3166>(72)
			.Should()
			.Be(Iso3166.ZW);

		Utilities.EnumFrom<Iso3166>(73)
			.Should()
			.Be(Iso3166.IL);

		Utilities.EnumFrom<Iso3166>(74)
			.Should()
			.Be(Iso3166.IN);

		Utilities.EnumFrom<Iso3166>(75)
			.Should()
			.Be(Iso3166.ID);

		Utilities.EnumFrom<Iso3166>(76)
			.Should()
			.Be(Iso3166.JO);

		Utilities.EnumFrom<Iso3166>(77)
			.Should()
			.Be(Iso3166.IQ);

		Utilities.EnumFrom<Iso3166>(78)
			.Should()
			.Be(Iso3166.IR);

		Utilities.EnumFrom<Iso3166>(79)
			.Should()
			.Be(Iso3166.IE);

		Utilities.EnumFrom<Iso3166>(80)
			.Should()
			.Be(Iso3166.IS);

		Utilities.EnumFrom<Iso3166>(81)
			.Should()
			.Be(Iso3166.ES);

		Utilities.EnumFrom<Iso3166>(82)
			.Should()
			.Be(Iso3166.IT);

		Utilities.EnumFrom<Iso3166>(83)
			.Should()
			.Be(Iso3166.YE);

		Utilities.EnumFrom<Iso3166>(84)
			.Should()
			.Be(Iso3166.KP);

		Utilities.EnumFrom<Iso3166>(85)
			.Should()
			.Be(Iso3166.CV);

		Utilities.EnumFrom<Iso3166>(86)
			.Should()
			.Be(Iso3166.KZ);

		Utilities.EnumFrom<Iso3166>(87)
			.Should()
			.Be(Iso3166.KY);

		Utilities.EnumFrom<Iso3166>(88)
			.Should()
			.Be(Iso3166.KH);

		Utilities.EnumFrom<Iso3166>(89)
			.Should()
			.Be(Iso3166.CM);

		Utilities.EnumFrom<Iso3166>(90)
			.Should()
			.Be(Iso3166.CA);

		Utilities.EnumFrom<Iso3166>(91)
			.Should()
			.Be(Iso3166.QA);

		Utilities.EnumFrom<Iso3166>(92)
			.Should()
			.Be(Iso3166.KE);

		Utilities.EnumFrom<Iso3166>(93)
			.Should()
			.Be(Iso3166.CY);

		Utilities.EnumFrom<Iso3166>(94)
			.Should()
			.Be(Iso3166.KG);

		Utilities.EnumFrom<Iso3166>(95)
			.Should()
			.Be(Iso3166.KI);

		Utilities.EnumFrom<Iso3166>(96)
			.Should()
			.Be(Iso3166.CN);

		Utilities.EnumFrom<Iso3166>(97)
			.Should()
			.Be(Iso3166.CC);

		Utilities.EnumFrom<Iso3166>(98)
			.Should()
			.Be(Iso3166.CO);

		Utilities.EnumFrom<Iso3166>(99)
			.Should()
			.Be(Iso3166.KM);

		Utilities.EnumFrom<Iso3166>(100)
			.Should()
			.Be(Iso3166.CR);

		Utilities.EnumFrom<Iso3166>(101)
			.Should()
			.Be(Iso3166.CI);

		Utilities.EnumFrom<Iso3166>(102)
			.Should()
			.Be(Iso3166.CU);

		Utilities.EnumFrom<Iso3166>(103)
			.Should()
			.Be(Iso3166.KW);

		Utilities.EnumFrom<Iso3166>(104)
			.Should()
			.Be(Iso3166.LA);

		Utilities.EnumFrom<Iso3166>(105)
			.Should()
			.Be(Iso3166.LV);

		Utilities.EnumFrom<Iso3166>(106)
			.Should()
			.Be(Iso3166.LS);

		Utilities.EnumFrom<Iso3166>(107)
			.Should()
			.Be(Iso3166.LR);

		Utilities.EnumFrom<Iso3166>(108)
			.Should()
			.Be(Iso3166.LB);

		Utilities.EnumFrom<Iso3166>(109)
			.Should()
			.Be(Iso3166.LY);

		Utilities.EnumFrom<Iso3166>(110)
			.Should()
			.Be(Iso3166.LT);

		Utilities.EnumFrom<Iso3166>(111)
			.Should()
			.Be(Iso3166.LI);

		Utilities.EnumFrom<Iso3166>(112)
			.Should()
			.Be(Iso3166.LU);

		Utilities.EnumFrom<Iso3166>(113)
			.Should()
			.Be(Iso3166.MU);

		Utilities.EnumFrom<Iso3166>(114)
			.Should()
			.Be(Iso3166.MR);

		Utilities.EnumFrom<Iso3166>(115)
			.Should()
			.Be(Iso3166.MG);

		Utilities.EnumFrom<Iso3166>(116)
			.Should()
			.Be(Iso3166.YT);

		Utilities.EnumFrom<Iso3166>(117)
			.Should()
			.Be(Iso3166.MO);

		Utilities.EnumFrom<Iso3166>(118)
			.Should()
			.Be(Iso3166.MK);

		Utilities.EnumFrom<Iso3166>(119)
			.Should()
			.Be(Iso3166.MW);

		Utilities.EnumFrom<Iso3166>(120)
			.Should()
			.Be(Iso3166.MY);

		Utilities.EnumFrom<Iso3166>(121)
			.Should()
			.Be(Iso3166.ML);

		Utilities.EnumFrom<Iso3166>(122)
			.Should()
			.Be(Iso3166.MV);

		Utilities.EnumFrom<Iso3166>(123)
			.Should()
			.Be(Iso3166.MT);

		Utilities.EnumFrom<Iso3166>(124)
			.Should()
			.Be(Iso3166.MA);

		Utilities.EnumFrom<Iso3166>(125)
			.Should()
			.Be(Iso3166.MQ);

		Utilities.EnumFrom<Iso3166>(126)
			.Should()
			.Be(Iso3166.MH);

		Utilities.EnumFrom<Iso3166>(127)
			.Should()
			.Be(Iso3166.MX);

		Utilities.EnumFrom<Iso3166>(128)
			.Should()
			.Be(Iso3166.MZ);

		Utilities.EnumFrom<Iso3166>(129)
			.Should()
			.Be(Iso3166.MD);

		Utilities.EnumFrom<Iso3166>(130)
			.Should()
			.Be(Iso3166.MC);

		Utilities.EnumFrom<Iso3166>(131)
			.Should()
			.Be(Iso3166.MN);

		Utilities.EnumFrom<Iso3166>(132)
			.Should()
			.Be(Iso3166.MS);

		Utilities.EnumFrom<Iso3166>(133)
			.Should()
			.Be(Iso3166.MM);

		Utilities.EnumFrom<Iso3166>(134)
			.Should()
			.Be(Iso3166.NA);

		Utilities.EnumFrom<Iso3166>(135)
			.Should()
			.Be(Iso3166.NR);

		Utilities.EnumFrom<Iso3166>(136)
			.Should()
			.Be(Iso3166.NP);

		Utilities.EnumFrom<Iso3166>(137)
			.Should()
			.Be(Iso3166.NE);

		Utilities.EnumFrom<Iso3166>(138)
			.Should()
			.Be(Iso3166.NG);

		Utilities.EnumFrom<Iso3166>(139)
			.Should()
			.Be(Iso3166.AN);

		Utilities.EnumFrom<Iso3166>(140)
			.Should()
			.Be(Iso3166.NL);

		Utilities.EnumFrom<Iso3166>(141)
			.Should()
			.Be(Iso3166.NI);

		Utilities.EnumFrom<Iso3166>(142)
			.Should()
			.Be(Iso3166.NU);

		Utilities.EnumFrom<Iso3166>(143)
			.Should()
			.Be(Iso3166.NC);

		Utilities.EnumFrom<Iso3166>(144)
			.Should()
			.Be(Iso3166.NZ);

		Utilities.EnumFrom<Iso3166>(145)
			.Should()
			.Be(Iso3166.NO);

		Utilities.EnumFrom<Iso3166>(146)
			.Should()
			.Be(Iso3166.AE);

		Utilities.EnumFrom<Iso3166>(147)
			.Should()
			.Be(Iso3166.OM);

		Utilities.EnumFrom<Iso3166>(148)
			.Should()
			.Be(Iso3166.CX);

		Utilities.EnumFrom<Iso3166>(149)
			.Should()
			.Be(Iso3166.CK);

		Utilities.EnumFrom<Iso3166>(150)
			.Should()
			.Be(Iso3166.HM);

		Utilities.EnumFrom<Iso3166>(151)
			.Should()
			.Be(Iso3166.PK);

		Utilities.EnumFrom<Iso3166>(152)
			.Should()
			.Be(Iso3166.PW);

		Utilities.EnumFrom<Iso3166>(153)
			.Should()
			.Be(Iso3166.PS);

		Utilities.EnumFrom<Iso3166>(154)
			.Should()
			.Be(Iso3166.PA);

		Utilities.EnumFrom<Iso3166>(155)
			.Should()
			.Be(Iso3166.PG);

		Utilities.EnumFrom<Iso3166>(156)
			.Should()
			.Be(Iso3166.PY);

		Utilities.EnumFrom<Iso3166>(157)
			.Should()
			.Be(Iso3166.PE);

		Utilities.EnumFrom<Iso3166>(158)
			.Should()
			.Be(Iso3166.PN);

		Utilities.EnumFrom<Iso3166>(159)
			.Should()
			.Be(Iso3166.PL);

		Utilities.EnumFrom<Iso3166>(160)
			.Should()
			.Be(Iso3166.PT);

		Utilities.EnumFrom<Iso3166>(161)
			.Should()
			.Be(Iso3166.PR);

		Utilities.EnumFrom<Iso3166>(162)
			.Should()
			.Be(Iso3166.CG);

		Utilities.EnumFrom<Iso3166>(163)
			.Should()
			.Be(Iso3166.RE);

		Utilities.EnumFrom<Iso3166>(164)
			.Should()
			.Be(Iso3166.RU);

		Utilities.EnumFrom<Iso3166>(165)
			.Should()
			.Be(Iso3166.RW);

		Utilities.EnumFrom<Iso3166>(166)
			.Should()
			.Be(Iso3166.RO);

		Utilities.EnumFrom<Iso3166>(167)
			.Should()
			.Be(Iso3166.US);

		Utilities.EnumFrom<Iso3166>(168)
			.Should()
			.Be(Iso3166.SV);

		Utilities.EnumFrom<Iso3166>(169)
			.Should()
			.Be(Iso3166.WS);

		Utilities.EnumFrom<Iso3166>(170)
			.Should()
			.Be(Iso3166.SM);

		Utilities.EnumFrom<Iso3166>(171)
			.Should()
			.Be(Iso3166.ST);

		Utilities.EnumFrom<Iso3166>(172)
			.Should()
			.Be(Iso3166.SA);

		Utilities.EnumFrom<Iso3166>(173)
			.Should()
			.Be(Iso3166.SZ);

		Utilities.EnumFrom<Iso3166>(174)
			.Should()
			.Be(Iso3166.SJ);

		Utilities.EnumFrom<Iso3166>(175)
			.Should()
			.Be(Iso3166.MP);

		Utilities.EnumFrom<Iso3166>(176)
			.Should()
			.Be(Iso3166.SC);

		Utilities.EnumFrom<Iso3166>(177)
			.Should()
			.Be(Iso3166.SN);

		Utilities.EnumFrom<Iso3166>(178)
			.Should()
			.Be(Iso3166.VC);

		Utilities.EnumFrom<Iso3166>(179)
			.Should()
			.Be(Iso3166.KN);

		Utilities.EnumFrom<Iso3166>(180)
			.Should()
			.Be(Iso3166.LC);

		Utilities.EnumFrom<Iso3166>(181)
			.Should()
			.Be(Iso3166.PM);

		Utilities.EnumFrom<Iso3166>(182)
			.Should()
			.Be(Iso3166.RS);

		Utilities.EnumFrom<Iso3166>(183)
			.Should()
			.Be(Iso3166.CS);

		Utilities.EnumFrom<Iso3166>(184)
			.Should()
			.Be(Iso3166.SG);

		Utilities.EnumFrom<Iso3166>(185)
			.Should()
			.Be(Iso3166.SY);

		Utilities.EnumFrom<Iso3166>(186)
			.Should()
			.Be(Iso3166.SK);

		Utilities.EnumFrom<Iso3166>(187)
			.Should()
			.Be(Iso3166.SI);

		Utilities.EnumFrom<Iso3166>(188)
			.Should()
			.Be(Iso3166.SB);

		Utilities.EnumFrom<Iso3166>(189)
			.Should()
			.Be(Iso3166.SO);

		Utilities.EnumFrom<Iso3166>(190)
			.Should()
			.Be(Iso3166.SD);

		Utilities.EnumFrom<Iso3166>(191)
			.Should()
			.Be(Iso3166.SR);

		Utilities.EnumFrom<Iso3166>(192)
			.Should()
			.Be(Iso3166.SL);

		Utilities.EnumFrom<Iso3166>(193)
			.Should()
			.Be(Iso3166.SU);

		Utilities.EnumFrom<Iso3166>(194)
			.Should()
			.Be(Iso3166.TJ);

		Utilities.EnumFrom<Iso3166>(195)
			.Should()
			.Be(Iso3166.TH);

		Utilities.EnumFrom<Iso3166>(196)
			.Should()
			.Be(Iso3166.TW);

		Utilities.EnumFrom<Iso3166>(197)
			.Should()
			.Be(Iso3166.TZ);

		Utilities.EnumFrom<Iso3166>(198)
			.Should()
			.Be(Iso3166.TG);

		Utilities.EnumFrom<Iso3166>(199)
			.Should()
			.Be(Iso3166.TK);

		Utilities.EnumFrom<Iso3166>(200)
			.Should()
			.Be(Iso3166.TO);

		Utilities.EnumFrom<Iso3166>(201)
			.Should()
			.Be(Iso3166.TT);

		Utilities.EnumFrom<Iso3166>(202)
			.Should()
			.Be(Iso3166.TV);

		Utilities.EnumFrom<Iso3166>(203)
			.Should()
			.Be(Iso3166.TN);

		Utilities.EnumFrom<Iso3166>(204)
			.Should()
			.Be(Iso3166.TM);

		Utilities.EnumFrom<Iso3166>(205)
			.Should()
			.Be(Iso3166.TR);

		Utilities.EnumFrom<Iso3166>(206)
			.Should()
			.Be(Iso3166.UG);

		Utilities.EnumFrom<Iso3166>(207)
			.Should()
			.Be(Iso3166.UZ);

		Utilities.EnumFrom<Iso3166>(208)
			.Should()
			.Be(Iso3166.UA);

		Utilities.EnumFrom<Iso3166>(209)
			.Should()
			.Be(Iso3166.UY);

		Utilities.EnumFrom<Iso3166>(210)
			.Should()
			.Be(Iso3166.FO);

		Utilities.EnumFrom<Iso3166>(211)
			.Should()
			.Be(Iso3166.FM);

		Utilities.EnumFrom<Iso3166>(212)
			.Should()
			.Be(Iso3166.FJ);

		Utilities.EnumFrom<Iso3166>(213)
			.Should()
			.Be(Iso3166.PH);

		Utilities.EnumFrom<Iso3166>(214)
			.Should()
			.Be(Iso3166.FI);

		Utilities.EnumFrom<Iso3166>(215)
			.Should()
			.Be(Iso3166.FK);

		Utilities.EnumFrom<Iso3166>(216)
			.Should()
			.Be(Iso3166.FR);

		Utilities.EnumFrom<Iso3166>(217)
			.Should()
			.Be(Iso3166.GF);

		Utilities.EnumFrom<Iso3166>(218)
			.Should()
			.Be(Iso3166.PF);

		Utilities.EnumFrom<Iso3166>(219)
			.Should()
			.Be(Iso3166.TF);

		Utilities.EnumFrom<Iso3166>(220)
			.Should()
			.Be(Iso3166.HR);

		Utilities.EnumFrom<Iso3166>(221)
			.Should()
			.Be(Iso3166.CF);

		Utilities.EnumFrom<Iso3166>(222)
			.Should()
			.Be(Iso3166.TD);

		Utilities.EnumFrom<Iso3166>(223)
			.Should()
			.Be(Iso3166.ME);

		Utilities.EnumFrom<Iso3166>(224)
			.Should()
			.Be(Iso3166.CZ);

		Utilities.EnumFrom<Iso3166>(225)
			.Should()
			.Be(Iso3166.CL);

		Utilities.EnumFrom<Iso3166>(226)
			.Should()
			.Be(Iso3166.CH);

		Utilities.EnumFrom<Iso3166>(227)
			.Should()
			.Be(Iso3166.SE);

		Utilities.EnumFrom<Iso3166>(228)
			.Should()
			.Be(Iso3166.LK);

		Utilities.EnumFrom<Iso3166>(229)
			.Should()
			.Be(Iso3166.EC);

		Utilities.EnumFrom<Iso3166>(230)
			.Should()
			.Be(Iso3166.GQ);

		Utilities.EnumFrom<Iso3166>(231)
			.Should()
			.Be(Iso3166.ER);

		Utilities.EnumFrom<Iso3166>(232)
			.Should()
			.Be(Iso3166.EE);

		Utilities.EnumFrom<Iso3166>(233)
			.Should()
			.Be(Iso3166.ET);

		Utilities.EnumFrom<Iso3166>(234)
			.Should()
			.Be(Iso3166.ZA);

		Utilities.EnumFrom<Iso3166>(235)
			.Should()
			.Be(Iso3166.KR);

		Utilities.EnumFrom<Iso3166>(236)
			.Should()
			.Be(Iso3166.GS);

		Utilities.EnumFrom<Iso3166>(237)
			.Should()
			.Be(Iso3166.JM);

		Utilities.EnumFrom<Iso3166>(238)
			.Should()
			.Be(Iso3166.JP);

		Utilities.EnumFrom<Iso3166>(239)
			.Should()
			.Be(Iso3166.BV);

		Utilities.EnumFrom<Iso3166>(240)
			.Should()
			.Be(Iso3166.NF);

		Utilities.EnumFrom<Iso3166>(241)
			.Should()
			.Be(Iso3166.SH);

		Utilities.EnumFrom<Iso3166>(242)
			.Should()
			.Be(Iso3166.TC);

		Utilities.EnumFrom<Iso3166>(243)
			.Should()
			.Be(Iso3166.WF);
	}

	[Fact]
	public void LeaderboardTypesTest()
	{
		Utilities.EnumFrom<LeaderboardTypes>(0)
			.Should()
			.Be(LeaderboardTypes.NotSupported);

		Utilities.EnumFrom<LeaderboardTypes>(1)
			.Should()
			.Be(LeaderboardTypes.ByLevel);

		Utilities.EnumFrom<LeaderboardTypes>(2)
			.Should()
			.Be(LeaderboardTypes.ByPoints);
	}

	[Fact]
	public void LifeMainTest()
	{
		Utilities.EnumFrom<LifeMain>(0)
			.Should()
			.Be(LifeMain.Unknown);

		Utilities.EnumFrom<LifeMain>(1)
			.Should()
			.Be(LifeMain.FamilyAndChildren);

		Utilities.EnumFrom<LifeMain>(2)
			.Should()
			.Be(LifeMain.CareerAndMoney);

		Utilities.EnumFrom<LifeMain>(3)
			.Should()
			.Be(LifeMain.Activities);

		Utilities.EnumFrom<LifeMain>(4)
			.Should()
			.Be(LifeMain.ScienceAndResearch);

		Utilities.EnumFrom<LifeMain>(5)
			.Should()
			.Be(LifeMain.ImprovingTheWorld);

		Utilities.EnumFrom<LifeMain>(6)
			.Should()
			.Be(LifeMain.SelfDevelopment);

		Utilities.EnumFrom<LifeMain>(7)
			.Should()
			.Be(LifeMain.BeautyAndArt);

		Utilities.EnumFrom<LifeMain>(8)
			.Should()
			.Be(LifeMain.FameAndInfluence);
	}

	[Fact]
	public void MainSectionTest()
	{
		Utilities.EnumFrom<MainSection>(0)
			.Should()
			.Be(MainSection.NoSection);

		Utilities.EnumFrom<MainSection>(1)
			.Should()
			.Be(MainSection.Photo);

		Utilities.EnumFrom<MainSection>(2)
			.Should()
			.Be(MainSection.Post);

		Utilities.EnumFrom<MainSection>(3)
			.Should()
			.Be(MainSection.Audio);

		Utilities.EnumFrom<MainSection>(4)
			.Should()
			.Be(MainSection.Video);

		Utilities.EnumFrom<MainSection>(5)
			.Should()
			.Be(MainSection.Goods);
	}

	[Fact]
	public void MaritalStatusTest()
	{
		Utilities.EnumFrom<MaritalStatus>(1)
			.Should()
			.Be(MaritalStatus.Single);

		Utilities.EnumFrom<MaritalStatus>(2)
			.Should()
			.Be(MaritalStatus.Meets);

		Utilities.EnumFrom<MaritalStatus>(3)
			.Should()
			.Be(MaritalStatus.Engaged);

		Utilities.EnumFrom<MaritalStatus>(4)
			.Should()
			.Be(MaritalStatus.Married);

		Utilities.EnumFrom<MaritalStatus>(5)
			.Should()
			.Be(MaritalStatus.ItsComplicated);

		Utilities.EnumFrom<MaritalStatus>(6)
			.Should()
			.Be(MaritalStatus.TheActiveSearch);

		Utilities.EnumFrom<MaritalStatus>(7)
			.Should()
			.Be(MaritalStatus.InLove);
	}

	[Fact]
	public void MarketCurrencyIdTest()
	{
		Utilities.EnumFrom<MarketCurrencyId>(643)
			.Should()
			.Be(MarketCurrencyId.Rub);

		Utilities.EnumFrom<MarketCurrencyId>(980)
			.Should()
			.Be(MarketCurrencyId.Uah);

		Utilities.EnumFrom<MarketCurrencyId>(398)
			.Should()
			.Be(MarketCurrencyId.Kzt);

		Utilities.EnumFrom<MarketCurrencyId>(978)
			.Should()
			.Be(MarketCurrencyId.Eur);

		Utilities.EnumFrom<MarketCurrencyId>(840)
			.Should()
			.Be(MarketCurrencyId.Usd);
	}

	[Fact]
	public void MessageReadStateTest()
	{
		Utilities.EnumFrom<MessageReadState>(0)
			.Should()
			.Be(MessageReadState.Unreaded);

		Utilities.EnumFrom<MessageReadState>(1)
			.Should()
			.Be(MessageReadState.Readed);
	}

	[Fact]
	public void MessagesFilterTest()
	{
		Utilities.EnumFrom<MessagesFilter>(0)
			.Should()
			.Be(MessagesFilter.All);

		Utilities.EnumFrom<MessagesFilter>(8)
			.Should()
			.Be(MessagesFilter.Important);
	}

	[Fact]
	public void MessageTypeTest()
	{
		Utilities.EnumFrom<MessageType>(0)
			.Should()
			.Be(MessageType.Received);

		Utilities.EnumFrom<MessageType>(1)
			.Should()
			.Be(MessageType.Sended);
	}

	[Fact]
	public void PageAccessKindTest()
	{
		Utilities.EnumFrom<PageAccessKind>(0)
			.Should()
			.Be(PageAccessKind.OnlyAdministrators);

		Utilities.EnumFrom<PageAccessKind>(1)
			.Should()
			.Be(PageAccessKind.OnlyMembers);

		Utilities.EnumFrom<PageAccessKind>(2)
			.Should()
			.Be(PageAccessKind.Unrestricted);
	}

	[Fact]
	public void PeopleMainTest()
	{
		Utilities.EnumFrom<PeopleMain>(0)
			.Should()
			.Be(PeopleMain.Unknown);

		Utilities.EnumFrom<PeopleMain>(1)
			.Should()
			.Be(PeopleMain.MindAndCreativity);

		Utilities.EnumFrom<PeopleMain>(2)
			.Should()
			.Be(PeopleMain.KindnessAndHonesty);

		Utilities.EnumFrom<PeopleMain>(3)
			.Should()
			.Be(PeopleMain.HealthAndBeauty);

		Utilities.EnumFrom<PeopleMain>(4)
			.Should()
			.Be(PeopleMain.PowerAndWealth);

		Utilities.EnumFrom<PeopleMain>(5)
			.Should()
			.Be(PeopleMain.CourageAndPersistence);

		Utilities.EnumFrom<PeopleMain>(6)
			.Should()
			.Be(PeopleMain.HumorAndLoveForLife);
	}

	[Fact]
	public void PoliticalPreferencesTest()
	{
		Utilities.EnumFrom<PoliticalPreferences>(0)
			.Should()
			.Be(PoliticalPreferences.Unknown);

		Utilities.EnumFrom<PoliticalPreferences>(1)
			.Should()
			.Be(PoliticalPreferences.Communist);

		Utilities.EnumFrom<PoliticalPreferences>(2)
			.Should()
			.Be(PoliticalPreferences.Socialist);

		Utilities.EnumFrom<PoliticalPreferences>(3)
			.Should()
			.Be(PoliticalPreferences.Moderate);

		Utilities.EnumFrom<PoliticalPreferences>(4)
			.Should()
			.Be(PoliticalPreferences.Liberal);

		Utilities.EnumFrom<PoliticalPreferences>(5)
			.Should()
			.Be(PoliticalPreferences.Conservative);

		Utilities.EnumFrom<PoliticalPreferences>(6)
			.Should()
			.Be(PoliticalPreferences.Monarchist);

		Utilities.EnumFrom<PoliticalPreferences>(7)
			.Should()
			.Be(PoliticalPreferences.Ultraconservative);

		Utilities.EnumFrom<PoliticalPreferences>(8)
			.Should()
			.Be(PoliticalPreferences.Apathetic);

		Utilities.EnumFrom<PoliticalPreferences>(9)
			.Should()
			.Be(PoliticalPreferences.Libertarian);
	}

	[Fact]
	public void ProductAvailabilityTest()
	{
		Utilities.EnumFrom<ProductAvailability>(0)
			.Should()
			.Be(ProductAvailability.Available);

		Utilities.EnumFrom<ProductAvailability>(1)
			.Should()
			.Be(ProductAvailability.Removed);

		Utilities.EnumFrom<ProductAvailability>(2)
			.Should()
			.Be(ProductAvailability.Unavailable);
	}

	[Fact]
	public void ProductSortTest()
	{
		Utilities.EnumFrom<ProductSort>(0)
			.Should()
			.Be(ProductSort.UserSort);

		Utilities.EnumFrom<ProductSort>(1)
			.Should()
			.Be(ProductSort.ByAdd);

		Utilities.EnumFrom<ProductSort>(2)
			.Should()
			.Be(ProductSort.ByCost);

		Utilities.EnumFrom<ProductSort>(3)
			.Should()
			.Be(ProductSort.ByPopularity);
	}

	[Fact]
	public void RelationTypeTest()
	{
		Utilities.EnumFrom<RelationType>(0)
			.Should()
			.Be(RelationType.Unknown);

		Utilities.EnumFrom<RelationType>(1)
			.Should()
			.Be(RelationType.NotMarried);

		Utilities.EnumFrom<RelationType>(2)
			.Should()
			.Be(RelationType.HasFriend);

		Utilities.EnumFrom<RelationType>(3)
			.Should()
			.Be(RelationType.Engaged);

		Utilities.EnumFrom<RelationType>(4)
			.Should()
			.Be(RelationType.Married);

		Utilities.EnumFrom<RelationType>(5)
			.Should()
			.Be(RelationType.ItsComplex);

		Utilities.EnumFrom<RelationType>(6)
			.Should()
			.Be(RelationType.InActiveSearch);

		Utilities.EnumFrom<RelationType>(7)
			.Should()
			.Be(RelationType.Amorous);
	}

	[Fact]
	public void ReportReasonTest()
	{
		Utilities.EnumFrom<ReportReason>(0)
			.Should()
			.Be(ReportReason.Spam);

		Utilities.EnumFrom<ReportReason>(1)
			.Should()
			.Be(ReportReason.ChildPornography);

		Utilities.EnumFrom<ReportReason>(2)
			.Should()
			.Be(ReportReason.Extremism);

		Utilities.EnumFrom<ReportReason>(3)
			.Should()
			.Be(ReportReason.Violence);

		Utilities.EnumFrom<ReportReason>(4)
			.Should()
			.Be(ReportReason.DrugPropaganda);

		Utilities.EnumFrom<ReportReason>(5)
			.Should()
			.Be(ReportReason.AdultMaterial);

		Utilities.EnumFrom<ReportReason>(6)
			.Should()
			.Be(ReportReason.Abuse);
	}

	[Fact]
	public void SexTest()
	{
		Utilities.EnumFrom<Sex>(0)
			.Should()
			.Be(Sex.Unknown);

		Utilities.EnumFrom<Sex>(1)
			.Should()
			.Be(Sex.Female);

		Utilities.EnumFrom<Sex>(2)
			.Should()
			.Be(Sex.Male);
	}

	[Fact]
	public void SortOrderByTest()
	{
		Utilities.EnumFrom<SortOrderBy>(0)
			.Should()
			.Be(SortOrderBy.Desc);

		Utilities.EnumFrom<SortOrderBy>(1)
			.Should()
			.Be(SortOrderBy.Asc);
	}

	[Fact]
	public void UserSortTest()
	{
		Utilities.EnumFrom<UserSort>(0)
			.Should()
			.Be(UserSort.ByPopularity);

		Utilities.EnumFrom<UserSort>(1)
			.Should()
			.Be(UserSort.ByRegDate);
	}

	[Fact]
	public void VideoSortTest()
	{
		Utilities.EnumFrom<VideoSort>(0)
			.Should()
			.Be(VideoSort.AddedDate);

		Utilities.EnumFrom<VideoSort>(1)
			.Should()
			.Be(VideoSort.Duration);

		Utilities.EnumFrom<VideoSort>(2)
			.Should()
			.Be(VideoSort.Relevance);
	}

	[Fact]
	public void VideoWidthTest()
	{
		Utilities.EnumFrom<VideoWidth>(130)
			.Should()
			.Be(VideoWidth.Small130);

		Utilities.EnumFrom<VideoWidth>(160)
			.Should()
			.Be(VideoWidth.Medium160);

		Utilities.EnumFrom<VideoWidth>(320)
			.Should()
			.Be(VideoWidth.Large320);
	}

	[Fact]
	public void VkObjectTypeTest()
	{
		Utilities.EnumFrom<VkObjectType>(0)
			.Should()
			.Be(VkObjectType.User);

		Utilities.EnumFrom<VkObjectType>(1)
			.Should()
			.Be(VkObjectType.Group);

		Utilities.EnumFrom<VkObjectType>(2)
			.Should()
			.Be(VkObjectType.Application);

		Utilities.EnumFrom<VkObjectType>(3)
			.Should()
			.Be(VkObjectType.Page);
	}

	[Fact]
	public void WallContentAccessTest()
	{
		Utilities.EnumFrom<WallContentAccess>(0)
			.Should()
			.Be(WallContentAccess.Off);

		Utilities.EnumFrom<WallContentAccess>(1)
			.Should()
			.Be(WallContentAccess.Opened);

		Utilities.EnumFrom<WallContentAccess>(2)
			.Should()
			.Be(WallContentAccess.Restricted);

		Utilities.EnumFrom<WallContentAccess>(3)
			.Should()
			.Be(WallContentAccess.Closed);
	}
}