using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.Attachments
{
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
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public TranscriptStates TranscriptState { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AudioMessage FromJson(VkResponse response)
		{
			return new AudioMessage
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Duration = response["duration"],
				Waveform = response["waveform"].ToReadOnlyCollectionOf<int>(x => x),
				LinkOgg = response["link_ogg"],
				LinkMp3 = response["link_mp3"],
				AccessKey = response["access_key"],
				Transcript = response["transcript"],
				TranscriptState = response["transcript_state"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioMessage" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="AudioMessage" /></returns>
		public static implicit operator AudioMessage(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}