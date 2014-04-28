namespace VkNet.Model
{
    using Utils;

    /// <summary>
    /// Вариант ответа в опросе
    /// </summary>
    public class PollAnswer
    {
        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Кол-во проголосовавших
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        /// Процент текущего ответа ко всем остальным вариантам
        /// </summary>
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