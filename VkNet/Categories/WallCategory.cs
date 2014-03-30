namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Enums;
    using Model;
    using Utils;

    /// <summary>
    /// Методы для работы со стеной пользователя.
    /// </summary>
    public class WallCategory
    {
        private readonly VkApi _vk;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WallCategory"/>.
        /// </summary>
        /// <param name="vk">API для работы с ВКонтакте.</param>
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.get"/>.
        /// </remarks>
        public ReadOnlyCollection<Post> Get(long ownerId, out int totalCount, int? count = null, int? offset = null, WallFilter filter = WallFilter.All)
        {
            var parameters = new VkParameters { { "owner_id", ownerId }, { "count", count }, { "offset", offset }, { "filter", filter.ToString().ToLowerInvariant() } };

            VkResponseArray response = _vk.Call("wall.get", parameters);

            totalCount = response[0];

            return response.Skip(1).ToReadOnlyCollectionOf<Post>(r => r);
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
        /// <returns>
        /// Список комментариев к записи на стене пользователя.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getComments"/>.
        /// </remarks>       
        public ReadOnlyCollection<Comment> GetComments(
            long ownerId,
            long postId,
            out int totalCount,
            CommentsSort sort = null,
            bool needLikes = false,
            int? count = null,
            int? offset = null,
            int previewLength = 0)
        {
            var parameters = new VkParameters
                             {
                                 { "owner_id", ownerId },
                                 { "post_id", postId },
                                 { "need_likes", needLikes },
                                 { "count", count },
                                 { "offset", offset },
                                 { "preview_length", previewLength },
                                 { "v", _vk.ApiVersion }
                             };

            if (sort != null)
                parameters.Add("sort", sort.ToString().ToLowerInvariant());

            VkResponseArray response = _vk.Call("wall.getComments", parameters);

            totalCount = response[0];

            return response.Skip(1).ToReadOnlyCollectionOf<Comment>(c => c);
        }

        /// <summary>
        /// Возвращает список записей со стен пользователей или сообществ по их идентификаторам.
        /// </summary>
        /// <param name="posts">
        /// Список строковых идентификаторов записий в формате - идентификатор пользователя (группы), знак подчеркивания и идентификатор записи.
        /// Примеры возможных значений идентификаторов: "93388_21539", "93388_20904", "2943_4276".
        /// </param>
        /// <returns>
        /// После успешного выполнения возвращает список объектов записей со стены. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.getById"/>.
        /// </remarks>       
        public ReadOnlyCollection<Post> GetById(IEnumerable<string> posts)
        {
            if (posts == null)
                throw new ArgumentNullException("posts");

            var parameters = new VkParameters { { "posts", posts } };

            VkResponseArray response = _vk.Call("wall.getById", parameters);

            return response.ToReadOnlyCollectionOf<Post>(x => x);
        }

        /// <summary>
        /// Публикует новую запись на своей или чужой стене. 
        /// Данный метод позволяет создать новую запись на стене, а также опубликовать предложенную новость или отложенную запись. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.post"/>.
        /// </remarks>
        public void Post()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Редактирует запись на стене. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.edit"/>.
        /// </remarks>
        public void Edit()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет запись со стены. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.delete"/>.
        /// </remarks>
        public void Delete()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Восстанавливает удаленную запись на стене пользователя или сообщества. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restore"/>.
        /// </remarks>
        public void Restore()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавляет комментарий к записи на стене пользователя или сообщества. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.addComment"/>.
        /// </remarks>
        public void AddComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет комментарий текущего пользователя к записи на своей или чужой стене. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.deleteComment"/>.
        /// </remarks>
        public void DeleteComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Восстанавливает комментарий текущего пользователя к записи на своей или чужой стене. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.restoreComment"/>.
        /// </remarks>
        public void RestoreComment()
        {
            // TODO:
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавляет запись на стене пользователя или сообщества в список Мне нравится, а также создает копию понравившейся записи на 
        /// стене текущего пользователя при необходимости. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.addLike"/>.
        /// </remarks>
        public void AddLike()
        {
            // TODO: ДАННЫЙ МЕТОД УСТАРЕЛ.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет запись на стене пользователя из списка Мне нравится. 
        /// </summary>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Wall"/>.
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/wall.deleteLike"/>.
        /// </remarks>
        public void DeleteLike()
        {
            // TODO: ДАННЫЙ МЕТОД УСТАРЕЛ.
            throw new NotImplementedException();
        } 
    }
}