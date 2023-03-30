using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.Attachments;

/// <summary>
/// Аудио сообщение
/// </summary>
[Serializable]
public class AudioMessage : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "audio_message";

	/// <summary>
	/// Продолжительность
	/// </summary>
	[JsonProperty("duration")]
	public ulong Duration { get; set; }

	/// <summary>
	/// Форма волны
	/// </summary>
	[JsonProperty("waveform")]
	public ReadOnlyCollection<int> Waveform { get; set; }

	/// <summary>
	/// Ссылка на файл в ogg
	/// </summary>
	[JsonProperty("link_ogg")]
	public Uri LinkOgg { get; set; }

	/// <summary>
	/// Ссылка на файл в mp3
	/// </summary>
	[JsonProperty("link_mp3")]
	public Uri LinkMp3 { get; set; }

	/// <summary>
	/// Текст транскрипции
	/// </summary>
	[JsonProperty("transcript")]
	public string Transcript { get; set; }

	/// <summary>
	/// Статус транскрипции
	/// </summary>
	[JsonProperty("transcript_state")]
	public TranscriptStates TranscriptState { get; set; }
}