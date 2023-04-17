using System.Threading;
using System.Threading.Tasks;
using VkNet.Model.Results.Asr;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с ASR
/// </summary>
public interface IAsrCategoryAsync
{
	/// <summary>
	/// Метод проверяет статус задачи на обработку аудиозаписи и возвращает текстовую расшифровку аудиозаписи
	/// </summary>
	/// <param name="taskId">
	/// Идентификатор созданной задачи на обработку аудиозаписи в формате UUID.
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает объект задачи на обработку аудиозаписи.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://dev.vk.com/method/asr.checkStatus
	/// </remarks>
	public Task<AudioRecordingTask> CheckStatusAsync(string taskId,
								CancellationToken token = default);
}