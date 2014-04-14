using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Опрос.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Опрос".
    /// </summary>
    public class Poll : MediaAttachment
    {
      	static Poll()
      	{
      		type = "poll";
      	}

        /// <summary>
        /// Вопрос, заданный в голосовании.
        /// </summary>
        public string Question { get; set; }

        #region Методы

        internal static Poll FromJson(VkResponse response)
        {
            var poll = new Poll();

            poll.Id = response["id"];
	        poll.OwnerId = response["owner_id"];
            poll.Question = response["question"];

            return poll;
        }

        #endregion
    }
}