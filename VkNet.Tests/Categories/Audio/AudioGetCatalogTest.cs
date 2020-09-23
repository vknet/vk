using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]

	public class AudioGetCatalogTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetCatalog()
		{
			Url = "https://api.vk.com/method/audio.getCatalog";

			ReadCategoryJsonPath(nameof(Api.Audio.GetCatalog));

			var result = Api.Audio.GetCatalog(20, true, UsersFields.FirstNameGen| UsersFields.Photo100);

			Assert.NotNull(result);
			Assert.AreEqual(result.Items[0].Type, AudioCatalogType.AudiosSpecial);
			Assert.AreEqual(result.Items[0].Source, AudioCatalogSourceType.RecomsRecoms);
			Assert.AreEqual(result.Items[0].Thumbs[0].Width, 300);
			Assert.AreEqual(result.Items[0].Audios[0].Id, 64754323);
			Assert.AreEqual(result.Items[0].Audios[0].Ads.Duration, "187");
			Assert.AreEqual(result.Items[0].Audios[0].Date.Year, 2020);
			Assert.AreEqual(result.Items[0].Audios[0].Album.Thumb.Height, 300);
			Assert.AreEqual(result.Items[0].Audios[0].MainArtists[0].Id, "4885835127738846121");
			Assert.AreEqual(result.Items[1].Playlists[0].Genres[0].Id, 1);
			Assert.AreEqual(result.Items[1].Playlists[0].Original.OwnerId, -2000239709);
			Assert.AreEqual(result.Items[1].Playlists[0].Photo.Height, 300);
			Assert.AreEqual(result.Items[1].Playlists[0].MainArtists[0].Id, "2488610606427153840");
			Assert.AreEqual(result.Items[1].Playlists[0].AlbumType, AudioAlbumType.MainOnly);
			Assert.AreEqual(result.Items[2].Items[0].Meta.ContentType, UserOrGroupType.Group);
		}
	}
}
