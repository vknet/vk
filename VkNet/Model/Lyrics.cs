using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Текст аудиозаписи.
	/// См. описание http://vk.com/dev/audio.getLyrics
	/// </summary>
	[Serializable]
	public class Lyrics
	{
		/// <summary>
		/// Идентификатор текста аудиозаписи.
		/// </summary>
		[JsonProperty("lyrics_id")]
		public long Id { get; set; }

		/// <summary>
		/// Тест аудиозаписи. В качестве переводов строк в тексте используется '\n'.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Lyrics FromJson(VkResponse response)
		{
			return new Lyrics
			{
				Id = response[key: "lyrics_id"],
				Text = response[key: "text"]
			};
		}

	#endregion
	}
}