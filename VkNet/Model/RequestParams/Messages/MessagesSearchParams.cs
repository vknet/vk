using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// Параметры запроса messages.search
    /// </summary>
    [Serializable]
    public class MessagesSearchParams
    {
        /// <summary>
        /// Подстрока, по которой будет производиться поиск.
        /// </summary>
        [JsonProperty("q")]
        public string Query { get; set; }
        
        /// <summary>
        /// Фильтр по идентификатору назначения для поиска по отдельному диалогу
        /// </summary>
        [JsonProperty("peer_id")]
        public long PeerId { get; set; }
        
        /// <summary>
        /// Дата в формате DDMMYYYY — если параметр задан, в ответе будут только сообщения, отправленные до указанной даты. 
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }
        
        /// <summary>
        /// Количество символов, по которому нужно обрезать сообщение.
        /// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются). 
        /// </summary>
        [JsonProperty("preview_length")]
        public uint PreviewLength { get; set; }
        
        /// <summary>
        /// Смещение, необходимое для выборки определенного подмножества сообщений из списка найденных. 
        /// </summary>
        [JsonProperty("offset")]
        public uint Offset { get; set; }

        /// <summary>
        /// Количество сообщений, которое необходимо получить. 
        /// </summary>
        [JsonProperty("count")]
        public uint Count { get; set; } = 20;
        
        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>
        public static VkParameters ToVkParameters(MessagesSearchParams p)
        {
            return new VkParameters
            {
                { "q", p.Query },
                { "peer_id", p.PeerId },
                { "date", p.Date },
                { "preview_length", p.PreviewLength },
                { "offset", p.Offset },
                { "count", p.Count }
            };
        }
    }
}