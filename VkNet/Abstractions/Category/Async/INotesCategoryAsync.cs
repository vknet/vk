using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions.Async;

/// <summary>
/// Методы для работы с заметками.
/// </summary>
public interface INotesCategoryAsync
{
	/// <summary>
	/// Создает новую заметку у текущего пользователя
	/// </summary>
	/// <param name="notesAddParams">
	/// Входные параметры запроса
	/// </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает идентификатор созданной заметки (nid).</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
	/// </remarks>
	Task<long> AddAsync(NotesAddParams notesAddParams,
						CancellationToken token = default);

	/// <summary>
	/// Добавляет новый комментарий к заметке.
	/// </summary>
	/// <param name="createCommentParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// После успешного выполнения возвращает идентификатор созданного комментария (cid).
	///</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.createComment
	/// </remarks>
	Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams,
								CancellationToken token = default);

	/// <summary>
	/// Удаляет заметку текущего пользователя.
	/// </summary>
	/// <param name="noteId">идентификатор заметки.</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает true.</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.delete
	/// </remarks>
	Task<bool> DeleteAsync(long noteId,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет комментарий к заметке.
	/// </summary>
	/// <param name="deleteCommentParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает true. </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.deleteComment
	/// </remarks>
	Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams,
								CancellationToken token = default);

	/// <summary>
	/// Редактирует заметку текущего пользователя.
	/// </summary>
	/// <param name="editParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает true.</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.edit
	/// </remarks>
	Task<bool> EditAsync(NotesEditParams editParams,
						CancellationToken token = default);

	/// <summary>
	/// Редактирует указанный комментарий у заметки.
	/// </summary>
	/// <param name="editCommentParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает true.</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.editComment
	/// </remarks>
	Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams,
								CancellationToken token = default);

	/// <summary>
	/// Возвращает список заметок, созданных пользователем.
	/// </summary>
	/// <param name="notesGetParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>возвращает список объектов заметок</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
	/// </remarks>
	Task<VkCollection<Note>> GetAsync(NotesGetParams notesGetParams,
									CancellationToken token = default);

	/// <summary>
	/// Возвращает заметку по её id.
	/// </summary>
	/// <param name="getByIdParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>Возвращает заметку</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.getById
	/// </remarks>
	Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams,
							CancellationToken token = default);

	/// <summary>
	/// Возвращает список комментариев к заметке.
	/// </summary>
	/// <param name="getCommentParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>Возвращает массив объектов comment</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.getComments
	/// </remarks>
	Task<VkCollection<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams,
													CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удалённый комментарий.
	/// </summary>
	/// <param name="restoreCommentParams">Входные параметры запроса</param>
	/// <param name="token">Токен отмены</param>
	/// <returns>После успешного выполнения возвращает true</returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.restoreComment
	/// </remarks>
	Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams,
									CancellationToken token = default);
}