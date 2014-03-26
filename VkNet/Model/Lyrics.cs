namespace VkNet.Model
{
    using VkNet.Utils;

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

        internal static Lyrics FromJson(VkResponse re)
        {
            var lyrics = new Lyrics();

            lyrics.Id = re["lyrics_id"];
            lyrics.Text = re["text"];

            return lyrics;
        }

        #endregion
    }
}