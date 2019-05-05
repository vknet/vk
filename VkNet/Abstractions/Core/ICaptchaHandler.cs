using System;
using System.Threading;
using System.Threading.Tasks;

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
		T Perform<T>(Func<long?, string, T> action);

		/// <summary>
		/// Обработка капчи
		/// </summary>
		/// <param name="action"> Действие </param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <typeparam name="T"> Тип результата </typeparam>
		/// <returns> Результат действия </returns>
		Task<T> PerformAsync<T>(Func<long?, string, Task<T>> action, CancellationToken cancellationToken = default);
	}
}