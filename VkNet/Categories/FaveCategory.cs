namespace VkNet.Categories
{
    using System.Collections.ObjectModel;
    
    using Model;
    using Utils;

    /// <summary>
    /// Категория работы с закладками.
    /// </summary>
    public class FaveCategory
    {
        private readonly VkApi _vk;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FaveCategory"/>.
        /// </summary>
        /// <param name="vk">API для работы с ВКонтакте.</param>
        public FaveCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список пользователей, добавленных текущим пользователем в закладки.
        /// </summary>
        /// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
        /// <returns>После успешного выполнения возвращает список объектов пользователей.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getUsers"/>.
        /// </remarks>
        public ReadOnlyCollection<User> GetUsers(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.ApiVersion}
                };

            VkResponseArray response = _vk.Call("fave.getUsers", parameters);

            return response.ToReadOnlyCollectionOf<User>(x => x);
        }

        /// <summary>
        /// Возвращает фотографии, на которых текущий пользователь поставил отметку "Мне нравится".
        /// </summary>
        /// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
        /// <returns>После успешного выполнения возвращает список объектов фотографий.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPhotos"/>.
        /// </remarks>
        public ReadOnlyCollection<Photo> GetPhotos(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.ApiVersion}
                };

            VkResponseArray response = _vk.Call("fave.getPhotos", parameters);
            return response.ToReadOnlyCollectionOf<Photo>(x => x);
        }

        /// <summary>
        /// Возвращает записи, на которых текущий пользователь поставил отметку «Мне нравится».
        /// </summary>
        /// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
        /// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getPosts"/>.
        /// </remarks>
        public ReadOnlyCollection<Post> GetPosts(int? count = null, int? offset = null)//, bool extended = false)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    //{"extended", extended},
                    {"v", _vk.ApiVersion}
                };

            VkResponseArray response = _vk.Call("fave.getPosts", parameters);
            return response.ToReadOnlyCollectionOf<Post>(x => x);
        }

        /// <summary>
        /// Возвращает список видеозаписей, на которых текущий пользователь поставил отметку «Мне нравится».
        /// </summary>
        /// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
        /// <returns>После успешного выполнения возвращает список объектов записей на стене.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getVideos"/>.
        /// </remarks>
        public ReadOnlyCollection<Video> GetVideos(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.ApiVersion}
                };

            VkResponseArray response = _vk.Call("fave.getVideos", parameters);

            return response.ToReadOnlyCollectionOf<Video>(x => x);
        }

        /// <summary>
        /// Возвращает ссылки, добавленные в закладки текущим пользователем.
        /// </summary>
        /// <param name="count">Количество пользователей, информацию о которых необходимо вернуть</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества пользователей</param>
        /// <returns>После успешного выполнения возвращает общее количество ссылок и массив объектов Link.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/fave.getLinks"/>.
        /// </remarks>
        public ReadOnlyCollection<Link> GetLinks(int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"count", count},
                    {"offset", offset},
                    {"v", _vk.ApiVersion}
                };

            VkResponseArray response = _vk.Call("fave.getLinks", parameters);

            return response.ToReadOnlyCollectionOf<Link>(x => x);
        }
    }
}