using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Utils;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// Список параметров для метода polls.create
    /// </summary>
    public struct PollsCreateParams
    {
        /// <summary>
        /// Идентификатор владельца опроса.
        /// </summary>
        public long OwnerId
        { get; set; }

        /// <summary>
        /// Идентификатор владельца опроса.
        /// True – анонимный опрос, список проголосовавших недоступен;
        /// False – опрос публичный, список проголосовавших доступен;
        /// По умолчанию – False. 
        /// </summary>
        public bool? IsAnonymous
        { get; set; }

        /// <summary>
        /// Текст опроса.
        /// </summary>
        public string Question
        { get; set; }

        /// <summary>
        /// Список вариантов ответов.
        /// </summary>
        public List<string> AddAnswers
        { get; set; }

        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>
        public static VkParameters ToVkParameters(PollsCreateParams p)
        {
            return new VkParameters
            {
                { "owner_id", p.OwnerId },
                { "is_anonymous", p.IsAnonymous },
                { "question", p.Question },
                { "add_answers", Serialize(p.AddAnswers) }
            };
        }

        private static string Serialize(object @object)
        {
            string result = JsonConvert.SerializeObject(@object);
            if (result == "null")
                return null;
            return result;
        }
    }
}
