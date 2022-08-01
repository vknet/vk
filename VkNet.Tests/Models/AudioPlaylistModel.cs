using FluentAssertions;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models;

public class AudioPlaylistModel : BaseTest
{
	[Fact]
	public void ShouldDeserializeFromVkResponseToAttachment()
	{
		ReadJsonFile("Models", "audio_playlist_attachment");

		var response = GetResponse();

		var attachment = Attachment.FromJson(response);

		attachment.Instance.Should()
			.BeOfType<AudioPlaylist>();
	}
}