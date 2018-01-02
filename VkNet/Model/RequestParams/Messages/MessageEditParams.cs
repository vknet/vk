using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// Параметры запроса Messages.Edit
    /// </summary>
    public class MessageEditParams
    {
        /// <summary>
        /// Идентификатор назначения.
        /// </summary>
        [JsonProperty("peer_id")]
        public long PeerId { get; set; }

        /// <summary>
        /// Текст сообщения. Обязательный параметр, если не задан параметр attachment.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Идентификатор сообщения.
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// Географическая широта (от -90 до 90).
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Географическая долгота (от -180 до 180).
        /// </summary>
        [JsonProperty("long")]
        public double Longitude { get; set; }

        /// <summary>
        /// медиавложения к личному сообщению, перечисленные через запятую. 
        /// </summary>
        [JsonProperty("attachment")]
        public IEnumerable<MediaAttachment> Attachments { get; set; }

        /// <summary>
        /// 1, чтобы сохранить прикреплённые пересланные сообщения
        /// </summary>
        [JsonProperty("keep_forward_messages")]
        public bool? KeepForwardMessages { get; set; }

        /// <summary>
        /// 1, чтобы сохранить прикреплённые внешние ссылки (сниппеты). 
        /// </summary>
        [JsonProperty("keep_snippets")]
        public bool? KeepSnippets { get; set; }

        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>
        public static VkParameters ToVkParameters(MessageEditParams p)
        {
            return new VkParameters
            {
                {"peer_id", p.PeerId},
                {"message", p.Message},
                {"message_id", p.MessageId},
                {"lat", p.Latitude},
                {"long", p.Longitude},
                {"attachment", p.Attachments},
                {"keep_forward_messages", p.KeepForwardMessages},
                {"keep_snippets", p.KeepSnippets}
            };
        }
    }
}