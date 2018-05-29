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
			Assert.That(actual: Utilities.EnumFrom<AccessPages>(value: 0), expression: Is.EqualTo(expected: AccessPages.Leaders));
			Assert.That(actual: Utilities.EnumFrom<AccessPages>(value: 1), expression: Is.EqualTo(expected: AccessPages.Participants));
			Assert.That(actual: Utilities.EnumFrom<AccessPages>(value: 2), expression: Is.EqualTo(expected: AccessPages.All));
		}

		[Test]
		public void AddFriendStatusTest()
		{
			Assert.That(actual: Utilities.EnumFrom<AddFriendStatus>(value: 0), expression: Is.EqualTo(expected: AddFriendStatus.Unknown));
			Assert.That(actual: Utilities.EnumFrom<AddFriendStatus>(value: 1), expression: Is.EqualTo(expected: AddFriendStatus.Sended));
			Assert.That(actual: Utilities.EnumFrom<AddFriendStatus>(value: 2), expression: Is.EqualTo(expected: AddFriendStatus.Accepted));
			Assert.That(actual: Utilities.EnumFrom<AddFriendStatus>(value: 4), expression: Is.EqualTo(expected: AddFriendStatus.Resubmit));
		}

		[Test]
		public void AdminLevelTest()
		{
			Assert.That(actual: Utilities.EnumFrom<AdminLevel>(value: 1), expression: Is.EqualTo(expected: AdminLevel.Moderator));
			Assert.That(actual: Utilities.EnumFrom<AdminLevel>(value: 2), expression: Is.EqualTo(expected: AdminLevel.Editor));
			Assert.That(actual: Utilities.EnumFrom<AdminLevel>(value: 3), expression: Is.EqualTo(expected: AdminLevel.Administrator));
		}

		[Test]
		public void AttitudeTest()
		{
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 0), expression: Is.EqualTo(expected: Attitude.Unknown));
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 1), expression: Is.EqualTo(expected: Attitude.VeryNegative));
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 2), expression: Is.EqualTo(expected: Attitude.Negative));
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 3), expression: Is.EqualTo(expected: Attitude.Compromise));
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 4), expression: Is.EqualTo(expected: Attitude.Neutral));
			Assert.That(actual: Utilities.EnumFrom<Attitude>(value: 5), expression: Is.EqualTo(expected: Attitude.Positive));
		}

		[Test]
		public void AudioGenreTest()
		{
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 1), expression: Is.EqualTo(expected: AudioGenre.Rock));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 2), expression: Is.EqualTo(expected: AudioGenre.Pop));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 3), expression: Is.EqualTo(expected: AudioGenre.RapAndHipHop));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 4), expression: Is.EqualTo(expected: AudioGenre.EasyListening));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 5), expression: Is.EqualTo(expected: AudioGenre.DanceAndHouse));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 6), expression: Is.EqualTo(expected: AudioGenre.Instrumental));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 7), expression: Is.EqualTo(expected: AudioGenre.Metal));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 21), expression: Is.EqualTo(expected: AudioGenre.Alternative));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 8), expression: Is.EqualTo(expected: AudioGenre.Dubstep));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 1001), expression: Is.EqualTo(expected: AudioGenre.JazzAndBlues));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 10), expression: Is.EqualTo(expected: AudioGenre.DrumAndBass));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 11), expression: Is.EqualTo(expected: AudioGenre.Trance));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 12), expression: Is.EqualTo(expected: AudioGenre.Chanson));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 13), expression: Is.EqualTo(expected: AudioGenre.Ethnic));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 14), expression: Is.EqualTo(expected: AudioGenre.AcousticAndVocal));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 15), expression: Is.EqualTo(expected: AudioGenre.Reggae));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 16), expression: Is.EqualTo(expected: AudioGenre.Classical));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 17), expression: Is.EqualTo(expected: AudioGenre.IndiePop));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 19), expression: Is.EqualTo(expected: AudioGenre.Speech));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 22), expression: Is.EqualTo(expected: AudioGenre.ElectropopAndDisco));
			Assert.That(actual: Utilities.EnumFrom<AudioGenre>(value: 18), expression: Is.EqualTo(expected: AudioGenre.Other));
		}

		[Test]
		public void AudioSortTest()
		{
			Assert.That(actual: Utilities.EnumFrom<AudioSort>(value: 0), expression: Is.EqualTo(expected: AudioSort.AddedDate));
			Assert.That(actual: Utilities.EnumFrom<AudioSort>(value: 1), expression: Is.EqualTo(expected: AudioSort.Duration));
			Assert.That(actual: Utilities.EnumFrom<AudioSort>(value: 2), expression: Is.EqualTo(expected: AudioSort.Popularity));
		}

		[Test]
		public void BanReasonTest()
		{
			Assert.That(actual: Utilities.EnumFrom<BanReason>(value: 0), expression: Is.EqualTo(expected: BanReason.Other));
			Assert.That(actual: Utilities.EnumFrom<BanReason>(value: 1), expression: Is.EqualTo(expected: BanReason.Spam));
			Assert.That(actual: Utilities.EnumFrom<BanReason>(value: 2), expression: Is.EqualTo(expected: BanReason.VerbalAbuse));
			Assert.That(actual: Utilities.EnumFrom<BanReason>(value: 3), expression: Is.EqualTo(expected: BanReason.StrongLanguage));
			Assert.That(actual: Utilities.EnumFrom<BanReason>(value: 4), expression: Is.EqualTo(expected: BanReason.IrrelevantMessages));
		}

		[Test]
		public void BirthdayVisibilityTest()
		{
			Assert.That(actual: Utilities.EnumFrom<BirthdayVisibility>(value: 0)
					, expression: Is.EqualTo(expected: BirthdayVisibility.Invisible));

			Assert.That(actual: Utilities.EnumFrom<BirthdayVisibility>(value: 1)
					, expression: Is.EqualTo(expected: BirthdayVisibility.Full));

			Assert.That(actual: Utilities.EnumFrom<BirthdayVisibility>(value: 2)
					, expression: Is.EqualTo(expected: BirthdayVisibility.OnlyDayAndMonth));
		}

		[Test]
		public void ContentAccessTest()
		{
			Assert.That(actual: Utilities.EnumFrom<ContentAccess>(value: 0), expression: Is.EqualTo(expected: ContentAccess.Off));
			Assert.That(actual: Utilities.EnumFrom<ContentAccess>(value: 1), expression: Is.EqualTo(expected: ContentAccess.Opened));
			Assert.That(actual: Utilities.EnumFrom<ContentAccess>(value: 2), expression: Is.EqualTo(expected: ContentAccess.Restricted));
		}

		[Test]
		public void DeleteFriendStatusTest()
		{
			Assert.That(actual: Utilities.EnumFrom<DeleteFriendStatus>(value: 0)
					, expression: Is.EqualTo(expected: DeleteFriendStatus.Unknown));

			Assert.That(actual: Utilities.EnumFrom<DeleteFriendStatus>(value: 1)
					, expression: Is.EqualTo(expected: DeleteFriendStatus.UserIsDeleted));

			Assert.That(actual: Utilities.EnumFrom<DeleteFriendStatus>(value: 2)
					, expression: Is.EqualTo(expected: DeleteFriendStatus.RequestRejected));

			Assert.That(actual: Utilities.EnumFrom<DeleteFriendStatus>(value: 3)
					, expression: Is.EqualTo(expected: DeleteFriendStatus.RecommendationDeleted));
		}

		[Test]
		public void DocFilterTest()
		{
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 1), expression: Is.EqualTo(expected: DocFilter.Text));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 2), expression: Is.EqualTo(expected: DocFilter.Archive));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 3), expression: Is.EqualTo(expected: DocFilter.Gif));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 4), expression: Is.EqualTo(expected: DocFilter.Image));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 5), expression: Is.EqualTo(expected: DocFilter.Audio));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 6), expression: Is.EqualTo(expected: DocFilter.Video));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 7), expression: Is.EqualTo(expected: DocFilter.EBook));
			Assert.That(actual: Utilities.EnumFrom<DocFilter>(value: 8), expression: Is.EqualTo(expected: DocFilter.Unknown));
		}

		[Test]
		public void FriendStatusTest()
		{
			Assert.That(actual: Utilities.EnumFrom<FriendStatus>(value: 0), expression: Is.EqualTo(expected: FriendStatus.NotFriend));
			Assert.That(actual: Utilities.EnumFrom<FriendStatus>(value: 1), expression: Is.EqualTo(expected: FriendStatus.OutputRequest));
			Assert.That(actual: Utilities.EnumFrom<FriendStatus>(value: 2), expression: Is.EqualTo(expected: FriendStatus.InputRequest));
			Assert.That(actual: Utilities.EnumFrom<FriendStatus>(value: 3), expression: Is.EqualTo(expected: FriendStatus.Friend));
		}

		[Test]
		public void GiftPrivacyTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GiftPrivacy>(value: 0), expression: Is.EqualTo(expected: GiftPrivacy.All));

			Assert.That(actual: Utilities.EnumFrom<GiftPrivacy>(value: 1)
					, expression: Is.EqualTo(expected: GiftPrivacy.NameAllMessageUser));

			Assert.That(actual: Utilities.EnumFrom<GiftPrivacy>(value: 2)
					, expression: Is.EqualTo(expected: GiftPrivacy.NameHideMessageUser));
		}

		[Test]
		public void GroupAccessTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GroupAccess>(value: 0), expression: Is.EqualTo(expected: GroupAccess.Open));
			Assert.That(actual: Utilities.EnumFrom<GroupAccess>(value: 1), expression: Is.EqualTo(expected: GroupAccess.Closed));
			Assert.That(actual: Utilities.EnumFrom<GroupAccess>(value: 2), expression: Is.EqualTo(expected: GroupAccess.Private));
		}

		[Test]
		public void GroupPublicityTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GroupPublicity>(value: 0), expression: Is.EqualTo(expected: GroupPublicity.Public));
			Assert.That(actual: Utilities.EnumFrom<GroupPublicity>(value: 1), expression: Is.EqualTo(expected: GroupPublicity.Closed));
			Assert.That(actual: Utilities.EnumFrom<GroupPublicity>(value: 2), expression: Is.EqualTo(expected: GroupPublicity.Private));
		}

		[Test]
		public void GroupSortTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 0), expression: Is.EqualTo(expected: GroupSort.Normal));
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 1), expression: Is.EqualTo(expected: GroupSort.Growth));
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 2), expression: Is.EqualTo(expected: GroupSort.Relation));
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 3), expression: Is.EqualTo(expected: GroupSort.Likes));
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 4), expression: Is.EqualTo(expected: GroupSort.Comments));
			Assert.That(actual: Utilities.EnumFrom<GroupSort>(value: 5), expression: Is.EqualTo(expected: GroupSort.Records));
		}

		[Test]
		public void GroupSubjectsTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 1), expression: Is.EqualTo(expected: GroupSubjects.AutoMoto));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 2), expression: Is.EqualTo(expected: GroupSubjects.Leisure));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 3), expression: Is.EqualTo(expected: GroupSubjects.Business));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 4)
					, expression: Is.EqualTo(expected: GroupSubjects.DomesticAnimals));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 5), expression: Is.EqualTo(expected: GroupSubjects.Health));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 6), expression: Is.EqualTo(expected: GroupSubjects.MeetAndChat));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 7), expression: Is.EqualTo(expected: GroupSubjects.Games));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 8), expression: Is.EqualTo(expected: GroupSubjects.It));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 9), expression: Is.EqualTo(expected: GroupSubjects.Cinema));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 10)
					, expression: Is.EqualTo(expected: GroupSubjects.BeautyAndFashion));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 11), expression: Is.EqualTo(expected: GroupSubjects.Cookery));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 12)
					, expression: Is.EqualTo(expected: GroupSubjects.CultureAndArt));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 13), expression: Is.EqualTo(expected: GroupSubjects.References));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 14)
					, expression: Is.EqualTo(expected: GroupSubjects.MobileTelephonyAndInternet));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 15), expression: Is.EqualTo(expected: GroupSubjects.Music));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 16)
					, expression: Is.EqualTo(expected: GroupSubjects.ScienceAndTechnology));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 17), expression: Is.EqualTo(expected: GroupSubjects.RealEstate));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 18), expression: Is.EqualTo(expected: GroupSubjects.NewsAndMedia));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 19), expression: Is.EqualTo(expected: GroupSubjects.Security));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 20), expression: Is.EqualTo(expected: GroupSubjects.Forming));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 21)
					, expression: Is.EqualTo(expected: GroupSubjects.ConstructionAndRepair));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 22), expression: Is.EqualTo(expected: GroupSubjects.Policy));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 23), expression: Is.EqualTo(expected: GroupSubjects.FoodItems));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 24), expression: Is.EqualTo(expected: GroupSubjects.Industry));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 25), expression: Is.EqualTo(expected: GroupSubjects.Travels));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 26), expression: Is.EqualTo(expected: GroupSubjects.Job));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 27)
					, expression: Is.EqualTo(expected: GroupSubjects.Entertainment));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 28), expression: Is.EqualTo(expected: GroupSubjects.Religion));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 29)
					, expression: Is.EqualTo(expected: GroupSubjects.HomeAndFamily));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 30), expression: Is.EqualTo(expected: GroupSubjects.Sports));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 31), expression: Is.EqualTo(expected: GroupSubjects.Coverage));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 32), expression: Is.EqualTo(expected: GroupSubjects.Tv));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 33)
					, expression: Is.EqualTo(expected: GroupSubjects.GoodsAndServices));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 34)
					, expression: Is.EqualTo(expected: GroupSubjects.InterestsAndHobbies));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 35), expression: Is.EqualTo(expected: GroupSubjects.Finances));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 36), expression: Is.EqualTo(expected: GroupSubjects.Photography));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 37), expression: Is.EqualTo(expected: GroupSubjects.Esoterics));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 38)
					, expression: Is.EqualTo(expected: GroupSubjects.ElectronicsAndAppliances));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 39), expression: Is.EqualTo(expected: GroupSubjects.Erotica));
			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 40), expression: Is.EqualTo(expected: GroupSubjects.Humor));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 41)
					, expression: Is.EqualTo(expected: GroupSubjects.SocietyHumanities));

			Assert.That(actual: Utilities.EnumFrom<GroupSubjects>(value: 42)
					, expression: Is.EqualTo(expected: GroupSubjects.DesignAndGraphics));
		}

		[Test]
		public void GroupSubTypeTest()
		{
			Assert.That(actual: Utilities.EnumFrom<GroupSubType>(value: 1)
					, expression: Is.EqualTo(expected: GroupSubType.PlaceOrSmallCompany));

			Assert.That(actual: Utilities.EnumFrom<GroupSubType>(value: 2)
					, expression: Is.EqualTo(expected: GroupSubType.OrganizationOrWebsite));

			Assert.That(actual: Utilities.EnumFrom<GroupSubType>(value: 3), expression: Is.EqualTo(expected: GroupSubType.PersonOrTeam));

			Assert.That(actual: Utilities.EnumFrom<GroupSubType>(value: 4)
					, expression: Is.EqualTo(expected: GroupSubType.ProductOrProducts));
		}

		[Test]
		public void Iso3166Test()
		{
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 0), expression: Is.EqualTo(expected: Iso3166.AU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 1), expression: Is.EqualTo(expected: Iso3166.AT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 2), expression: Is.EqualTo(expected: Iso3166.AZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 3), expression: Is.EqualTo(expected: Iso3166.AX));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 4), expression: Is.EqualTo(expected: Iso3166.AL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 5), expression: Is.EqualTo(expected: Iso3166.DZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 6), expression: Is.EqualTo(expected: Iso3166.UM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 7), expression: Is.EqualTo(expected: Iso3166.VI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 8), expression: Is.EqualTo(expected: Iso3166.AS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 9), expression: Is.EqualTo(expected: Iso3166.AI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 10), expression: Is.EqualTo(expected: Iso3166.AO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 11), expression: Is.EqualTo(expected: Iso3166.AD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 12), expression: Is.EqualTo(expected: Iso3166.AQ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 13), expression: Is.EqualTo(expected: Iso3166.AG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 14), expression: Is.EqualTo(expected: Iso3166.AR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 15), expression: Is.EqualTo(expected: Iso3166.AM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 16), expression: Is.EqualTo(expected: Iso3166.AW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 17), expression: Is.EqualTo(expected: Iso3166.AF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 18), expression: Is.EqualTo(expected: Iso3166.BS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 19), expression: Is.EqualTo(expected: Iso3166.BD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 20), expression: Is.EqualTo(expected: Iso3166.BB));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 21), expression: Is.EqualTo(expected: Iso3166.BH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 22), expression: Is.EqualTo(expected: Iso3166.BZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 23), expression: Is.EqualTo(expected: Iso3166.BY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 24), expression: Is.EqualTo(expected: Iso3166.BE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 25), expression: Is.EqualTo(expected: Iso3166.BJ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 26), expression: Is.EqualTo(expected: Iso3166.BM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 27), expression: Is.EqualTo(expected: Iso3166.BG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 28), expression: Is.EqualTo(expected: Iso3166.BO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 29), expression: Is.EqualTo(expected: Iso3166.BA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 30), expression: Is.EqualTo(expected: Iso3166.BW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 31), expression: Is.EqualTo(expected: Iso3166.BR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 32), expression: Is.EqualTo(expected: Iso3166.IO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 33), expression: Is.EqualTo(expected: Iso3166.VG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 34), expression: Is.EqualTo(expected: Iso3166.BN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 35), expression: Is.EqualTo(expected: Iso3166.BF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 36), expression: Is.EqualTo(expected: Iso3166.BI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 37), expression: Is.EqualTo(expected: Iso3166.BT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 38), expression: Is.EqualTo(expected: Iso3166.VU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 39), expression: Is.EqualTo(expected: Iso3166.VA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 40), expression: Is.EqualTo(expected: Iso3166.GB));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 41), expression: Is.EqualTo(expected: Iso3166.HU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 42), expression: Is.EqualTo(expected: Iso3166.VE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 43), expression: Is.EqualTo(expected: Iso3166.TL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 44), expression: Is.EqualTo(expected: Iso3166.VN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 45), expression: Is.EqualTo(expected: Iso3166.GA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 46), expression: Is.EqualTo(expected: Iso3166.HT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 47), expression: Is.EqualTo(expected: Iso3166.GY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 48), expression: Is.EqualTo(expected: Iso3166.GM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 49), expression: Is.EqualTo(expected: Iso3166.GH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 50), expression: Is.EqualTo(expected: Iso3166.GP));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 51), expression: Is.EqualTo(expected: Iso3166.GT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 52), expression: Is.EqualTo(expected: Iso3166.GN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 53), expression: Is.EqualTo(expected: Iso3166.GW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 54), expression: Is.EqualTo(expected: Iso3166.DE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 55), expression: Is.EqualTo(expected: Iso3166.GI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 56), expression: Is.EqualTo(expected: Iso3166.HN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 57), expression: Is.EqualTo(expected: Iso3166.HK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 58), expression: Is.EqualTo(expected: Iso3166.GD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 59), expression: Is.EqualTo(expected: Iso3166.GL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 60), expression: Is.EqualTo(expected: Iso3166.GR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 61), expression: Is.EqualTo(expected: Iso3166.GE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 62), expression: Is.EqualTo(expected: Iso3166.GU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 63), expression: Is.EqualTo(expected: Iso3166.DK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 64), expression: Is.EqualTo(expected: Iso3166.CD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 65), expression: Is.EqualTo(expected: Iso3166.DJ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 66), expression: Is.EqualTo(expected: Iso3166.DM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 67), expression: Is.EqualTo(expected: Iso3166.DO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 68), expression: Is.EqualTo(expected: Iso3166.EU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 69), expression: Is.EqualTo(expected: Iso3166.EG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 70), expression: Is.EqualTo(expected: Iso3166.ZM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 71), expression: Is.EqualTo(expected: Iso3166.EH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 72), expression: Is.EqualTo(expected: Iso3166.ZW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 73), expression: Is.EqualTo(expected: Iso3166.IL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 74), expression: Is.EqualTo(expected: Iso3166.IN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 75), expression: Is.EqualTo(expected: Iso3166.ID));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 76), expression: Is.EqualTo(expected: Iso3166.JO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 77), expression: Is.EqualTo(expected: Iso3166.IQ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 78), expression: Is.EqualTo(expected: Iso3166.IR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 79), expression: Is.EqualTo(expected: Iso3166.IE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 80), expression: Is.EqualTo(expected: Iso3166.IS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 81), expression: Is.EqualTo(expected: Iso3166.ES));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 82), expression: Is.EqualTo(expected: Iso3166.IT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 83), expression: Is.EqualTo(expected: Iso3166.YE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 84), expression: Is.EqualTo(expected: Iso3166.KP));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 85), expression: Is.EqualTo(expected: Iso3166.CV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 86), expression: Is.EqualTo(expected: Iso3166.KZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 87), expression: Is.EqualTo(expected: Iso3166.KY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 88), expression: Is.EqualTo(expected: Iso3166.KH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 89), expression: Is.EqualTo(expected: Iso3166.CM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 90), expression: Is.EqualTo(expected: Iso3166.CA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 91), expression: Is.EqualTo(expected: Iso3166.QA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 92), expression: Is.EqualTo(expected: Iso3166.KE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 93), expression: Is.EqualTo(expected: Iso3166.CY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 94), expression: Is.EqualTo(expected: Iso3166.KG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 95), expression: Is.EqualTo(expected: Iso3166.KI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 96), expression: Is.EqualTo(expected: Iso3166.CN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 97), expression: Is.EqualTo(expected: Iso3166.CC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 98), expression: Is.EqualTo(expected: Iso3166.CO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 99), expression: Is.EqualTo(expected: Iso3166.KM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 100), expression: Is.EqualTo(expected: Iso3166.CR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 101), expression: Is.EqualTo(expected: Iso3166.CI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 102), expression: Is.EqualTo(expected: Iso3166.CU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 103), expression: Is.EqualTo(expected: Iso3166.KW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 104), expression: Is.EqualTo(expected: Iso3166.LA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 105), expression: Is.EqualTo(expected: Iso3166.LV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 106), expression: Is.EqualTo(expected: Iso3166.LS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 107), expression: Is.EqualTo(expected: Iso3166.LR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 108), expression: Is.EqualTo(expected: Iso3166.LB));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 109), expression: Is.EqualTo(expected: Iso3166.LY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 110), expression: Is.EqualTo(expected: Iso3166.LT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 111), expression: Is.EqualTo(expected: Iso3166.LI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 112), expression: Is.EqualTo(expected: Iso3166.LU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 113), expression: Is.EqualTo(expected: Iso3166.MU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 114), expression: Is.EqualTo(expected: Iso3166.MR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 115), expression: Is.EqualTo(expected: Iso3166.MG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 116), expression: Is.EqualTo(expected: Iso3166.YT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 117), expression: Is.EqualTo(expected: Iso3166.MO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 118), expression: Is.EqualTo(expected: Iso3166.MK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 119), expression: Is.EqualTo(expected: Iso3166.MW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 120), expression: Is.EqualTo(expected: Iso3166.MY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 121), expression: Is.EqualTo(expected: Iso3166.ML));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 122), expression: Is.EqualTo(expected: Iso3166.MV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 123), expression: Is.EqualTo(expected: Iso3166.MT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 124), expression: Is.EqualTo(expected: Iso3166.MA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 125), expression: Is.EqualTo(expected: Iso3166.MQ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 126), expression: Is.EqualTo(expected: Iso3166.MH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 127), expression: Is.EqualTo(expected: Iso3166.MX));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 128), expression: Is.EqualTo(expected: Iso3166.MZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 129), expression: Is.EqualTo(expected: Iso3166.MD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 130), expression: Is.EqualTo(expected: Iso3166.MC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 131), expression: Is.EqualTo(expected: Iso3166.MN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 132), expression: Is.EqualTo(expected: Iso3166.MS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 133), expression: Is.EqualTo(expected: Iso3166.MM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 134), expression: Is.EqualTo(expected: Iso3166.NA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 135), expression: Is.EqualTo(expected: Iso3166.NR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 136), expression: Is.EqualTo(expected: Iso3166.NP));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 137), expression: Is.EqualTo(expected: Iso3166.NE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 138), expression: Is.EqualTo(expected: Iso3166.NG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 139), expression: Is.EqualTo(expected: Iso3166.AN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 140), expression: Is.EqualTo(expected: Iso3166.NL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 141), expression: Is.EqualTo(expected: Iso3166.NI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 142), expression: Is.EqualTo(expected: Iso3166.NU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 143), expression: Is.EqualTo(expected: Iso3166.NC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 144), expression: Is.EqualTo(expected: Iso3166.NZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 145), expression: Is.EqualTo(expected: Iso3166.NO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 146), expression: Is.EqualTo(expected: Iso3166.AE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 147), expression: Is.EqualTo(expected: Iso3166.OM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 148), expression: Is.EqualTo(expected: Iso3166.CX));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 149), expression: Is.EqualTo(expected: Iso3166.CK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 150), expression: Is.EqualTo(expected: Iso3166.HM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 151), expression: Is.EqualTo(expected: Iso3166.PK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 152), expression: Is.EqualTo(expected: Iso3166.PW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 153), expression: Is.EqualTo(expected: Iso3166.PS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 154), expression: Is.EqualTo(expected: Iso3166.PA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 155), expression: Is.EqualTo(expected: Iso3166.PG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 156), expression: Is.EqualTo(expected: Iso3166.PY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 157), expression: Is.EqualTo(expected: Iso3166.PE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 158), expression: Is.EqualTo(expected: Iso3166.PN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 159), expression: Is.EqualTo(expected: Iso3166.PL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 160), expression: Is.EqualTo(expected: Iso3166.PT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 161), expression: Is.EqualTo(expected: Iso3166.PR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 162), expression: Is.EqualTo(expected: Iso3166.CG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 163), expression: Is.EqualTo(expected: Iso3166.RE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 164), expression: Is.EqualTo(expected: Iso3166.RU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 165), expression: Is.EqualTo(expected: Iso3166.RW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 166), expression: Is.EqualTo(expected: Iso3166.RO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 167), expression: Is.EqualTo(expected: Iso3166.US));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 168), expression: Is.EqualTo(expected: Iso3166.SV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 169), expression: Is.EqualTo(expected: Iso3166.WS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 170), expression: Is.EqualTo(expected: Iso3166.SM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 171), expression: Is.EqualTo(expected: Iso3166.ST));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 172), expression: Is.EqualTo(expected: Iso3166.SA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 173), expression: Is.EqualTo(expected: Iso3166.SZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 174), expression: Is.EqualTo(expected: Iso3166.SJ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 175), expression: Is.EqualTo(expected: Iso3166.MP));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 176), expression: Is.EqualTo(expected: Iso3166.SC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 177), expression: Is.EqualTo(expected: Iso3166.SN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 178), expression: Is.EqualTo(expected: Iso3166.VC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 179), expression: Is.EqualTo(expected: Iso3166.KN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 180), expression: Is.EqualTo(expected: Iso3166.LC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 181), expression: Is.EqualTo(expected: Iso3166.PM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 182), expression: Is.EqualTo(expected: Iso3166.RS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 183), expression: Is.EqualTo(expected: Iso3166.CS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 184), expression: Is.EqualTo(expected: Iso3166.SG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 185), expression: Is.EqualTo(expected: Iso3166.SY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 186), expression: Is.EqualTo(expected: Iso3166.SK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 187), expression: Is.EqualTo(expected: Iso3166.SI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 188), expression: Is.EqualTo(expected: Iso3166.SB));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 189), expression: Is.EqualTo(expected: Iso3166.SO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 190), expression: Is.EqualTo(expected: Iso3166.SD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 191), expression: Is.EqualTo(expected: Iso3166.SR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 192), expression: Is.EqualTo(expected: Iso3166.SL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 193), expression: Is.EqualTo(expected: Iso3166.SU));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 194), expression: Is.EqualTo(expected: Iso3166.TJ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 195), expression: Is.EqualTo(expected: Iso3166.TH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 196), expression: Is.EqualTo(expected: Iso3166.TW));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 197), expression: Is.EqualTo(expected: Iso3166.TZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 198), expression: Is.EqualTo(expected: Iso3166.TG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 199), expression: Is.EqualTo(expected: Iso3166.TK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 200), expression: Is.EqualTo(expected: Iso3166.TO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 201), expression: Is.EqualTo(expected: Iso3166.TT));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 202), expression: Is.EqualTo(expected: Iso3166.TV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 203), expression: Is.EqualTo(expected: Iso3166.TN));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 204), expression: Is.EqualTo(expected: Iso3166.TM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 205), expression: Is.EqualTo(expected: Iso3166.TR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 206), expression: Is.EqualTo(expected: Iso3166.UG));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 207), expression: Is.EqualTo(expected: Iso3166.UZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 208), expression: Is.EqualTo(expected: Iso3166.UA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 209), expression: Is.EqualTo(expected: Iso3166.UY));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 210), expression: Is.EqualTo(expected: Iso3166.FO));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 211), expression: Is.EqualTo(expected: Iso3166.FM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 212), expression: Is.EqualTo(expected: Iso3166.FJ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 213), expression: Is.EqualTo(expected: Iso3166.PH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 214), expression: Is.EqualTo(expected: Iso3166.FI));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 215), expression: Is.EqualTo(expected: Iso3166.FK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 216), expression: Is.EqualTo(expected: Iso3166.FR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 217), expression: Is.EqualTo(expected: Iso3166.GF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 218), expression: Is.EqualTo(expected: Iso3166.PF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 219), expression: Is.EqualTo(expected: Iso3166.TF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 220), expression: Is.EqualTo(expected: Iso3166.HR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 221), expression: Is.EqualTo(expected: Iso3166.CF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 222), expression: Is.EqualTo(expected: Iso3166.TD));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 223), expression: Is.EqualTo(expected: Iso3166.ME));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 224), expression: Is.EqualTo(expected: Iso3166.CZ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 225), expression: Is.EqualTo(expected: Iso3166.CL));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 226), expression: Is.EqualTo(expected: Iso3166.CH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 227), expression: Is.EqualTo(expected: Iso3166.SE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 228), expression: Is.EqualTo(expected: Iso3166.LK));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 229), expression: Is.EqualTo(expected: Iso3166.EC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 230), expression: Is.EqualTo(expected: Iso3166.GQ));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 231), expression: Is.EqualTo(expected: Iso3166.ER));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 232), expression: Is.EqualTo(expected: Iso3166.EE));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 233), expression: Is.EqualTo(expected: Iso3166.ET));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 234), expression: Is.EqualTo(expected: Iso3166.ZA));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 235), expression: Is.EqualTo(expected: Iso3166.KR));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 236), expression: Is.EqualTo(expected: Iso3166.GS));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 237), expression: Is.EqualTo(expected: Iso3166.JM));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 238), expression: Is.EqualTo(expected: Iso3166.JP));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 239), expression: Is.EqualTo(expected: Iso3166.BV));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 240), expression: Is.EqualTo(expected: Iso3166.NF));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 241), expression: Is.EqualTo(expected: Iso3166.SH));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 242), expression: Is.EqualTo(expected: Iso3166.TC));
			Assert.That(actual: Utilities.EnumFrom<Iso3166>(value: 243), expression: Is.EqualTo(expected: Iso3166.WF));
		}

		[Test]
		public void LeaderboardTypesTest()
		{
			Assert.That(actual: Utilities.EnumFrom<LeaderboardTypes>(value: 0)
					, expression: Is.EqualTo(expected: LeaderboardTypes.NotSupported));

			Assert.That(actual: Utilities.EnumFrom<LeaderboardTypes>(value: 1), expression: Is.EqualTo(expected: LeaderboardTypes.ByLevel));

			Assert.That(actual: Utilities.EnumFrom<LeaderboardTypes>(value: 2)
					, expression: Is.EqualTo(expected: LeaderboardTypes.ByPoints));
		}

		[Test]
		public void LifeMainTest()
		{
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 0), expression: Is.EqualTo(expected: LifeMain.Unknown));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 1), expression: Is.EqualTo(expected: LifeMain.FamilyAndChildren));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 2), expression: Is.EqualTo(expected: LifeMain.CareerAndMoney));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 3), expression: Is.EqualTo(expected: LifeMain.Activities));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 4), expression: Is.EqualTo(expected: LifeMain.ScienceAndResearch));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 5), expression: Is.EqualTo(expected: LifeMain.ImprovingTheWorld));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 6), expression: Is.EqualTo(expected: LifeMain.SelfDevelopment));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 7), expression: Is.EqualTo(expected: LifeMain.BeautyAndArt));
			Assert.That(actual: Utilities.EnumFrom<LifeMain>(value: 8), expression: Is.EqualTo(expected: LifeMain.FameAndInfluence));
		}

		[Test]
		public void MainSectionTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 0), expression: Is.EqualTo(expected: MainSection.NoSection));
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 1), expression: Is.EqualTo(expected: MainSection.Photo));
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 2), expression: Is.EqualTo(expected: MainSection.Post));
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 3), expression: Is.EqualTo(expected: MainSection.Audio));
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 4), expression: Is.EqualTo(expected: MainSection.Video));
			Assert.That(actual: Utilities.EnumFrom<MainSection>(value: 5), expression: Is.EqualTo(expected: MainSection.Goods));
		}

		[Test]
		public void MaritalStatusTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 1), expression: Is.EqualTo(expected: MaritalStatus.Single));
			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 2), expression: Is.EqualTo(expected: MaritalStatus.Meets));
			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 3), expression: Is.EqualTo(expected: MaritalStatus.Engaged));
			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 4), expression: Is.EqualTo(expected: MaritalStatus.Married));

			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 5)
					, expression: Is.EqualTo(expected: MaritalStatus.ItsComplicated));

			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 6)
					, expression: Is.EqualTo(expected: MaritalStatus.TheActiveSearch));

			Assert.That(actual: Utilities.EnumFrom<MaritalStatus>(value: 7), expression: Is.EqualTo(expected: MaritalStatus.InLove));
		}

		[Test]
		public void MarketCurrencyIdTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MarketCurrencyId>(value: 643), expression: Is.EqualTo(expected: MarketCurrencyId.Rub));
			Assert.That(actual: Utilities.EnumFrom<MarketCurrencyId>(value: 980), expression: Is.EqualTo(expected: MarketCurrencyId.Uah));
			Assert.That(actual: Utilities.EnumFrom<MarketCurrencyId>(value: 398), expression: Is.EqualTo(expected: MarketCurrencyId.Kzt));
			Assert.That(actual: Utilities.EnumFrom<MarketCurrencyId>(value: 978), expression: Is.EqualTo(expected: MarketCurrencyId.Eur));
			Assert.That(actual: Utilities.EnumFrom<MarketCurrencyId>(value: 840), expression: Is.EqualTo(expected: MarketCurrencyId.Usd));
		}

		[Test]
		public void MessageReadStateTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MessageReadState>(value: 0)
					, expression: Is.EqualTo(expected: MessageReadState.Unreaded));

			Assert.That(actual: Utilities.EnumFrom<MessageReadState>(value: 1), expression: Is.EqualTo(expected: MessageReadState.Readed));
		}

		[Test]
		public void MessagesFilterTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MessagesFilter>(value: 0), expression: Is.EqualTo(expected: MessagesFilter.All));
			Assert.That(actual: Utilities.EnumFrom<MessagesFilter>(value: 8), expression: Is.EqualTo(expected: MessagesFilter.Important));
		}

		[Test]
		public void MessageTypeTest()
		{
			Assert.That(actual: Utilities.EnumFrom<MessageType>(value: 0), expression: Is.EqualTo(expected: MessageType.Received));
			Assert.That(actual: Utilities.EnumFrom<MessageType>(value: 1), expression: Is.EqualTo(expected: MessageType.Sended));
		}

		[Test]
		public void PageAccessKindTest()
		{
			Assert.That(actual: Utilities.EnumFrom<PageAccessKind>(value: 0)
					, expression: Is.EqualTo(expected: PageAccessKind.OnlyAdministrators));

			Assert.That(actual: Utilities.EnumFrom<PageAccessKind>(value: 1), expression: Is.EqualTo(expected: PageAccessKind.OnlyMembers));

			Assert.That(actual: Utilities.EnumFrom<PageAccessKind>(value: 2)
					, expression: Is.EqualTo(expected: PageAccessKind.Unrestricted));
		}

		[Test]
		public void PeopleMainTest()
		{
			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 0), expression: Is.EqualTo(expected: PeopleMain.Unknown));
			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 1), expression: Is.EqualTo(expected: PeopleMain.MindAndCreativity));
			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 2), expression: Is.EqualTo(expected: PeopleMain.KindnessAndHonesty));
			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 3), expression: Is.EqualTo(expected: PeopleMain.HealthAndBeauty));
			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 4), expression: Is.EqualTo(expected: PeopleMain.PowerAndWealth));

			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 5)
					, expression: Is.EqualTo(expected: PeopleMain.CourageAndPersistence));

			Assert.That(actual: Utilities.EnumFrom<PeopleMain>(value: 6), expression: Is.EqualTo(expected: PeopleMain.HumorAndLoveForLife));
		}

		[Test]
		public void PoliticalPreferencesTest()
		{
			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 0)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Unknown));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 1)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Communist));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 2)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Socialist));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 3)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Moderate));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 4)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Liberal));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 5)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Conservative));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 6)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Monarchist));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 7)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Ultraconservative));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 8)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Apathetic));

			Assert.That(actual: Utilities.EnumFrom<PoliticalPreferences>(value: 9)
					, expression: Is.EqualTo(expected: PoliticalPreferences.Libertarian));
		}

		[Test]
		public void ProductAvailabilityTest()
		{
			Assert.That(actual: Utilities.EnumFrom<ProductAvailability>(value: 0)
					, expression: Is.EqualTo(expected: ProductAvailability.Available));

			Assert.That(actual: Utilities.EnumFrom<ProductAvailability>(value: 1)
					, expression: Is.EqualTo(expected: ProductAvailability.Removed));

			Assert.That(actual: Utilities.EnumFrom<ProductAvailability>(value: 2)
					, expression: Is.EqualTo(expected: ProductAvailability.Unavailable));
		}

		[Test]
		public void ProductSortTest()
		{
			Assert.That(actual: Utilities.EnumFrom<ProductSort>(value: 0), expression: Is.EqualTo(expected: ProductSort.UserSort));
			Assert.That(actual: Utilities.EnumFrom<ProductSort>(value: 1), expression: Is.EqualTo(expected: ProductSort.ByAdd));
			Assert.That(actual: Utilities.EnumFrom<ProductSort>(value: 2), expression: Is.EqualTo(expected: ProductSort.ByCost));
			Assert.That(actual: Utilities.EnumFrom<ProductSort>(value: 3), expression: Is.EqualTo(expected: ProductSort.ByPopularity));
		}

		[Test]
		public void RelationTypeTest()
		{
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 0), expression: Is.EqualTo(expected: RelationType.Unknown));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 1), expression: Is.EqualTo(expected: RelationType.NotMarried));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 2), expression: Is.EqualTo(expected: RelationType.HasFriend));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 3), expression: Is.EqualTo(expected: RelationType.Engaged));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 4), expression: Is.EqualTo(expected: RelationType.Married));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 5), expression: Is.EqualTo(expected: RelationType.ItsComplex));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 6), expression: Is.EqualTo(expected: RelationType.InActiveSearch));
			Assert.That(actual: Utilities.EnumFrom<RelationType>(value: 7), expression: Is.EqualTo(expected: RelationType.Amorous));
		}

		[Test]
		public void ReportReasonTest()
		{
			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 0), expression: Is.EqualTo(expected: ReportReason.Spam));

			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 1)
					, expression: Is.EqualTo(expected: ReportReason.ChildPornography));

			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 2), expression: Is.EqualTo(expected: ReportReason.Extremism));
			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 3), expression: Is.EqualTo(expected: ReportReason.Violence));
			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 4), expression: Is.EqualTo(expected: ReportReason.DrugPropaganda));
			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 5), expression: Is.EqualTo(expected: ReportReason.AdultMaterial));
			Assert.That(actual: Utilities.EnumFrom<ReportReason>(value: 6), expression: Is.EqualTo(expected: ReportReason.Abuse));
		}

		[Test]
		public void SexTest()
		{
			Assert.That(actual: Utilities.EnumFrom<Sex>(value: 0), expression: Is.EqualTo(expected: Sex.Unknown));
			Assert.That(actual: Utilities.EnumFrom<Sex>(value: 1), expression: Is.EqualTo(expected: Sex.Female));
			Assert.That(actual: Utilities.EnumFrom<Sex>(value: 2), expression: Is.EqualTo(expected: Sex.Male));
		}

		[Test]
		public void SortOrderByTest()
		{
			Assert.That(actual: Utilities.EnumFrom<SortOrderBy>(value: 0), expression: Is.EqualTo(expected: SortOrderBy.Desc));
			Assert.That(actual: Utilities.EnumFrom<SortOrderBy>(value: 1), expression: Is.EqualTo(expected: SortOrderBy.Asc));
		}

		[Test]
		public void UserSortTest()
		{
			Assert.That(actual: Utilities.EnumFrom<UserSort>(value: 0), expression: Is.EqualTo(expected: UserSort.ByPopularity));
			Assert.That(actual: Utilities.EnumFrom<UserSort>(value: 1), expression: Is.EqualTo(expected: UserSort.ByRegDate));
		}

		[Test]
		public void VideoSortTest()
		{
			Assert.That(actual: Utilities.EnumFrom<VideoSort>(value: 0), expression: Is.EqualTo(expected: VideoSort.AddedDate));
			Assert.That(actual: Utilities.EnumFrom<VideoSort>(value: 1), expression: Is.EqualTo(expected: VideoSort.Duration));
			Assert.That(actual: Utilities.EnumFrom<VideoSort>(value: 2), expression: Is.EqualTo(expected: VideoSort.Relevance));
		}

		[Test]
		public void VideoWidthTest()
		{
			Assert.That(actual: Utilities.EnumFrom<VideoWidth>(value: 130), expression: Is.EqualTo(expected: VideoWidth.Small130));
			Assert.That(actual: Utilities.EnumFrom<VideoWidth>(value: 160), expression: Is.EqualTo(expected: VideoWidth.Medium160));
			Assert.That(actual: Utilities.EnumFrom<VideoWidth>(value: 320), expression: Is.EqualTo(expected: VideoWidth.Large320));
		}

		[Test]
		public void VkObjectTypeTest()
		{
			Assert.That(actual: Utilities.EnumFrom<VkObjectType>(value: 0), expression: Is.EqualTo(expected: VkObjectType.User));
			Assert.That(actual: Utilities.EnumFrom<VkObjectType>(value: 1), expression: Is.EqualTo(expected: VkObjectType.Group));
			Assert.That(actual: Utilities.EnumFrom<VkObjectType>(value: 2), expression: Is.EqualTo(expected: VkObjectType.Application));
		}

		[Test]
		public void WallContentAccessTest()
		{
			Assert.That(actual: Utilities.EnumFrom<WallContentAccess>(value: 0), expression: Is.EqualTo(expected: WallContentAccess.Off));

			Assert.That(actual: Utilities.EnumFrom<WallContentAccess>(value: 1)
					, expression: Is.EqualTo(expected: WallContentAccess.Opened));

			Assert.That(actual: Utilities.EnumFrom<WallContentAccess>(value: 2)
					, expression: Is.EqualTo(expected: WallContentAccess.Restricted));

			Assert.That(actual: Utilities.EnumFrom<WallContentAccess>(value: 3)
					, expression: Is.EqualTo(expected: WallContentAccess.Closed));
		}
	}
}