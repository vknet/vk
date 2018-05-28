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
    public class AdsAccount
    {
        /// <summary>
        /// Идентификатор рекламного кабинета.
        /// </summary>
        [JsonProperty("account_id")]
        public ulong AccountId { get; set; }

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