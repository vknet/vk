using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с универсальным методом.
    /// </summary>
    public partial class ExecuteCategory
    {
        /// <summary>
        /// API.
        /// </summary>
        private readonly IVkApi _vk;

        /// <summary>
        /// Методы для работы с универсальным методом.
        /// </summary>
        /// <param name="vk">API.</param>
        public ExecuteCategory(IVkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Универсальный метод, который позволяет запускать последовательность других методов, сохраняя и фильтруя промежуточные результаты.
        /// </summary>
        /// <param name="code">
        /// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript (предполагается совместимость с ECMAScript).
        /// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть разделены точкой с запятой.
        /// </param>
        /// <returns>
        /// Возвращает данные, запрошенные алгоритмом.
        /// При работе с методом execute структура ответа в XML ближе к JSON и может незначительно отличаться от стандартного представления других методов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/execute
        /// </remarks>
        public async Task<VkResponse> ExecuteAsync(string code)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Execute.Execute(code));
        }

        /// <summary>
        /// Универсальный метод, который позволяет запускать последовательность других методов, сохраняя и фильтруя промежуточные результаты.
        /// </summary>
        /// <param name="code">
        /// Код алгоритма в VKScript - формате, похожем на JavaSсript или ActionScript (предполагается совместимость с ECMAScript).
        /// Алгоритм должен завершаться командой return %выражение%. Операторы должны быть разделены точкой с запятой.
        /// </param>
        /// <returns>
        /// Возвращает данные, запрошенные алгоритмом.
        /// При работе с методом execute структура ответа в XML ближе к JSON и может незначительно отличаться от стандартного представления других методов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/execute
        /// </remarks>
        public async Task<T> ExecuteAsync<T>(string code)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Execute.Execute<T>(code));
        }
    }
}