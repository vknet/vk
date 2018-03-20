
using VkNet.Utils;

namespace VkNet.Exception
{
    using System;

    /// <summary>
    /// Исключение, выбрасываемое при необходимости ввода капчи для вызова метода
	/// Код ошибки - 14
    /// </summary>
    [Serializable]
    public class CaptchaNeededException : VkApiMethodInvokeException
    {
        /// <summary>
        /// Идентификатор капчи
        /// </summary>
        public long Sid { get; }

        /// <summary>
        /// Uri-адрес изображения с капчей
        /// </summary>
        public Uri Img { get; }

        /// <summary>
        /// Создания экземпляра CaptchaNeededException
        /// </summary>
        /// <param name="sid">Сид</param>
        /// <param name="img">Uri-адрес изображения с капчей</param>
        public CaptchaNeededException(long sid, string img) : this(sid, string.IsNullOrEmpty(img) ? null : new Uri(img))
        {
			
        }

        /// <summary>
        /// Создания экземпляра CaptchaNeededException
        /// </summary>
        /// <param name="sid">Сид</param>
        /// <param name="img">Uri-адрес изображения с капчей</param>
        public CaptchaNeededException(long sid, Uri img)
        {
            Sid = sid;
            Img = img;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response">Ответ от сервера vk</param>
		public CaptchaNeededException(VkResponse response) : base(response["error_msg"])
		{
			ErrorCode = response["error_code"];
			Sid = response["captcha_sid"];
			Img = response["captcha_img"];
		}
	}
}
