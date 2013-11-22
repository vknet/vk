using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Lyrics
    {
        public long Id { get; set; }
        public string Text { get; set; }

        internal static Lyrics FromJson(VkResponse lyrics)
        {
            var result = new Lyrics();

            result.Id = lyrics["lyrics_id"];
            result.Text = lyrics["text"];

            return result;
        }
    }
}