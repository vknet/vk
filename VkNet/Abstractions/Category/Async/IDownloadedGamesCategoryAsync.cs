using System.Threading;
using System.Threading.Tasks;
using VkNet.Model.Results.DownloadedGames;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Список методов секции downloadedGames
	/// </summary>
	public interface IDownloadedGamesCategoryAsync
	{
		/// <summary>
		/// </summary>
		/// <param name = "userId">
		/// ID пользователя возможно купившего приложение положительное число
		/// </param>
		/// <param name="token">Токен отмены запроса</param>
		/// <returns>
		/// В случае успеха возвращает объект с полем is_paid, которое может принимать значения true (если пользователь купил игру) или false (если пользователь игру не покупал));
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/downloadedGames.getPaidStatus
		/// </remarks>
		Task<GetPaidStatusResult> GetPaidStatusAsync(ulong? userId = null, CancellationToken token = default);
	}
}