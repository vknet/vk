using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Данные для отображения блока видеокаталога
    /// </summary>
    public class VideoCatalog
    {
        /// <summary>
        /// Список элементов блока видеокаталога
        /// </summary>
        public ReadOnlyCollection<VideoCatalogItem> Items { get; set; }

        /// <summary>
        /// Идентификатор блока. Возвращается строка для предопределенных блоков. Для других возвращается число.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Заголовок блока.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Параметр для получения следующей страницы результатов. Необходимо передать его значение в from в следующем вызове, чтобы получить содержимое каталога, следующее за полученным в текущем вызове. 
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// предпочтительный способ отображения контента
        /// </summary>
        [JsonProperty("view")]
        public VideoView View { get; set; }

        /// <summary>
        /// Наличие возможности скрыть блок.
        /// </summary>
        public bool? CanHide { get; set; }

        /// <summary>
        /// Тип блока.
        /// </summary>
        public VideoCatalogType Type { get; set; }


        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static VideoCatalog FromJson(VkResponse response)
        {
            var item = new VideoCatalog
            {
                Id = response["id"],
                Name = response["name"],
                CanHide = response["can_hide"],
                Type = response["type"],
                Next = response["next"],
                Items = response["items"].ToReadOnlyCollectionOf<VideoCatalogItem>(x => x)
            };

            return item;
        }
    }
}