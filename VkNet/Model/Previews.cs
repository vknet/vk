namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Набор Url к картинкам с различным разрешениям.
    /// Используется в <see cref="User"/>, <see cref="Group"/> и <see cref="Message"/>.
    /// </summary>
    public class Previews
    {
        /// <summary>
        /// Url квадратной фотографии, имеющей ширину 50 пикселей.
        /// </summary>
        public string Photo50 { get; set; }

        /// <summary>
        /// Url квадратной фотографии, имеющей ширину 100 пикселей.
        /// </summary>
        public string Photo100 { get; set; }

        /// <summary>
        /// Url квадратной фотографии, имеющей ширину 200 пикселей.
        /// </summary>
        public string Photo200 { get; set; }

        /// <summary>
        /// Url квадратной фотографии, имеющей ширину 400 пикселей.
        /// </summary>
        public string Photo400 { get; set; }

        /// <summary>
        /// Url квадратной фотографии, имеющей максимальную ширину.
        /// </summary>
        public string PhotoMax { get; set; }

        #region Методы 

        internal static Previews FromJson(VkResponse response)
        {
            var previews = new Previews();

            previews.Photo50 = response["photo_50"] ?? response["photo"];
            previews.Photo100 = response["photo_100"] ?? response["photo_medium"];
            previews.Photo200 = response["photo_200"] ?? response["photo_200_orig"];
            previews.Photo400 = response["photo_400_orig"];
            previews.PhotoMax = response["photo_max"] ?? response["photo_max_orig"] ?? response["photo_big"] ?? previews.Photo400 ?? previews.Photo200 ?? previews.Photo100 ?? previews.Photo50;

            return previews;
        }

        #endregion
    }
}