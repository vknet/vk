using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    /// <inheritdoc />
    [Serializable]
    public class PrettyCards : MediaAttachment
    {
        /// <inheritdoc />
        static PrettyCards()
        {
            RegisterType(typeof(PrettyCards), "pretty_cards");
        }

        /// <summary>
        /// Cards
        /// </summary>
        [JsonProperty("cards")]
        public ReadOnlyCollection<PrettyCard> Cards { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static PrettyCards FromJson(VkResponse response)
        {
            return new PrettyCards
            {
                Cards = response["cards"].ToReadOnlyCollectionOf<PrettyCard>(x => x)
            };
        }

        /// <summary>
        /// Преобразовать из VkResponse
        /// </summary>
        /// <param name="response">Ответ.</param>
        /// <returns>
        /// Результат преобразования.
        /// </returns>
        public static implicit operator PrettyCards(VkResponse response)
        {
            return response != null && !response.HasToken()? null : FromJson(response);
        }
    }
}