namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Опрос.
    /// См. описание <see cref="http://vk.com/dev/attachments_w"/>. Раздел "Опрос".
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// Идентификатор опроса для получения информации о нем через метод <see cref="PollsCategory.GetById"/>.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Вопрос, заданный в голосовании.
        /// </summary>
        public string Question { get; set; }

        #region Методы

        internal static Poll FromJson(VkResponse response)
        {
            var poll = new Poll();

            poll.Id = response["id"];
            poll.Question = response["question"];

            return poll;
        }

        #endregion
    }
}