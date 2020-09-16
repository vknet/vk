using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class AudioMessageModel : BaseTest
	{
		[Test]
		public void ToString_AudioMessageShouldHaveAccessKey()
		{
			var audioMessage = new AudioMessage
			{
				Id = 1234,
				OwnerId = 1234,
				AccessKey = "test"
			};

			var result = audioMessage.ToString();

			Assert.AreEqual(result, "audio_message1234_1234_test");
		}

		[Test]
		public void ShouldDeserializeFromVkResponseToAudioMessageWithTranscript()
		{
			ReadJsonFile("Models", "audio_message_with_transcription");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);
			Assert.True(attachment.Instance is AudioMessage);

			var audioMessage = attachment.Instance as AudioMessage;
			Assert.That(audioMessage.Duration, Is.EqualTo(25));
			Assert.That(audioMessage.LinkOgg, Is.EqualTo(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.ogg")));
			Assert.That(audioMessage.LinkMp3, Is.EqualTo(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.mp3")));
			Assert.That(audioMessage.Transcript, Is.EqualTo("demo message"));
			Assert.That(audioMessage.TranscriptState, Is.EqualTo(TranscriptStates.Done));
		}

		[Test]
		public void ShouldDeserializeFromVkResponseToAudioMessage()
		{
			ReadJsonFile("Models", "audio_message_without_transcription");

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);
			Assert.True(attachment.Instance is AudioMessage);

			var audioMessage = attachment.Instance as AudioMessage;
			Assert.That(audioMessage.Duration, Is.EqualTo(25));
			Assert.That(audioMessage.LinkOgg, Is.EqualTo(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.ogg")));
			Assert.That(audioMessage.LinkMp3, Is.EqualTo(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.mp3")));
			Assert.That(audioMessage.Transcript, Is.EqualTo(null));
		}
	}
}