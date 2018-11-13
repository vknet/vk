using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Аудио сообщение
	/// </summary>
	[Serializable]
	public class AudioMessage : MediaAttachment
	{
		static AudioMessage()
		{
			RegisterType(typeof(AudioMessage), "audio_message");
		}

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
		/// Ключ доступа
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }

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
				AccessKey = response["access_key"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="AudioMessage" /> в <see cref="VkParameters" />
		/// >
		/// </summary>
		/// <param name="response"> Параметр. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AudioMessage(VkResponse response)
		{
			return response.HasToken() ? FromJson(response) : null;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(AccessKey)
				? base.ToString()
				: $"{base.ToString()}_{AccessKey}";
		}
	}
}