using System.Threading.Tasks;

namespace VkNet.Abstractions
{
    /// <summary>
    /// VkApi Authorization Async
    /// </summary>
    public interface IVkApiAuthAsync
    {
        /// <summary>
        /// Была ли произведена авторизация каким либо образом
        /// </summary>
        bool IsAuthorized { get; }
        
        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        Task AuthorizeAsync(IApiAuthParams @params);
    }
}