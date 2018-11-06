namespace VkNet.Utils
{
	/// <summary>
	/// Тексты для атрибута Obsolete
	/// </summary>
	public static class ObsoleteText
	{
		/// <summary>
		/// Параметры для капчи устаревшие.
		/// Необходимо реализовать интефейс ICapthaSolver и внедрить через констуктор.
		/// </summary>
		public const string CaptchaNeeded = "Использование параметров капчи устаревший метод взаимодействия с Captcha."
											+ " Необходимо реализовать интефейс ICapthaSolver и внедрить через констуктор."
											+ "Данный параметр будет удален в версии 2.0.0";

		/// <summary>
		/// Stats.Get
		/// </summary>
		public const string StatsGet = "устаревший параметр, доступен только для версий меньше 5.86";

	}
}