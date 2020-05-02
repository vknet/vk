using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;

namespace VkNet.Abstractions.Async
{
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
		/// <returns>После успешного выполнения возвращает идентификатор созданной заметки (nid).</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
		/// </remarks>
		Task<long> AddAsync(NotesAddParams notesAddParams);

		/// <summary>
		/// Добавляет новый комментарий к заметке.
		/// </summary>
		/// <param name="createCommentParams">Входные параметры запроса</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария (cid).
		///</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.createComment
		/// </remarks>
		Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams);

		/// <summary>
		/// Удаляет заметку текущего пользователя.
		/// </summary>
		/// <param name="noteId">идентификатор заметки.</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.delete
		/// </remarks>
		Task<bool> DeleteAsync(long noteId);

		/// <summary>
		/// Удаляет комментарий к заметке.
		/// </summary>
		/// <param name="deleteCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.deleteComment
		/// </remarks>
		Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams);

		/// <summary>
		/// Редактирует заметку текущего пользователя.
		/// </summary>
		/// <param name="editParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.edit
		/// </remarks>
		Task<bool> EditAsync(NotesEditParams editParams);

		/// <summary>
		/// Редактирует указанный комментарий у заметки.
		/// </summary>
		/// <param name="editCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.editComment
		/// </remarks>
		Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams);

		/// <summary>
		/// Возвращает список заметок, созданных пользователем.
		/// </summary>
		/// <param name="notesGetParams">Входные параметры запроса</param>
		/// <returns>возвращает список объектов заметок</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
		/// </remarks>
		Task<IEnumerable<Note>> GetAsync(NotesGetParams notesGetParams);

		/// <summary>
		/// Возвращает заметку по её id.
		/// </summary>
		/// <param name="getByIdParams">Входные параметры запроса</param>
		/// <returns>Возвращает заметку</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.getById
		/// </remarks>
		Task<Note> GetByIdAsync(NotesGetByIdParams getByIdParams);

		/// <summary>
		/// Возвращает список комментариев к заметке.
		/// </summary>
		/// <param name="getCommentParams">Входные параметры запроса</param>
		/// <returns>Возвращает массив объектов comment</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.getComments
		/// </remarks>
		Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams);

		/// <summary>
		/// Восстанавливает удалённый комментарий.
		/// </summary>
		/// <param name="restoreCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/notifications.restoreComment
		/// </remarks>
		Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams);
	}
}