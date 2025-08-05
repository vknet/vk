using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы этого класса позволяют производить действия с опросами.
/// </summary>
public interface IPollsCategoryAsync
{
	/// <summary>
	/// Возвращает детальную информацию об опросе по его идентификатору.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Опрос
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.GetById
	/// </remarks>
	Task<Poll> GetByIdAsync(PollsGetByIdParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Позволяет редактировать созданные опросы.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Признак успешного редактирования
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.Edit
	/// </remarks>
	Task<bool> EditAsync(PollsEditParams @params,
						CancellationToken token = default);

	/// <summary>
	/// Отдает голос текущего пользователя за выбранный вариант ответа в указанном
	/// опросе.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// 1 — если голос текущего пользователя был отдан за выбранный вариант ответа;
	/// 0 — если текущий пользователь уже голосовал в указанном опросе
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.addVote
	/// </remarks>
	Task<bool> AddVoteAsync(PollsAddVoteParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Снимает голос текущего пользователя с выбранного варианта ответа в указанном
	/// опросе.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// 1 — если голос текущего пользователя был снят с выбранного варианта ответа
	/// 0 — если текущий пользователь еще не голосовал в указанном опросе или указан не
	/// выбранный им вариант ответа
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.DeleteVote
	/// </remarks>
	Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Получает список идентификаторов пользователей, которые выбрали определенные
	/// варианты ответа в опросе.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Список ответов
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.GetVoters
	/// </remarks>
	Task<ReadOnlyCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params,
															CancellationToken token = default);

	/// <summary>
	/// Позволяет создавать опросы, которые впоследствии можно прикреплять к записям на
	/// странице пользователя или
	/// сообщества.
	/// </summary>
	/// <param name="params"> Параметры </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// В случае успешного создания опроса в качестве результата возвращается объект
	/// опроса.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.create
	/// </remarks>
	Task<Poll> CreateAsync(PollsCreateParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Получает варианты фонового изображения для опросов.
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Возвращает массив объектов, описывающих фоновое изображение опроса.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/polls.getBackgrounds
	/// </remarks>
	Task<ReadOnlyCollection<GetBackgroundsResult>> GetBackgroundsAsync(CancellationToken token = default);

	/// <summary>
	/// Получает адрес сервера для загрузки фоновой фотографии в опрос.
	/// </summary>
	/// <param name="ownerId">Идентификатор пользователя или сообщества</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Возвращает объект с полем содержащим URL для загрузки фотографии
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev.php?method=polls.getPhotoUploadServer
	/// </remarks>
	Task<UploadServer> GetPhotoUploadServerAsync(long ownerId,
												CancellationToken token = default);

	/// <summary>
	/// Сохраняет фотографию, загруженную в опрос.
	/// </summary>
	/// <param name="params">Параметры</param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	///	В случае успешного сохранения возвращает объект описывающий фотографию
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/polls.savePhoto
	/// </remarks>
	public Task<SavePhotoResult> SavePhotoAsync(SavePhotoParams @params,
												CancellationToken token = default);
}