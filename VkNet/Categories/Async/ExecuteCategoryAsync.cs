using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Abstractions.Async;
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

        /// <inheritdoc />
        public async Task<VkResponse> ExecuteAsync(string code)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Execute.Execute(code));
        }

        /// <inheritdoc />
        public async Task<T> ExecuteAsync<T>(string code)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Execute.Execute<T>(code));
        }

        /// <inheritdoc />
        public async Task<T> StoredProcedureAsync<T>(string procedureName, VkParameters vkParameters)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Execute.StoredProcedure<T>(procedureName, vkParameters));
        }
    }
}