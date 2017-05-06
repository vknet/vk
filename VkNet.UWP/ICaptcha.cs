namespace VkNet
{
    using Utils.AntiCaptcha;

    /// <summary>
    /// Интерфейс для работы с каптчей
    /// </summary>
    public interface ICaptcha
    {
        /// <summary>
		/// Максимальное количество попыток распознавания капчи c помощью зарегистрированного обработчика
		/// </summary>
        int MaxCaptchaRecognitionCount { get; set; }

        /// <summary>
		/// Обработчик распознавания капчи
		/// </summary>
        ICaptchaSolver CaptchaSolver { get; }
    }
}