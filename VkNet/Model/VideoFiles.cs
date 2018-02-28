using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Видео файлы
    /// </summary>
    [Serializable]
    public class VideoFiles
    {
        /// <summary>
        /// Uri ролика с размером 320x240px.
        /// </summary>
        public Uri Mp4_240 { get; set; }
        /// <summary>
        /// Uri ролика с размером 640x360px.
        /// </summary>
        public Uri Mp4_360 { get; set; }
        /// <summary>
        /// Uri ролика с размером 640x480px.
        /// </summary>
        public Uri Mp4_480 { get; set; }
        /// <summary>
        /// Uri ролика с размером 1280x720px.
        /// </summary>
        public Uri Mp4_720 { get; set; }

        /// <summary>
        /// Uri ролика с размером 1920х1080px.
        /// </summary>
        public Uri Mp4_1080 { get; set; }

        /// <summary>
        /// Внешняя ссылка
        /// </summary>
        public Uri External { get; set; }

        #region public Methods
        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static VideoFiles FromJson(VkResponse response)
        {
            return new VideoFiles
            {
                Mp4_240 = response["mp4_240"],
                Mp4_360 = response["mp4_360"],
                Mp4_480 = response["mp4_480"],
                Mp4_720 = response["mp4_720"],
                Mp4_1080 = response["mp4_1080"],
                External = response["external"]
            };
        }

        #endregion
    }
}
