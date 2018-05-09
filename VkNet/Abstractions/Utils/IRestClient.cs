using System;
using System.Net;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Abstractions.Utils
{
    /// <summary>
    /// Rest Client
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Proxy
        /// </summary>
        IWebProxy Proxy { get; set; }

        /// <summary>
        /// Get request
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <param name="parameters"></param>
        /// <returns>String result</returns>
        Task<string> GetAsync(Uri uri, VkParameters parameters);

        /// <summary>
        /// POST запрос
        /// </summary>
        /// <param name="uri">Uri</param>
        /// <param name="parameters">Параметры</param>
        /// <typeparam name="T">Тип параметра</typeparam>
        /// <returns>Строковый результат</returns>
        Task<string> PostAsync<T>(Uri uri, T parameters);
    }
}