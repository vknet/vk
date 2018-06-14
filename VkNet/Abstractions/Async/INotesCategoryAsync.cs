using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;

namespace VkNet.Abstractions.Async
{
	/// <summary>
	/// Notes Методы для работы с заметками. 
	/// </summary>
	public interface INotesCategoryAsync
	{
		/// <summary>
		/// Создает новую заметку у текущего пользователя
		/// </summary>
		/// <param name="notesAddParams">
		/// Входные параметры запроса
		///</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданной заметки (nid).</returns>
		Task<long> AddAsync(NotesAddParams notesAddParams);

		/// <summary>
		/// Добавляет новый комментарий к заметке.
		/// </summary>
		/// <param name="createCommentParams">Входные параметры запроса</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария (cid).
		///</returns>
		Task<long> CreateCommentAsync(NotesCreateCommentParams createCommentParams);

		/// <summary>
		/// Удаляет заметку текущего пользователя.
		/// </summary>
		/// <param name="noteId">идентификатор заметки.</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		Task<bool> DeleteNoteAsync(long noteId);

		/// <summary>
		/// Удаляет комментарий к заметке. 
		/// </summary>
		/// <param name="deleteCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true. </returns>
		Task<bool> DeleteCommentAsync(NotesDeleteCommentParams deleteCommentParams);

		/// <summary>
		/// Редактирует заметку текущего пользователя. 
		/// </summary>
		/// <param name="editParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		Task<bool> EditNoteAsync(NotesEditParams editParams);

		/// <summary>
		/// Редактирует указанный комментарий у заметки. 
		/// </summary>
		/// <param name="editCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		Task<bool> EditCommentAsync(NotesEditCommentParams editCommentParams);

		/// <summary>
		/// Возвращает список заметок, созданных пользователем.
		/// </summary>
		/// <param name="notesGetParams">Входные параметры запроса</param>
		/// <returns>возвращает список объектов заметок</returns>
		Task<IEnumerable<Note>> GetNotesAsync(NotesGetParams notesGetParams);

		/// <summary>
		/// Возвращает заметку по её id. 
		/// </summary>
		/// <param name="getByIdParams">Входные параметры запроса</param>
		/// <returns>Возвращает заметку</returns>
		Task<Note> GetNoteByIdAsync(NotesGetByIdParams getByIdParams);

		/// <summary>
		/// Возвращает список комментариев к заметке.
		/// </summary>
		/// <param name="getCommentParams">Входные параметры запроса</param>
		/// <returns>Возвращает массив объектов comment</returns>
		Task<IEnumerable<CommentNote>> GetCommentsAsync(NotesGetCommentParams getCommentParams);

		/// <summary>
		/// Восстанавливает удалённый комментарий.
		/// </summary>
		/// <param name="restoreCommentParams">Входные параметры запроса</param>
		/// <returns>После успешного выполнения возвращает true</returns>
		Task<bool> RestoreCommentAsync(NotesRestoreCommentParams restoreCommentParams);
	}
}
