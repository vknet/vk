using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с фотографиями.
    /// </summary>
    public partial class PhotoCategory
    {

        /// <summary>
        /// Возвращает список фотографий со страницы пользователя или сообщества.
        /// </summary>
        /// <param name="ownerId">Идентификатор пользователя или сообщества, фотографии которого нужно получить. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)</param>
        /// <param name="photoIds">Идентификаторы фотографий, информацию о которых необходимо вернуть</param>
        /// <param name="rev">Порядок сортировки фотографий (1 — антихронологический, 0 — хронологический). флаг, может принимать значения 1 или 0</param>
        /// <param name="extended"><c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения 1 или 0</param>
        /// <param name="feedType">Тип новости, получаемый в поле type метода newsfeed.get. строка</param>
        /// <param name="feed">Unixtime, который может быть получен методом newsfeed.get в поле date, для получения всех фотографий загруженных пользователем в определённый день либо на которых пользователь был отмечен. Также нужно указать параметр uid пользователя, с которым произошло событие</param>
        /// <param name="photoSizes">Возвращать ли размеры фотографий в специальном формате</param>
        /// <param name="count">Положительное число, максимальное значение 1000</param>
        /// <param name="offset">Положительное число</param>
        /// <returns>После успешного выполнения возвращает массив объектов <see cref="Photo"/>. В случае, если запись на стене о том, что была обновлена фотография профиля, не удалена, будет возвращено дополнительное поле post_id, содержащее идентификатор записи на стене.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getProfile"/>.
        /// </remarks>
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
        public ReadOnlyCollection<Photo> GetProfile(long? ownerId = null, IEnumerable<long> photoIds = null, bool? rev = null, bool? extended = null, string feedType = null, DateTime? feed = null, bool? photoSizes = null, ulong? count = null, ulong? offset = null)
        {
            throw new System.Exception("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.");
        }

        /// <summary>
        /// Возвращает адрес сервера для загрузки фотографии на страницу пользователя.
        /// </summary>
        /// <returns>После успешного выполнения возвращает объект с единственным полем upload_url. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.getProfileUploadServer"/>.
        /// </remarks>
        [Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод GetOwnerPhotoUploadServer")]
        public UploadServerInfo GetProfileUploadServer()
        {
            return GetOwnerPhotoUploadServer();
        }

        /// <summary>
        /// Сохраняет фотографию пользователя после успешной загрузки.
        /// </summary>
        /// <param name="server">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
        /// <param name="hash">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
        /// <param name="photo">Параметр, возвращаемый в результате загрузки фотографии на сервер.</param>
        /// <returns>После успешного выполнения возвращает объект, содержащий поля photo_hash и photo_src (при работе через VK.api метод вернёт поля photo_src, photo_src_big, photo_src_small). Параметр photo_hash необходим для подтверждения пользователем изменения его фотографии через вызов метода saveProfilePhoto Javascript API. Поле photo_src содержит путь к загруженной фотографии. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/photos.saveProfilePhoto"/>.
        /// </remarks>
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте метод SaveOwnerPhoto")]
        public Photo SaveProfilePhoto(string server = null, string hash = null, string photo = null)
        {
            var response = @"{
				""server"": " + server + @"
				""photo"":" + photo + @"
				""hash"": " + hash + @"
			}";
            return SaveOwnerPhoto(response);
        }

    }
}