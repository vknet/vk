using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.StringEnums;
using VkNet.Model;

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

	/// <summary>
	/// Метод возвращает ссылку на адрес сервера для загрузки аудиозаписи.
	/// Обратите внимание! Ссылка доступна в течение 24 часов.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// Возвращает параметр — ссылку на адрес сервера для загрузки аудиозаписи
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://dev.vk.com/method/asr.getUploadUrl
	/// </remarks>
	public Task<AsrUploadUrlResult> GetUploadUrlAsync(CancellationToken token = default);

	/// <summary>
	/// Метод выполняет распознавание речи из загруженного файла аудиозаписи.
	/// </summary>
	/// <param name="model">Модель распознавания речи, которую нужно использовать</param>
	/// <param name="token">Токен отмены</param>
	/// <param name="audio">JSON-ответ из запроса на отправку файла аудиозаписи на адрес сервера загрузки.</param>
	/// <returns>
	/// Возвращает параметр — идентификатор созданной задачи на обработку аудиозаписи в формате UUID
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://dev.vk.com/method/asr.process
	/// </remarks>
	public Task<TaskIdResult> ProcessAsync(string audio,
											AsrProcessModel model,
											CancellationToken token = default);
}