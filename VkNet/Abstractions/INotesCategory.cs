using System.Collections.Generic;
using VkNet.Abstractions.Async;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Notes Методы для работы с заметками.
	/// </summary>
	public interface INotesCategory : INotesCategoryAsync
	{
		/// <summary>
		/// Создает новую заметку у текущего пользователя
		/// </summary>
		/// <param name="notesAddParams">
		/// Входные параметры запроса
		///</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданной заметки (nid).</returns>
		/// <remarks>
		///Страница документации ВКонтакте http://vk.com/dev/notifications.get
		/// </remarks>
		long Add(NotesAddParams notesAddParams);

		/// <summary>
		/// Добавляет новый комментарий к заметке.
		/// </summary>
		/// <param name="createCommentParams">Входные параметры запроса</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария (cid).
		///</returns>
		long CreateComment(NotesCreateCommentParams createCommentParams);

		/// <summary>
		/// Удаляет заметку текущего пользователя.
		/// </summary>
		/// <param name="noteId">идентификатор заметки.</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		bool Delete(long noteId);

		/// <summary>
		/// Удаляет комментарий к заметке.
		/// </summary>
		/// <param name="deleteCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true. </returns>
		bool DeleteComment(NotesDeleteCommentParams deleteCommentParams);

		/// <summary>
		/// Редактирует заметку текущего пользователя.
		/// </summary>
		/// <param name="editParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		bool Edit(NotesEditParams editParams);

		/// <summary>
		/// Редактирует указанный комментарий у заметки.
		/// </summary>
		/// <param name="editCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		bool EditComment(NotesEditCommentParams editCommentParams);

		/// <summary>
		/// Возвращает список заметок, созданных пользователем.
		/// </summary>
		/// <param name="notesGetParams">Входные параметры запроса</param>
		/// <returns>возвращает список объектов заметок</returns>
		IEnumerable<Note> Get(NotesGetParams notesGetParams);

		/// <summary>
		/// Возвращает заметку по её id.
		/// </summary>
		/// <param name="getByIdParams">Входные параметры запроса</param>
		/// <returns>Возвращает заметку</returns>
		Note GetById(NotesGetByIdParams getByIdParams);

		/// <summary>
		/// Возвращает список комментариев к заметке.
		/// </summary>
		/// <param name="getCommentParams">Входные параметры запроса</param>
		/// <returns>Возвращает массив объектов comment</returns>
		IEnumerable<CommentNote> GetComments(NotesGetCommentParams getCommentParams);

		/// <summary>
		/// Восстанавливает удалённый комментарий.
		/// </summary>
		/// <param name="restoreCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true</returns>
		bool RestoreComment(NotesRestoreCommentParams restoreCommentParams);
	}
}