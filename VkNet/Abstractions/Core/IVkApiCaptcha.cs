using VkNet.Utils.AntiCaptcha;

namespace VkNet.Abstractions
{
	/// <summary>
	/// VkApi капча
	/// </summary>
	public interface IVkApiCaptcha
	{
		/// <summary>
		/// Обработчик распознавания капчи
		/// </summary>
		ICaptchaSolver CaptchaSolver { get; }

		/// <summary>
		/// Максимальное количество попыток распознавания капчи c помощью
		/// зарегистрированного обработчика
		/// </summary>
		int MaxCaptchaRecognitionCount { get; set; }
	}
}