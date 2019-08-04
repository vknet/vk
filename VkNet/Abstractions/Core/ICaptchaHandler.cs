using System;

namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// Обработчик капчи
	/// </summary>
	public interface ICaptchaHandler
	{
		/// <summary>
		/// Максимальное количество попыток распознавания капчи c помощью
		/// зарегистрированного обработчика
		/// </summary>
		int MaxCaptchaRecognitionCount { get; set; }

		/// <summary>
		/// Обработка капчи
		/// </summary>
		/// <param name="action"> Действие </param>
		/// <typeparam name="T"> Тип результата </typeparam>
		/// <returns> Результат действия </returns>
		T Perform<T>(Func<ulong?, string, T> action);
	}
}