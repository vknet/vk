using NUnit.Framework;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Tests.Enum
{
	[TestFixture]
	public class EnumsTest
	{
		[Test]
		public void AccessPagesTest()
		{
			Assert.That(Utilities.EnumFrom<AccessPages>(0), Is.EqualTo(AccessPages.Leaders));
			Assert.That(Utilities.EnumFrom<AccessPages>(1), Is.EqualTo(AccessPages.Participants));
			Assert.That(Utilities.EnumFrom<AccessPages>(2), Is.EqualTo(AccessPages.All));
		}

		[Test]
		public void AddFriendStatusTest()
		{
			Assert.That(Utilities.EnumFrom<AddFriendStatus>(0), Is.EqualTo(AddFriendStatus.Unknown));
			Assert.That(Utilities.EnumFrom<AddFriendStatus>(1), Is.EqualTo(AddFriendStatus.Sended));
			Assert.That(Utilities.EnumFrom<AddFriendStatus>(2), Is.EqualTo(AddFriendStatus.Accepted));
			Assert.That(Utilities.EnumFrom<AddFriendStatus>(4), Is.EqualTo(AddFriendStatus.Resubmit));
		}

		[Test]
		public void AdminLevelTest()
		{
			Assert.That(Utilities.EnumFrom<AdminLevel>(1), Is.EqualTo(AdminLevel.Moderator));
			Assert.That(Utilities.EnumFrom<AdminLevel>(2), Is.EqualTo(AdminLevel.Editor));
			Assert.That(Utilities.EnumFrom<AdminLevel>(3), Is.EqualTo(AdminLevel.Administrator));
		}

		[Test]
		public void AttitudeTest()
		{
			Assert.That(Utilities.EnumFrom<Attitude>(0), Is.EqualTo(Attitude.Unknown));
			Assert.That(Utilities.EnumFrom<Attitude>(1), Is.EqualTo(Attitude.VeryNegative));
			Assert.That(Utilities.EnumFrom<Attitude>(2), Is.EqualTo(Attitude.Negative));
			Assert.That(Utilities.EnumFrom<Attitude>(3), Is.EqualTo(Attitude.Compromise));
			Assert.That(Utilities.EnumFrom<Attitude>(4), Is.EqualTo(Attitude.Neutral));
			Assert.That(Utilities.EnumFrom<Attitude>(5), Is.EqualTo(Attitude.Positive));
		}

		[Test]
		public void AudioGenreTest()
		{
			Assert.That(Utilities.EnumFrom<AudioGenre>(1), Is.EqualTo(AudioGenre.Rock));
			Assert.That(Utilities.EnumFrom<AudioGenre>(2), Is.EqualTo(AudioGenre.Pop));
			Assert.That(Utilities.EnumFrom<AudioGenre>(3), Is.EqualTo(AudioGenre.RapAndHipHop));
			Assert.That(Utilities.EnumFrom<AudioGenre>(4), Is.EqualTo(AudioGenre.EasyListening));
			Assert.That(Utilities.EnumFrom<AudioGenre>(5), Is.EqualTo(AudioGenre.DanceAndHouse));
			Assert.That(Utilities.EnumFrom<AudioGenre>(6), Is.EqualTo(AudioGenre.Instrumental));
			Assert.That(Utilities.EnumFrom<AudioGenre>(7), Is.EqualTo(AudioGenre.Metal));
			Assert.That(Utilities.EnumFrom<AudioGenre>(21), Is.EqualTo(AudioGenre.Alternative));
			Assert.That(Utilities.EnumFrom<AudioGenre>(8), Is.EqualTo(AudioGenre.Dubstep));
			Assert.That(Utilities.EnumFrom<AudioGenre>(1001), Is.EqualTo(AudioGenre.JazzAndBlues));
			Assert.That(Utilities.EnumFrom<AudioGenre>(10), Is.EqualTo(AudioGenre.DrumAndBass));
			Assert.That(Utilities.EnumFrom<AudioGenre>(11), Is.EqualTo(AudioGenre.Trance));
			Assert.That(Utilities.EnumFrom<AudioGenre>(12), Is.EqualTo(AudioGenre.Chanson));
			Assert.That(Utilities.EnumFrom<AudioGenre>(13), Is.EqualTo(AudioGenre.Ethnic));
			Assert.That(Utilities.EnumFrom<AudioGenre>(14), Is.EqualTo(AudioGenre.AcousticAndVocal));
			Assert.That(Utilities.EnumFrom<AudioGenre>(15), Is.EqualTo(AudioGenre.Reggae));
			Assert.That(Utilities.EnumFrom<AudioGenre>(16), Is.EqualTo(AudioGenre.Classical));
			Assert.That(Utilities.EnumFrom<AudioGenre>(17), Is.EqualTo(AudioGenre.IndiePop));
			Assert.That(Utilities.EnumFrom<AudioGenre>(19), Is.EqualTo(AudioGenre.Speech));
			Assert.That(Utilities.EnumFrom<AudioGenre>(22), Is.EqualTo(AudioGenre.ElectropopAndDisco));
			Assert.That(Utilities.EnumFrom<AudioGenre>(18), Is.EqualTo(AudioGenre.Other));
		}

		[Test]
		public void AudioSortTest()
		{
			Assert.That(Utilities.EnumFrom<AudioSort>(0), Is.EqualTo(AudioSort.AddedDate));
			Assert.That(Utilities.EnumFrom<AudioSort>(1), Is.EqualTo(AudioSort.Duration));
			Assert.That(Utilities.EnumFrom<AudioSort>(2), Is.EqualTo(AudioSort.Popularity));
		}

		[Test]
		public void BanReasonTest()
		{
			Assert.That(Utilities.EnumFrom<BanReason>(0), Is.EqualTo(BanReason.Other));
			Assert.That(Utilities.EnumFrom<BanReason>(1), Is.EqualTo(BanReason.Spam));
			Assert.That(Utilities.EnumFrom<BanReason>(2), Is.EqualTo(BanReason.VerbalAbuse));
			Assert.That(Utilities.EnumFrom<BanReason>(3), Is.EqualTo(BanReason.StrongLanguage));
			Assert.That(Utilities.EnumFrom<BanReason>(4), Is.EqualTo(BanReason.IrrelevantMessages));
		}

		[Test]
		public void BirthdayVisibilityTest()
		{
			Assert.That(Utilities.EnumFrom<BirthdayVisibility>(0)
					, Is.EqualTo(BirthdayVisibility.Invisible));

			Assert.That(Utilities.EnumFrom<BirthdayVisibility>(1)
					, Is.EqualTo(BirthdayVisibility.Full));

			Assert.That(Utilities.EnumFrom<BirthdayVisibility>(2)
					, Is.EqualTo(BirthdayVisibility.OnlyDayAndMonth));
		}

		[Test]
		public void ContentAccessTest()
		{
			Assert.That(Utilities.EnumFrom<ContentAccess>(0), Is.EqualTo(ContentAccess.Off));
			Assert.That(Utilities.EnumFrom<ContentAccess>(1), Is.EqualTo(ContentAccess.Opened));
			Assert.That(Utilities.EnumFrom<ContentAccess>(2), Is.EqualTo(ContentAccess.Restricted));
		}

		[Test]
		public void DeleteFriendStatusTest()
		{
			Assert.That(Utilities.EnumFrom<DeleteFriendStatus>(0)
					, Is.EqualTo(DeleteFriendStatus.Unknown));

			Assert.That(Utilities.EnumFrom<DeleteFriendStatus>(1)
					, Is.EqualTo(DeleteFriendStatus.UserIsDeleted));

			Assert.That(Utilities.EnumFrom<DeleteFriendStatus>(2)
					, Is.EqualTo(DeleteFriendStatus.RequestRejected));

			Assert.That(Utilities.EnumFrom<DeleteFriendStatus>(3)
					, Is.EqualTo(DeleteFriendStatus.RecommendationDeleted));
		}

		[Test]
		public void DocFilterTest()
		{
			Assert.That(Utilities.EnumFrom<DocFilter>(1), Is.EqualTo(DocFilter.Text));
			Assert.That(Utilities.EnumFrom<DocFilter>(2), Is.EqualTo(DocFilter.Archive));
			Assert.That(Utilities.EnumFrom<DocFilter>(3), Is.EqualTo(DocFilter.Gif));
			Assert.That(Utilities.EnumFrom<DocFilter>(4), Is.EqualTo(DocFilter.Image));
			Assert.That(Utilities.EnumFrom<DocFilter>(5), Is.EqualTo(DocFilter.Audio));
			Assert.That(Utilities.EnumFrom<DocFilter>(6), Is.EqualTo(DocFilter.Video));
			Assert.That(Utilities.EnumFrom<DocFilter>(7), Is.EqualTo(DocFilter.EBook));
			Assert.That(Utilities.EnumFrom<DocFilter>(8), Is.EqualTo(DocFilter.Unknown));
		}

		[Test]
		public void FriendStatusTest()
		{
			Assert.That(Utilities.EnumFrom<FriendStatus>(0), Is.EqualTo(FriendStatus.NotFriend));
			Assert.That(Utilities.EnumFrom<FriendStatus>(1), Is.EqualTo(FriendStatus.OutputRequest));
			Assert.That(Utilities.EnumFrom<FriendStatus>(2), Is.EqualTo(FriendStatus.InputRequest));
			Assert.That(Utilities.EnumFrom<FriendStatus>(3), Is.EqualTo(FriendStatus.Friend));
		}

		[Test]
		public void GiftPrivacyTest()
		{
			Assert.That(Utilities.EnumFrom<GiftPrivacy>(0), Is.EqualTo(GiftPrivacy.All));

			Assert.That(Utilities.EnumFrom<GiftPrivacy>(1)
					, Is.EqualTo(GiftPrivacy.NameAllMessageUser));

			Assert.That(Utilities.EnumFrom<GiftPrivacy>(2)
					, Is.EqualTo(GiftPrivacy.NameHideMessageUser));
		}

		[Test]
		public void GroupAccessTest()
		{
			Assert.That(Utilities.EnumFrom<GroupAccess>(0), Is.EqualTo(GroupAccess.Open));
			Assert.That(Utilities.EnumFrom<GroupAccess>(1), Is.EqualTo(GroupAccess.Closed));
			Assert.That(Utilities.EnumFrom<GroupAccess>(2), Is.EqualTo(GroupAccess.Private));
		}

		[Test]
		public void GroupPublicityTest()
		{
			Assert.That(Utilities.EnumFrom<GroupPublicity>(0), Is.EqualTo(GroupPublicity.Public));
			Assert.That(Utilities.EnumFrom<GroupPublicity>(1), Is.EqualTo(GroupPublicity.Closed));
			Assert.That(Utilities.EnumFrom<GroupPublicity>(2), Is.EqualTo(GroupPublicity.Private));
		}

		[Test]
		public void GroupSortTest()
		{
			Assert.That(Utilities.EnumFrom<GroupSort>(0), Is.EqualTo(GroupSort.Normal));
			Assert.That(Utilities.EnumFrom<GroupSort>(1), Is.EqualTo(GroupSort.Growth));
			Assert.That(Utilities.EnumFrom<GroupSort>(2), Is.EqualTo(GroupSort.Relation));
			Assert.That(Utilities.EnumFrom<GroupSort>(3), Is.EqualTo(GroupSort.Likes));
			Assert.That(Utilities.EnumFrom<GroupSort>(4), Is.EqualTo(GroupSort.Comments));
			Assert.That(Utilities.EnumFrom<GroupSort>(5), Is.EqualTo(GroupSort.Records));
		}

		[Test]
		public void GroupSubjectsTest()
		{
			Assert.That(Utilities.EnumFrom<GroupSubjects>(1), Is.EqualTo(GroupSubjects.AutoMoto));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(2), Is.EqualTo(GroupSubjects.Leisure));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(3), Is.EqualTo(GroupSubjects.Business));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(4)
					, Is.EqualTo(GroupSubjects.DomesticAnimals));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(5), Is.EqualTo(GroupSubjects.Health));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(6), Is.EqualTo(GroupSubjects.MeetAndChat));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(7), Is.EqualTo(GroupSubjects.Games));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(8), Is.EqualTo(GroupSubjects.It));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(9), Is.EqualTo(GroupSubjects.Cinema));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(10)
					, Is.EqualTo(GroupSubjects.BeautyAndFashion));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(11), Is.EqualTo(GroupSubjects.Cookery));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(12)
					, Is.EqualTo(GroupSubjects.CultureAndArt));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(13), Is.EqualTo(GroupSubjects.References));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(14)
					, Is.EqualTo(GroupSubjects.MobileTelephonyAndInternet));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(15), Is.EqualTo(GroupSubjects.Music));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(16)
					, Is.EqualTo(GroupSubjects.ScienceAndTechnology));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(17), Is.EqualTo(GroupSubjects.RealEstate));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(18), Is.EqualTo(GroupSubjects.NewsAndMedia));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(19), Is.EqualTo(GroupSubjects.Security));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(20), Is.EqualTo(GroupSubjects.Forming));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(21)
					, Is.EqualTo(GroupSubjects.ConstructionAndRepair));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(22), Is.EqualTo(GroupSubjects.Policy));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(23), Is.EqualTo(GroupSubjects.FoodItems));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(24), Is.EqualTo(GroupSubjects.Industry));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(25), Is.EqualTo(GroupSubjects.Travels));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(26), Is.EqualTo(GroupSubjects.Job));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(27)
					, Is.EqualTo(GroupSubjects.Entertainment));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(28), Is.EqualTo(GroupSubjects.Religion));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(29)
					, Is.EqualTo(GroupSubjects.HomeAndFamily));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(30), Is.EqualTo(GroupSubjects.Sports));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(31), Is.EqualTo(GroupSubjects.Coverage));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(32), Is.EqualTo(GroupSubjects.Tv));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(33)
					, Is.EqualTo(GroupSubjects.GoodsAndServices));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(34)
					, Is.EqualTo(GroupSubjects.InterestsAndHobbies));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(35), Is.EqualTo(GroupSubjects.Finances));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(36), Is.EqualTo(GroupSubjects.Photography));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(37), Is.EqualTo(GroupSubjects.Esoterics));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(38)
					, Is.EqualTo(GroupSubjects.ElectronicsAndAppliances));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(39), Is.EqualTo(GroupSubjects.Erotica));
			Assert.That(Utilities.EnumFrom<GroupSubjects>(40), Is.EqualTo(GroupSubjects.Humor));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(41)
					, Is.EqualTo(GroupSubjects.SocietyHumanities));

			Assert.That(Utilities.EnumFrom<GroupSubjects>(42)
					, Is.EqualTo(GroupSubjects.DesignAndGraphics));
		}

		[Test]
		public void GroupSubTypeTest()
		{
			Assert.That(Utilities.EnumFrom<GroupSubType>(1)
					, Is.EqualTo(GroupSubType.PlaceOrSmallCompany));

			Assert.That(Utilities.EnumFrom<GroupSubType>(2)
					, Is.EqualTo(GroupSubType.OrganizationOrWebsite));

			Assert.That(Utilities.EnumFrom<GroupSubType>(3), Is.EqualTo(GroupSubType.PersonOrTeam));

			Assert.That(Utilities.EnumFrom<GroupSubType>(4)
					, Is.EqualTo(GroupSubType.ProductOrProducts));
		}

		[Test]
		public void Iso3166Test()
		{
			Assert.That(Utilities.EnumFrom<Iso3166>(0), Is.EqualTo(Iso3166.AU));
			Assert.That(Utilities.EnumFrom<Iso3166>(1), Is.EqualTo(Iso3166.AT));
			Assert.That(Utilities.EnumFrom<Iso3166>(2), Is.EqualTo(Iso3166.AZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(3), Is.EqualTo(Iso3166.AX));
			Assert.That(Utilities.EnumFrom<Iso3166>(4), Is.EqualTo(Iso3166.AL));
			Assert.That(Utilities.EnumFrom<Iso3166>(5), Is.EqualTo(Iso3166.DZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(6), Is.EqualTo(Iso3166.UM));
			Assert.That(Utilities.EnumFrom<Iso3166>(7), Is.EqualTo(Iso3166.VI));
			Assert.That(Utilities.EnumFrom<Iso3166>(8), Is.EqualTo(Iso3166.AS));
			Assert.That(Utilities.EnumFrom<Iso3166>(9), Is.EqualTo(Iso3166.AI));
			Assert.That(Utilities.EnumFrom<Iso3166>(10), Is.EqualTo(Iso3166.AO));
			Assert.That(Utilities.EnumFrom<Iso3166>(11), Is.EqualTo(Iso3166.AD));
			Assert.That(Utilities.EnumFrom<Iso3166>(12), Is.EqualTo(Iso3166.AQ));
			Assert.That(Utilities.EnumFrom<Iso3166>(13), Is.EqualTo(Iso3166.AG));
			Assert.That(Utilities.EnumFrom<Iso3166>(14), Is.EqualTo(Iso3166.AR));
			Assert.That(Utilities.EnumFrom<Iso3166>(15), Is.EqualTo(Iso3166.AM));
			Assert.That(Utilities.EnumFrom<Iso3166>(16), Is.EqualTo(Iso3166.AW));
			Assert.That(Utilities.EnumFrom<Iso3166>(17), Is.EqualTo(Iso3166.AF));
			Assert.That(Utilities.EnumFrom<Iso3166>(18), Is.EqualTo(Iso3166.BS));
			Assert.That(Utilities.EnumFrom<Iso3166>(19), Is.EqualTo(Iso3166.BD));
			Assert.That(Utilities.EnumFrom<Iso3166>(20), Is.EqualTo(Iso3166.BB));
			Assert.That(Utilities.EnumFrom<Iso3166>(21), Is.EqualTo(Iso3166.BH));
			Assert.That(Utilities.EnumFrom<Iso3166>(22), Is.EqualTo(Iso3166.BZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(23), Is.EqualTo(Iso3166.BY));
			Assert.That(Utilities.EnumFrom<Iso3166>(24), Is.EqualTo(Iso3166.BE));
			Assert.That(Utilities.EnumFrom<Iso3166>(25), Is.EqualTo(Iso3166.BJ));
			Assert.That(Utilities.EnumFrom<Iso3166>(26), Is.EqualTo(Iso3166.BM));
			Assert.That(Utilities.EnumFrom<Iso3166>(27), Is.EqualTo(Iso3166.BG));
			Assert.That(Utilities.EnumFrom<Iso3166>(28), Is.EqualTo(Iso3166.BO));
			Assert.That(Utilities.EnumFrom<Iso3166>(29), Is.EqualTo(Iso3166.BA));
			Assert.That(Utilities.EnumFrom<Iso3166>(30), Is.EqualTo(Iso3166.BW));
			Assert.That(Utilities.EnumFrom<Iso3166>(31), Is.EqualTo(Iso3166.BR));
			Assert.That(Utilities.EnumFrom<Iso3166>(32), Is.EqualTo(Iso3166.IO));
			Assert.That(Utilities.EnumFrom<Iso3166>(33), Is.EqualTo(Iso3166.VG));
			Assert.That(Utilities.EnumFrom<Iso3166>(34), Is.EqualTo(Iso3166.BN));
			Assert.That(Utilities.EnumFrom<Iso3166>(35), Is.EqualTo(Iso3166.BF));
			Assert.That(Utilities.EnumFrom<Iso3166>(36), Is.EqualTo(Iso3166.BI));
			Assert.That(Utilities.EnumFrom<Iso3166>(37), Is.EqualTo(Iso3166.BT));
			Assert.That(Utilities.EnumFrom<Iso3166>(38), Is.EqualTo(Iso3166.VU));
			Assert.That(Utilities.EnumFrom<Iso3166>(39), Is.EqualTo(Iso3166.VA));
			Assert.That(Utilities.EnumFrom<Iso3166>(40), Is.EqualTo(Iso3166.GB));
			Assert.That(Utilities.EnumFrom<Iso3166>(41), Is.EqualTo(Iso3166.HU));
			Assert.That(Utilities.EnumFrom<Iso3166>(42), Is.EqualTo(Iso3166.VE));
			Assert.That(Utilities.EnumFrom<Iso3166>(43), Is.EqualTo(Iso3166.TL));
			Assert.That(Utilities.EnumFrom<Iso3166>(44), Is.EqualTo(Iso3166.VN));
			Assert.That(Utilities.EnumFrom<Iso3166>(45), Is.EqualTo(Iso3166.GA));
			Assert.That(Utilities.EnumFrom<Iso3166>(46), Is.EqualTo(Iso3166.HT));
			Assert.That(Utilities.EnumFrom<Iso3166>(47), Is.EqualTo(Iso3166.GY));
			Assert.That(Utilities.EnumFrom<Iso3166>(48), Is.EqualTo(Iso3166.GM));
			Assert.That(Utilities.EnumFrom<Iso3166>(49), Is.EqualTo(Iso3166.GH));
			Assert.That(Utilities.EnumFrom<Iso3166>(50), Is.EqualTo(Iso3166.GP));
			Assert.That(Utilities.EnumFrom<Iso3166>(51), Is.EqualTo(Iso3166.GT));
			Assert.That(Utilities.EnumFrom<Iso3166>(52), Is.EqualTo(Iso3166.GN));
			Assert.That(Utilities.EnumFrom<Iso3166>(53), Is.EqualTo(Iso3166.GW));
			Assert.That(Utilities.EnumFrom<Iso3166>(54), Is.EqualTo(Iso3166.DE));
			Assert.That(Utilities.EnumFrom<Iso3166>(55), Is.EqualTo(Iso3166.GI));
			Assert.That(Utilities.EnumFrom<Iso3166>(56), Is.EqualTo(Iso3166.HN));
			Assert.That(Utilities.EnumFrom<Iso3166>(57), Is.EqualTo(Iso3166.HK));
			Assert.That(Utilities.EnumFrom<Iso3166>(58), Is.EqualTo(Iso3166.GD));
			Assert.That(Utilities.EnumFrom<Iso3166>(59), Is.EqualTo(Iso3166.GL));
			Assert.That(Utilities.EnumFrom<Iso3166>(60), Is.EqualTo(Iso3166.GR));
			Assert.That(Utilities.EnumFrom<Iso3166>(61), Is.EqualTo(Iso3166.GE));
			Assert.That(Utilities.EnumFrom<Iso3166>(62), Is.EqualTo(Iso3166.GU));
			Assert.That(Utilities.EnumFrom<Iso3166>(63), Is.EqualTo(Iso3166.DK));
			Assert.That(Utilities.EnumFrom<Iso3166>(64), Is.EqualTo(Iso3166.CD));
			Assert.That(Utilities.EnumFrom<Iso3166>(65), Is.EqualTo(Iso3166.DJ));
			Assert.That(Utilities.EnumFrom<Iso3166>(66), Is.EqualTo(Iso3166.DM));
			Assert.That(Utilities.EnumFrom<Iso3166>(67), Is.EqualTo(Iso3166.DO));
			Assert.That(Utilities.EnumFrom<Iso3166>(68), Is.EqualTo(Iso3166.EU));
			Assert.That(Utilities.EnumFrom<Iso3166>(69), Is.EqualTo(Iso3166.EG));
			Assert.That(Utilities.EnumFrom<Iso3166>(70), Is.EqualTo(Iso3166.ZM));
			Assert.That(Utilities.EnumFrom<Iso3166>(71), Is.EqualTo(Iso3166.EH));
			Assert.That(Utilities.EnumFrom<Iso3166>(72), Is.EqualTo(Iso3166.ZW));
			Assert.That(Utilities.EnumFrom<Iso3166>(73), Is.EqualTo(Iso3166.IL));
			Assert.That(Utilities.EnumFrom<Iso3166>(74), Is.EqualTo(Iso3166.IN));
			Assert.That(Utilities.EnumFrom<Iso3166>(75), Is.EqualTo(Iso3166.ID));
			Assert.That(Utilities.EnumFrom<Iso3166>(76), Is.EqualTo(Iso3166.JO));
			Assert.That(Utilities.EnumFrom<Iso3166>(77), Is.EqualTo(Iso3166.IQ));
			Assert.That(Utilities.EnumFrom<Iso3166>(78), Is.EqualTo(Iso3166.IR));
			Assert.That(Utilities.EnumFrom<Iso3166>(79), Is.EqualTo(Iso3166.IE));
			Assert.That(Utilities.EnumFrom<Iso3166>(80), Is.EqualTo(Iso3166.IS));
			Assert.That(Utilities.EnumFrom<Iso3166>(81), Is.EqualTo(Iso3166.ES));
			Assert.That(Utilities.EnumFrom<Iso3166>(82), Is.EqualTo(Iso3166.IT));
			Assert.That(Utilities.EnumFrom<Iso3166>(83), Is.EqualTo(Iso3166.YE));
			Assert.That(Utilities.EnumFrom<Iso3166>(84), Is.EqualTo(Iso3166.KP));
			Assert.That(Utilities.EnumFrom<Iso3166>(85), Is.EqualTo(Iso3166.CV));
			Assert.That(Utilities.EnumFrom<Iso3166>(86), Is.EqualTo(Iso3166.KZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(87), Is.EqualTo(Iso3166.KY));
			Assert.That(Utilities.EnumFrom<Iso3166>(88), Is.EqualTo(Iso3166.KH));
			Assert.That(Utilities.EnumFrom<Iso3166>(89), Is.EqualTo(Iso3166.CM));
			Assert.That(Utilities.EnumFrom<Iso3166>(90), Is.EqualTo(Iso3166.CA));
			Assert.That(Utilities.EnumFrom<Iso3166>(91), Is.EqualTo(Iso3166.QA));
			Assert.That(Utilities.EnumFrom<Iso3166>(92), Is.EqualTo(Iso3166.KE));
			Assert.That(Utilities.EnumFrom<Iso3166>(93), Is.EqualTo(Iso3166.CY));
			Assert.That(Utilities.EnumFrom<Iso3166>(94), Is.EqualTo(Iso3166.KG));
			Assert.That(Utilities.EnumFrom<Iso3166>(95), Is.EqualTo(Iso3166.KI));
			Assert.That(Utilities.EnumFrom<Iso3166>(96), Is.EqualTo(Iso3166.CN));
			Assert.That(Utilities.EnumFrom<Iso3166>(97), Is.EqualTo(Iso3166.CC));
			Assert.That(Utilities.EnumFrom<Iso3166>(98), Is.EqualTo(Iso3166.CO));
			Assert.That(Utilities.EnumFrom<Iso3166>(99), Is.EqualTo(Iso3166.KM));
			Assert.That(Utilities.EnumFrom<Iso3166>(100), Is.EqualTo(Iso3166.CR));
			Assert.That(Utilities.EnumFrom<Iso3166>(101), Is.EqualTo(Iso3166.CI));
			Assert.That(Utilities.EnumFrom<Iso3166>(102), Is.EqualTo(Iso3166.CU));
			Assert.That(Utilities.EnumFrom<Iso3166>(103), Is.EqualTo(Iso3166.KW));
			Assert.That(Utilities.EnumFrom<Iso3166>(104), Is.EqualTo(Iso3166.LA));
			Assert.That(Utilities.EnumFrom<Iso3166>(105), Is.EqualTo(Iso3166.LV));
			Assert.That(Utilities.EnumFrom<Iso3166>(106), Is.EqualTo(Iso3166.LS));
			Assert.That(Utilities.EnumFrom<Iso3166>(107), Is.EqualTo(Iso3166.LR));
			Assert.That(Utilities.EnumFrom<Iso3166>(108), Is.EqualTo(Iso3166.LB));
			Assert.That(Utilities.EnumFrom<Iso3166>(109), Is.EqualTo(Iso3166.LY));
			Assert.That(Utilities.EnumFrom<Iso3166>(110), Is.EqualTo(Iso3166.LT));
			Assert.That(Utilities.EnumFrom<Iso3166>(111), Is.EqualTo(Iso3166.LI));
			Assert.That(Utilities.EnumFrom<Iso3166>(112), Is.EqualTo(Iso3166.LU));
			Assert.That(Utilities.EnumFrom<Iso3166>(113), Is.EqualTo(Iso3166.MU));
			Assert.That(Utilities.EnumFrom<Iso3166>(114), Is.EqualTo(Iso3166.MR));
			Assert.That(Utilities.EnumFrom<Iso3166>(115), Is.EqualTo(Iso3166.MG));
			Assert.That(Utilities.EnumFrom<Iso3166>(116), Is.EqualTo(Iso3166.YT));
			Assert.That(Utilities.EnumFrom<Iso3166>(117), Is.EqualTo(Iso3166.MO));
			Assert.That(Utilities.EnumFrom<Iso3166>(118), Is.EqualTo(Iso3166.MK));
			Assert.That(Utilities.EnumFrom<Iso3166>(119), Is.EqualTo(Iso3166.MW));
			Assert.That(Utilities.EnumFrom<Iso3166>(120), Is.EqualTo(Iso3166.MY));
			Assert.That(Utilities.EnumFrom<Iso3166>(121), Is.EqualTo(Iso3166.ML));
			Assert.That(Utilities.EnumFrom<Iso3166>(122), Is.EqualTo(Iso3166.MV));
			Assert.That(Utilities.EnumFrom<Iso3166>(123), Is.EqualTo(Iso3166.MT));
			Assert.That(Utilities.EnumFrom<Iso3166>(124), Is.EqualTo(Iso3166.MA));
			Assert.That(Utilities.EnumFrom<Iso3166>(125), Is.EqualTo(Iso3166.MQ));
			Assert.That(Utilities.EnumFrom<Iso3166>(126), Is.EqualTo(Iso3166.MH));
			Assert.That(Utilities.EnumFrom<Iso3166>(127), Is.EqualTo(Iso3166.MX));
			Assert.That(Utilities.EnumFrom<Iso3166>(128), Is.EqualTo(Iso3166.MZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(129), Is.EqualTo(Iso3166.MD));
			Assert.That(Utilities.EnumFrom<Iso3166>(130), Is.EqualTo(Iso3166.MC));
			Assert.That(Utilities.EnumFrom<Iso3166>(131), Is.EqualTo(Iso3166.MN));
			Assert.That(Utilities.EnumFrom<Iso3166>(132), Is.EqualTo(Iso3166.MS));
			Assert.That(Utilities.EnumFrom<Iso3166>(133), Is.EqualTo(Iso3166.MM));
			Assert.That(Utilities.EnumFrom<Iso3166>(134), Is.EqualTo(Iso3166.NA));
			Assert.That(Utilities.EnumFrom<Iso3166>(135), Is.EqualTo(Iso3166.NR));
			Assert.That(Utilities.EnumFrom<Iso3166>(136), Is.EqualTo(Iso3166.NP));
			Assert.That(Utilities.EnumFrom<Iso3166>(137), Is.EqualTo(Iso3166.NE));
			Assert.That(Utilities.EnumFrom<Iso3166>(138), Is.EqualTo(Iso3166.NG));
			Assert.That(Utilities.EnumFrom<Iso3166>(139), Is.EqualTo(Iso3166.AN));
			Assert.That(Utilities.EnumFrom<Iso3166>(140), Is.EqualTo(Iso3166.NL));
			Assert.That(Utilities.EnumFrom<Iso3166>(141), Is.EqualTo(Iso3166.NI));
			Assert.That(Utilities.EnumFrom<Iso3166>(142), Is.EqualTo(Iso3166.NU));
			Assert.That(Utilities.EnumFrom<Iso3166>(143), Is.EqualTo(Iso3166.NC));
			Assert.That(Utilities.EnumFrom<Iso3166>(144), Is.EqualTo(Iso3166.NZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(145), Is.EqualTo(Iso3166.NO));
			Assert.That(Utilities.EnumFrom<Iso3166>(146), Is.EqualTo(Iso3166.AE));
			Assert.That(Utilities.EnumFrom<Iso3166>(147), Is.EqualTo(Iso3166.OM));
			Assert.That(Utilities.EnumFrom<Iso3166>(148), Is.EqualTo(Iso3166.CX));
			Assert.That(Utilities.EnumFrom<Iso3166>(149), Is.EqualTo(Iso3166.CK));
			Assert.That(Utilities.EnumFrom<Iso3166>(150), Is.EqualTo(Iso3166.HM));
			Assert.That(Utilities.EnumFrom<Iso3166>(151), Is.EqualTo(Iso3166.PK));
			Assert.That(Utilities.EnumFrom<Iso3166>(152), Is.EqualTo(Iso3166.PW));
			Assert.That(Utilities.EnumFrom<Iso3166>(153), Is.EqualTo(Iso3166.PS));
			Assert.That(Utilities.EnumFrom<Iso3166>(154), Is.EqualTo(Iso3166.PA));
			Assert.That(Utilities.EnumFrom<Iso3166>(155), Is.EqualTo(Iso3166.PG));
			Assert.That(Utilities.EnumFrom<Iso3166>(156), Is.EqualTo(Iso3166.PY));
			Assert.That(Utilities.EnumFrom<Iso3166>(157), Is.EqualTo(Iso3166.PE));
			Assert.That(Utilities.EnumFrom<Iso3166>(158), Is.EqualTo(Iso3166.PN));
			Assert.That(Utilities.EnumFrom<Iso3166>(159), Is.EqualTo(Iso3166.PL));
			Assert.That(Utilities.EnumFrom<Iso3166>(160), Is.EqualTo(Iso3166.PT));
			Assert.That(Utilities.EnumFrom<Iso3166>(161), Is.EqualTo(Iso3166.PR));
			Assert.That(Utilities.EnumFrom<Iso3166>(162), Is.EqualTo(Iso3166.CG));
			Assert.That(Utilities.EnumFrom<Iso3166>(163), Is.EqualTo(Iso3166.RE));
			Assert.That(Utilities.EnumFrom<Iso3166>(164), Is.EqualTo(Iso3166.RU));
			Assert.That(Utilities.EnumFrom<Iso3166>(165), Is.EqualTo(Iso3166.RW));
			Assert.That(Utilities.EnumFrom<Iso3166>(166), Is.EqualTo(Iso3166.RO));
			Assert.That(Utilities.EnumFrom<Iso3166>(167), Is.EqualTo(Iso3166.US));
			Assert.That(Utilities.EnumFrom<Iso3166>(168), Is.EqualTo(Iso3166.SV));
			Assert.That(Utilities.EnumFrom<Iso3166>(169), Is.EqualTo(Iso3166.WS));
			Assert.That(Utilities.EnumFrom<Iso3166>(170), Is.EqualTo(Iso3166.SM));
			Assert.That(Utilities.EnumFrom<Iso3166>(171), Is.EqualTo(Iso3166.ST));
			Assert.That(Utilities.EnumFrom<Iso3166>(172), Is.EqualTo(Iso3166.SA));
			Assert.That(Utilities.EnumFrom<Iso3166>(173), Is.EqualTo(Iso3166.SZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(174), Is.EqualTo(Iso3166.SJ));
			Assert.That(Utilities.EnumFrom<Iso3166>(175), Is.EqualTo(Iso3166.MP));
			Assert.That(Utilities.EnumFrom<Iso3166>(176), Is.EqualTo(Iso3166.SC));
			Assert.That(Utilities.EnumFrom<Iso3166>(177), Is.EqualTo(Iso3166.SN));
			Assert.That(Utilities.EnumFrom<Iso3166>(178), Is.EqualTo(Iso3166.VC));
			Assert.That(Utilities.EnumFrom<Iso3166>(179), Is.EqualTo(Iso3166.KN));
			Assert.That(Utilities.EnumFrom<Iso3166>(180), Is.EqualTo(Iso3166.LC));
			Assert.That(Utilities.EnumFrom<Iso3166>(181), Is.EqualTo(Iso3166.PM));
			Assert.That(Utilities.EnumFrom<Iso3166>(182), Is.EqualTo(Iso3166.RS));
			Assert.That(Utilities.EnumFrom<Iso3166>(183), Is.EqualTo(Iso3166.CS));
			Assert.That(Utilities.EnumFrom<Iso3166>(184), Is.EqualTo(Iso3166.SG));
			Assert.That(Utilities.EnumFrom<Iso3166>(185), Is.EqualTo(Iso3166.SY));
			Assert.That(Utilities.EnumFrom<Iso3166>(186), Is.EqualTo(Iso3166.SK));
			Assert.That(Utilities.EnumFrom<Iso3166>(187), Is.EqualTo(Iso3166.SI));
			Assert.That(Utilities.EnumFrom<Iso3166>(188), Is.EqualTo(Iso3166.SB));
			Assert.That(Utilities.EnumFrom<Iso3166>(189), Is.EqualTo(Iso3166.SO));
			Assert.That(Utilities.EnumFrom<Iso3166>(190), Is.EqualTo(Iso3166.SD));
			Assert.That(Utilities.EnumFrom<Iso3166>(191), Is.EqualTo(Iso3166.SR));
			Assert.That(Utilities.EnumFrom<Iso3166>(192), Is.EqualTo(Iso3166.SL));
			Assert.That(Utilities.EnumFrom<Iso3166>(193), Is.EqualTo(Iso3166.SU));
			Assert.That(Utilities.EnumFrom<Iso3166>(194), Is.EqualTo(Iso3166.TJ));
			Assert.That(Utilities.EnumFrom<Iso3166>(195), Is.EqualTo(Iso3166.TH));
			Assert.That(Utilities.EnumFrom<Iso3166>(196), Is.EqualTo(Iso3166.TW));
			Assert.That(Utilities.EnumFrom<Iso3166>(197), Is.EqualTo(Iso3166.TZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(198), Is.EqualTo(Iso3166.TG));
			Assert.That(Utilities.EnumFrom<Iso3166>(199), Is.EqualTo(Iso3166.TK));
			Assert.That(Utilities.EnumFrom<Iso3166>(200), Is.EqualTo(Iso3166.TO));
			Assert.That(Utilities.EnumFrom<Iso3166>(201), Is.EqualTo(Iso3166.TT));
			Assert.That(Utilities.EnumFrom<Iso3166>(202), Is.EqualTo(Iso3166.TV));
			Assert.That(Utilities.EnumFrom<Iso3166>(203), Is.EqualTo(Iso3166.TN));
			Assert.That(Utilities.EnumFrom<Iso3166>(204), Is.EqualTo(Iso3166.TM));
			Assert.That(Utilities.EnumFrom<Iso3166>(205), Is.EqualTo(Iso3166.TR));
			Assert.That(Utilities.EnumFrom<Iso3166>(206), Is.EqualTo(Iso3166.UG));
			Assert.That(Utilities.EnumFrom<Iso3166>(207), Is.EqualTo(Iso3166.UZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(208), Is.EqualTo(Iso3166.UA));
			Assert.That(Utilities.EnumFrom<Iso3166>(209), Is.EqualTo(Iso3166.UY));
			Assert.That(Utilities.EnumFrom<Iso3166>(210), Is.EqualTo(Iso3166.FO));
			Assert.That(Utilities.EnumFrom<Iso3166>(211), Is.EqualTo(Iso3166.FM));
			Assert.That(Utilities.EnumFrom<Iso3166>(212), Is.EqualTo(Iso3166.FJ));
			Assert.That(Utilities.EnumFrom<Iso3166>(213), Is.EqualTo(Iso3166.PH));
			Assert.That(Utilities.EnumFrom<Iso3166>(214), Is.EqualTo(Iso3166.FI));
			Assert.That(Utilities.EnumFrom<Iso3166>(215), Is.EqualTo(Iso3166.FK));
			Assert.That(Utilities.EnumFrom<Iso3166>(216), Is.EqualTo(Iso3166.FR));
			Assert.That(Utilities.EnumFrom<Iso3166>(217), Is.EqualTo(Iso3166.GF));
			Assert.That(Utilities.EnumFrom<Iso3166>(218), Is.EqualTo(Iso3166.PF));
			Assert.That(Utilities.EnumFrom<Iso3166>(219), Is.EqualTo(Iso3166.TF));
			Assert.That(Utilities.EnumFrom<Iso3166>(220), Is.EqualTo(Iso3166.HR));
			Assert.That(Utilities.EnumFrom<Iso3166>(221), Is.EqualTo(Iso3166.CF));
			Assert.That(Utilities.EnumFrom<Iso3166>(222), Is.EqualTo(Iso3166.TD));
			Assert.That(Utilities.EnumFrom<Iso3166>(223), Is.EqualTo(Iso3166.ME));
			Assert.That(Utilities.EnumFrom<Iso3166>(224), Is.EqualTo(Iso3166.CZ));
			Assert.That(Utilities.EnumFrom<Iso3166>(225), Is.EqualTo(Iso3166.CL));
			Assert.That(Utilities.EnumFrom<Iso3166>(226), Is.EqualTo(Iso3166.CH));
			Assert.That(Utilities.EnumFrom<Iso3166>(227), Is.EqualTo(Iso3166.SE));
			Assert.That(Utilities.EnumFrom<Iso3166>(228), Is.EqualTo(Iso3166.LK));
			Assert.That(Utilities.EnumFrom<Iso3166>(229), Is.EqualTo(Iso3166.EC));
			Assert.That(Utilities.EnumFrom<Iso3166>(230), Is.EqualTo(Iso3166.GQ));
			Assert.That(Utilities.EnumFrom<Iso3166>(231), Is.EqualTo(Iso3166.ER));
			Assert.That(Utilities.EnumFrom<Iso3166>(232), Is.EqualTo(Iso3166.EE));
			Assert.That(Utilities.EnumFrom<Iso3166>(233), Is.EqualTo(Iso3166.ET));
			Assert.That(Utilities.EnumFrom<Iso3166>(234), Is.EqualTo(Iso3166.ZA));
			Assert.That(Utilities.EnumFrom<Iso3166>(235), Is.EqualTo(Iso3166.KR));
			Assert.That(Utilities.EnumFrom<Iso3166>(236), Is.EqualTo(Iso3166.GS));
			Assert.That(Utilities.EnumFrom<Iso3166>(237), Is.EqualTo(Iso3166.JM));
			Assert.That(Utilities.EnumFrom<Iso3166>(238), Is.EqualTo(Iso3166.JP));
			Assert.That(Utilities.EnumFrom<Iso3166>(239), Is.EqualTo(Iso3166.BV));
			Assert.That(Utilities.EnumFrom<Iso3166>(240), Is.EqualTo(Iso3166.NF));
			Assert.That(Utilities.EnumFrom<Iso3166>(241), Is.EqualTo(Iso3166.SH));
			Assert.That(Utilities.EnumFrom<Iso3166>(242), Is.EqualTo(Iso3166.TC));
			Assert.That(Utilities.EnumFrom<Iso3166>(243), Is.EqualTo(Iso3166.WF));
		}

		[Test]
		public void LeaderboardTypesTest()
		{
			Assert.That(Utilities.EnumFrom<LeaderboardTypes>(0)
					, Is.EqualTo(LeaderboardTypes.NotSupported));

			Assert.That(Utilities.EnumFrom<LeaderboardTypes>(1), Is.EqualTo(LeaderboardTypes.ByLevel));

			Assert.That(Utilities.EnumFrom<LeaderboardTypes>(2)
					, Is.EqualTo(LeaderboardTypes.ByPoints));
		}

		[Test]
		public void LifeMainTest()
		{
			Assert.That(Utilities.EnumFrom<LifeMain>(0), Is.EqualTo(LifeMain.Unknown));
			Assert.That(Utilities.EnumFrom<LifeMain>(1), Is.EqualTo(LifeMain.FamilyAndChildren));
			Assert.That(Utilities.EnumFrom<LifeMain>(2), Is.EqualTo(LifeMain.CareerAndMoney));
			Assert.That(Utilities.EnumFrom<LifeMain>(3), Is.EqualTo(LifeMain.Activities));
			Assert.That(Utilities.EnumFrom<LifeMain>(4), Is.EqualTo(LifeMain.ScienceAndResearch));
			Assert.That(Utilities.EnumFrom<LifeMain>(5), Is.EqualTo(LifeMain.ImprovingTheWorld));
			Assert.That(Utilities.EnumFrom<LifeMain>(6), Is.EqualTo(LifeMain.SelfDevelopment));
			Assert.That(Utilities.EnumFrom<LifeMain>(7), Is.EqualTo(LifeMain.BeautyAndArt));
			Assert.That(Utilities.EnumFrom<LifeMain>(8), Is.EqualTo(LifeMain.FameAndInfluence));
		}

		[Test]
		public void MainSectionTest()
		{
			Assert.That(Utilities.EnumFrom<MainSection>(0), Is.EqualTo(MainSection.NoSection));
			Assert.That(Utilities.EnumFrom<MainSection>(1), Is.EqualTo(MainSection.Photo));
			Assert.That(Utilities.EnumFrom<MainSection>(2), Is.EqualTo(MainSection.Post));
			Assert.That(Utilities.EnumFrom<MainSection>(3), Is.EqualTo(MainSection.Audio));
			Assert.That(Utilities.EnumFrom<MainSection>(4), Is.EqualTo(MainSection.Video));
			Assert.That(Utilities.EnumFrom<MainSection>(5), Is.EqualTo(MainSection.Goods));
		}

		[Test]
		public void MaritalStatusTest()
		{
			Assert.That(Utilities.EnumFrom<MaritalStatus>(1), Is.EqualTo(MaritalStatus.Single));
			Assert.That(Utilities.EnumFrom<MaritalStatus>(2), Is.EqualTo(MaritalStatus.Meets));
			Assert.That(Utilities.EnumFrom<MaritalStatus>(3), Is.EqualTo(MaritalStatus.Engaged));
			Assert.That(Utilities.EnumFrom<MaritalStatus>(4), Is.EqualTo(MaritalStatus.Married));

			Assert.That(Utilities.EnumFrom<MaritalStatus>(5)
					, Is.EqualTo(MaritalStatus.ItsComplicated));

			Assert.That(Utilities.EnumFrom<MaritalStatus>(6)
					, Is.EqualTo(MaritalStatus.TheActiveSearch));

			Assert.That(Utilities.EnumFrom<MaritalStatus>(7), Is.EqualTo(MaritalStatus.InLove));
		}

		[Test]
		public void MarketCurrencyIdTest()
		{
			Assert.That(Utilities.EnumFrom<MarketCurrencyId>(643), Is.EqualTo(MarketCurrencyId.Rub));
			Assert.That(Utilities.EnumFrom<MarketCurrencyId>(980), Is.EqualTo(MarketCurrencyId.Uah));
			Assert.That(Utilities.EnumFrom<MarketCurrencyId>(398), Is.EqualTo(MarketCurrencyId.Kzt));
			Assert.That(Utilities.EnumFrom<MarketCurrencyId>(978), Is.EqualTo(MarketCurrencyId.Eur));
			Assert.That(Utilities.EnumFrom<MarketCurrencyId>(840), Is.EqualTo(MarketCurrencyId.Usd));
		}

		[Test]
		public void MessageReadStateTest()
		{
			Assert.That(Utilities.EnumFrom<MessageReadState>(0)
					, Is.EqualTo(MessageReadState.Unreaded));

			Assert.That(Utilities.EnumFrom<MessageReadState>(1), Is.EqualTo(MessageReadState.Readed));
		}

		[Test]
		public void MessagesFilterTest()
		{
			Assert.That(Utilities.EnumFrom<MessagesFilter>(0), Is.EqualTo(MessagesFilter.All));
			Assert.That(Utilities.EnumFrom<MessagesFilter>(8), Is.EqualTo(MessagesFilter.Important));
		}

		[Test]
		public void MessageTypeTest()
		{
			Assert.That(Utilities.EnumFrom<MessageType>(0), Is.EqualTo(MessageType.Received));
			Assert.That(Utilities.EnumFrom<MessageType>(1), Is.EqualTo(MessageType.Sended));
		}

		[Test]
		public void PageAccessKindTest()
		{
			Assert.That(Utilities.EnumFrom<PageAccessKind>(0)
					, Is.EqualTo(PageAccessKind.OnlyAdministrators));

			Assert.That(Utilities.EnumFrom<PageAccessKind>(1), Is.EqualTo(PageAccessKind.OnlyMembers));

			Assert.That(Utilities.EnumFrom<PageAccessKind>(2)
					, Is.EqualTo(PageAccessKind.Unrestricted));
		}

		[Test]
		public void PeopleMainTest()
		{
			Assert.That(Utilities.EnumFrom<PeopleMain>(0), Is.EqualTo(PeopleMain.Unknown));
			Assert.That(Utilities.EnumFrom<PeopleMain>(1), Is.EqualTo(PeopleMain.MindAndCreativity));
			Assert.That(Utilities.EnumFrom<PeopleMain>(2), Is.EqualTo(PeopleMain.KindnessAndHonesty));
			Assert.That(Utilities.EnumFrom<PeopleMain>(3), Is.EqualTo(PeopleMain.HealthAndBeauty));
			Assert.That(Utilities.EnumFrom<PeopleMain>(4), Is.EqualTo(PeopleMain.PowerAndWealth));

			Assert.That(Utilities.EnumFrom<PeopleMain>(5)
					, Is.EqualTo(PeopleMain.CourageAndPersistence));

			Assert.That(Utilities.EnumFrom<PeopleMain>(6), Is.EqualTo(PeopleMain.HumorAndLoveForLife));
		}

		[Test]
		public void PoliticalPreferencesTest()
		{
			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(0)
					, Is.EqualTo(PoliticalPreferences.Unknown));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(1)
					, Is.EqualTo(PoliticalPreferences.Communist));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(2)
					, Is.EqualTo(PoliticalPreferences.Socialist));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(3)
					, Is.EqualTo(PoliticalPreferences.Moderate));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(4)
					, Is.EqualTo(PoliticalPreferences.Liberal));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(5)
					, Is.EqualTo(PoliticalPreferences.Conservative));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(6)
					, Is.EqualTo(PoliticalPreferences.Monarchist));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(7)
					, Is.EqualTo(PoliticalPreferences.Ultraconservative));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(8)
					, Is.EqualTo(PoliticalPreferences.Apathetic));

			Assert.That(Utilities.EnumFrom<PoliticalPreferences>(9)
					, Is.EqualTo(PoliticalPreferences.Libertarian));
		}

		[Test]
		public void ProductAvailabilityTest()
		{
			Assert.That(Utilities.EnumFrom<ProductAvailability>(0)
					, Is.EqualTo(ProductAvailability.Available));

			Assert.That(Utilities.EnumFrom<ProductAvailability>(1)
					, Is.EqualTo(ProductAvailability.Removed));

			Assert.That(Utilities.EnumFrom<ProductAvailability>(2)
					, Is.EqualTo(ProductAvailability.Unavailable));
		}

		[Test]
		public void ProductSortTest()
		{
			Assert.That(Utilities.EnumFrom<ProductSort>(0), Is.EqualTo(ProductSort.UserSort));
			Assert.That(Utilities.EnumFrom<ProductSort>(1), Is.EqualTo(ProductSort.ByAdd));
			Assert.That(Utilities.EnumFrom<ProductSort>(2), Is.EqualTo(ProductSort.ByCost));
			Assert.That(Utilities.EnumFrom<ProductSort>(3), Is.EqualTo(ProductSort.ByPopularity));
		}

		[Test]
		public void RelationTypeTest()
		{
			Assert.That(Utilities.EnumFrom<RelationType>(0), Is.EqualTo(RelationType.Unknown));
			Assert.That(Utilities.EnumFrom<RelationType>(1), Is.EqualTo(RelationType.NotMarried));
			Assert.That(Utilities.EnumFrom<RelationType>(2), Is.EqualTo(RelationType.HasFriend));
			Assert.That(Utilities.EnumFrom<RelationType>(3), Is.EqualTo(RelationType.Engaged));
			Assert.That(Utilities.EnumFrom<RelationType>(4), Is.EqualTo(RelationType.Married));
			Assert.That(Utilities.EnumFrom<RelationType>(5), Is.EqualTo(RelationType.ItsComplex));
			Assert.That(Utilities.EnumFrom<RelationType>(6), Is.EqualTo(RelationType.InActiveSearch));
			Assert.That(Utilities.EnumFrom<RelationType>(7), Is.EqualTo(RelationType.Amorous));
		}

		[Test]
		public void ReportReasonTest()
		{
			Assert.That(Utilities.EnumFrom<ReportReason>(0), Is.EqualTo(ReportReason.Spam));

			Assert.That(Utilities.EnumFrom<ReportReason>(1)
					, Is.EqualTo(ReportReason.ChildPornography));

			Assert.That(Utilities.EnumFrom<ReportReason>(2), Is.EqualTo(ReportReason.Extremism));
			Assert.That(Utilities.EnumFrom<ReportReason>(3), Is.EqualTo(ReportReason.Violence));
			Assert.That(Utilities.EnumFrom<ReportReason>(4), Is.EqualTo(ReportReason.DrugPropaganda));
			Assert.That(Utilities.EnumFrom<ReportReason>(5), Is.EqualTo(ReportReason.AdultMaterial));
			Assert.That(Utilities.EnumFrom<ReportReason>(6), Is.EqualTo(ReportReason.Abuse));
		}

		[Test]
		public void SexTest()
		{
			Assert.That(Utilities.EnumFrom<Sex>(0), Is.EqualTo(Sex.Unknown));
			Assert.That(Utilities.EnumFrom<Sex>(1), Is.EqualTo(Sex.Female));
			Assert.That(Utilities.EnumFrom<Sex>(2), Is.EqualTo(Sex.Male));
		}

		[Test]
		public void SortOrderByTest()
		{
			Assert.That(Utilities.EnumFrom<SortOrderBy>(0), Is.EqualTo(SortOrderBy.Desc));
			Assert.That(Utilities.EnumFrom<SortOrderBy>(1), Is.EqualTo(SortOrderBy.Asc));
		}

		[Test]
		public void UserSortTest()
		{
			Assert.That(Utilities.EnumFrom<UserSort>(0), Is.EqualTo(UserSort.ByPopularity));
			Assert.That(Utilities.EnumFrom<UserSort>(1), Is.EqualTo(UserSort.ByRegDate));
		}

		[Test]
		public void VideoSortTest()
		{
			Assert.That(Utilities.EnumFrom<VideoSort>(0), Is.EqualTo(VideoSort.AddedDate));
			Assert.That(Utilities.EnumFrom<VideoSort>(1), Is.EqualTo(VideoSort.Duration));
			Assert.That(Utilities.EnumFrom<VideoSort>(2), Is.EqualTo(VideoSort.Relevance));
		}

		[Test]
		public void VideoWidthTest()
		{
			Assert.That(Utilities.EnumFrom<VideoWidth>(130), Is.EqualTo(VideoWidth.Small130));
			Assert.That(Utilities.EnumFrom<VideoWidth>(160), Is.EqualTo(VideoWidth.Medium160));
			Assert.That(Utilities.EnumFrom<VideoWidth>(320), Is.EqualTo(VideoWidth.Large320));
		}

		[Test]
		public void VkObjectTypeTest()
		{
			Assert.That(Utilities.EnumFrom<VkObjectType>(0), Is.EqualTo(VkObjectType.User));
			Assert.That(Utilities.EnumFrom<VkObjectType>(1), Is.EqualTo(VkObjectType.Group));
			Assert.That(Utilities.EnumFrom<VkObjectType>(2), Is.EqualTo(VkObjectType.Application));
		}

		[Test]
		public void WallContentAccessTest()
		{
			Assert.That(Utilities.EnumFrom<WallContentAccess>(0), Is.EqualTo(WallContentAccess.Off));

			Assert.That(Utilities.EnumFrom<WallContentAccess>(1)
					, Is.EqualTo(WallContentAccess.Opened));

			Assert.That(Utilities.EnumFrom<WallContentAccess>(2)
					, Is.EqualTo(WallContentAccess.Restricted));

			Assert.That(Utilities.EnumFrom<WallContentAccess>(3)
					, Is.EqualTo(WallContentAccess.Closed));
		}
	}
}