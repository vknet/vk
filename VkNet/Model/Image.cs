using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Копия изображения обложки.
    /// </summary>
    [Serializable]
    public class Image
    {
        /// <summary>
        /// URL копии;
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Ширина копии;
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота копии.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static Image FromJson(VkResponse response)
        {
            return new Image
            {
                Url = response["url"],
                Width = response["width"],
                Height = response["height"]
            };
        }

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static implicit operator Image(VkResponse response)
        {
            return response.HasToken()
                ? FromJson(response)
                : null;
        }
    }
}
