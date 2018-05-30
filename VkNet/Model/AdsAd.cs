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
    /// Описание рекламного аккаунта.
    /// </summary>
    /// <remarks>
    /// См. описание https://vk.com/dev/ads.getAccounts
    /// </remarks>
    [Serializable]
    public class Ad
    {
        /// <summary>
        /// Идентификатор рекламного объявления.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор кампании.
        /// </summary>
        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        /// <summary>
        /// Формат объявления
        /// </summary>
        [JsonProperty("ad_format")]
        public AdFormat AdFormat { get; set; }

        /// <summary>
        /// Цена за переход в копейках. (если cost_type = 0)
        /// </summary>
        [JsonProperty("cpc")]
        public long CPC { get; set; }

        /// <summary>
        /// Цена за 1000 показов в копейках. (если cost_type = 1)
        /// </summary>
        [JsonProperty("cpm")]
        public long CPM { get; set; }

        /// <summary>
        /// (если задано) Ограничение количества показов данного объявления на одного пользователя.
        /// Может присутствовать для некоторых форматов объявлений, для которых разрешена установка точного значения.
        /// </summary>
        [JsonProperty("impressions_limit")]
        public long ImpressionsLimit { get; set; }

        /// <summary>
        /// (если задано) Признак того, что количество показов объявления на одного пользователя ограничено. 
        /// Может присутствовать для некоторых объявлений, для которых разрешена установка ограничения, но не разрешена установка точного значения. 1 — не более 100 показов на одного пользователя.
        /// </summary>
        [JsonProperty("impressions_limited")]
        public long ImpressionsLimited { get; set; }

        /// <summary>
        /// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления) 
        /// </summary>
        [JsonProperty("ad_platform")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public AdPlatform AdPlatform { get; set; }

        /// <summary>
        /// 1 — для объявления задано ограничение «Не показывать на стенах сообществ».
        /// </summary>
        [JsonProperty("ad_platform_no_wall")]
        public long AdPPlatformNoWall { get; set; }

        /// <summary>
        /// Общий лимит объявления в рублях. 0 — лимит не задан.
        /// </summary>
        [JsonProperty("all_limit")]
        public long AllLimit { get; set; }




        /// <summary>
        /// Тип рекламного кабинета.
        /// </summary>
        [JsonProperty("account_type")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Cтатус рекламного кабинета.
        /// </summary>
        [JsonProperty("account_status")]
        public AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Название аккаунта
        /// </summary>
        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        /// <summary>
        /// Права пользователя в рекламном кабинете.
        /// </summary>
        [JsonProperty("access_role")]
        [JsonConverter(typeof(SafetyEnumJsonConverter))]
        public AccessRole AccessRole { get; set; }

        #region Методы
        /// <summary>
        /// Информация о рекламном аккаунте
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static AdsAccount FromJson(VkResponse response)
        {
            if (response["account_id"] == null)
            {
                return null;
            }

            var adsaccount = new AdsAccount
            {
                AccountId = response["account_id"],
                AccountType = response["account_type"],
                AccountStatus = response["account_status"],
                AccountName = response["account_name"],
                AccessRole = response["access_role"]

            };

            return adsaccount;
        }
        #endregion  

    }
}