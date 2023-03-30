using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с подкастами.
/// </summary>
public interface IPodcastsCategoryAsync
{
	/// <summary>
	/// Метод очищает последние запросы.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.clearRecentSearches
	/// </remarks>
	Task<bool> ClearRecentSearchesAsync(CancellationToken token);

	/// <summary>
	/// Метод удаляет карточку карусели.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.getPopular
	/// </remarks>
	Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync(CancellationToken token);

	/// <summary>
	/// Метод редактирует карточку карусели.
	/// </summary>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.getRecentSearchRequests
	/// </remarks>
	Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync(CancellationToken token);

	/// <summary>
	/// Метод возвращает неиспользованные карточки владельца.
	/// </summary>
	/// <param name="params"> Параметры запроса </param>
	/// <param name="token">Токен отмены</param>
	/// <returns>
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.search
	/// </remarks>
	Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params,
											CancellationToken token);
}