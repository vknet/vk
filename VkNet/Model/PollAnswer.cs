namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Вариант ответа в опросе
    /// </summary>
    public class PollAnswer
    {
        public long? Id { get; set; }

        public string Text { get; set; }

        public int Votes { get; set; }

        public double? Rate { get; set; }

        internal static PollAnswer FromJson(VkResponse response)
        {
            var answer = new PollAnswer();

            answer.Id = response["id"];
            answer.Text = response["text"];
            answer.Votes = response["votes"];
            answer.Rate = response["rate"];

            return answer;
        }
    }
}