using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
    /// <summary>
    /// Возвращает список кампаний рекламного кабинета.
    /// </summary>
    /// <remarks>
    /// См. описание https://vk.com/dev/ads.getCampaigns
    /// </remarks>
    [Serializable]
    public class AdsCampaign
    {
        /// <summary>
        /// Идентификатор рекламного кабинета.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Тип кампании
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public CampaignType Type { get; set; }

        /// <summary>
        /// Название кампании
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Статус кампании
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CampaignStatus Status { get; set; }

        /// <summary>
        /// Дневной лимит кампании в рублях
        /// </summary>
        [JsonProperty("day_limit")]
        public int DayLimit { get; set; }

        /// <summary>
        /// Общий лимит кампании в рублях
        /// </summary>
        [JsonProperty("all_limit")]
        public int AllLimit { get; set; }

        /// <summary>
        /// Время запуска кампании в формате unixtime
        /// </summary>
        [JsonProperty("start_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Время запуска кампании в формате unixtime
        /// </summary>
        [JsonProperty("stop_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? StopTime { get; set; }

        /// <summary>
        /// Время создания кампании в формате unixtime
        /// </summary>
        [JsonProperty("create_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Время последнего изменения кампании в формате unixtime
        /// </summary>
        [JsonProperty("update_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? UpdateTime { get; set; }

        #region Методы
        /// <summary>
        /// Информация о рекламном аккаунте
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static AdsCampaign FromJson(VkResponse response)
        {
            if (response["id"] == null)
            {
                return null;
            }

            var compaign = new AdsCampaign()
            {
                Id = response["id"],
                Type = response["type"],
                Name = response["name"],
                Status = response["status"],
                DayLimit = response["day_limit"],
                AllLimit = response["all_limit"],
                StartTime = response["start_time"],
                StopTime = response["stop_time"],
            };

            return compaign;
        }
        #endregion  

    }
}