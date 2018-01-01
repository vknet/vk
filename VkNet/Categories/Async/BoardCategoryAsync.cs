using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Асинхронные методы для работы со темами группы.
    /// </summary>
    public partial class BoardCategory
    {
        /// <summary>
        /// Возвращает список тем в обсуждениях указанной группы.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getTopics" />.
        /// </remarks>
        public async Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.GetTopics(@params, skipAuthorization));
        }

        /// <summary>
        /// Возвращает список сообщений в указанной теме.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getComments" />.
        /// </remarks>
        public async Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params, bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.GetComments(@params, skipAuthorization));
        }

        /// <summary>
        /// Создает новую тему в списке обсуждений группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.addTopic
        /// </remarks>
        public async Task<long> AddTopicAsync(BoardAddTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.AddTopic(@params));
        }

        /// <summary>
        /// Удаляет тему в обсуждениях группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.deleteTopic
        /// </remarks>
        public async Task<bool> DeleteTopicAsync(BoardTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.DeleteTopic(@params));
        }

        /// <summary>
        /// Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять новые сообщения).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.closeTopic
        /// </remarks>
        public async Task<bool> CloseTopicAsync(BoardTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.CloseTopic(@params));
        }

        /// <summary>
        /// Открывает ранее закрытую тему (в ней станет возможно оставлять новые сообщения).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.openTopic
        /// </remarks>
        public async Task<bool> OpenTopicAsync(BoardTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.OpenTopic(@params));
        }

        /// <summary>
        /// Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке выводится выше остальных).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.fixTopic
        /// </remarks>
        public async Task<bool> FixTopicAsync(BoardTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.FixTopic(@params));
        }

        /// <summary>
        /// Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться согласно выбранной сортировке).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.unfixTopic
        /// </remarks>
        public async Task<bool> UnFixTopicAsync(BoardTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.UnFixTopic(@params));
        }

        /// <summary>
        /// Изменяет заголовок темы в списке обсуждений группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.editTopic
        /// </remarks>
        public async Task<bool> EditTopicAsync(BoardEditTopicParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.EditTopic(@params));
        }

        /// <summary>
        /// Добавляет новый комментарий в обсуждении.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.createComment" />.
        /// </remarks>
        public async Task<long> CreateCommentAsync(BoardCreateCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.CreateComment(@params));
        }

        /// <summary>
        /// Удаляет сообщение в обсуждениях сообщества.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.deleteComment" />.
        /// </remarks>
        public async Task<bool> DeleteCommentAsync(BoardCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.DeleteComment(@params));
        }

        /// <summary>
        /// Редактирует одно из сообщений в обсуждении сообщества..
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.editComment
        /// </remarks>
        public async Task<bool> EditCommentAsync(BoardEditCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.EditComment(@params));
        }

        /// <summary>
        /// Восстанавливает удаленное сообщение темы в обсуждениях группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/board.restoreComment
        /// </remarks>
        public async Task<bool> RestoreCommentAsync(BoardCommentParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Board.RestoreComment(@params));
        }
    }
}