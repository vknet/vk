// ReSharper disable CheckNamespace
namespace VkNet.Utils.AntiCaptcha
{
	/// <summary>
	/// Определяет интерфейс взаимодействия с сервисом-распознавателем капчи
	/// </summary>
	public interface ICaptchaSolver
	{
		/// <summary>
		/// Распознает текст капчи.
		/// </summary>
		/// <param name="url"> Ссылка на изображение капчи. </param>
		/// <returns> Строка, содержащая текст, который был закодирован в капче. </returns>
		string Solve(string url);

		/// <summary>
		/// Сообщает сервису, что последняя капча была распознана неверно.
		/// </summary>
		void CaptchaIsFalse();
	}
}