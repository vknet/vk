using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы со темами группы.
	/// </summary>
	public interface IBoardCategory : IBoardCategoryAsync
	{
		/// <summary>
		/// Возвращает список тем в обсуждениях указанной группы.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.getTopics" />.
		/// </remarks>
		VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Возвращает список сообщений в указанной теме.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.getComments" />.
		/// </remarks>
		TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Создает новую тему в списке обсуждений группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.addTopic
		/// </remarks>
		long AddTopic(BoardAddTopicParams @params);

		/// <summary>
		/// Удаляет тему в обсуждениях группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.deleteTopic
		/// </remarks>
		bool DeleteTopic(BoardTopicParams @params);

		/// <summary>
		/// Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять
		/// новые сообщения).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.closeTopic
		/// </remarks>
		bool CloseTopic(BoardTopicParams @params);

		/// <summary>
		/// Открывает ранее закрытую тему (в ней станет возможно оставлять новые
		/// сообщения).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.openTopic
		/// </remarks>
		bool OpenTopic(BoardTopicParams @params);

		/// <summary>
		/// Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке
		/// выводится выше остальных).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.fixTopic
		/// </remarks>
		bool FixTopic(BoardTopicParams @params);

		/// <summary>
		/// Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться
		/// согласно выбранной сортировке).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.unfixTopic
		/// </remarks>
		bool UnFixTopic(BoardTopicParams @params);

		/// <summary>
		/// Изменяет заголовок темы в списке обсуждений группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.editTopic
		/// </remarks>
		bool EditTopic(BoardEditTopicParams @params);

		/// <summary>
		/// Добавляет новый комментарий в обсуждении.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.createComment" />.
		/// </remarks>
		long CreateComment(BoardCreateCommentParams @params);

		/// <summary>
		/// Удаляет сообщение в обсуждениях сообщества.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.deleteComment" />.
		/// </remarks>
		bool DeleteComment(BoardCommentParams @params);

		/// <summary>
		/// Редактирует одно из сообщений в обсуждении сообщества..
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.editComment
		/// </remarks>
		bool EditComment(BoardEditCommentParams @params);

		/// <summary>
		/// Восстанавливает удаленное сообщение темы в обсуждениях группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.restoreComment
		/// </remarks>
		bool RestoreComment(BoardCommentParams @params);
	}
}