namespace VkNet.Exception
{
    using System;

    /// <summary>
    /// Исключение, выбрасываемое при необходимости ввода капчи для вызова метода
    /// </summary>
    [Serializable]
    public class CaptchaNeededException : VkApiException
    {
        /// <summary>
        /// Идентификатор капчи
        /// </summary>
        public long Sid { get; private set; }

        /// <summary>
        /// Url-адрес изображения с капчей
        /// </summary>
        public Uri Img { get; private set; }


        /// <summary>
        /// Создания экземпляра <see cref="CaptchaNeededException"/>
        /// </summary>
        /// <param name="sid">Сид</param>
        /// <param name="img">Url-адрес изображения с капчей</param>
        public CaptchaNeededException(long sid, string img) : this(sid, new Uri(img))
        {
            
        }

        /// <summary>
        /// Создания экземпляра <see cref="CaptchaNeededException"/>
        /// </summary>
        /// <param name="sid">Сид</param>
        /// <param name="img">Url-адрес изображения с капчей</param>
        public CaptchaNeededException(long sid, Uri img)
        {
            Sid = sid;
            Img = img;
        }
    }
}