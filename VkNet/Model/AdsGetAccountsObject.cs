using System;
using System.Collections.ObjectModel;
using VkNet.Utils;


namespace VkNet.Model
{
    /// <summary>
    /// Результат выполнения запроса получения списка рекламных кабинетов https://vk.com/dev/ads.getAccounts
    /// </summary>
    [Serializable]
    public class AdsGetAccountsObject
    {
        /// <summary>
        /// Доступные рекламные кабинеты
        /// </summary>
        public ReadOnlyCollection<AdsAccount> Accounts { get; set; }

        #region Методы
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static AdsGetAccountsObject FromJson(VkResponse response)
        {
            var adsGetAccountsObject = new AdsGetAccountsObject()
            {
                Accounts = response.ToReadOnlyCollectionOf<AdsAccount>(r => r)
            };

            return adsGetAccountsObject;
        }

        #endregion
    }
}