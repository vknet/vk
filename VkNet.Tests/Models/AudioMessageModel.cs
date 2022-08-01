using System;
using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models;

public class AudioMessageModel : BaseTest
{
	[Fact]
	public void ToString_AudioMessageShouldHaveAccessKey()
	{
		var audioMessage = new AudioMessage
		{
			Id = 1234,
			OwnerId = 1234,
			AccessKey = "test"
		};

		var result = audioMessage.ToString();

		result.Should()
			.Be("audio_message1234_1234_test");
	}

	[Fact]
	public void ShouldDeserializeFromVkResponseToAudioMessageWithTranscript()
	{
		ReadJsonFile("Models", "audio_message_with_transcription");

		var response = GetResponse();

		var attachment = Attachment.FromJson(response);

		attachment.Instance.Should()
			.BeOfType<AudioMessage>();

		var audioMessage = attachment.Instance as AudioMessage;

		audioMessage.Duration.Should()
			.Be(25);

		audioMessage.LinkOgg.Should()
			.Be(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.ogg"));

		audioMessage.LinkMp3.Should()
			.Be(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.mp3"));

		audioMessage.Transcript.Should()
			.Be("demo message");

		audioMessage.TranscriptState.Should()
			.Be(TranscriptStates.Done);
	}

	[Fact]
	public void ShouldDeserializeFromVkResponseToAudioMessage()
	{
		ReadJsonFile("Models", "audio_message_without_transcription");

		var response = GetResponse();

		var attachment = Attachment.FromJson(response);

		attachment.Instance.Should()
			.BeOfType<AudioMessage>();

		var audioMessage = attachment.Instance as AudioMessage;

		audioMessage.Duration.Should()
			.Be(25);

		audioMessage.LinkOgg.Should()
			.Be(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.ogg"));

		audioMessage.LinkMp3.Should()
			.Be(new Uri("https://psv4.userapi.com/c205420//u111874665/audiomsg/d12/794c8440a8.mp3"));

		audioMessage.Transcript.Should()
			.Be(null);
	}
}