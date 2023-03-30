using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со темами группы.
/// </summary>
public interface IBoardCategoryAsync
{
	/// <summary>
	/// Возвращает список тем в обсуждениях указанной группы.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// <see href="https://new.vk.com/dev/board.getTopics" />.
	/// </remarks>
	Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default);

	/// <summary>
	/// Возвращает список сообщений в указанной теме.
	/// </summary>
	/// <param name="params"> Входные параметры выборки. </param>
	/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// <see href="https://new.vk.com/dev/board.getComments" />.
	/// </remarks>
	Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params,
									bool skipAuthorization = false,
									CancellationToken token = default);

	/// <summary>
	/// Создает новую тему в списке обсуждений группы.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.addTopic
	/// </remarks>
	Task<long> AddTopicAsync(BoardAddTopicParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Удаляет тему в обсуждениях группы.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.deleteTopic
	/// </remarks>
	Task<bool> DeleteTopicAsync(BoardTopicParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять
	/// новые сообщения).
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.closeTopic
	/// </remarks>
	Task<bool> CloseTopicAsync(BoardTopicParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Открывает ранее закрытую тему (в ней станет возможно оставлять новые
	/// сообщения).
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.openTopic
	/// </remarks>
	Task<bool> OpenTopicAsync(BoardTopicParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке
	/// выводится выше остальных).
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.fixTopic
	/// </remarks>
	Task<bool> FixTopicAsync(BoardTopicParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться
	/// согласно выбранной сортировке).
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.unfixTopic
	/// </remarks>
	Task<bool> UnFixTopicAsync(BoardTopicParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Изменяет заголовок темы в списке обсуждений группы.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.editTopic
	/// </remarks>
	Task<bool> EditTopicAsync(BoardEditTopicParams @params,
							CancellationToken token = default);

	/// <summary>
	/// Добавляет новый комментарий в обсуждении.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// <see href="https://new.vk.com/dev/board.createComment" />.
	/// </remarks>
	Task<long> CreateCommentAsync(BoardCreateCommentParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Удаляет сообщение в обсуждениях сообщества.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте
	/// <see href="https://new.vk.com/dev/board.deleteComment" />.
	/// </remarks>
	Task<bool> DeleteCommentAsync(BoardCommentParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Редактирует одно из сообщений в обсуждении сообщества..
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.editComment
	/// </remarks>
	Task<bool> EditCommentAsync(BoardEditCommentParams @params,
								CancellationToken token = default);

	/// <summary>
	/// Восстанавливает удаленное сообщение темы в обсуждениях группы.
	/// </summary>
	/// <param name="params"> Входные параметры. </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/board.restoreComment
	/// </remarks>
	Task<bool> RestoreCommentAsync(BoardCommentParams @params,
									CancellationToken token = default);
}