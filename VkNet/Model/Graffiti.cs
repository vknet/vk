namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Граффити.
    /// См. описание <see href="http://vk.com/dev/attachments_w"/>. Раздел "Граффити".
    /// </summary>
    public class Graffiti
    {
        /// <summary>
        /// Идентификатор граффити.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор автора граффити.
        /// </summary>
        public long OwnerId { get; set; }

        /// <summary>
        /// Адрес изображения для предпросмотра.
        /// </summary>
        public string Photo200 { get; set; }

        /// <summary>
        /// Адрес полноразмерного изображения. 
        /// </summary>
        public string Photo586 { get; set; }

        #region Методы

        internal static Graffiti FromJson(VkResponse response)
        {
            var graffiti = new Graffiti();

            graffiti.Id = response["id"];
            graffiti.OwnerId = response["owner_id"];
            graffiti.Photo200 = response["photo_200"];
            graffiti.Photo586 = response["photo_586"];

            return graffiti;
        }

        #endregion
    }
}