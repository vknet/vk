using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Audio;

public class AudioGetCatalogTest : CategoryBaseTest
{
	protected override string Folder => "Audio";

	[Fact]
	public void GetCatalog()
	{
		Url = "https://api.vk.com/method/audio.getCatalog";

		ReadCategoryJsonPath(nameof(Api.Audio.GetCatalog));

		var result = Api.Audio.GetCatalog(20, true, UsersFields.FirstNameGen|UsersFields.Photo100);

		result.Should()
			.NotBeNull();

		result.Items[0]
			.Type.Should()
			.Be(AudioCatalogType.AudiosSpecial);

		result.Items[1]
			.Type.Should()
			.Be(AudioCatalogType.Playlists);

		AudioCatalogType.AudiosSpecial.Should()
			.Be(result.Items[0]
				.Type);

		AudioCatalogSourceType.RecomsRecoms.Should()
			.Be(result.Items[0]
				.Source);

		result.Items[0]
			.Thumbs[0]
			.Width.Should()
			.Be(300);

		result.Items[0]
			.Audios[0]
			.Id.Should()
			.Be(64754323);

		result.Items[0]
			.Audios[0]
			.Ads.Duration.Should()
			.Be("187");

		result.Items[0]
			.Audios[0]
			.Date.Year.Should()
			.Be(2020);

		result.Items[0]
			.Audios[0]
			.Album.Thumb.Height.Should()
			.Be(300);

		result.Items[0]
			.Audios[0]
			.MainArtists[0]
			.Id.Should()
			.Be("4885835127738846121");

		result.Items[1]
			.Playlists[0]
			.Genres[0]
			.Id.Should()
			.Be(1);

		result.Items[1]
			.Playlists[0]
			.Original.OwnerId.Should()
			.Be(-2000239709);

		result.Items[1]
			.Playlists[0]
			.Photo.Height.Should()
			.Be(300);

		result.Items[1]
			.Playlists[0]
			.MainArtists[0]
			.Id.Should()
			.Be("2488610606427153840");

		result.Items[1]
			.Playlists[0]
			.AlbumType.Should()
			.Be(AudioAlbumType.MainOnly);

		result.Items[2]
			.Items[0]
			.Meta.ContentType.Should()
			.Be(UserOrGroupType.Group);
	}
}