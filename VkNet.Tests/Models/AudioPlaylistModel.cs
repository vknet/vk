using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class AudioPlaylistModel : BaseTest
	{
		[Test]
		public void ShouldDeserializeFromVkResponseToAttachment()
		{
			ReadJsonFile("Models", "audio_playlist_attachment");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			Assert.True(attachment.Instance is AudioPlaylist);
		}
	}
}