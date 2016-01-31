namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Текст аудиозаписи.
    /// См. описание <see href="http://vk.com/dev/audio.getLyrics"/>.
    /// </summary>
    public class Lyrics
    {
        /// <summary>
        /// Идентификатор текста аудиозаписи.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тест аудиозаписи. В качестве переводов строк в тексте используется '\n'.
        /// </summary>
        public string Text { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Lyrics FromJson(VkResponse response)
        {
			return new Lyrics
			{
				Id = response["lyrics_id"],
				Text = response["text"]
			};
        }

        #endregion
    }
}