using System;
using System.Collections.Generic;
using VkToolkit.Enums;
using VkToolkit.Model;
using VkToolkit.Utils;

namespace VkToolkit.Categories
{
    using System.Linq;

    /// <summary>
    /// Методы для работы со стеной пользователя.
    /// </summary>
    public class WallCategory
    {
        private readonly VkApi _vk;

        public WallCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список записей со стены пользователя или сообщества. 
        /// </summary>
        /// <param name="ownerId">Идентификатор поьзователя. Чтобы получить записи со стены группы (публичной страницы, встречи), укажите её идентификатор 
        /// со знаком "минус": например, owner_id=-1 соответствует группе с идентификатором 1.</param>
        /// <param name="totalCount">Общее количество записей на стене.</param>
        /// <param name="count">Количество сообщений, которое необходимо получить (но не более 100).</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений.</param>
        /// <param name="filter">Типы сообщений, которые необходимо получить (по умолчанию возвращаются все сообщения).</param>
        /// <returns>В случае успеха возвращается запрошенный список записей со стены.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/pages?oid=-1&p=wall.get"/>.
        /// </remarks>
        public List<WallRecord> Get(long ownerId, out int totalCount, int? count = null, int? offset = null, WallFilter filter = WallFilter.All)
        {
            var parameters = new VkParameters
                {
                    { "owner_id", ownerId },
                    { "count", count },
                    { "offset", offset },
                    { "filter", filter.ToString().ToLowerInvariant() }
                };

            VkResponseArray response = _vk.Call("wall.get", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (WallRecord)r);
        }

        /// <summary>
        /// Возвращает список комментариев к записи на стене пользователя. 
        /// </summary>
        /// <param name="ownerId">Идентификатор пользователя, на чьей стене находится запись, к которой необходимо получить комментарии.</param>
        /// <param name="postId">Идентификатор записи на стене пользователя.</param>
        /// <param name="totalCount">Общее количество комментариев к записи.</param>
        /// <param name="sort">Порядок сортировки комментариев (по умолчанию хронологический).</param>
        /// <param name="needLikes">Признак нужно ли возвращать поле Likes в комментариях.</param>
        /// <param name="count">Количество комментариев, которое необходимо получить (но не более 100).</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества комментариев.</param>
        /// <param name="previewLength">Количество символов, по которому нужно обрезать комментарии. Если указано 0, то комментарии не образеютяс. 
        /// Обратите внимание, что комментарии обрезаются по словам.</param>
        /// <remarks>
        /// <returns>
        /// Список комментариев к записи на стене пользователя.
        /// </returns>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/pages?oid=-1&p=wall.getComments"/>.
        /// </remarks>       
        public List<Comment> GetComments(long ownerId, long postId, out int totalCount, CommentsSort sort = CommentsSort.Ascending, bool needLikes = false, int? count = null, 
            int? offset = null, int previewLength = 0)
        {
            var parameters = new VkParameters
                {
                    { "owner_id", ownerId },
                    { "post_id", postId },
                    { "sort", sort.ToString().ToLowerInvariant() },
                    { "need_likes", needLikes },
                    { "count", count },
                    { "offset", offset },
                    { "preview_length", previewLength },
                    { "v", "4.4" }
                };

            VkResponseArray response = _vk.Call("wall.getComments", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(c => (Comment)c);
        }

        public void GetById()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Post()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Edit()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Delete()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void Restore()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void AddComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void DeleteComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void RestoreComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void AddLike()
        {
            // TODO:
            throw new NotImplementedException();
        }

        public void DeleteLike()
        {
            // TODO:
            throw new NotImplementedException();
        }
    }
}