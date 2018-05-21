using System;
using VkNet.Enums;
using VkNet.Utils;

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
        public ulong AccountId { get; set; }

        /// <summary>
        /// Тип рекламного кабинета.
        /// </summary>
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Cтатус рекламного кабинета.
        /// </summary>
        public AccountStatus AccountStatus { get; set; }


        /// <summary>
        /// Название аккаунта
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Права пользователя в рекламном кабинете.
        /// </summary>
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
                AccountType = response["account_type"] == "general" ? AccountType.General : AccountType.Agency,
                AccountStatus = response["account_status"] == 1 ? AccountStatus.Active : AccountStatus.Inactive,
                AccountName = response["account_name"]
            };

            // Начитываем роль аккаунта
            switch ((string)response["access_role"])
            {
                case "admin":
                    adsaccount.AccessRole = AccessRole.Admin;
                    break;
                case "manager":
                    adsaccount.AccessRole = AccessRole.Manager;
                    break;
                case "reports":
                    adsaccount.AccessRole = AccessRole.Reports;
                    break;
                default:
                    break;
            }

            return adsaccount;
        }
        #endregion  

    }
}