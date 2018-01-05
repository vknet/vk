using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
    /// <summary>
    /// Методы для работы с поиском.
    /// </summary>
    public interface ISearchCategory
    {
        /// <summary>
        /// Метод позволяет получить результаты быстрого поиска по произвольной подстроке
        /// </summary>
        /// <param name="params">Параметры запроса</param>
        /// <returns></returns>
        SearchGetHintsResult GetHints(SearchGetHintsParams @params);
    }
}