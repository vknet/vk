using System;
using System.Collections.ObjectModel;
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
      		RegisterType(typeof (Poll), "poll");
      	}

        /// <summary>
        /// Вопрос, заданный в голосовании.
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Дата создания опроса
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Кол-во ответов
        /// </summary>
        public int? Votes { get; set; }
    
        /// <summary>
        /// Идентификатор выбранного ответа
        /// </summary>
        public long? AnswerId { get; set; }

        /// <summary>
        /// Возможность анонимых ответов
        /// </summary>
        public bool? IsAnonymous { get; set; }

        /// <summary>
        /// Варианты ответов
        /// </summary>
        public Collection<PollAnswer> Answers { get; set; } 

        #region Методы

        internal static Poll FromJson(VkResponse response)
        {
            var poll = new Poll();

            poll.Id = response["id"];
	        poll.OwnerId = response["owner_id"];
            poll.Question = response["question"];
            poll.Created = response["created"];
            poll.Votes = response["votes"];
            poll.AnswerId = response["answer_id"];
            poll.IsAnonymous = response["anonymous"];
            poll.Answers = response["answers"];

            return poll;
        }

        #endregion
    }
}