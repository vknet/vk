using System.Threading.Tasks;

namespace VkNet
{
    /// <summary>
    /// Интерфейс асинхронной авторизации в Vk
    /// </summary>
    public interface IAuthAsync
    {
        /// <summary>
		/// Была ли произведена авторизация каким либо образом
		/// </summary>
        bool IsAuthorized { get; }

        /// <summary>
        /// Авторизация и получение токена в асинхронном режиме
        /// </summary>
        /// <param name="params">Данные авторизации</param>
        Task AuthorizeAsync(AuthParams @params);
    }
}